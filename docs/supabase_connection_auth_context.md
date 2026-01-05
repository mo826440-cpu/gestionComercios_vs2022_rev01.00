# Supabase – Connection Context (for development)

## Project overview
- Backend: Supabase
- Database: PostgreSQL (managed by Supabase)
- App type: Frontend (Blazor WebAssembly + PWA)
- Direct database connections: NOT allowed

## Access method
The application connects to Supabase using:
- Supabase REST API / SDK
- Public (anon) API key
- No direct PostgreSQL connection from the frontend

## Connection identifiers
- Supabase Project URL: https://jnplnwpofxzfqchkvgpv.supabase.co
- API key type used: anon public key

> NOTE:
> The anon key will be stored in environment configuration
> and will NOT be committed to GitHub.

## Authentication
- Auth is DISABLED for the MVP
- No RLS logic required at this stage

## Data usage rules
- Supabase is the single source of truth
- All writes must go through Supabase
- IndexedDB is used only as local cache / offline support
- No business logic is stored in IndexedDB

## Sync expectations
- Offline data is marked as "pending_sync"
- On reconnect, data is synced to Supabase
- Supabase-generated IDs override local temporary IDs

## Security constraints
- Never expose service_role keys
- Never assume database credentials are available
- All data access must respect Supabase policies

## Environment notes
- Local development environment
- Production deployment via GitHub Pages or similar static hosting
