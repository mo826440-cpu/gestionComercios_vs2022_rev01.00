// Caution! Be sure you understand the caveats before publishing an application with
// offline support. See https://aka.ms/blazor-offline-considerations

self.importScripts('./service-worker-assets.js');
self.addEventListener('install', event => event.waitUntil(onInstall(event)));
self.addEventListener('activate', event => event.waitUntil(onActivate(event)));
self.addEventListener('fetch', event => event.respondWith(onFetch(event)));

const cacheNamePrefix = 'offline-cache-';
const cacheName = `${cacheNamePrefix}${self.assetsManifest.version}`;
const offlineAssetsInclude = [ /\.dll$/, /\.pdb$/, /\.wasm/, /\.html/, /\.js$/, /\.json$/, /\.css$/, /\.woff$/, /\.png$/, /\.jpe?g$/, /\.gif$/, /\.ico$/, /\.blat$/, /\.dat$/ ];
const offlineAssetsExclude = [ /^service-worker\.js$/ ];

// Replace with your base path if you are hosting on a subfolder. Ensure there is a trailing '/'.
const base = "/";
const baseUrl = new URL(base, self.origin);
const manifestUrlList = self.assetsManifest.assets.map(asset => new URL(asset.url, baseUrl).href);

async function onInstall(event) {
    console.info('Service worker: Install');

    // Fetch and cache all matching items from the assets manifest
    const assetsRequests = self.assetsManifest.assets
        .filter(asset => offlineAssetsInclude.some(pattern => pattern.test(asset.url)))
        .filter(asset => !offlineAssetsExclude.some(pattern => pattern.test(asset.url)))
        .map(asset => new Request(asset.url, { integrity: asset.hash, cache: 'no-cache' }));
    await caches.open(cacheName).then(cache => cache.addAll(assetsRequests));
}

async function onActivate(event) {
    console.info('Service worker: Activate');

    // Delete unused caches
    const cacheKeys = await caches.keys();
    await Promise.all(cacheKeys
        .filter(key => key.startsWith(cacheNamePrefix) && key !== cacheName)
        .map(key => caches.delete(key)));
}

async function onFetch(event) {
    // No interceptar peticiones a dominios externos (Supabase, APIs, etc.)
    const url = new URL(event.request.url);
    if (url.origin !== self.location.origin) {
        // Para peticiones externas, hacer fetch directamente sin interceptar
        return fetch(event.request);
    }

    // Solo manejar peticiones GET del mismo origen
    if (event.request.method !== 'GET') {
        return fetch(event.request);
    }

    // Para peticiones de navegación, siempre intentar servir desde la red primero
    if (event.request.mode === 'navigate') {
        try {
            // Intentar fetch desde la red primero
            const networkResponse = await fetch(event.request, { 
                redirect: 'follow',
                cache: 'no-cache' 
            });
            
            // Si es exitoso, cachear para uso offline futuro
            if (networkResponse.ok) {
                try {
                    const cache = await caches.open(cacheName);
                    await cache.put('index.html', networkResponse.clone());
                } catch (cacheError) {
                    console.warn('Error caching navigation response:', cacheError);
                }
            }
            
            return networkResponse;
        } catch (error) {
            // Si falla la red, intentar servir desde cache
            try {
                const cache = await caches.open(cacheName);
                const cachedResponse = await cache.match('index.html');
                if (cachedResponse) {
                    return cachedResponse;
                }
            } catch (cacheError) {
                console.warn('Error accessing cache:', cacheError);
            }
            throw error;
        }
    }

    // Para otros recursos (JS, CSS, imágenes, etc.), usar estrategia cache-first
    let cachedResponse = null;
    try {
        const cache = await caches.open(cacheName);
        cachedResponse = await cache.match(event.request);
    } catch (error) {
        console.warn('Error accessing cache:', error);
    }

    // Si hay respuesta en cache, usarla
    if (cachedResponse) {
        return cachedResponse;
    }

    // Si no hay cache, hacer fetch desde la red
    try {
        const response = await fetch(event.request, { redirect: 'follow' });
        
        // Cachear respuestas exitosas
        if (response.ok) {
            try {
                const cache = await caches.open(cacheName);
                await cache.put(event.request, response.clone());
            } catch (cacheError) {
                console.warn('Error caching response:', cacheError);
            }
        }
        
        return response;
    } catch (error) {
        throw error;
    }
}
