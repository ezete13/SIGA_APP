-- =========================================================
-- CERTIFICADOS PARA DIPLOMATURA EN ORTODONCIA (Propuesta 1)
-- Unidad: Facultad de Ciencias Médicas (FCM) - id=6
-- =========================================================

-- 1. Certificado de Maria del Valle Mejibar Rivas (certificacion_id = 1)
INSERT INTO certificacion_autoridad (certificacion_id, autoridad_id, orden) VALUES
(1, 2, 1),  -- Rectora - Lic. María Laura Simonassi
(1, 17, 2), -- Decano FCM - Esp. Méd. Sergio Gabriel Albarracín (id=17)
(1, 18, 3); -- Vicedecana FCM - Dra. Mariana del Valle Romero (id=18)

-- 2. Certificado de Jesica Paola Romarion Alvarado (certificacion_id = 2)
INSERT INTO certificacion_autoridad (certificacion_id, autoridad_id, orden) VALUES
(2, 2, 1),  -- Rectora
(2, 17, 2), -- Decano FCM
(2, 18, 3); -- Vicedecana FCM

-- 3. Certificado de Carolina Soledad Ibazeta (certificacion_id = 3)
INSERT INTO certificacion_autoridad (certificacion_id, autoridad_id, orden) VALUES
(3, 2, 1),  -- Rectora
(3, 17, 2), -- Decano FCM
(3, 18, 3); -- Vicedecana FCM

-- =========================================================
-- CERTIFICADOS PARA CURSO DE HIPERTENSIÓN ARTERIAL (Propuesta 2)
-- Unidad: Facultad de Ciencias Médicas (FCM) - id=6
-- =========================================================

-- 4. Certificado de Valeria Orellano (certificacion_id = 4)
INSERT INTO certificacion_autoridad (certificacion_id, autoridad_id, orden) VALUES
(4, 2, 1),  -- Rectora
(4, 17, 2), -- Decano FCM
(4, 18, 3); -- Vicedecana FCM

-- 5. Certificado de Maria Quiroga (certificacion_id = 5)
INSERT INTO certificacion_autoridad (certificacion_id, autoridad_id, orden) VALUES
(5, 2, 1),  -- Rectora
(5, 17, 2), -- Decano FCM
(5, 18, 3); -- Vicedecana FCM

-- 6. Certificado de Melisa Villavicencio - VERSIÓN 2 (certificacion_id = 7)
INSERT INTO certificacion_autoridad (certificacion_id, autoridad_id, orden) VALUES
(7, 2, 1),  -- Rectora
(7, 17, 2), -- Decano FCM
(7, 18, 3); -- Vicedecana FCM

-- =========================================================
-- CERTIFICADOS PARA SIMPOSIO INTERNACIONAL DE EDUCACIÓN (Propuesta 3)
-- Unidad: Facultad de Educación (FE) - id=10
-- =========================================================

-- 7. Certificado de Yanina Mulet - No Generable (certificacion_id = 8)
INSERT INTO certificacion_autoridad (certificacion_id, autoridad_id, orden) VALUES
(8, 2, 1),   -- Rectora
(8, 25, 2),  -- Decana FE - Mg. Lucía Mabel Ghilardi (id=25)
(8, 26, 3);  -- Vicedecana FE - Lic. Patricia Elena Funes (id=26)

-- 8. Certificado de Natalia Orellano - Pendiente (certificacion_id = 9)
INSERT INTO certificacion_autoridad (certificacion_id, autoridad_id, orden) VALUES
(9, 2, 1),   -- Rectora
(9, 25, 2),  -- Decana FE
(9, 26, 3);  -- Vicedecana FE

-- 9. Certificado de Paz Marcela Fernanda Sanchez - Inhabilitado (certificacion_id = 10)
INSERT INTO certificacion_autoridad (certificacion_id, autoridad_id, orden) VALUES
(10, 2, 1),  -- Rectora
(10, 25, 2), -- Decana FE
(10, 26, 3); -- Vicedecana FE

-- =========================================================
-- CERTIFICADO REVOCADO - ENFERMERÍA (Propuesta 4)
-- Unidad: Facultad de Ciencias Médicas (FCM) - id=6
-- =========================================================

-- 10. Certificado de Gerardo Uliarte - Revocado (certificacion_id = 11)
INSERT INTO certificacion_autoridad (certificacion_id, autoridad_id, orden) VALUES
(11, 2, 1),  -- Rectora
(11, 17, 2), -- Decano FCM
(11, 18, 3); -- Vicedecana FCM

-- =========================================================
-- CERTIFICADOS PARA MERCADO DE CAPITALES (Propuesta 7)
-- Unidad: Facultad de Ciencias Económicas (FCEE) - id=4
-- =========================================================

-- Suponiendo que también creaste certificados para estas inscripciones:
-- 11. Certificado de Ernesto Gonzalez (certificacion_id = 12 - si existe)
INSERT INTO certificacion_autoridad (certificacion_id, autoridad_id, orden) VALUES
(12, 2, 1),  -- Rectora
(12, 13, 2), -- Decana FCEE - Esp. María Alejandra Segovia (id=13)
(12, 14, 3); -- Vicedecano FCEE - Cr. Pablo Andrés Quiroga (id=14)

-- 12. Certificado de Silvina Dorado (certificacion_id = 13)
INSERT INTO certificacion_autoridad (certificacion_id, autoridad_id, orden) VALUES
(13, 2, 1),  -- Rectora
(13, 13, 2), -- Decana FCEE
(13, 14, 3); -- Vicedecano FCEE

-- 13. Certificado de Marianela Cano (certificacion_id = 14)
INSERT INTO certificacion_autoridad (certificacion_id, autoridad_id, orden) VALUES
(14, 2, 1),  -- Rectora
(14, 13, 2), -- Decana FCEE
(14, 14, 3); -- Vicedecano FCEE