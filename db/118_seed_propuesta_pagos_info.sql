-- INSERTS para propuesta_pagos_info (Opciones de pago para algunas propuestas)
INSERT INTO propuesta_pagos_info (propuesta_id, concepto, importe, cuotas, observaciones) VALUES
-- Opciones para Propuesta 1
(1, 'Pago Contado con Descuento', 40500.00, 1, '10% de descuento por pago al contado'),
(1, '6 Cuotas Mensuales', 7500.00, 6, '6 cuotas mensuales de $7.500'),

-- Opciones para Propuesta 2
(2, 'Pago Único', 12000.00, 1, 'Curso completo'),

-- Opciones para Propuesta 7
(7, 'Pago Contado', 31500.00, 1, '10% descuento por pago contado'),
(7, '5 Cuotas Mensuales', 7000.00, 5, '5 cuotas de $7.000'),

-- Opciones para Propuesta 12
(12, 'Matrícula', 10000.00, 1, 'Matrícula de inscripción'),
(12, '12 Cuotas Mensuales', 4583.33, 12, 'Cuotas mensuales durante el ciclo lectivo'),

-- Opciones para Propuesta 15
(15, 'Pago Anticipado', 36000.00, 1, '10% descuento por pago anticipado'),
(15, '8 Cuotas Mensuales', 5000.00, 8, '8 cuotas mensuales de $5.000'),

-- Opciones para Propuesta 18 (Taller de Primeros Auxilios)
(18, 'Inscripción General', 2500.00, 1, 'Incluye material de práctica y certificado'),
(18, 'Estudiantes UCCuyo', 2000.00, 1, 'Descuento especial para estudiantes de la universidad'),

-- Opciones para Propuesta 24 (Jornada de Innovación)
(24, 'Inscripción General', 4000.00, 1, 'Acceso a todas las charlas y materiales'),
(24, 'Estudiantes y Docentes', 2000.00, 1, '50% de descuento para estudiantes y docentes');