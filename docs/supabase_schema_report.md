-- ==============================
-- DATABASE STRUCTURE REPORT
-- ==============================

-- 1. DATABASE INFO

| database_name | database_user | postgres_version                                                                   |
| ------------- | ------------- | ---------------------------------------------------------------------------------- |
| postgres      | postgres      | PostgreSQL 17.6 on aarch64-unknown-linux-gnu, compiled by gcc (GCC) 13.2.0, 64-bit |

-- 2. SCHEMAS

| schema_name        |
| ------------------ |
| auth               |
| extensions         |
| graphql            |
| graphql_public     |
| information_schema |
| pg_catalog         |
| pg_temp_0          |
| pg_temp_1          |
| pg_temp_10         |
| pg_temp_11         |
| pg_temp_12         |
| pg_temp_13         |
| pg_temp_14         |
| pg_temp_15         |
| pg_temp_16         |
| pg_temp_17         |
| pg_temp_18         |
| pg_temp_19         |
| pg_temp_2          |
| pg_temp_20         |
| pg_temp_21         |
| pg_temp_22         |
| pg_temp_23         |
| pg_temp_24         |
| pg_temp_25         |
| pg_temp_26         |
| pg_temp_27         |
| pg_temp_28         |
| pg_temp_29         |
| pg_temp_30         |
| pg_temp_31         |
| pg_temp_32         |
| pg_temp_33         |
| pg_temp_34         |
| pg_temp_35         |
| pg_temp_36         |
| pg_temp_37         |
| pg_temp_38         |
| pg_temp_39         |
| pg_temp_40         |
| pg_temp_41         |
| pg_temp_42         |
| pg_temp_43         |
| pg_temp_44         |
| pg_temp_45         |
| pg_temp_46         |
| pg_temp_47         |
| pg_temp_48         |
| pg_temp_49         |
| pg_temp_5          |
| pg_temp_50         |
| pg_temp_51         |
| pg_temp_52         |
| pg_temp_53         |
| pg_temp_54         |
| pg_temp_55         |
| pg_temp_56         |
| pg_temp_57         |
| pg_temp_58         |
| pg_temp_59         |
| pg_temp_6          |
| pg_temp_7          |
| pg_temp_8          |
| pg_temp_9          |
| pg_toast           |
| pg_toast_temp_0    |
| pg_toast_temp_1    |
| pg_toast_temp_10   |
| pg_toast_temp_11   |
| pg_toast_temp_12   |
| pg_toast_temp_13   |
| pg_toast_temp_14   |
| pg_toast_temp_15   |
| pg_toast_temp_16   |
| pg_toast_temp_17   |
| pg_toast_temp_18   |
| pg_toast_temp_19   |
| pg_toast_temp_2    |
| pg_toast_temp_20   |
| pg_toast_temp_21   |
| pg_toast_temp_22   |
| pg_toast_temp_23   |
| pg_toast_temp_24   |
| pg_toast_temp_25   |
| pg_toast_temp_26   |
| pg_toast_temp_27   |
| pg_toast_temp_28   |
| pg_toast_temp_29   |
| pg_toast_temp_30   |
| pg_toast_temp_31   |
| pg_toast_temp_32   |
| pg_toast_temp_33   |
| pg_toast_temp_34   |
| pg_toast_temp_35   |
| pg_toast_temp_36   |
| pg_toast_temp_37   |
| pg_toast_temp_38   |
| pg_toast_temp_39   |
| pg_toast_temp_40   |
| pg_toast_temp_41   |

-- 3. TABLES

| table_schema | table_name                 |
| ------------ | -------------------------- |
| auth         | audit_log_entries          |
| auth         | flow_state                 |
| auth         | identities                 |
| auth         | instances                  |
| auth         | mfa_amr_claims             |
| auth         | mfa_challenges             |
| auth         | mfa_factors                |
| auth         | oauth_authorizations       |
| auth         | oauth_client_states        |
| auth         | oauth_clients              |
| auth         | oauth_consents             |
| auth         | one_time_tokens            |
| auth         | refresh_tokens             |
| auth         | saml_providers             |
| auth         | saml_relay_states          |
| auth         | schema_migrations          |
| auth         | sessions                   |
| auth         | sso_domains                |
| auth         | sso_providers              |
| auth         | users                      |
| public       | cajas                      |
| public       | categorias                 |
| public       | clientes                   |
| public       | comercios                  |
| public       | compras                    |
| public       | configuraciones            |
| public       | detalle_compras            |
| public       | detalle_ventas             |
| public       | logs_sistema               |
| public       | marcas                     |
| public       | movimientos_stock          |
| public       | pagos_compras              |
| public       | pagos_ventas               |
| public       | permisos                   |
| public       | productos                  |
| public       | proveedores                |
| public       | roles                      |
| public       | roles_permisos             |
| public       | stock                      |
| public       | usuarios                   |
| public       | ventas                     |
| realtime     | messages                   |
| realtime     | schema_migrations          |
| realtime     | subscription               |
| storage      | buckets                    |
| storage      | buckets_analytics          |
| storage      | buckets_vectors            |
| storage      | migrations                 |
| storage      | objects                    |
| storage      | prefixes                   |
| storage      | s3_multipart_uploads       |
| storage      | s3_multipart_uploads_parts |
| storage      | vector_indexes             |
| vault        | secrets                    |

-- 4. COLUMNS (FULL DETAIL)

