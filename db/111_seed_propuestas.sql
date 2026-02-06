
-- Asumiendo IDs basados en el orden de inserción:
-- Unidades: UCCSJ=1, UCCSL=2, UCCMZ=3, FCEE=4, FDCS=5, FCM=6, FFYH=7, FCQT=8, ISFDSM=9, FE=10, ES=11, ECRP=12, FCV=13, FDBEYCA=14
-- Modalidades: PRE=1, DIS=2, SEM=3, ELE=4
-- Tipos Propuesta: GR=1, TC=2, PG=3, CS=4, JR=5, AC=6, SM=7, TL=8, CP=9, HB=10
-- Periodos Lectivos: 24S1=1, 24S2=2, 25S1=3, 25S2=4, 24AN=5, 25AN=6
-- Tipos Estado Propuesta: BOR=1, PUB=2, ARC=3

-- Curso 1: Diplomatura en Ortodoncia (FCM = unidad_id 6, PRE = modalidad_id 1, PG = tipo_propuesta_id 3, 24AN = periodo_id 5, PUB = estado_id 2)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    6, 1, 3, 5, 2, 
    'Diplomatura en Ortodoncia y Ortopedia Maxilar', 2024, 1, 
    '2024-03-15', '2024-12-10', 30, 180, 45000.00, 6, 'MED001',
    'posgradomedicina@uccuyo.edu.ar', NULL, 'Facultad de Ciencias Médicas - Aula Magna', TRUE
);

-- Curso 2: Hipertensión Arterial (FCM = 6, DIS = 2, AC = 6, 24S1 = 1, PUB = 2)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    6, 2, 6, 1, 2,
    'Curso de Actualización: Hipertensión Arterial', 2024, 3, 
    '2024-04-10', '2024-06-20', 50, 40, 12000.00, 1, 'MED002',
    'posgradomedicina@uccuyo.edu.ar', NULL, 'Plataforma Virtual UCCuyo', TRUE
);

-- Curso 3: Simposio Internacional de Educación (FFYH = 7, PRE = 1, JR = 5, 24S2 = 2, PUB = 2)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    7, 1, 5, 2, 2,
    'Simposio Internacional de Educación', 2024, 2, 
    '2024-08-15', '2024-08-16', 200, 16, 3000.00, 1, 'EDU001',
    'educacion@uccuyo.edu.ar', NULL, 'SUM Universidad Católica de Cuyo', TRUE
);

-- Curso 4: Enfermería en Cuidados Críticos (FCM = 6, SEM = 3, PG = 3, 24S2 = 2, PUB = 2)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    6, 3, 3, 2, 2,
    'Enfermería en Cuidados Críticos', 2024, 1, 
    '2024-05-20', '2024-11-15', 25, 120, 28000.00, 4, 'MED003',
    'enfermeria@uccuyo.edu.ar', NULL, 'Hospital Central de San Juan', TRUE
);

-- Curso 5: Jornadas de Emergentología Pediátrica (FCM = 6, PRE = 1, JR = 5, 24S2 = 2, PUB = 2)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    6, 1, 5, 2, 2,
    'Jornadas de Emergentología Pediátrica', 2024, 1, 
    '2024-09-05', '2024-09-05', 80, 12, 2000.00, 1, 'MED004',
    'posgradomedicina@uccuyo.edu.ar', NULL, 'Facultad de Ciencias Médicas - Auditorio', TRUE
);

-- Curso 6: Curso de Lectocomprensión en Idioma Inglés (FFYH = 7, ELE = 4, CS = 4, 24S1 = 1, PUB = 2)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    7, 4, 4, 1, 2,
    'Curso de Lectocomprensión en Idioma Inglés', 2024, 1, 
    '2024-04-01', '2024-07-15', 40, 60, 8000.00, 2, 'IDI001',
    'idiomas@uccuyo.edu.ar', NULL, 'Campus Virtual UCCuyo', TRUE
);

-- Curso 7: Diplomatura en Mercado de Capitales (FCEE = 4, PRE = 1, PG = 3, 24S2 = 2, PUB = 2)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    4, 1, 3, 2, 2,
    'Diplomatura en Mercado de Capitales', 2024, 1, 
    '2024-03-25', '2024-12-02', 35, 160, 35000.00, 5, 'ECO001',
    'economicas@uccuyo.edu.ar', NULL, 'Facultad de Ciencias Económicas - Aula 12', TRUE
);

