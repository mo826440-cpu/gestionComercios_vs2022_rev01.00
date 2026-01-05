# Supabase – Auth & Authorization Model

## Authentication
- Authentication handled by Supabase Auth
- Users log in via Supabase Auth
- Each auth user is linked to business user data

## User mapping
- auth.users.id → usuarios.auth_user_id
- usuarios table contains business-specific user data

## usuarios table
- id (uuid)
- auth_user_id (uuid, FK to auth.users)
- comercio_id (uuid)
- rol_id (uuid, FK to roles)
- activo (boolean)
- es_propietario (boolean)
- sync_id (uuid, used for offline sync)
- created_at / updated_at

## Roles
- Roles are stored in roles table
- Example roles:
  - admin
  - editor
  - viewer

## Permissions
- Permissions are linked to roles via roles_permisos table
- Role-based access control (RBAC) is implemented at application level and database level

## Security
- Row Level Security (RLS) is ENABLED
- Data access is restricted based on:
  - authenticated user
  - assigned role
  - associated comercio_id