| table_schema | table_name           | column_name                  | data_type                | internal_type              | is_nullable | column_default                             | character_maximum_length | numeric_precision | datetime_precision |
| ------------ | -------------------- | ---------------------------- | ------------------------ | -------------------------- | ----------- | ------------------------------------------ | ------------------------ | ----------------- | ------------------ |
| auth         | audit_log_entries    | instance_id                  | uuid                     | uuid                       | YES         | null                                       | null                     | null              | null               |
| auth         | audit_log_entries    | id                           | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | audit_log_entries    | payload                      | json                     | json                       | YES         | null                                       | null                     | null              | null               |
| auth         | audit_log_entries    | created_at                   | timestamp with time zone | timestamptz                | YES         | null                                       | null                     | null              | 6                  |
| auth         | audit_log_entries    | ip_address                   | character varying        | varchar                    | NO          | ''::character varying                      | 64                       | null              | null               |
| auth         | flow_state           | id                           | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | flow_state           | user_id                      | uuid                     | uuid                       | YES         | null                                       | null                     | null              | null               |
| auth         | flow_state           | auth_code                    | text                     | text                       | NO          | null                                       | null                     | null              | null               |
| auth         | flow_state           | code_challenge_method        | USER-DEFINED             | code_challenge_method      | NO          | null                                       | null                     | null              | null               |
| auth         | flow_state           | code_challenge               | text                     | text                       | NO          | null                                       | null                     | null              | null               |
| auth         | flow_state           | provider_type                | text                     | text                       | NO          | null                                       | null                     | null              | null               |
| auth         | flow_state           | provider_access_token        | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | flow_state           | provider_refresh_token       | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | flow_state           | created_at                   | timestamp with time zone | timestamptz                | YES         | null                                       | null                     | null              | 6                  |
| auth         | flow_state           | updated_at                   | timestamp with time zone | timestamptz                | YES         | null                                       | null                     | null              | 6                  |
| auth         | flow_state           | authentication_method        | text                     | text                       | NO          | null                                       | null                     | null              | null               |
| auth         | flow_state           | auth_code_issued_at          | timestamp with time zone | timestamptz                | YES         | null                                       | null                     | null              | 6                  |
| auth         | identities           | provider_id                  | text                     | text                       | NO          | null                                       | null                     | null              | null               |
| auth         | identities           | user_id                      | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | identities           | identity_data                | jsonb                    | jsonb                      | NO          | null                                       | null                     | null              | null               |
| auth         | identities           | provider                     | text                     | text                       | NO          | null                                       | null                     | null              | null               |
| auth         | identities           | last_sign_in_at              | timestamp with time zone | timestamptz                | YES         | null                                       | null                     | null              | 6                  |
| auth         | identities           | created_at                   | timestamp with time zone | timestamptz                | YES         | null                                       | null                     | null              | 6                  |
| auth         | identities           | updated_at                   | timestamp with time zone | timestamptz                | YES         | null                                       | null                     | null              | 6                  |
| auth         | identities           | email                        | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | identities           | id                           | uuid                     | uuid                       | NO          | gen_random_uuid()                          | null                     | null              | null               |
| auth         | instances            | id                           | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | instances            | uuid                         | uuid                     | uuid                       | YES         | null                                       | null                     | null              | null               |
| auth         | instances            | raw_base_config              | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | instances            | created_at                   | timestamp with time zone | timestamptz                | YES         | null                                       | null                     | null              | 6                  |
| auth         | instances            | updated_at                   | timestamp with time zone | timestamptz                | YES         | null                                       | null                     | null              | 6                  |
| auth         | mfa_amr_claims       | session_id                   | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | mfa_amr_claims       | created_at                   | timestamp with time zone | timestamptz                | NO          | null                                       | null                     | null              | 6                  |
| auth         | mfa_amr_claims       | updated_at                   | timestamp with time zone | timestamptz                | NO          | null                                       | null                     | null              | 6                  |
| auth         | mfa_amr_claims       | authentication_method        | text                     | text                       | NO          | null                                       | null                     | null              | null               |
| auth         | mfa_amr_claims       | id                           | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | mfa_challenges       | id                           | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | mfa_challenges       | factor_id                    | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | mfa_challenges       | created_at                   | timestamp with time zone | timestamptz                | NO          | null                                       | null                     | null              | 6                  |
| auth         | mfa_challenges       | verified_at                  | timestamp with time zone | timestamptz                | YES         | null                                       | null                     | null              | 6                  |
| auth         | mfa_challenges       | ip_address                   | inet                     | inet                       | NO          | null                                       | null                     | null              | null               |
| auth         | mfa_challenges       | otp_code                     | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | mfa_challenges       | web_authn_session_data       | jsonb                    | jsonb                      | YES         | null                                       | null                     | null              | null               |
| auth         | mfa_factors          | id                           | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | mfa_factors          | user_id                      | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | mfa_factors          | friendly_name                | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | mfa_factors          | factor_type                  | USER-DEFINED             | factor_type                | NO          | null                                       | null                     | null              | null               |
| auth         | mfa_factors          | status                       | USER-DEFINED             | factor_status              | NO          | null                                       | null                     | null              | null               |
| auth         | mfa_factors          | created_at                   | timestamp with time zone | timestamptz                | NO          | null                                       | null                     | null              | 6                  |
| auth         | mfa_factors          | updated_at                   | timestamp with time zone | timestamptz                | NO          | null                                       | null                     | null              | 6                  |
| auth         | mfa_factors          | secret                       | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | mfa_factors          | phone                        | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | mfa_factors          | last_challenged_at           | timestamp with time zone | timestamptz                | YES         | null                                       | null                     | null              | 6                  |
| auth         | mfa_factors          | web_authn_credential         | jsonb                    | jsonb                      | YES         | null                                       | null                     | null              | null               |
| auth         | mfa_factors          | web_authn_aaguid             | uuid                     | uuid                       | YES         | null                                       | null                     | null              | null               |
| auth         | mfa_factors          | last_webauthn_challenge_data | jsonb                    | jsonb                      | YES         | null                                       | null                     | null              | null               |
| auth         | oauth_authorizations | id                           | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | oauth_authorizations | authorization_id             | text                     | text                       | NO          | null                                       | null                     | null              | null               |
| auth         | oauth_authorizations | client_id                    | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | oauth_authorizations | user_id                      | uuid                     | uuid                       | YES         | null                                       | null                     | null              | null               |
| auth         | oauth_authorizations | redirect_uri                 | text                     | text                       | NO          | null                                       | null                     | null              | null               |
| auth         | oauth_authorizations | scope                        | text                     | text                       | NO          | null                                       | null                     | null              | null               |
| auth         | oauth_authorizations | state                        | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | oauth_authorizations | resource                     | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | oauth_authorizations | code_challenge               | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | oauth_authorizations | code_challenge_method        | USER-DEFINED             | code_challenge_method      | YES         | null                                       | null                     | null              | null               |
| auth         | oauth_authorizations | response_type                | USER-DEFINED             | oauth_response_type        | NO          | 'code'::auth.oauth_response_type           | null                     | null              | null               |
| auth         | oauth_authorizations | status                       | USER-DEFINED             | oauth_authorization_status | NO          | 'pending'::auth.oauth_authorization_status | null                     | null              | null               |
| auth         | oauth_authorizations | authorization_code           | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | oauth_authorizations | created_at                   | timestamp with time zone | timestamptz                | NO          | now()                                      | null                     | null              | 6                  |
| auth         | oauth_authorizations | expires_at                   | timestamp with time zone | timestamptz                | NO          | (now() + '00:03:00'::interval)             | null                     | null              | 6                  |
| auth         | oauth_authorizations | approved_at                  | timestamp with time zone | timestamptz                | YES         | null                                       | null                     | null              | 6                  |
| auth         | oauth_authorizations | nonce                        | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | oauth_client_states  | id                           | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | oauth_client_states  | provider_type                | text                     | text                       | NO          | null                                       | null                     | null              | null               |
| auth         | oauth_client_states  | code_verifier                | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | oauth_client_states  | created_at                   | timestamp with time zone | timestamptz                | NO          | null                                       | null                     | null              | 6                  |
| auth         | oauth_clients        | id                           | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | oauth_clients        | client_secret_hash           | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | oauth_clients        | registration_type            | USER-DEFINED             | oauth_registration_type    | NO          | null                                       | null                     | null              | null               |
| auth         | oauth_clients        | redirect_uris                | text                     | text                       | NO          | null                                       | null                     | null              | null               |
| auth         | oauth_clients        | grant_types                  | text                     | text                       | NO          | null                                       | null                     | null              | null               |
| auth         | oauth_clients        | client_name                  | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | oauth_clients        | client_uri                   | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | oauth_clients        | logo_uri                     | text                     | text                       | YES         | null                                       | null                     | null              | null               |
| auth         | oauth_clients        | created_at                   | timestamp with time zone | timestamptz                | NO          | now()                                      | null                     | null              | 6                  |
| auth         | oauth_clients        | updated_at                   | timestamp with time zone | timestamptz                | NO          | now()                                      | null                     | null              | 6                  |
| auth         | oauth_clients        | deleted_at                   | timestamp with time zone | timestamptz                | YES         | null                                       | null                     | null              | 6                  |
| auth         | oauth_clients        | client_type                  | USER-DEFINED             | oauth_client_type          | NO          | 'confidential'::auth.oauth_client_type     | null                     | null              | null               |
| auth         | oauth_consents       | id                           | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | oauth_consents       | user_id                      | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | oauth_consents       | client_id                    | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | oauth_consents       | scopes                       | text                     | text                       | NO          | null                                       | null                     | null              | null               |
| auth         | oauth_consents       | granted_at                   | timestamp with time zone | timestamptz                | NO          | now()                                      | null                     | null              | 6                  |
| auth         | oauth_consents       | revoked_at                   | timestamp with time zone | timestamptz                | YES         | null                                       | null                     | null              | 6                  |
| auth         | one_time_tokens      | id                           | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | one_time_tokens      | user_id                      | uuid                     | uuid                       | NO          | null                                       | null                     | null              | null               |
| auth         | one_time_tokens      | token_type                   | USER-DEFINED             | one_time_token_type        | NO          | null                                       | null                     | null              | null               |
| auth         | one_time_tokens      | token_hash                   | text                     | text                       | NO          | null                                       | null                     | null              | null               |
| auth         | one_time_tokens      | relates_to                   | text                     | text                       | NO          | null                                       | null                     | null              | null               |



