-- CERTIFICADOS PARA DIPLOMATURA EN ORTODONCIA (Propuesta 1)
-- Inscripciones IDs: 1, 2, 3
-- Estado: Aprobado (APR) - ID 4 (asumiendo que los IDs empiezan en 1)

-- Maria del Valle Mejibar Rivas (inscripcion_id = 1)
INSERT INTO certificaciones (
    inscripcion_id, 
    tipo_estado_certificado_id, 
    token, 
    fecha_finalizacion, 
    fecha_emision,
    metadata,
    version,
    es_version_actual,
    motivo_cambio
) VALUES (
    1, -- Maria del Valle Mejibar Rivas
    4, -- Estado: Aprobado
    'cert_' || substr(md5(random()::text), 1, 20), -- Token único
    '2024-06-15', -- Fecha de finalización del curso
    '2024-06-20', -- Fecha de emisión del certificado
    '{"calificacion": "9.5", "horas_cursadas": 120, "modalidad": "Presencial", "promedio": "Excelente"}'::jsonb,
    1,
    TRUE,
    'Emisión inicial - Curso completado exitosamente'
);

-- Jesica Paola Romarion Alvarado (inscripcion_id = 2)
INSERT INTO certificaciones (
    inscripcion_id, 
    tipo_estado_certificado_id, 
    token, 
    fecha_finalizacion, 
    fecha_emision,
    metadata,
    version,
    es_version_actual,
    motivo_cambio
) VALUES (
    2, -- Jesica Paola Romarion Alvarado
    4, -- Estado: Aprobado
    'cert_' || substr(md5(random()::text), 1, 20),
    '2024-06-15',
    '2024-06-20',
    '{"calificacion": "8.7", "horas_cursadas": 120, "modalidad": "Presencial", "promedio": "Muy Bueno", "observaciones": "Asistencia perfecta"}'::jsonb,
    1,
    TRUE,
    'Emisión inicial'
);

-- Carolina Soledad Ibazeta (inscripcion_id = 3)
INSERT INTO certificaciones (
    inscripcion_id, 
    tipo_estado_certificado_id, 
    token, 
    fecha_finalizacion, 
    fecha_emision,
    metadata,
    version,
    es_version_actual,
    motivo_cambio
) VALUES (
    3, -- Carolina Soledad Ibazeta
    4, -- Estado: Aprobado
    'cert_' || substr(md5(random()::text), 1, 20),
    '2024-06-15',
    '2024-06-20',
    '{"calificacion": "9.0", "horas_cursadas": 120, "modalidad": "Presencial", "promedio": "Excelente", "distincion": "Mejor proyecto final"}'::jsonb,
    1,
    TRUE,
    'Emisión inicial con distinción'
);

-- CERTIFICADOS PARA CURSO DE HIPERTENSIÓN ARTERIAL (Propuesta 2)
-- Inscripciones IDs: 4, 5, 6
-- Estado: Generado (GEN) - ID 3

-- Valeria Orellano (inscripcion_id = 4)
INSERT INTO certificaciones (
    inscripcion_id, 
    tipo_estado_certificado_id, 
    token, 
    fecha_finalizacion, 
    fecha_emision,
    metadata,
    version,
    es_version_actual,
    motivo_cambio
) VALUES (
    4, -- Valeria Orellano
    3, -- Estado: Generado
    'cert_' || substr(md5(random()::text), 1, 20),
    '2024-05-30',
    '2024-06-05',
    '{"calificacion": "8.5", "horas_cursadas": 40, "modalidad": "Virtual", "aprobado": true, "trabajo_final": "Aprobado"}'::jsonb,
    1,
    TRUE,
    'Certificado generado automáticamente'
);

-- Maria Quiroga (inscripcion_id = 5)
INSERT INTO certificaciones (
    inscripcion_id, 
    tipo_estado_certificado_id, 
    token, 
    fecha_finalizacion, 
    fecha_emision,
    metadata,
    version,
    es_version_actual,
    motivo_cambio
) VALUES (
    5, -- Maria Quiroga
    3, -- Estado: Generado
    'cert_' || substr(md5(random()::text), 1, 20),
    '2024-05-30',
    '2024-06-05',
    '{"calificacion": "7.8", "horas_cursadas": 40, "modalidad": "Virtual", "aprobado": true, "trabajo_final": "Aprobado con observaciones"}'::jsonb,
    1,
    TRUE,
    'Generado por sistema'
);

-- Melisa Villavicencio (inscripcion_id = 6) - CON VERSIÓN 2 (ejemplo de corrección)
-- Primero versión 1
INSERT INTO certificaciones (
    inscripcion_id, 
    tipo_estado_certificado_id, 
    token, 
    fecha_finalizacion, 
    fecha_emision,
    metadata,
    version,
    es_version_actual,
    motivo_cambio
) VALUES (
    6, -- Melisa Villavicencio
    3, -- Estado: Generado
    'cert_' || substr(md5(random()::text), 1, 20),
    '2024-05-30',
    '2024-06-05',
    '{"calificacion": "9.2", "horas_cursadas": 40, "modalidad": "Virtual", "aprobado": true}'::jsonb,
    1,
    FALSE, -- NO es actual
    'Versión inicial con error en nombre'
);

