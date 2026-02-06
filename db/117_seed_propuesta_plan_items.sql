-- INSERTS para propuesta_plan_items (Items específicos para los módulos)
INSERT INTO propuesta_plan_items (modulo_id, titulo, detalle, orden) VALUES
-- Items para Módulo 1 (Diagnóstico en Ortodoncia)
(1, 'Análisis Cefalométrico', 'Técnicas de análisis cefalométrico digital y manual.', 1),
(1, 'Diagnóstico por Imágenes', 'Interpretación de radiografías panorámicas y tomografías.', 2),
(1, 'Estudio de Modelos', 'Análisis de modelos dentales y oclusales.', 3),

-- Items para Módulo 2 (Fisiopatología de la Hipertensión)
(4, 'Sistema Renina-Angiotensina', 'Mecanismo de regulación de la presión arterial.', 1),
(4, 'Función Endotelial', 'Papel del endotelio vascular en la hipertensión.', 2),
(4, 'Factores de Riesgo', 'Identificación y manejo de factores de riesgo cardiovascular.', 3),

-- Items para Módulo 7 (Introducción al Mercado de Capitales)
(7, 'Estructura del Mercado', 'Organización y participantes del mercado de capitales argentino.', 1),
(7, 'Marco Regulatorio', 'Leyes y regulaciones que rigen el mercado financiero.', 2),
(7, 'Sistemas de Negociación', 'Funcionamiento de los sistemas de negociación electrónica.', 3),

-- Items para Módulo 12 (Viticultura)
(10, 'Variedades de Vid', 'Características de las principales variedades vitivinícolas.', 1),
(10, 'Manejo del Viñedo', 'Técnicas de poda, riego y fertilización.', 2),
(10, 'Control de Plagas', 'Manejo integrado de plagas y enfermedades.', 3),

-- Items para Módulo 15 (Fundamentos de la Educación Especial)
(13, 'Marco Legal', 'Leyes y normativas que regulan la educación inclusiva.', 1),
(13, 'Modelos de Inclusión', 'Diferentes enfoques y modelos de educación inclusiva.', 2),
(13, 'Derechos de las Personas con Discapacidad', 'Protección jurídica y derechos educativos.', 3);