-- 5. PRIMARY KEYS

| table_schema | table_name                 | column_name |
| ------------ | -------------------------- | ----------- |
| auth         | audit_log_entries          | id          |
| auth         | flow_state                 | id          |
| auth         | identities                 | id          |
| auth         | instances                  | id          |
| auth         | mfa_amr_claims             | id          |
| auth         | mfa_challenges             | id          |
| auth         | mfa_factors                | id          |
| auth         | oauth_authorizations       | id          |
| auth         | oauth_client_states        | id          |
| auth         | oauth_clients              | id          |
| auth         | oauth_consents             | id          |
| auth         | one_time_tokens            | id          |
| auth         | refresh_tokens             | id          |
| auth         | saml_providers             | id          |
| auth         | saml_relay_states          | id          |
| auth         | sessions                   | id          |
| auth         | sso_domains                | id          |
| auth         | sso_providers              | id          |
| auth         | users                      | id          |
| public       | cajas                      | id          |
| public       | categorias                 | id          |
| public       | clientes                   | id          |
| public       | comercios                  | id          |
| public       | compras                    | id          |
| public       | configuraciones            | id          |
| public       | detalle_compras            | id          |
| public       | detalle_ventas             | id          |
| public       | logs_sistema               | id          |
| public       | marcas                     | id          |
| public       | movimientos_stock          | id          |
| public       | pagos_compras              | id          |
| public       | pagos_ventas               | id          |
| public       | permisos                   | id          |
| public       | productos                  | id          |
| public       | proveedores                | id          |
| public       | roles                      | id          |
| public       | roles_permisos             | permiso_id  |
| public       | roles_permisos             | rol_id      |
| public       | stock                      | id          |
| public       | usuarios                   | id          |
| public       | ventas                     | id          |
| realtime     | messages                   | inserted_at |
| realtime     | messages                   | id          |
| realtime     | schema_migrations          | version     |
| realtime     | schema_migrations          | version     |
| realtime     | subscription               | id          |
| storage      | buckets                    | id          |
| storage      | buckets_analytics          | id          |
| storage      | objects                    | id          |
| storage      | prefixes                   | name        |
| storage      | prefixes                   | level       |
| storage      | prefixes                   | bucket_id   |
| storage      | s3_multipart_uploads       | id          |
| storage      | s3_multipart_uploads_parts | id          |
| vault        | secrets                    | id          |

-- 6. FOREIGN KEYS (RELATIONSHIPS)

| table_schema | table_name        | column_name         | foreign_table_schema | foreign_table_name | foreign_column_name |
| ------------ | ----------------- | ------------------- | -------------------- | ------------------ | ------------------- |
| public       | cajas             | usuario_cierre_id   | public               | usuarios           | id                  |
| public       | cajas             | usuario_apertura_id | public               | usuarios           | id                  |
| public       | cajas             | comercio_id         | public               | comercios          | id                  |
| public       | categorias        | comercio_id         | public               | comercios          | id                  |
| public       | clientes          | comercio_id         | public               | comercios          | id                  |
| public       | compras           | proveedor_id        | public               | proveedores        | id                  |
| public       | compras           | comercio_id         | public               | comercios          | id                  |
| public       | configuraciones   | comercio_id         | public               | comercios          | id                  |
| public       | detalle_compras   | producto_id         | public               | productos          | id                  |
| public       | detalle_compras   | compra_id           | public               | compras            | id                  |
| public       | detalle_ventas    | venta_id            | public               | ventas             | id                  |
| public       | detalle_ventas    | producto_id         | public               | productos          | id                  |
| public       | logs_sistema      | usuario_id          | public               | usuarios           | id                  |
| public       | logs_sistema      | comercio_id         | public               | comercios          | id                  |
| public       | marcas            | comercio_id         | public               | comercios          | id                  |
| public       | movimientos_stock | usuario_id          | public               | usuarios           | id                  |
| public       | movimientos_stock | comercio_id         | public               | comercios          | id                  |
| public       | movimientos_stock | producto_id         | public               | productos          | id                  |
| public       | pagos_compras     | compra_id           | public               | compras            | id                  |
| public       | pagos_ventas      | venta_id            | public               | ventas             | id                  |
| public       | productos         | comercio_id         | public               | comercios          | id                  |
| public       | productos         | categoria_id        | public               | categorias         | id                  |
| public       | productos         | marca_id            | public               | marcas             | id                  |
| public       | proveedores       | comercio_id         | public               | comercios          | id                  |
| public       | roles_permisos    | rol_id              | public               | roles              | id                  |
| public       | roles_permisos    | permiso_id          | public               | permisos           | id                  |
| public       | stock             | comercio_id         | public               | comercios          | id                  |
| public       | stock             | producto_id         | public               | productos          | id                  |
| public       | usuarios          | rol_id              | public               | roles              | id                  |
| public       | usuarios          | comercio_id         | public               | comercios          | id                  |
| public       | ventas            | caja_id             | public               | cajas              | id                  |
| public       | ventas            | comercio_id         | public               | comercios          | id                  |
| public       | ventas            | cliente_id          | public               | clientes           | id                  |
| public       | ventas            | usuario_id          | public               | usuarios           | id                  |

-- 7. INDEXES

