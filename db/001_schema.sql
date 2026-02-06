/*
Datos Admin Base de datos
$C4t0lic4!
Libreria: Npgsql
EF: Npgsql.EntityFrameworkCore.PostgreSQL
*/

-- 1. SEDES
CREATE TABLE sedes (
    id SERIAL PRIMARY KEY,
    codigo VARCHAR(10) NOT NULL UNIQUE,
    provincia VARCHAR(255) NOT NULL,
    localidad VARCHAR(255) NOT NULL,
    codigo_postal VARCHAR(255) NOT NULL,
    direccion VARCHAR(255) NOT NULL,
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 2. UNIDADES
CREATE TABLE unidades (
    id SERIAL PRIMARY KEY,
    codigo VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(255) NOT NULL,
    nombre_corto VARCHAR(100) NOT NULL,
    siglas VARCHAR(20) NOT NULL UNIQUE,
    color_principal VARCHAR(7) DEFAULT '#064a31',
    color_secundario VARCHAR(7) DEFAULT '#7d1b1c',
    direccion TEXT,
    telefono VARCHAR(50),
    email VARCHAR(255),
    sede_id INT NOT NULL,
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (sede_id) REFERENCES sedes(id) ON DELETE RESTRICT
);

-- 3. MODALIDADES
CREATE TABLE modalidades (
    id SERIAL PRIMARY KEY,
    codigo VARCHAR(10) NOT NULL UNIQUE,
    nombre VARCHAR(50) NOT NULL UNIQUE,
    descripcion TEXT,
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 4. PERIODOS_LECTIVOS
CREATE TABLE periodos_lectivos (
    id SERIAL PRIMARY KEY,
    codigo VARCHAR(10) NOT NULL UNIQUE,
    nombre VARCHAR(100) NOT NULL,
    fecha_inicio DATE NOT NULL,
    fecha_fin DATE NOT NULL,
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT chk_periodo_fechas CHECK (fecha_inicio <= fecha_fin)
);

-- 5. TIPOS_PROPUESTA
CREATE TABLE tipos_propuesta (
    id SERIAL PRIMARY KEY,
    codigo VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(100) NOT NULL UNIQUE,
    descripcion TEXT,
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 6. TIPOS_DOCUMENTO
CREATE TABLE tipos_documento (
    id SERIAL PRIMARY KEY,
    codigo VARCHAR(10) NOT NULL UNIQUE,
    nombre VARCHAR(50) NOT NULL,
    descripcion TEXT,
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 7. TIPOS_ESTADO_PROPUESTA
CREATE TABLE tipos_estado_propuesta (
    id SERIAL PRIMARY KEY,
    codigo VARCHAR(10) NOT NULL UNIQUE,
    nombre VARCHAR(50) NOT NULL,
    descripcion TEXT,
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 8. TIPOS_ESTADO_INSCRIPCION
CREATE TABLE tipos_estado_inscripcion (
    id SERIAL PRIMARY KEY,
    codigo VARCHAR(10) NOT NULL UNIQUE,
    nombre VARCHAR(50) NOT NULL,
    descripcion TEXT,
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 9. TIPOS_ESTADO_CERTIFICADO
CREATE TABLE tipos_estado_certificado (
    id SERIAL PRIMARY KEY,
    codigo VARCHAR(10) NOT NULL UNIQUE,
    nombre VARCHAR(50) NOT NULL,
    descripcion TEXT,
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 10. AUTORIDADES
CREATE TABLE autoridades (
    id SERIAL PRIMARY KEY,
    unidad_id INT NOT NULL,
    periodo_lectivo_id INT NOT NULL,
    cargo VARCHAR(255) NOT NULL,
    nombre VARCHAR(255) NOT NULL,
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (unidad_id) REFERENCES unidades(id) ON DELETE RESTRICT,
    FOREIGN KEY (periodo_lectivo_id) REFERENCES periodos_lectivos(id) ON DELETE RESTRICT
);

-- 11. PROPUESTAS
CREATE TABLE propuestas (
    id SERIAL PRIMARY KEY,
    unidad_id INT NOT NULL,
    modalidad_id INT NOT NULL,
    tipo_propuesta_id INT NOT NULL,
    periodo_lectivo_id INT NOT NULL,
    tipo_estado_propuesta_id INT NOT NULL,
    titulo VARCHAR(255) NOT NULL,
    anio INT NOT NULL,
    edicion INT DEFAULT 1,
    fecha_inicio DATE NOT NULL,
    fecha_fin DATE NOT NULL,
    maximo_alumnos INT NOT NULL,
    cupos_disponibles INT NOT NULL,
    cantidad_horas INT,
    importe_base DECIMAL(10,2),
    cuotas INT DEFAULT 1,
    concepto_pago VARCHAR(50),
    email_encargado VARCHAR(255) NOT NULL,
    plan_estudio_pdf VARCHAR(255),
    lugar_realizacion VARCHAR(255),
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT chk_cupos_disponibles CHECK (cupos_disponibles >= 0);
    CONSTRAINT chk_propuesta_fechas CHECK (fecha_inicio <= fecha_fin),
    CONSTRAINT chk_maximo_alumnos CHECK (maximo_alumnos > 0),
    FOREIGN KEY (unidad_id) REFERENCES unidades(id) ON DELETE RESTRICT,
    FOREIGN KEY (modalidad_id) REFERENCES modalidades(id) ON DELETE RESTRICT,
    FOREIGN KEY (tipo_propuesta_id) REFERENCES tipos_propuesta(id) ON DELETE RESTRICT,
    FOREIGN KEY (periodo_lectivo_id) REFERENCES periodos_lectivos(id) ON DELETE RESTRICT,
    FOREIGN KEY (tipo_estado_propuesta_id) REFERENCES tipos_estado_propuesta(id) ON DELETE RESTRICT
);

-- 12. DOCENTES
CREATE TABLE docentes (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL,
    apellido VARCHAR(255) NOT NULL,
    dni VARCHAR(20) UNIQUE NOT NULL,
    profesion VARCHAR(255) NOT NULL,
    especialidad VARCHAR(100),
    biografia TEXT,
    telefono VARCHAR(30) NOT NULL,
    email VARCHAR(255) NOT NULL UNIQUE,
    linkedin VARCHAR(255),
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 13. PROPUESTA_DOCENTE
CREATE TABLE propuesta_docente (
    id SERIAL PRIMARY KEY,
    propuesta_id INT NOT NULL,
    docente_id INT NOT NULL,
    rol VARCHAR(255) NOT NULL,
    orden_web INT,
    FOREIGN KEY (propuesta_id) REFERENCES propuestas(id) ON DELETE CASCADE,
    FOREIGN KEY (docente_id) REFERENCES docentes(id) ON DELETE RESTRICT,
    UNIQUE (propuesta_id, docente_id)
);

-- 14. AUSPICIANTES
CREATE TABLE auspiciantes (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(255) NOT NULL,
    logo VARCHAR(500),
    sitio_web VARCHAR(255),
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 15. PROPUESTA_AUSPICIANTES
CREATE TABLE propuesta_auspiciantes (
    id SERIAL PRIMARY KEY,
    propuesta_id INT NOT NULL,
    auspiciante_id INT NOT NULL,
    orden INT,
    FOREIGN KEY (propuesta_id) REFERENCES propuestas(id) ON DELETE CASCADE,
    FOREIGN KEY (auspiciante_id) REFERENCES auspiciantes(id) ON DELETE RESTRICT,
    UNIQUE (propuesta_id, auspiciante_id)
);

-- 16. PROPUESTA_PLAN_MODULOS
CREATE TABLE propuesta_plan_modulos (
    id SERIAL PRIMARY KEY,
    propuesta_id INT NOT NULL,
    titulo VARCHAR(255) NOT NULL,
    descripcion TEXT,
    orden INT NOT NULL,
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (propuesta_id)
        REFERENCES propuestas(id) ON DELETE CASCADE
);

-- 17. PROPUESTA_PLAN_ITEMS
CREATE TABLE propuesta_plan_items (
    id SERIAL PRIMARY KEY,
    modulo_id INT NOT NULL,
    titulo VARCHAR(255) NOT NULL,
    detalle TEXT,
    orden INT NOT NULL,
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (modulo_id)
        REFERENCES propuesta_plan_modulos(id) ON DELETE CASCADE
);


-- 18. PROPUESTA_PAGOS_INFO
CREATE TABLE propuesta_pagos_info (
    id SERIAL PRIMARY KEY,
    propuesta_id INT NOT NULL,
    concepto VARCHAR(100) NOT NULL, -- Ej: Contado, 3 cuotas, Promo
    importe DECIMAL(10,2),
    cuotas INT,
    observaciones TEXT,
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (propuesta_id)
        REFERENCES propuestas(id) ON DELETE CASCADE,
    CONSTRAINT chk_importe CHECK (importe >= 0)
);

-- 19. PROPUESTA_CONTACTOS
CREATE TABLE propuesta_contactos (
    id SERIAL PRIMARY KEY,
    propuesta_id INT NOT NULL,
    nombre VARCHAR(255),
    email VARCHAR(255),
    telefono VARCHAR(50),
    horario_atencion VARCHAR(255),
    tipo VARCHAR(50), -- administrativo, académico, pagos, general
    orden INT DEFAULT 0,
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (propuesta_id)
        REFERENCES propuestas(id) ON DELETE CASCADE
);

-- 20. PORTALES
CREATE TABLE portales (
    id SERIAL PRIMARY KEY,
    propuesta_id INT NOT NULL UNIQUE,
    titulo_web VARCHAR(255),
    slug VARCHAR(100) NOT NULL UNIQUE,
    banner_img VARCHAR(500),
    acerca_de TEXT,
    perfil_estudiante TEXT,
    requisitos TEXT,
    destinatarios TEXT,
    fundamentacion TEXT,
    etiquetas TEXT,
    permite_inscripciones BOOLEAN DEFAULT TRUE, -- ♦️ACA
    meta_og_title VARCHAR(255),
    meta_og_image VARCHAR(500),
    meta_description VARCHAR(500),
    meta_keywords TEXT,
    visitas INT DEFAULT 0,
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (propuesta_id)
        REFERENCES propuestas(id) ON DELETE CASCADE
);


-- 21. INSCRIPCIONES
CREATE TABLE inscripciones (
    id SERIAL PRIMARY KEY,
    propuesta_id INT NOT NULL,
    modalidad_id INT,
    tipo_documento_id INT,
    tipo_estado_inscripcion_id INT NOT NULL,
    documento VARCHAR(20) NOT NULL,
    apellido VARCHAR(150),
    nombre VARCHAR(100),
    apellido_nombre VARCHAR(250), -- GENERATED ALWAYS AS (apellido || ', ' || nombre) STORED,
    fecha_nacimiento DATE,
    sexo VARCHAR(2),
    edad INT,
    email VARCHAR(100),
    telefono VARCHAR(30),
    domicilio VARCHAR(200),
    codigo_postal VARCHAR(15),
    ciudad VARCHAR(150),
    provincia VARCHAR(150),
    pais VARCHAR(150),
    ciudad_nacimiento VARCHAR(150),
    colegio VARCHAR(100),
    profesion VARCHAR(100),
    lugar_trabajo VARCHAR(150),
    numero_socio VARCHAR(25),
    es_socio INT,
    fecha_inscripcion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    baja BOOLEAN DEFAULT FALSE,
    fecha_baja TIMESTAMP,
    pago_mercadopago BOOLEAN DEFAULT FALSE,
    codigo_concepto INT,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT chk_edad CHECK (edad >= 0),
    FOREIGN KEY (propuesta_id) REFERENCES propuestas(id) ON DELETE RESTRICT,
    FOREIGN KEY (modalidad_id) REFERENCES modalidades(id) ON DELETE RESTRICT,
    FOREIGN KEY (tipo_documento_id) REFERENCES tipos_documento(id) ON DELETE RESTRICT,
    FOREIGN KEY (tipo_estado_inscripcion_id) REFERENCES tipos_estado_inscripcion(id) ON DELETE RESTRICT
);

-- 22. CERTIFICACIONES
CREATE TABLE certificaciones (
    id SERIAL PRIMARY KEY,
    inscripcion_id INT NOT NULL,
    tipo_estado_certificado_id INT NOT NULL,
    uuid UUID UNIQUE NOT NULL DEFAULT gen_random_uuid(),
    token VARCHAR(100) UNIQUE NOT NULL,
    fecha_finalizacion DATE,
    fecha_emision DATE DEFAULT CURRENT_DATE,
    metadata JSONB,
    version INT DEFAULT 1,
    es_version_actual BOOLEAN DEFAULT TRUE,
    motivo_cambio VARCHAR(100),
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT chk_version CHECK (version > 0),
    FOREIGN KEY (inscripcion_id) REFERENCES inscripciones(id) ON DELETE RESTRICT,
    FOREIGN KEY (tipo_estado_certificado_id) REFERENCES tipos_estado_certificado(id) ON DELETE RESTRICT
);

-- 23. CERTIFICACION_AUTORIDAD
CREATE TABLE certificacion_autoridad (
    id SERIAL PRIMARY KEY,
    certificacion_id INT NOT NULL,
    autoridad_id INT NOT NULL,
    orden INT DEFAULT 0,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (certificacion_id) REFERENCES certificaciones(id) ON DELETE CASCADE,
    FOREIGN KEY (autoridad_id) REFERENCES autoridades(id) ON DELETE RESTRICT
);

-- 24. MODULOS
CREATE TABLE modulos (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL UNIQUE,
    descripcion TEXT,
    estado BOOLEAN DEFAULT TRUE,
    orden INT DEFAULT 0,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- 25. IDENTITY USERS
CREATE TABLE identity_users (
    id SERIAL PRIMARY KEY,
    user_name VARCHAR(256),
    normalized_user_name VARCHAR(256),
    email VARCHAR(256),
    normalized_email VARCHAR(256),
    email_confirmed BOOLEAN DEFAULT FALSE,
    password_hash TEXT,
    security_stamp TEXT,
    concurrency_stamp TEXT,
    phone_number TEXT,
    phone_number_confirmed BOOLEAN DEFAULT FALSE,
    two_factor_enabled BOOLEAN DEFAULT FALSE,
    lockout_end TIMESTAMP WITH TIME ZONE,
    lockout_enabled BOOLEAN DEFAULT FALSE,
    access_failed_count INT DEFAULT 0
);
CREATE INDEX idx_identity_users_normalized_user_name
ON identity_users(normalized_user_name);

CREATE INDEX idx_identity_users_normalized_email
ON identity_users(normalized_email);


-- 26. USUARIOS
CREATE TABLE usuarios (
    id SERIAL PRIMARY KEY,
    dni VARCHAR(20) UNIQUE NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    email VARCHAR(150) UNIQUE NOT NULL,
    identity_user_id INT UNIQUE NOT NULL, -- RELACIÓN OBLIGATORIA
    telefono VARCHAR(20),
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    actualizado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (identity_user_id) REFERENCES identity_users(id) ON DELETE CASCADE
);


-- 27. USUARIO PERMISO UNIDAD
CREATE TABLE usuario_permisos_unidad (
    id SERIAL PRIMARY KEY,
    usuario_id INT NOT NULL,
    unidad_id INT NOT NULL,
    modulo_id INT NOT NULL,
    permisos JSONB,
    estado BOOLEAN DEFAULT TRUE,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE (usuario_id, unidad_id, modulo_id),
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id) ON DELETE CASCADE,
    FOREIGN KEY (unidad_id) REFERENCES unidades(id) ON DELETE CASCADE,
    FOREIGN KEY (modulo_id) REFERENCES modulos(id) ON DELETE CASCADE
);

/*CREATE TABLE usuario_unidades (
    id SERIAL PRIMARY KEY,
    usuario_id INT NOT NULL,
    unidad_id INT NOT NULL,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE(usuario_id, unidad_id),
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id) ON DELETE CASCADE,
    FOREIGN KEY (unidad_id) REFERENCES unidades(id) ON DELETE CASCADE
);*/


-- 28. IDENTITY ROLES
CREATE TABLE identity_roles (
    id INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    name VARCHAR(256),
    normalized_name VARCHAR(256),
    concurrency_stamp TEXT
);


-- 29. IDENTITY USER ROLES
CREATE TABLE identity_user_roles (
    user_id INT NOT NULL,
    role_id INT NOT NULL,
    PRIMARY KEY (user_id, role_id),
    FOREIGN KEY (user_id) REFERENCES identity_users(id) ON DELETE CASCADE,
    FOREIGN KEY (role_id) REFERENCES identity_roles(id) ON DELETE CASCADE
);


-- 30. IDENTITY ROLES CLAIMS
CREATE TABLE identity_role_claims (
    id SERIAL PRIMARY KEY,
    role_id INT NOT NULL,
    claim_type VARCHAR(256),
    claim_value VARCHAR(256),
    FOREIGN KEY (role_id) REFERENCES identity_roles(id) ON DELETE CASCADE
);


-- 31. IDENTITY USER CLAIMS
CREATE TABLE identity_user_claims (
    id SERIAL PRIMARY KEY,
    user_id INT NOT NULL,
    claim_type VARCHAR(256),
    claim_value VARCHAR(256),
    FOREIGN KEY (user_id) REFERENCES identity_users(id) ON DELETE CASCADE
);

-- 32. IDENTITY USER LOGINS
CREATE TABLE identity_user_logins (
    login_provider VARCHAR(255) NOT NULL,
    provider_key VARCHAR(255) NOT NULL,
    provider_display_name TEXT,
    user_id INT NOT NULL,
    PRIMARY KEY (login_provider, provider_key),
    FOREIGN KEY (user_id) REFERENCES identity_users(id) ON DELETE CASCADE
);

-- 33. IDENTITY USER TOKENS
CREATE TABLE identity_user_tokens (
    user_id INT NOT NULL,
    login_provider VARCHAR(255) NOT NULL,
    name VARCHAR(255) NOT NULL,
    value TEXT,
    PRIMARY KEY (user_id, login_provider, name),
    FOREIGN KEY (user_id) REFERENCES identity_users(id) ON DELETE CASCADE
);


-- 34. HISTORIAL_ESTADO_PROPUESTAS
CREATE TABLE historial_estado_propuestas (
    id SERIAL PRIMARY KEY,
    propuesta_id INT NOT NULL,
    tipo_estado_propuesta_id INT NOT NULL,
    usuario_id INT,
    observaciones TEXT,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (propuesta_id) REFERENCES propuestas(id) ON DELETE CASCADE,
    FOREIGN KEY (tipo_estado_propuesta_id) REFERENCES tipos_estado_propuesta(id) ON DELETE RESTRICT,
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id) ON DELETE SET NULL
);

-- 35. HISTORIAL_ESTADO_INSCRIPCIONES
CREATE TABLE historial_estado_inscripciones (
    inscripcion_id INT NOT NULL,
    tipo_estado_inscripcion_id INT NOT NULL,
    usuario_id INT,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (inscripcion_id) REFERENCES inscripciones(id) ON DELETE CASCADE,
    FOREIGN KEY (tipo_estado_inscripcion_id) REFERENCES tipos_estado_inscripcion(id) ON DELETE RESTRICT,
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id) ON DELETE SET NULL
);

-- 36. HISTORIAL_ESTADO_CERTIFICACIONES
CREATE TABLE historial_estado_certificaciones (
    certificacion_id INT NOT NULL,
    tipo_estado_certificado_id INT NOT NULL,
    usuario_id INT,
    creado_en TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (certificacion_id) REFERENCES certificaciones(id) ON DELETE CASCADE,
    FOREIGN KEY (tipo_estado_certificado_id) REFERENCES tipos_estado_certificado(id) ON DELETE RESTRICT,
    FOREIGN KEY (usuario_id) REFERENCES usuarios(id) ON DELETE SET NULL
);