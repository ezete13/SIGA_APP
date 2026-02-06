-- =========================================================
-- INSERTS CORREGIDOS PARA LA TABLA PROPUESTA_DOCENTE
-- Usando los IDs correctos de docentes (1-27) y propuestas (1-25)
-- =========================================================

-- Propuesta 1: Diplomatura en Ortodoncia
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(1, 1, 'Titular', 1),  -- Carlos López
(1, 2, 'Adjunto', 2);  -- María González

-- Propuesta 2: Curso de Hipertensión Arterial
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(2, 3, 'Titular', 1);  -- Alejandro Martínez

-- Propuesta 3: Simposio Internacional de Educación
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(3, 6, 'Titular', 1),  -- Laura Mendez
(3, 7, 'Adjunto', 2);  -- Roberto García

-- Propuesta 4: Enfermería en Cuidados Críticos
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(4, 4, 'Titular', 1);  -- Sandra Ojeda

-- Propuesta 5: Jornadas de Emergentología Pediátrica
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(5, 5, 'Titular', 1);  -- Miguel Ángel Ruiz

-- Propuesta 6: Curso de Lectocomprensión en Inglés
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(6, 8, 'Titular', 1);  -- María Wilson

-- Propuesta 7: Diplomatura en Mercado de Capitales
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(7, 9, 'Titular', 1),   -- Jorge Domínguez
(7, 10, 'Adjunto', 2);  -- Ana Beltrán

-- Propuesta 8: Talleres de Robótica Educativa
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(8, 11, 'Titular', 1);  -- Gastón Molina

-- Propuesta 9: Talleres de Programación para Docentes
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(9, 12, 'Titular', 1);  -- Daniel Castro

-- Propuesta 10: Talleres de Arduino
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(10, 13, 'Titular', 1);  -- Javier López

-- Propuesta 11: Maestría en Derecho Penal
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(11, 14, 'Titular', 1),   -- Andrea Sánchez
(11, 26, 'Ayudante', 2);  -- Juan Pérez (docente 26)

-- Propuesta 12: Tecnicatura en Enología
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(12, 15, 'Titular', 1);  -- Ricardo Fernández

-- Propuesta 13: Curso de Marketing Digital
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(13, 16, 'Titular', 1);  -- Pablo Gómez (está bien porque el docente 16 es Pablo Gómez según tu listado)

-- Propuesta 14: Jornada de Actualización Veterinaria
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(14, 17, 'Titular', 1);  -- Luis Rodríguez (docente 17 según tu listado)

-- Propuesta 15: Diplomatura en Educación Especial
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(15, 6, 'Titular', 1),    -- Laura Mendez (reutilizada)
(15, 26, 'Ayudante', 2);  -- Mónica Rojas (docente 27)

-- Propuesta 16: Seminario de Filosofía Contemporánea
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(16, 18, 'Titular', 1);  -- Carolina Díaz (docente 18 según tu listado)

-- Propuesta 17: Curso de Química Analítica
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(17, 19, 'Titular', 1);  -- Marcelo Silva (docente 19 según tu listado)

-- Propuesta 18: Taller de Primeros Auxilios
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(18, 3, 'Titular', 1),   -- Alejandro Martínez (reutilizado)
(18, 4, 'Ayudante', 2);  -- Sandra Ojeda (reutilizada)

-- Propuesta 19: Capacitación en Seguridad Informática
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(19, 20, 'Titular', 1);  -- Gabriela Torres (docente 20 según tu listado)

-- Propuesta 20: Curso de Pastoral Juvenil
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(20, 21, 'Titular', 1);  -- Fernando Mendoza (docente 21 según tu listado)

-- Propuesta 21: Diplomatura en Gestión Pública
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(21, 22, 'Titular', 1);  -- Martín Castro (docente 22 según tu listado)

-- Propuesta 22: Taller de Cerveza Artesanal
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(22, 23, 'Titular', 1);  -- Patricia Wilson (docente 23 según tu listado)

-- Propuesta 23: Curso de Inglés para Negocios
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(23, 24, 'Titular', 1);  -- Eduardo Pérez (docente 24 según tu listado)

-- Propuesta 24: Jornada de Innovación Tecnológica
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(24, 25, 'Titular', 1);  -- Juan Pérez (docente 25 - OJO: Este es el mismo DNI que el docente 26, hay un error)

-- Propuesta 25: Capacitación en Manipulación de Alimentos
INSERT INTO propuesta_docente (propuesta_id, docente_id, rol, orden_web) VALUES
(25, 15, 'Titular', 1);  -- Ricardo Fernández (reutilizado)