| schemaname | tablename            | indexname                                            | indexdef                                                                                                                                                                  |
| ---------- | -------------------- | ---------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| auth       | audit_log_entries    | audit_log_entries_pkey                               | CREATE UNIQUE INDEX audit_log_entries_pkey ON auth.audit_log_entries USING btree (id)                                                                                     |
| auth       | audit_log_entries    | audit_logs_instance_id_idx                           | CREATE INDEX audit_logs_instance_id_idx ON auth.audit_log_entries USING btree (instance_id)                                                                               |
| auth       | flow_state           | idx_user_id_auth_method                              | CREATE INDEX idx_user_id_auth_method ON auth.flow_state USING btree (user_id, authentication_method)                                                                      |
| auth       | flow_state           | idx_auth_code                                        | CREATE INDEX idx_auth_code ON auth.flow_state USING btree (auth_code)                                                                                                     |
| auth       | flow_state           | flow_state_pkey                                      | CREATE UNIQUE INDEX flow_state_pkey ON auth.flow_state USING btree (id)                                                                                                   |
| auth       | flow_state           | flow_state_created_at_idx                            | CREATE INDEX flow_state_created_at_idx ON auth.flow_state USING btree (created_at DESC)                                                                                   |
| auth       | identities           | identities_email_idx                                 | CREATE INDEX identities_email_idx ON auth.identities USING btree (email text_pattern_ops)                                                                                 |
| auth       | identities           | identities_user_id_idx                               | CREATE INDEX identities_user_id_idx ON auth.identities USING btree (user_id)                                                                                              |
| auth       | identities           | identities_provider_id_provider_unique               | CREATE UNIQUE INDEX identities_provider_id_provider_unique ON auth.identities USING btree (provider_id, provider)                                                         |
| auth       | identities           | identities_pkey                                      | CREATE UNIQUE INDEX identities_pkey ON auth.identities USING btree (id)                                                                                                   |
| auth       | instances            | instances_pkey                                       | CREATE UNIQUE INDEX instances_pkey ON auth.instances USING btree (id)                                                                                                     |
| auth       | mfa_amr_claims       | amr_id_pk                                            | CREATE UNIQUE INDEX amr_id_pk ON auth.mfa_amr_claims USING btree (id)                                                                                                     |
| auth       | mfa_amr_claims       | mfa_amr_claims_session_id_authentication_method_pkey | CREATE UNIQUE INDEX mfa_amr_claims_session_id_authentication_method_pkey ON auth.mfa_amr_claims USING btree (session_id, authentication_method)                           |
| auth       | mfa_challenges       | mfa_challenges_pkey                                  | CREATE UNIQUE INDEX mfa_challenges_pkey ON auth.mfa_challenges USING btree (id)                                                                                           |
| auth       | mfa_challenges       | mfa_challenge_created_at_idx                         | CREATE INDEX mfa_challenge_created_at_idx ON auth.mfa_challenges USING btree (created_at DESC)                                                                            |
| auth       | mfa_factors          | mfa_factors_user_id_idx                              | CREATE INDEX mfa_factors_user_id_idx ON auth.mfa_factors USING btree (user_id)                                                                                            |
| auth       | mfa_factors          | mfa_factors_last_challenged_at_key                   | CREATE UNIQUE INDEX mfa_factors_last_challenged_at_key ON auth.mfa_factors USING btree (last_challenged_at)                                                               |
| auth       | mfa_factors          | unique_phone_factor_per_user                         | CREATE UNIQUE INDEX unique_phone_factor_per_user ON auth.mfa_factors USING btree (user_id, phone)                                                                         |
| auth       | mfa_factors          | mfa_factors_pkey                                     | CREATE UNIQUE INDEX mfa_factors_pkey ON auth.mfa_factors USING btree (id)                                                                                                 |
| auth       | mfa_factors          | mfa_factors_user_friendly_name_unique                | CREATE UNIQUE INDEX mfa_factors_user_friendly_name_unique ON auth.mfa_factors USING btree (friendly_name, user_id) WHERE (TRIM(BOTH FROM friendly_name) <> ''::text)      |
| auth       | mfa_factors          | factor_id_created_at_idx                             | CREATE INDEX factor_id_created_at_idx ON auth.mfa_factors USING btree (user_id, created_at)                                                                               |
| auth       | oauth_authorizations | oauth_authorizations_pkey                            | CREATE UNIQUE INDEX oauth_authorizations_pkey ON auth.oauth_authorizations USING btree (id)                                                                               |
| auth       | oauth_authorizations | oauth_authorizations_authorization_code_key          | CREATE UNIQUE INDEX oauth_authorizations_authorization_code_key ON auth.oauth_authorizations USING btree (authorization_code)                                             |
| auth       | oauth_authorizations | oauth_auth_pending_exp_idx                           | CREATE INDEX oauth_auth_pending_exp_idx ON auth.oauth_authorizations USING btree (expires_at) WHERE (status = 'pending'::auth.oauth_authorization_status)                 |
| auth       | oauth_authorizations | oauth_authorizations_authorization_id_key            | CREATE UNIQUE INDEX oauth_authorizations_authorization_id_key ON auth.oauth_authorizations USING btree (authorization_id)                                                 |
| auth       | oauth_client_states  | idx_oauth_client_states_created_at                   | CREATE INDEX idx_oauth_client_states_created_at ON auth.oauth_client_states USING btree (created_at)                                                                      |
| auth       | oauth_client_states  | oauth_client_states_pkey                             | CREATE UNIQUE INDEX oauth_client_states_pkey ON auth.oauth_client_states USING btree (id)                                                                                 |
| auth       | oauth_clients        | oauth_clients_deleted_at_idx                         | CREATE INDEX oauth_clients_deleted_at_idx ON auth.oauth_clients USING btree (deleted_at)                                                                                  |
| auth       | oauth_clients        | oauth_clients_pkey                                   | CREATE UNIQUE INDEX oauth_clients_pkey ON auth.oauth_clients USING btree (id)                                                                                             |
| auth       | oauth_consents       | oauth_consents_pkey                                  | CREATE UNIQUE INDEX oauth_consents_pkey ON auth.oauth_consents USING btree (id)                                                                                           |
| auth       | oauth_consents       | oauth_consents_user_client_unique                    | CREATE UNIQUE INDEX oauth_consents_user_client_unique ON auth.oauth_consents USING btree (user_id, client_id)                                                             |
| auth       | oauth_consents       | oauth_consents_active_user_client_idx                | CREATE INDEX oauth_consents_active_user_client_idx ON auth.oauth_consents USING btree (user_id, client_id) WHERE (revoked_at IS NULL)                                     |
| auth       | oauth_consents       | oauth_consents_active_client_idx                     | CREATE INDEX oauth_consents_active_client_idx ON auth.oauth_consents USING btree (client_id) WHERE (revoked_at IS NULL)                                                   |
| auth       | oauth_consents       | oauth_consents_user_order_idx                        | CREATE INDEX oauth_consents_user_order_idx ON auth.oauth_consents USING btree (user_id, granted_at DESC)                                                                  |
| auth       | one_time_tokens      | one_time_tokens_pkey                                 | CREATE UNIQUE INDEX one_time_tokens_pkey ON auth.one_time_tokens USING btree (id)                                                                                         |
| auth       | one_time_tokens      | one_time_tokens_token_hash_hash_idx                  | CREATE INDEX one_time_tokens_token_hash_hash_idx ON auth.one_time_tokens USING hash (token_hash)                                                                          |
| auth       | one_time_tokens      | one_time_tokens_relates_to_hash_idx                  | CREATE INDEX one_time_tokens_relates_to_hash_idx ON auth.one_time_tokens USING hash (relates_to)                                                                          |
| auth       | one_time_tokens      | one_time_tokens_user_id_token_type_key               | CREATE UNIQUE INDEX one_time_tokens_user_id_token_type_key ON auth.one_time_tokens USING btree (user_id, token_type)                                                      |
| auth       | refresh_tokens       | refresh_tokens_updated_at_idx                        | CREATE INDEX refresh_tokens_updated_at_idx ON auth.refresh_tokens USING btree (updated_at DESC)                                                                           |
| auth       | refresh_tokens       | refresh_tokens_instance_id_idx                       | CREATE INDEX refresh_tokens_instance_id_idx ON auth.refresh_tokens USING btree (instance_id)                                                                              |
| auth       | refresh_tokens       | refresh_tokens_instance_id_user_id_idx               | CREATE INDEX refresh_tokens_instance_id_user_id_idx ON auth.refresh_tokens USING btree (instance_id, user_id)                                                             |
| auth       | refresh_tokens       | refresh_tokens_token_unique                          | CREATE UNIQUE INDEX refresh_tokens_token_unique ON auth.refresh_tokens USING btree (token)                                                                                |
| auth       | refresh_tokens       | refresh_tokens_parent_idx                            | CREATE INDEX refresh_tokens_parent_idx ON auth.refresh_tokens USING btree (parent)                                                                                        |
| auth       | refresh_tokens       | refresh_tokens_session_id_revoked_idx                | CREATE INDEX refresh_tokens_session_id_revoked_idx ON auth.refresh_tokens USING btree (session_id, revoked)                                                               |
| auth       | refresh_tokens       | refresh_tokens_pkey                                  | CREATE UNIQUE INDEX refresh_tokens_pkey ON auth.refresh_tokens USING btree (id)                                                                                           |
| auth       | saml_providers       | saml_providers_sso_provider_id_idx                   | CREATE INDEX saml_providers_sso_provider_id_idx ON auth.saml_providers USING btree (sso_provider_id)                                                                      |
| auth       | saml_providers       | saml_providers_entity_id_key                         | CREATE UNIQUE INDEX saml_providers_entity_id_key ON auth.saml_providers USING btree (entity_id)                                                                           |
| auth       | saml_providers       | saml_providers_pkey                                  | CREATE UNIQUE INDEX saml_providers_pkey ON auth.saml_providers USING btree (id)                                                                                           |
| auth       | saml_relay_states    | saml_relay_states_for_email_idx                      | CREATE INDEX saml_relay_states_for_email_idx ON auth.saml_relay_states USING btree (for_email)                                                                            |
| auth       | saml_relay_states    | saml_relay_states_created_at_idx                     | CREATE INDEX saml_relay_states_created_at_idx ON auth.saml_relay_states USING btree (created_at DESC)                                                                     |
| auth       | saml_relay_states    | saml_relay_states_pkey                               | CREATE UNIQUE INDEX saml_relay_states_pkey ON auth.saml_relay_states USING btree (id)                                                                                     |
| auth       | saml_relay_states    | saml_relay_states_sso_provider_id_idx                | CREATE INDEX saml_relay_states_sso_provider_id_idx ON auth.saml_relay_states USING btree (sso_provider_id)                                                                |
| auth       | schema_migrations    | schema_migrations_pkey                               | CREATE UNIQUE INDEX schema_migrations_pkey ON auth.schema_migrations USING btree (version)                                                                                |
| auth       | sessions             | user_id_created_at_idx                               | CREATE INDEX user_id_created_at_idx ON auth.sessions USING btree (user_id, created_at)                                                                                    |
| auth       | sessions             | sessions_pkey                                        | CREATE UNIQUE INDEX sessions_pkey ON auth.sessions USING btree (id)                                                                                                       |
| auth       | sessions             | sessions_oauth_client_id_idx                         | CREATE INDEX sessions_oauth_client_id_idx ON auth.sessions USING btree (oauth_client_id)                                                                                  |
| auth       | sessions             | sessions_not_after_idx                               | CREATE INDEX sessions_not_after_idx ON auth.sessions USING btree (not_after DESC)                                                                                         |
| auth       | sessions             | sessions_user_id_idx                                 | CREATE INDEX sessions_user_id_idx ON auth.sessions USING btree (user_id)                                                                                                  |
| auth       | sso_domains          | sso_domains_pkey                                     | CREATE UNIQUE INDEX sso_domains_pkey ON auth.sso_domains USING btree (id)                                                                                                 |
| auth       | sso_domains          | sso_domains_sso_provider_id_idx                      | CREATE INDEX sso_domains_sso_provider_id_idx ON auth.sso_domains USING btree (sso_provider_id)                                                                            |
| auth       | sso_domains          | sso_domains_domain_idx                               | CREATE UNIQUE INDEX sso_domains_domain_idx ON auth.sso_domains USING btree (lower(domain))                                                                                |
| auth       | sso_providers        | sso_providers_resource_id_pattern_idx                | CREATE INDEX sso_providers_resource_id_pattern_idx ON auth.sso_providers USING btree (resource_id text_pattern_ops)                                                       |
| auth       | sso_providers        | sso_providers_pkey                                   | CREATE UNIQUE INDEX sso_providers_pkey ON auth.sso_providers USING btree (id)                                                                                             |
| auth       | sso_providers        | sso_providers_resource_id_idx                        | CREATE UNIQUE INDEX sso_providers_resource_id_idx ON auth.sso_providers USING btree (lower(resource_id))                                                                  |
| auth       | users                | users_is_anonymous_idx                               | CREATE INDEX users_is_anonymous_idx ON auth.users USING btree (is_anonymous)                                                                                              |
| auth       | users                | reauthentication_token_idx                           | CREATE UNIQUE INDEX reauthentication_token_idx ON auth.users USING btree (reauthentication_token) WHERE ((reauthentication_token)::text !~ '^[0-9 ]*$'::text)             |
| auth       | users                | email_change_token_new_idx                           | CREATE UNIQUE INDEX email_change_token_new_idx ON auth.users USING btree (email_change_token_new) WHERE ((email_change_token_new)::text !~ '^[0-9 ]*$'::text)             |
| auth       | users                | email_change_token_current_idx                       | CREATE UNIQUE INDEX email_change_token_current_idx ON auth.users USING btree (email_change_token_current) WHERE ((email_change_token_current)::text !~ '^[0-9 ]*$'::text) |
| auth       | users                | recovery_token_idx                                   | CREATE UNIQUE INDEX recovery_token_idx ON auth.users USING btree (recovery_token) WHERE ((recovery_token)::text !~ '^[0-9 ]*$'::text)                                     |
| auth       | users                | confirmation_token_idx                               | CREATE UNIQUE INDEX confirmation_token_idx ON auth.users USING btree (confirmation_token) WHERE ((confirmation_token)::text !~ '^[0-9 ]*$'::text)                         |
| auth       | users                | users_instance_id_email_idx                          | CREATE INDEX users_instance_id_email_idx ON auth.users USING btree (instance_id, lower((email)::text))                                                                    |
| auth       | users                | users_phone_key                                      | CREATE UNIQUE INDEX users_phone_key ON auth.users USING btree (phone)                                                                                                     |
| auth       | users                | users_instance_id_idx                                | CREATE INDEX users_instance_id_idx ON auth.users USING btree (instance_id)                                                                                                |
| auth       | users                | users_email_partial_key                              | CREATE UNIQUE INDEX users_email_partial_key ON auth.users USING btree (email) WHERE (is_sso_user = false)                                                                 |
| auth       | users                | users_pkey                                           | CREATE UNIQUE INDEX users_pkey ON auth.users USING btree (id)                                                                                                             |
| public     | cajas                | cajas_pkey                                           | CREATE UNIQUE INDEX cajas_pkey ON public.cajas USING btree (id)                                                                                                           |
| public     | cajas                | idx_cajas_comercio                                   | CREATE INDEX idx_cajas_comercio ON public.cajas USING btree (comercio_id)                                                                                                 |
| public     | categorias           | idx_categorias_comercio                              | CREATE INDEX idx_categorias_comercio ON public.categorias USING btree (comercio_id)                                                                                       |
| public     | categorias           | categorias_nombre_comercio_unique                    | CREATE UNIQUE INDEX categorias_nombre_comercio_unique ON public.categorias USING btree (comercio_id, nombre)                                                              |
| public     | categorias           | idx_categorias_nombre                                | CREATE INDEX idx_categorias_nombre ON public.categorias USING btree (comercio_id, nombre)                                                                                 |
| public     | categorias           | categorias_pkey                                      | CREATE UNIQUE INDEX categorias_pkey ON public.categorias USING btree (id)                                                                                                 |
| public     | clientes             | clientes_nombre_comercio_unique                      | CREATE UNIQUE INDEX clientes_nombre_comercio_unique ON public.clientes USING btree (comercio_id, nombre)                                                                  |
| public     | clientes             | idx_clientes_nombre                                  | CREATE INDEX idx_clientes_nombre ON public.clientes USING btree (comercio_id, nombre)                                                                                     |
| public     | clientes             | idx_clientes_comercio                                | CREATE INDEX idx_clientes_comercio ON public.clientes USING btree (comercio_id)                                                                                           |
| public     | clientes             | clientes_pkey                                        | CREATE UNIQUE INDEX clientes_pkey ON public.clientes USING btree (id)                                                                                                     |
| public     | comercios            | comercios_email_key                                  | CREATE UNIQUE INDEX comercios_email_key ON public.comercios USING btree (email)                                                                                           |
| public     | comercios            | idx_comercios_email                                  | CREATE INDEX idx_comercios_email ON public.comercios USING btree (email)                                                                                                  |
| public     | comercios            | comercios_pkey                                       | CREATE UNIQUE INDEX comercios_pkey ON public.comercios USING btree (id)                                                                                                   |
| public     | compras              | idx_compras_comercio                                 | CREATE INDEX idx_compras_comercio ON public.compras USING btree (comercio_id)                                                                                             |
| public     | compras              | idx_compras_fecha                                    | CREATE INDEX idx_compras_fecha ON public.compras USING btree (fecha)                                                                                                      |
| public     | compras              | compras_pkey                                         | CREATE UNIQUE INDEX compras_pkey ON public.compras USING btree (id)                                                                                                       |
| public     | compras              | idx_compras_proveedor                                | CREATE INDEX idx_compras_proveedor ON public.compras USING btree (proveedor_id)                                                                                           |
| public     | configuraciones      | idx_config_comercio                                  | CREATE INDEX idx_config_comercio ON public.configuraciones USING btree (comercio_id)                                                                                      |
| public     | configuraciones      | configuraciones_comercio_id_categoria_clave_key      | CREATE UNIQUE INDEX configuraciones_comercio_id_categoria_clave_key ON public.configuraciones USING btree (comercio_id, categoria, clave)                                 |
| public     | configuraciones      | configuraciones_pkey                                 | CREATE UNIQUE INDEX configuraciones_pkey ON public.configuraciones USING btree (id)                                                                                       |
| public     | configuraciones      | idx_config_categoria                                 | CREATE INDEX idx_config_categoria ON public.configuraciones USING btree (comercio_id, categoria)                                                                          |
| public     | detalle_compras      | idx_detalle_compras_producto                         | CREATE INDEX idx_detalle_compras_producto ON public.detalle_compras USING btree (producto_id)                                                                             |
| public     | detalle_compras      | detalle_compras_pkey                                 | CREATE UNIQUE INDEX detalle_compras_pkey ON public.detalle_compras USING btree (id)                                                                                       |
| public     | detalle_compras      | idx_detalle_compras_compra                           | CREATE INDEX idx_detalle_compras_compra ON public.detalle_compras USING btree (compra_id)                                                                                 |
| public     | detalle_ventas       | idx_detalle_venta                                    | CREATE INDEX idx_detalle_venta ON public.detalle_ventas USING btree (venta_id)                                                                                            |