-- Curso 8: Talleres de Robótica Educativa (UCCSJ = 1, SEM = 3, TL = 8, 24S2 = 2, PUB = 2)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    1, 3, 8, 2, 2,
    'Talleres de Robótica Educativa - Nivel Inicial', 2024, 2, 
    '2024-04-15', '2024-07-15', 20, 48, 6000.00, 3, 'ROB001',
    'robotica@uccuyo.edu.ar', NULL, 'Centro Tecnológico de Robótica', TRUE
);

-- Curso 9: Talleres de Programación para Docentes (UCCSJ = 1, ELE = 4, TL = 8, 24S2 = 2, PUB = 2)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    1, 4, 8, 2, 2,
    'Talleres de Programación para Docentes', 2024, 2, 
    '2024-05-10', '2024-08-20', 30, 36, 9000.00, 1, 'ROB002',
    'robotica@uccuyo.edu.ar', NULL, 'Plataforma Virtual - CTRED', TRUE
);

-- Curso 10: Talleres de Arduino - Proyectos Avanzados (UCCSJ = 1, PRE = 1, TL = 8, 24S2 = 2, PUB = 2)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    1, 1, 8, 2, 2,
    'Talleres de Arduino - Proyectos Avanzados', 2024, 3, 
    '2024-06-01', '2024-09-30', 15, 72, 12000.00, 4, 'ROB003',
    'robotica@uccuyo.edu.ar', NULL, 'Laboratorio de Tecnología - UCCuyo', TRUE
);


-- Propuesta 11: Maestría en Derecho Penal (FDCS, Semipresencial, Postgrado, 25S1, Publicada)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    5, 3, 3, 3, 2,
    'Maestría en Derecho Penal', 2025, 1, 
    '2025-03-10', '2026-03-10', 25, 600, 85000.00, 10, 'DER001',
    'posgrado.derecho@uccuyo.edu.ar', 'maestria_derecho_penal.pdf', 'Facultad de Derecho - Aula 5', TRUE
);

-- Propuesta 12: Tecnicatura en Enología (UCCMZ, Presencial, Técnicatura, 24AN, Publicada)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    3, 1, 2, 5, 2,
    'Tecnicatura Universitaria en Enología', 2024, 1, 
    '2024-03-01', '2025-11-30', 40, 1600, 65000.00, 12, 'ENO001',
    'enologia@uccuyo.edu.ar', 'tecnicatura_enologia.pdf', 'Sede Mendoza - Laboratorios', TRUE
);

-- Propuesta 13: Curso de Marketing Digital (FCEE, A Distancia, Curso, 24S2, Publicada)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    4, 2, 4, 2, 2,
    'Curso Intensivo de Marketing Digital', 2024, 5, 
    '2024-09-01', '2024-10-15', 100, 80, 15000.00, 3, 'MKT001',
    'marketing.digital@uccuyo.edu.ar', NULL, 'Plataforma Virtual - Campus FCEE', TRUE
);

-- Propuesta 14: Jornada de Actualización Veterinaria (FCV, Presencial, Jornada, 24S2, Publicada)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    13, 1, 5, 2, 2,
    'Jornada de Actualización en Medicina Veterinaria', 2024, 3, 
    '2024-10-18', '2024-10-19', 60, 20, 3500.00, 1, 'VET001',
    'veterinaria@uccuyosl.edu.ar', 'jornada_veterinaria.pdf', 'Sede San Luis - Auditorio Principal', TRUE
);

-- Propuesta 15: Diplomatura en Educación Especial (FE, A Elección, Postgrado, 25S1, Borrador)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    10, 4, 3, 3, 1,
    'Diplomatura en Educación Especial e Inclusiva', 2025, 1, 
    '2025-04-01', '2025-11-30', 35, 200, 40000.00, 8, 'EDU002',
    'posgrado.educacion@uccuyo.edu.ar', 'diplomatura_educacion_especial.pdf', 'Modalidad Mixta', TRUE
);

-- Propuesta 16: Seminario de Filosofía Contemporánea (FFYH, Presencial, Seminario, 24S1, Archivada)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    7, 1, 7, 1, 3,
    'Seminario de Filosofía Contemporánea', 2024, 1, 
    '2024-03-20', '2024-06-20', 30, 60, 18000.00, 4, 'FIL001',
    'filosofia@uccuyo.edu.ar', 'seminario_filosofia.pdf', 'Facultad de Filosofía - Sala de Conferencias', FALSE
);

-- Propuesta 17: Curso de Química Analítica (FCQT, Semipresencial, Curso, 24S2, Publicada)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    8, 3, 4, 2, 2,
    'Curso Avanzado de Química Analítica Instrumental', 2024, 2, 
    '2024-08-05', '2024-11-25', 20, 120, 32000.00, 5, 'QUI001',
    'quimica@uccuyo.edu.ar', 'curso_quimica_analitica.pdf', 'Laboratorios FCQT - Campus Central', TRUE
);

