// IndexedDB wrapper para Blazor WebAssembly
// Base de datos: GestionComerciosDB
// Stores: productos, clientes, ventas, compras, etc.

let db = null;
const dbName = 'GestionComerciosDB';
const dbVersion = 1;

// Stores que se crearán automáticamente
const stores = [
    'productos',
    'clientes',
    'ventas',
    'compras',
    'stock',
    'categorias',
    'marcas',
    'proveedores',
    'syncQueue' // Cola de sincronización
];

export async function initializeDb(name, version) {
    return new Promise((resolve, reject) => {
        const request = indexedDB.open(name, version);

        request.onerror = () => reject(request.error);
        request.onsuccess = () => {
            db = request.result;
            resolve();
        };

        request.onupgradeneeded = (event) => {
            db = event.target.result;
            
            // Crear stores si no existen
            stores.forEach(storeName => {
                if (!db.objectStoreNames.contains(storeName)) {
                    const objectStore = db.createObjectStore(storeName, { keyPath: 'id' });
                    objectStore.createIndex('syncId', 'syncId', { unique: false });
                }
            });
        };
    });
}

export async function save(storeName, key, value) {
    if (!db) throw new Error('Database not initialized');
    
    return new Promise((resolve, reject) => {
        const transaction = db.transaction([storeName], 'readwrite');
        const store = transaction.objectStore(storeName);
        
        const item = {
            id: key,
            data: value,
            timestamp: new Date().toISOString()
        };
        
        const request = store.put(item);
        request.onsuccess = () => resolve();
        request.onerror = () => reject(request.error);
    });
}

export async function get(storeName, key) {
    if (!db) return null;
    
    return new Promise((resolve, reject) => {
        const transaction = db.transaction([storeName], 'readonly');
        const store = transaction.objectStore(storeName);
        const request = store.get(key);
        
        request.onsuccess = () => {
            const result = request.result;
            resolve(result ? result.data : null);
        };
        request.onerror = () => reject(request.error);
    });
}

export async function getAll(storeName) {
    if (!db) return '[]';
    
    return new Promise((resolve, reject) => {
        const transaction = db.transaction([storeName], 'readonly');
        const store = transaction.objectStore(storeName);
        const request = store.getAll();
        
        request.onsuccess = () => {
            const items = request.result.map(item => item.data);
            resolve(JSON.stringify(items));
        };
        request.onerror = () => reject(request.error);
    });
}

export async function deleteItem(storeName, key) {
    if (!db) return;
    
    return new Promise((resolve, reject) => {
        const transaction = db.transaction([storeName], 'readwrite');
        const store = transaction.objectStore(storeName);
        const request = store.delete(key);
        
        request.onsuccess = () => resolve();
        request.onerror = () => reject(request.error);
    });
}

export async function clear(storeName) {
    if (!db) return;
    
    return new Promise((resolve, reject) => {
        const transaction = db.transaction([storeName], 'readwrite');
        const store = transaction.objectStore(storeName);
        const request = store.clear();
        
        request.onsuccess = () => resolve();
        request.onerror = () => reject(request.error);
    });
}

export async function exists(storeName, key) {
    if (!db) return false;
    
    return new Promise((resolve, reject) => {
        const transaction = db.transaction([storeName], 'readonly');
        const store = transaction.objectStore(storeName);
        const request = store.count(IDBKeyRange.only(key));
        
        request.onsuccess = () => resolve(request.result > 0);
        request.onerror = () => reject(request.error);
    });
}