-- 8. RLS STATUS PER TABLE

| schemaname | tablename                  | rls_enabled |
| ---------- | -------------------------- | ----------- |
| auth       | audit_log_entries          | true        |
| auth       | flow_state                 | true        |
| auth       | identities                 | true        |
| auth       | instances                  | true        |
| auth       | mfa_amr_claims             | true        |
| auth       | mfa_challenges             | true        |
| auth       | mfa_factors                | true        |
| auth       | oauth_authorizations       | false       |
| auth       | oauth_client_states        | false       |
| auth       | oauth_clients              | false       |
| auth       | oauth_consents             | false       |
| auth       | one_time_tokens            | true        |
| auth       | refresh_tokens             | true        |
| auth       | saml_providers             | true        |
| auth       | saml_relay_states          | true        |
| auth       | schema_migrations          | true        |
| auth       | sessions                   | true        |
| auth       | sso_domains                | true        |
| auth       | sso_providers              | true        |
| auth       | users                      | true        |
| public     | cajas                      | false       |
| public     | categorias                 | false       |
| public     | clientes                   | true        |
| public     | comercios                  | false       |
| public     | compras                    | true        |
| public     | configuraciones            | true        |
| public     | detalle_compras            | true        |
| public     | detalle_ventas             | true        |
| public     | logs_sistema               | false       |
| public     | marcas                     | false       |
| public     | movimientos_stock          | false       |
| public     | pagos_compras              | true        |
| public     | pagos_ventas               | true        |
| public     | permisos                   | false       |
| public     | productos                  | true        |
| public     | proveedores                | true        |
| public     | roles                      | false       |
| public     | roles_permisos             | false       |
| public     | stock                      | false       |
| public     | usuarios                   | false       |
| public     | ventas                     | true        |
| realtime   | messages                   | true        |
| realtime   | schema_migrations          | false       |
| realtime   | subscription               | false       |
| storage    | buckets                    | true        |
| storage    | buckets_analytics          | true        |
| storage    | buckets_vectors            | true        |
| storage    | migrations                 | true        |
| storage    | objects                    | true        |
| storage    | prefixes                   | true        |
| storage    | s3_multipart_uploads       | true        |
| storage    | s3_multipart_uploads_parts | true        |
| storage    | vector_indexes             | true        |
| vault      | secrets                    | false       |