-- Versión 2 corregida
INSERT INTO certificaciones (
    inscripcion_id, 
    tipo_estado_certificado_id, 
    token, 
    fecha_finalizacion, 
    fecha_emision,
    metadata,
    version,
    es_version_actual,
    motivo_cambio
) VALUES (
    6, -- Mismo inscripcion_id
    3, -- Estado: Generado
    'cert_' || substr(md5(random()::text), 1, 20),
    '2024-05-30',
    '2024-06-10', -- Nueva fecha de emisión
    '{"calificacion": "9.2", "horas_cursadas": 40, "modalidad": "Virtual", "aprobado": true, "correccion": "Nombre completo actualizado"}'::jsonb,
    2,
    TRUE, -- Esta es la versión actual
    'Corrección: Se completó nombre "Melisa Andrea Villavicencio"'
);

-- CERTIFICADOS PARA SIMPOSIO INTERNACIONAL DE EDUCACIÓN (Propuesta 3)
-- Inscripciones IDs: 7, 8, 9
-- Estado: Pendiente (PEN) - ID 2 (aún no generados, pero pueden generarse)

-- Yanina Mulet (inscripcion_id = 7) - No Generable (aún no cumple requisitos)
INSERT INTO certificaciones (
    inscripcion_id, 
    tipo_estado_certificado_id, 
    token, 
    fecha_finalizacion,
    metadata,
    version,
    es_version_actual,
    motivo_cambio
) VALUES (
    7, -- Yanina Mulet
    1, -- Estado: No Generable (ID 1)
    'cert_' || substr(md5(random()::text), 1, 20),
    NULL, -- No hay fecha de finalización aún
    '{"asistencia_requerida": "80%", "asistencia_actual": "75%", "trabajos_pendientes": 1}'::jsonb,
    1,
    TRUE,
    'Aún no cumple requisitos de asistencia'
);

-- Natalia Orellano (inscripcion_id = 8) - Pendiente
INSERT INTO certificaciones (
    inscripcion_id, 
    tipo_estado_certificado_id, 
    token, 
    fecha_finalizacion,
    metadata,
    version,
    es_version_actual,
    motivo_cambio
) VALUES (
    8, -- Natalia Orellano
    2, -- Estado: Pendiente (ID 2)
    'cert_' || substr(md5(random()::text), 1, 20),
    '2024-07-20', -- Fecha estimada de finalización
    '{"asistencia_requerida": "80%", "asistencia_actual": "95%", "trabajos_entregados": "Todos", "apto_para_certificar": true}'::jsonb,
    1,
    TRUE,
    'Cumple todos los requisitos, pendiente de generación'
);

-- Paz Marcela Fernanda Sanchez (inscripcion_id = 9) - Inhabilitado (ejemplo especial)
INSERT INTO certificaciones (
    inscripcion_id, 
    tipo_estado_certificado_id, 
    token, 
    fecha_finalizacion, 
    fecha_emision,
    metadata,
    version,
    es_version_actual,
    motivo_cambio
) VALUES (
    9, -- Paz Marcela Fernanda Sanchez
    5, -- Estado: Inhabilitado (ID 5)
    'cert_' || substr(md5(random()::text), 1, 20),
    '2024-07-20',
    '2024-07-25',
    '{"calificacion": "8.0", "asistencia": "100%", "motivo_inhabilitacion": "Verificación de documentación pendiente", "fecha_revision": "2024-08-01"}'::jsonb,
    1,
    TRUE,
    'Certificado inhabilitado temporalmente por documentación pendiente'
);

-- CERTIFICADO REVOCADO (Ejemplo para mostrar todos los estados)
-- Usaremos una inscripción existente y crearemos un certificado revocado
INSERT INTO certificaciones (
    inscripcion_id, 
    tipo_estado_certificado_id, 
    token, 
    fecha_finalizacion, 
    fecha_emision,
    metadata,
    version,
    es_version_actual,
    motivo_cambio
) VALUES (
    10, -- Gerardo Uliarte (Enfermería - Propuesta 4)
    6, -- Estado: Revocado (ID 6)
    'cert_' || substr(md5(random()::text), 1, 20),
    '2024-08-10',
    '2024-08-15',
    '{"calificacion": "7.5", "horas": 60, "motivo_revocacion": "Datos académicos falsificados", "fecha_revocacion": "2024-09-01", "revocado_por": "Comité Académico"}'::jsonb,
    1,
    TRUE,
    'Certificado revocado por falsificación de información académica'
);