-- Propuesta 18: Taller de Primeros Auxilios (FCM, Presencial, Taller, 24S1, Publicada)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    6, 1, 8, 1, 2,
    'Taller de Primeros Auxilios y RCP Básico', 2024, 8, 
    '2024-05-10', '2024-05-11', 25, 16, 2500.00, 1, 'PAU001',
    'extension.medica@uccuyo.edu.ar', NULL, 'Facultad de Ciencias Médicas - Sala de Simulación', TRUE
);

-- Propuesta 19: Capacitación en Seguridad Informática (ES, A Distancia, Capacitación, 24S2, Publicada)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    11, 2, 9, 2, 2,
    'Capacitación en Seguridad Informática y Ciberdefensa', 2024, 1, 
    '2024-09-15', '2024-12-15', 50, 100, 28000.00, 6, 'SEG001',
    'seguridad@uccuyo.edu.ar', 'capacitacion_seguridad.pdf', 'Plataforma Virtual ES', TRUE
);

-- Propuesta 20: Curso de Pastoral Juvenil (ECRP, Presencial, Curso, 24AN, Publicada)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    12, 1, 4, 5, 2,
    'Curso de Formación en Pastoral Juvenil', 2024, 1, 
    '2024-03-15', '2024-11-30', 40, 150, 12000.00, 8, 'PAS001',
    'pastoral@uccuyo.edu.ar', 'curso_pastoral.pdf', 'Capilla Universitaria - Salón Parroquial', TRUE
);

-- Propuesta 21: Diplomatura en Gestión Pública (UCCSL, A Elección, Postgrado, 25S1, Publicada)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    2, 4, 3, 3, 2,
    'Diplomatura en Gestión Pública y Administración Gubernamental', 2025, 1, 
    '2025-04-15', '2025-12-15', 30, 180, 42000.00, 8, 'GES001',
    'posgrado.sanluis@uccuyosl.edu.ar', 'diplomatura_gestion_publica.pdf', 'Sede San Luis - Modalidad Híbrida', TRUE
);

-- Propuesta 22: Taller de Elaboración de Cerveza Artesanal (FDBEYCA, Presencial, Taller, 24S2, Publicada)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    14, 1, 8, 2, 2,
    'Taller de Elaboración de Cerveza Artesanal', 2024, 3, 
    '2024-08-20', '2024-10-20', 15, 48, 18000.00, 3, 'CER001',
    'cerveza.artesanal@uccuyo.edu.ar', 'taller_cerveza.pdf', 'Planta Piloto de Enología - Mendoza', TRUE
);

-- Propuesta 23: Curso de Inglés para Negocios (FFYH, A Distancia, Curso, 24S1, Archivada)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    7, 2, 4, 1, 3,
    'Curso de Inglés para Negocios y Comercio Internacional', 2024, 2, 
    '2024-03-01', '2024-06-30', 35, 90, 15000.00, 3, 'IDI002',
    'idiomas.negocios@uccuyo.edu.ar', 'curso_ingles_negocios.pdf', 'Plataforma Virtual', FALSE
);

-- Propuesta 24: Jornada de Innovación Tecnológica (UCCSJ, Presencial, Jornada, 24S2, Publicada)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    1, 1, 5, 2, 2,
    'Jornada de Innovación Tecnológica y Emprendedurismo', 2024, 4, 
    '2024-11-07', '2024-11-08', 150, 18, 4000.00, 1, 'INN001',
    'innovacion@uccuyo.edu.ar', 'jornada_innovacion.pdf', 'Auditorio Central - Sede San Juan', TRUE
);

-- Propuesta 25: Capacitación en Manipulación de Alimentos (FDBEYCA, Semipresencial, Capacitación, 24S2, Publicada)
INSERT INTO propuestas (
    unidad_id, modalidad_id, tipo_propuesta_id, periodo_lectivo_id, 
    tipo_estado_propuesta_id, titulo, anio, edicion, fecha_inicio, 
    fecha_fin, maximo_alumnos, cantidad_horas, importe_base, cuotas, 
    concepto_pago, email_encargado, plan_estudio_pdf, lugar_realizacion, estado
) VALUES (
    14, 3, 9, 2, 2,
    'Capacitación en Manipulación Higiénica de Alimentos', 2024, 12, 
    '2024-09-01', '2024-09-30', 60, 40, 5000.00, 1, 'ALI001',
    'capacitacion.alimentos@uccuyo.edu.ar', NULL, 'Sede Mendoza - Laboratorio de Alimentos', TRUE
);