-- 9. RLS POLICIES

| schemaname | tablename       | policyname                                                      | permissive | roles    | cmd    | qual                                                                                                                                                                                              | with_check                                                                                                                                                                                        |
| ---------- | --------------- | --------------------------------------------------------------- | ---------- | -------- | ------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| public     | clientes        | Los usuarios solo pueden actualizar clientes de su comercio     | PERMISSIVE | {public} | UPDATE | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     | null                                                                                                                                                                                              |
| public     | clientes        | Los usuarios solo pueden eliminar clientes de su comercio       | PERMISSIVE | {public} | DELETE | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     | null                                                                                                                                                                                              |
| public     | clientes        | Los usuarios solo pueden insertar clientes en su comercio       | PERMISSIVE | {public} | INSERT | null                                                                                                                                                                                              | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     |
| public     | clientes        | Los usuarios solo pueden ver clientes de su comercio            | PERMISSIVE | {public} | SELECT | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     | null                                                                                                                                                                                              |
| public     | compras         | Los usuarios solo pueden actualizar compras de su comercio      | PERMISSIVE | {public} | UPDATE | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     | null                                                                                                                                                                                              |
| public     | compras         | Los usuarios solo pueden eliminar compras de su comercio        | PERMISSIVE | {public} | DELETE | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     | null                                                                                                                                                                                              |
| public     | compras         | Los usuarios solo pueden insertar compras en su comercio        | PERMISSIVE | {public} | INSERT | null                                                                                                                                                                                              | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     |
| public     | compras         | Los usuarios solo pueden ver compras de su comercio             | PERMISSIVE | {public} | SELECT | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     | null                                                                                                                                                                                              |
| public     | configuraciones | Usuarios editan config de su comercio                           | PERMISSIVE | {public} | ALL    | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     | null                                                                                                                                                                                              |
| public     | configuraciones | Usuarios ven config de su comercio                              | PERMISSIVE | {public} | SELECT | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     | null                                                                                                                                                                                              |
| public     | detalle_compras | Los usuarios solo pueden actualizar detalle_compras de su comer | PERMISSIVE | {public} | UPDATE | (compra_id IN ( SELECT compras.id
   FROM compras
  WHERE (compras.comercio_id IN ( SELECT usuarios.comercio_id
           FROM usuarios
          WHERE (usuarios.auth_user_id = auth.uid()))))) | null                                                                                                                                                                                              |
| public     | detalle_compras | Los usuarios solo pueden eliminar detalle_compras de su comerci | PERMISSIVE | {public} | DELETE | (compra_id IN ( SELECT compras.id
   FROM compras
  WHERE (compras.comercio_id IN ( SELECT usuarios.comercio_id
           FROM usuarios
          WHERE (usuarios.auth_user_id = auth.uid()))))) | null                                                                                                                                                                                              |
| public     | detalle_compras | Los usuarios solo pueden insertar detalle_compras en su comerci | PERMISSIVE | {public} | INSERT | null                                                                                                                                                                                              | (compra_id IN ( SELECT compras.id
   FROM compras
  WHERE (compras.comercio_id IN ( SELECT usuarios.comercio_id
           FROM usuarios
          WHERE (usuarios.auth_user_id = auth.uid()))))) |
| public     | detalle_compras | Los usuarios solo pueden ver detalle_compras de su comercio     | PERMISSIVE | {public} | SELECT | (compra_id IN ( SELECT compras.id
   FROM compras
  WHERE (compras.comercio_id IN ( SELECT usuarios.comercio_id
           FROM usuarios
          WHERE (usuarios.auth_user_id = auth.uid()))))) | null                                                                                                                                                                                              |
| public     | detalle_ventas  | Los usuarios solo pueden actualizar detalle_ventas de su comerc | PERMISSIVE | {public} | UPDATE | (venta_id IN ( SELECT ventas.id
   FROM ventas
  WHERE (ventas.comercio_id IN ( SELECT usuarios.comercio_id
           FROM usuarios
          WHERE (usuarios.auth_user_id = auth.uid())))))     | null                                                                                                                                                                                              |
| public     | detalle_ventas  | Los usuarios solo pueden eliminar detalle_ventas de su comercio | PERMISSIVE | {public} | DELETE | (venta_id IN ( SELECT ventas.id
   FROM ventas
  WHERE (ventas.comercio_id IN ( SELECT usuarios.comercio_id
           FROM usuarios
          WHERE (usuarios.auth_user_id = auth.uid())))))     | null                                                                                                                                                                                              |
| public     | detalle_ventas  | Los usuarios solo pueden insertar detalle_ventas en su comercio | PERMISSIVE | {public} | INSERT | null                                                                                                                                                                                              | (venta_id IN ( SELECT ventas.id
   FROM ventas
  WHERE (ventas.comercio_id IN ( SELECT usuarios.comercio_id
           FROM usuarios
          WHERE (usuarios.auth_user_id = auth.uid())))))     |
| public     | detalle_ventas  | Los usuarios solo pueden ver detalle_ventas de su comercio      | PERMISSIVE | {public} | SELECT | (venta_id IN ( SELECT ventas.id
   FROM ventas
  WHERE (ventas.comercio_id IN ( SELECT usuarios.comercio_id
           FROM usuarios
          WHERE (usuarios.auth_user_id = auth.uid())))))     | null                                                                                                                                                                                              |
| public     | pagos_compras   | Los usuarios solo pueden actualizar pagos_compras de su comerci | PERMISSIVE | {public} | UPDATE | (compra_id IN ( SELECT compras.id
   FROM compras
  WHERE (compras.comercio_id IN ( SELECT usuarios.comercio_id
           FROM usuarios
          WHERE (usuarios.auth_user_id = auth.uid()))))) | null                                                                                                                                                                                              |
| public     | pagos_compras   | Los usuarios solo pueden eliminar pagos_compras de su comercio  | PERMISSIVE | {public} | DELETE | (compra_id IN ( SELECT compras.id
   FROM compras
  WHERE (compras.comercio_id IN ( SELECT usuarios.comercio_id
           FROM usuarios
          WHERE (usuarios.auth_user_id = auth.uid()))))) | null                                                                                                                                                                                              |
| public     | pagos_compras   | Los usuarios solo pueden insertar pagos_compras en su comercio  | PERMISSIVE | {public} | INSERT | null                                                                                                                                                                                              | (compra_id IN ( SELECT compras.id
   FROM compras
  WHERE (compras.comercio_id IN ( SELECT usuarios.comercio_id
           FROM usuarios
          WHERE (usuarios.auth_user_id = auth.uid()))))) |
| public     | pagos_compras   | Los usuarios solo pueden ver pagos_compras de su comercio       | PERMISSIVE | {public} | SELECT | (compra_id IN ( SELECT compras.id
   FROM compras
  WHERE (compras.comercio_id IN ( SELECT usuarios.comercio_id
           FROM usuarios
          WHERE (usuarios.auth_user_id = auth.uid()))))) | null                                                                                                                                                                                              |
| public     | pagos_ventas    | Los usuarios solo pueden actualizar pagos_ventas de su comercio | PERMISSIVE | {public} | UPDATE | (venta_id IN ( SELECT ventas.id
   FROM ventas
  WHERE (ventas.comercio_id IN ( SELECT usuarios.comercio_id
           FROM usuarios
          WHERE (usuarios.auth_user_id = auth.uid())))))     | null                                                                                                                                                                                              |
| public     | pagos_ventas    | Los usuarios solo pueden eliminar pagos_ventas de su comercio   | PERMISSIVE | {public} | DELETE | (venta_id IN ( SELECT ventas.id
   FROM ventas
  WHERE (ventas.comercio_id IN ( SELECT usuarios.comercio_id
           FROM usuarios
          WHERE (usuarios.auth_user_id = auth.uid())))))     | null                                                                                                                                                                                              |
| public     | pagos_ventas    | Los usuarios solo pueden insertar pagos_ventas en su comercio   | PERMISSIVE | {public} | INSERT | null                                                                                                                                                                                              | (venta_id IN ( SELECT ventas.id
   FROM ventas
  WHERE (ventas.comercio_id IN ( SELECT usuarios.comercio_id
           FROM usuarios
          WHERE (usuarios.auth_user_id = auth.uid())))))     |
| public     | pagos_ventas    | Los usuarios solo pueden ver pagos_ventas de su comercio        | PERMISSIVE | {public} | SELECT | (venta_id IN ( SELECT ventas.id
   FROM ventas
  WHERE (ventas.comercio_id IN ( SELECT usuarios.comercio_id
           FROM usuarios
          WHERE (usuarios.auth_user_id = auth.uid())))))     | null                                                                                                                                                                                              |
| public     | productos       | Los usuarios solo pueden actualizar productos de su comercio    | PERMISSIVE | {public} | UPDATE | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     | null                                                                                                                                                                                              |
| public     | productos       | Los usuarios solo pueden eliminar productos de su comercio      | PERMISSIVE | {public} | DELETE | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     | null                                                                                                                                                                                              |
| public     | productos       | Los usuarios solo pueden insertar productos en su comercio      | PERMISSIVE | {public} | INSERT | null                                                                                                                                                                                              | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     |
| public     | productos       | Los usuarios solo pueden ver productos de su comercio           | PERMISSIVE | {public} | SELECT | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     | null                                                                                                                                                                                              |
| public     | proveedores     | Los usuarios solo pueden actualizar proveedores de su comercio  | PERMISSIVE | {public} | UPDATE | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     | null                                                                                                                                                                                              |
| public     | proveedores     | Los usuarios solo pueden eliminar proveedores de su comercio    | PERMISSIVE | {public} | DELETE | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     | null                                                                                                                                                                                              |
| public     | proveedores     | Los usuarios solo pueden insertar proveedores en su comercio    | PERMISSIVE | {public} | INSERT | null                                                                                                                                                                                              | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     |
| public     | proveedores     | Los usuarios solo pueden ver proveedores de su comercio         | PERMISSIVE | {public} | SELECT | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     | null                                                                                                                                                                                              |
| public     | ventas          | Los usuarios solo pueden actualizar ventas de su comercio       | PERMISSIVE | {public} | UPDATE | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     | null                                                                                                                                                                                              |
| public     | ventas          | Los usuarios solo pueden eliminar ventas de su comercio         | PERMISSIVE | {public} | DELETE | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     | null                                                                                                                                                                                              |
| public     | ventas          | Los usuarios solo pueden insertar ventas en su comercio         | PERMISSIVE | {public} | INSERT | null                                                                                                                                                                                              | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     |
| public     | ventas          | Los usuarios solo pueden ver ventas de su comercio              | PERMISSIVE | {public} | SELECT | (comercio_id IN ( SELECT usuarios.comercio_id
   FROM usuarios
  WHERE (usuarios.auth_user_id = auth.uid())))                                                                                     | null                                                                                                                                                                                              |

-- 10. FUNCTIONS (USER DEFINED)

| routine_schema | routine_name                          | routine_type | return_type              |
| -------------- | ------------------------------------- | ------------ | ------------------------ |
| auth           | email                                 | FUNCTION     | text                     |
| auth           | jwt                                   | FUNCTION     | jsonb                    |
| auth           | role                                  | FUNCTION     | text                     |
| auth           | uid                                   | FUNCTION     | uuid                     |
| extensions     | armor                                 | FUNCTION     | text                     |
| extensions     | armor                                 | FUNCTION     | text                     |
| extensions     | crypt                                 | FUNCTION     | text                     |
| extensions     | dearmor                               | FUNCTION     | bytea                    |
| extensions     | decrypt                               | FUNCTION     | bytea                    |
| extensions     | decrypt_iv                            | FUNCTION     | bytea                    |
| extensions     | digest                                | FUNCTION     | bytea                    |
| extensions     | digest                                | FUNCTION     | bytea                    |
| extensions     | encrypt                               | FUNCTION     | bytea                    |
| extensions     | encrypt_iv                            | FUNCTION     | bytea                    |
| extensions     | gen_random_bytes                      | FUNCTION     | bytea                    |
| extensions     | gen_random_uuid                       | FUNCTION     | uuid                     |
| extensions     | gen_salt                              | FUNCTION     | text                     |
| extensions     | gen_salt                              | FUNCTION     | text                     |
| extensions     | grant_pg_cron_access                  | FUNCTION     | event_trigger            |
| extensions     | grant_pg_graphql_access               | FUNCTION     | event_trigger            |
| extensions     | grant_pg_net_access                   | FUNCTION     | event_trigger            |
| extensions     | hmac                                  | FUNCTION     | bytea                    |
| extensions     | hmac                                  | FUNCTION     | bytea                    |
| extensions     | pg_stat_statements                    | FUNCTION     | record                   |
| extensions     | pg_stat_statements_info               | FUNCTION     | record                   |
| extensions     | pg_stat_statements_reset              | FUNCTION     | timestamp with time zone |
| extensions     | pgp_armor_headers                     | FUNCTION     | record                   |
| extensions     | pgp_key_id                            | FUNCTION     | text                     |
| extensions     | pgp_pub_decrypt                       | FUNCTION     | text                     |
| extensions     | pgp_pub_decrypt                       | FUNCTION     | text                     |
| extensions     | pgp_pub_decrypt                       | FUNCTION     | text                     |
| extensions     | pgp_pub_decrypt_bytea                 | FUNCTION     | bytea                    |
| extensions     | pgp_pub_decrypt_bytea                 | FUNCTION     | bytea                    |
| extensions     | pgp_pub_decrypt_bytea                 | FUNCTION     | bytea                    |
| extensions     | pgp_pub_encrypt                       | FUNCTION     | bytea                    |
| extensions     | pgp_pub_encrypt                       | FUNCTION     | bytea                    |
| extensions     | pgp_pub_encrypt_bytea                 | FUNCTION     | bytea                    |
| extensions     | pgp_pub_encrypt_bytea                 | FUNCTION     | bytea                    |
| extensions     | pgp_sym_decrypt                       | FUNCTION     | text                     |
| extensions     | pgp_sym_decrypt                       | FUNCTION     | text                     |
| extensions     | pgp_sym_decrypt_bytea                 | FUNCTION     | bytea                    |
| extensions     | pgp_sym_decrypt_bytea                 | FUNCTION     | bytea                    |
| extensions     | pgp_sym_encrypt                       | FUNCTION     | bytea                    |
| extensions     | pgp_sym_encrypt                       | FUNCTION     | bytea                    |
| extensions     | pgp_sym_encrypt_bytea                 | FUNCTION     | bytea                    |
| extensions     | pgp_sym_encrypt_bytea                 | FUNCTION     | bytea                    |
| extensions     | pgrst_ddl_watch                       | FUNCTION     | event_trigger            |
| extensions     | pgrst_drop_watch                      | FUNCTION     | event_trigger            |
| extensions     | set_graphql_placeholder               | FUNCTION     | event_trigger            |
| extensions     | uuid_generate_v1                      | FUNCTION     | uuid                     |
| extensions     | uuid_generate_v1mc                    | FUNCTION     | uuid                     |
| extensions     | uuid_generate_v3                      | FUNCTION     | uuid                     |
| extensions     | uuid_generate_v4                      | FUNCTION     | uuid                     |
| extensions     | uuid_generate_v5                      | FUNCTION     | uuid                     |
| extensions     | uuid_nil                              | FUNCTION     | uuid                     |
| extensions     | uuid_ns_dns                           | FUNCTION     | uuid                     |
| extensions     | uuid_ns_oid                           | FUNCTION     | uuid                     |
| extensions     | uuid_ns_url                           | FUNCTION     | uuid                     |
| extensions     | uuid_ns_x500                          | FUNCTION     | uuid                     |
| graphql        | _internal_resolve                     | FUNCTION     | jsonb                    |
| graphql        | comment_directive                     | FUNCTION     | jsonb                    |
| graphql        | exception                             | FUNCTION     | text                     |
| graphql        | get_schema_version                    | FUNCTION     | integer                  |
| graphql        | increment_schema_version              | FUNCTION     | event_trigger            |
| graphql        | resolve                               | FUNCTION     | jsonb                    |
| graphql_public | graphql                               | FUNCTION     | jsonb                    |
| public         | actualizar_stock                      | FUNCTION     | trigger                  |
| public         | actualizar_updated_at                 | FUNCTION     | trigger                  |
| public         | crear_configuraciones_defecto         | FUNCTION     | void                     |
| public         | generar_numero_ticket                 | FUNCTION     | trigger                  |
| public         | set_ventas_updated_at                 | FUNCTION     | trigger                  |
| realtime       | apply_rls                             | FUNCTION     | USER-DEFINED             |
| realtime       | broadcast_changes                     | FUNCTION     | void                     |
| realtime       | build_prepared_statement_sql          | FUNCTION     | text                     |
| realtime       | cast                                  | FUNCTION     | jsonb                    |
| realtime       | check_equality_op                     | FUNCTION     | boolean                  |
| realtime       | is_visible_through_filters            | FUNCTION     | boolean                  |
| realtime       | list_changes                          | FUNCTION     | USER-DEFINED             |
| realtime       | quote_wal2json                        | FUNCTION     | text                     |
| realtime       | send                                  | FUNCTION     | void                     |
| realtime       | subscription_check_filters            | FUNCTION     | trigger                  |
| realtime       | to_regrole                            | FUNCTION     | regrole                  |
| realtime       | topic                                 | FUNCTION     | text                     |
| storage        | add_prefixes                          | FUNCTION     | void                     |
| storage        | can_insert_object                     | FUNCTION     | void                     |
| storage        | delete_leaf_prefixes                  | FUNCTION     | void                     |
| storage        | delete_prefix                         | FUNCTION     | boolean                  |
| storage        | delete_prefix_hierarchy_trigger       | FUNCTION     | trigger                  |
| storage        | enforce_bucket_name_length            | FUNCTION     | trigger                  |
| storage        | extension                             | FUNCTION     | text                     |
| storage        | filename                              | FUNCTION     | text                     |
| storage        | foldername                            | FUNCTION     | ARRAY                    |
| storage        | get_level                             | FUNCTION     | integer                  |
| storage        | get_prefix                            | FUNCTION     | text                     |
| storage        | get_prefixes                          | FUNCTION     | ARRAY                    |
| storage        | get_size_by_bucket                    | FUNCTION     | record                   |
| storage        | list_multipart_uploads_with_delimiter | FUNCTION     | record                   |
| storage        | list_objects_with_delimiter           | FUNCTION     | record                   |
| storage        | lock_top_prefixes                     | FUNCTION     | void                     |
| storage        | objects_delete_cleanup                | FUNCTION     | trigger                  |