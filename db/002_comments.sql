-- Tabla sedes
COMMENT ON TABLE sedes IS 'Tabla de sedes de la universidad en el país.';
COMMENT ON COLUMN sedes.id IS 'ID único autoincremental.';
COMMENT ON COLUMN sedes.codigo IS 'Código interno único.';
COMMENT ON COLUMN sedes.provincia IS 'Provincia donde se encuentra ubicada.';
COMMENT ON COLUMN sedes.localidad IS 'Localidad o ciudad donde se encuentra.';
COMMENT ON COLUMN sedes.codigo_postal IS 'Código postal.';
COMMENT ON COLUMN sedes.direccion IS 'Dirección física.';
COMMENT ON COLUMN sedes.estado IS 'Estado activo/inactivo (true=activa, false=inactiva).';
COMMENT ON COLUMN sedes.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN sedes.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla unidades
COMMENT ON TABLE unidades IS 'Unidades académicas que operan dentro de una sede (Facultades).';
COMMENT ON COLUMN unidades.id IS 'ID único autoincremental.';
COMMENT ON COLUMN unidades.codigo IS 'Código interno único.';
COMMENT ON COLUMN unidades.nombre IS 'Nombre o título de reconocimiento formal. Ej: Facultad de Ciencias Económicas.';
COMMENT ON COLUMN unidades.nombre_corto IS 'Nombre abreviado para usos internos. Ej: Económicas.';
COMMENT ON COLUMN unidades.siglas IS 'Sigla institucional única. Ej: FCE, FCM.';
COMMENT ON COLUMN unidades.color_principal IS 'Color primario de identidad visual en formato HEX. Ej: #064a31.';
COMMENT ON COLUMN unidades.color_secundario IS 'Color secundario para gradientes o elementos de diseño en formato HEX. Ej: #7d1b1c.';
COMMENT ON COLUMN unidades.direccion IS 'Dirección física.';
COMMENT ON COLUMN unidades.telefono IS 'Teléfono de contacto.';
COMMENT ON COLUMN unidades.email IS 'Email institucional.';
COMMENT ON COLUMN unidades.sede_id IS 'ID de la sede a la que pertenece (FK a sede.id).';
COMMENT ON COLUMN unidades.estado IS 'Estado activo/inactivo (true=activa, false=inactiva).';
COMMENT ON COLUMN unidades.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN unidades.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla modalidades
COMMENT ON TABLE modalidades IS 'Modalidades que un curso o jornada puede tener (presencial, virtual, híbrido).';
COMMENT ON COLUMN modalidades.id IS 'ID único autoincremental.';
COMMENT ON COLUMN modalidades.codigo IS 'Código interno único.';
COMMENT ON COLUMN modalidades.nombre IS 'Nombre de la modalidad. Ej: Presencial, Virtual, Híbrido.';
COMMENT ON COLUMN modalidades.descripcion IS 'Descripción detallada de la modalidad.';
COMMENT ON COLUMN modalidades.estado IS 'Estado activo/inactivo (true=activa, false=inactiva).';
COMMENT ON COLUMN modalidades.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN modalidades.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla periodos_lectivos
COMMENT ON TABLE periodos_lectivos IS 'Períodos lectivos institucionales para organización académica de cursos y actividades.';
COMMENT ON COLUMN periodos_lectivos.id IS 'ID único autoincremental.';
COMMENT ON COLUMN periodos_lectivos.codigo IS 'Código interno único. Ej: 2024-1, 2024-2.';
COMMENT ON COLUMN periodos_lectivos.nombre IS 'Nombre descriptivo del período. Ej: Primer Cuatrimestre 2024.';
COMMENT ON COLUMN periodos_lectivos.fecha_inicio IS 'Fecha de comienzo del ciclo lectivo.';
COMMENT ON COLUMN periodos_lectivos.fecha_fin IS 'Fecha de finalización del ciclo lectivo.';
COMMENT ON COLUMN periodos_lectivos.estado IS 'Estado activo/inactivo (true=activo, false=inactivo).';
COMMENT ON COLUMN periodos_lectivos.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN periodos_lectivos.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla tipos_propuesta
COMMENT ON TABLE tipos_propuesta IS 'Catálogo de tipos de propuestas académicas. Ej: Curso, Jornada, Diplomatura, Evento.';
COMMENT ON COLUMN tipos_propuesta.id IS 'ID único autoincremental.';
COMMENT ON COLUMN tipos_propuesta.codigo IS 'Código interno único.';
COMMENT ON COLUMN tipos_propuesta.nombre IS 'Nombre del tipo de propuesta. Ej: Curso, Jornada, Diplomatura.';
COMMENT ON COLUMN tipos_propuesta.descripcion IS 'Descripción del tipo de propuesta.';
COMMENT ON COLUMN tipos_propuesta.estado IS 'Estado activo/inactivo (true=activo, false=inactivo).';
COMMENT ON COLUMN tipos_propuesta.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN tipos_propuesta.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla tipos_documento
COMMENT ON TABLE tipos_documento IS 'Catálogo de tipos de documentos de identificación. Ej: DNI, Pasaporte, Cédula Extranjera.';
COMMENT ON COLUMN tipos_documento.id IS 'ID único autoincremental.';
COMMENT ON COLUMN tipos_documento.codigo IS 'Código interno único.';
COMMENT ON COLUMN tipos_documento.nombre IS 'Nombre del tipo de documento. Ej: DNI, Pasaporte.';
COMMENT ON COLUMN tipos_documento.descripcion IS 'Descripción del tipo de documento.';
COMMENT ON COLUMN tipos_documento.estado IS 'Estado activo/inactivo (true=activo, false=inactivo).';
COMMENT ON COLUMN tipos_documento.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN tipos_documento.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla tipos_estado_propuesta
COMMENT ON TABLE tipos_estado_propuesta IS 'Catálogo de estados posibles para las propuestas académicas.';
COMMENT ON COLUMN tipos_estado_propuesta.id IS 'ID único autoincremental.';
COMMENT ON COLUMN tipos_estado_propuesta.codigo IS 'Código interno único.';
COMMENT ON COLUMN tipos_estado_propuesta.nombre IS 'Nombre del estado. Ej: Borrador, Publicada, Archivada.';
COMMENT ON COLUMN tipos_estado_propuesta.descripcion IS 'Descripción del tipo de estado.';
COMMENT ON COLUMN tipos_estado_propuesta.estado IS 'Estado activo/inactivo (true=activo, false=inactivo).';
COMMENT ON COLUMN tipos_estado_propuesta.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN tipos_estado_propuesta.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla tipos_estado_inscripcion
COMMENT ON TABLE tipos_estado_inscripcion IS 'Catálogo de posibles estados que puede tener una inscripción.';
COMMENT ON COLUMN tipos_estado_inscripcion.id IS 'ID único autoincremental.';
COMMENT ON COLUMN tipos_estado_inscripcion.codigo IS 'Código interno único.';
COMMENT ON COLUMN tipos_estado_inscripcion.nombre IS 'Nombre del estado. Ej: Preinscripto, Confirmado, Aprobado.';
COMMENT ON COLUMN tipos_estado_inscripcion.descripcion IS 'Descripción del tipo de estado.';
COMMENT ON COLUMN tipos_estado_inscripcion.estado IS 'Estado activo/inactivo (true=activo, false=inactivo).';
COMMENT ON COLUMN tipos_estado_inscripcion.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN tipos_estado_inscripcion.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla tipos_estado_certificado
COMMENT ON TABLE tipos_estado_certificado IS 'Catálogo de estados posibles para las certificaciones.';
COMMENT ON COLUMN tipos_estado_certificado.id IS 'ID único autoincremental.';
COMMENT ON COLUMN tipos_estado_certificado.codigo IS 'Código interno único.';
COMMENT ON COLUMN tipos_estado_certificado.nombre IS 'Nombre del estado. Ej: Pendiente, Emitido, Anulado.';
COMMENT ON COLUMN tipos_estado_certificado.descripcion IS 'Descripción del tipo de estado.';
COMMENT ON COLUMN tipos_estado_certificado.estado IS 'Estado activo/inactivo (true=activo, false=inactivo).';
COMMENT ON COLUMN tipos_estado_certificado.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN tipos_estado_certificado.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla autoridades
COMMENT ON TABLE autoridades IS 'Directivos y autoridades que firman certificaciones, vinculadas a periodos lectivos.';
COMMENT ON COLUMN autoridades.id IS 'ID único autoincremental.';
COMMENT ON COLUMN autoridades.unidad_id IS 'ID de la unidad académica en la que opera (FK a unidad.id).';
COMMENT ON COLUMN autoridades.periodo_lectivo_id IS 'ID del periodo lectivo en el que cumple con el cargo (FK a periodo_lectivo.id).';
COMMENT ON COLUMN autoridades.cargo IS 'Cargo que ocupa o tarea que desempeña. Se verá en los certificados.';
COMMENT ON COLUMN autoridades.nombre IS 'Nombre completo de la autoridad.';
COMMENT ON COLUMN autoridades.estado IS 'Estado activo/inactivo (true=activa, false=inactiva).';
COMMENT ON COLUMN autoridades.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN autoridades.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla propuestas
COMMENT ON TABLE propuestas IS 'Configuración centralizada de jornadas académicas, cursos, diplomaturas y eventos.';
COMMENT ON COLUMN propuestas.id IS 'ID único autoincremental de la propuesta. Clave primaria.';
COMMENT ON COLUMN propuestas.unidad_id IS 'ID de la unidad académica organizadora (FK a unidad.id).';
COMMENT ON COLUMN propuestas.modalidad_id IS 'ID de la modalidad de cursado (FK a modalidad.id).';
COMMENT ON COLUMN propuestas.periodo_lectivo_id IS 'ID del período lectivo institucional (FK a periodo_lectivo.id).';
COMMENT ON COLUMN propuestas.tipo_propuesta_id IS 'ID del tipo de actividad académica (FK a tipo_propuesta.id).';
COMMENT ON COLUMN propuestas.tipo_estado_propuesta_id IS 'ID del estado actual de la propuesta (FK a tipo_estado_propuesta.id).';
COMMENT ON COLUMN propuestas.titulo IS 'Nombre completo y descriptivo del curso, jornada o evento académico.';
COMMENT ON COLUMN propuestas.anio IS 'Año académico en que se dicta la actividad.';
COMMENT ON COLUMN propuestas.edicion IS 'Número de edición de la actividad. Valor por defecto: 1.';
COMMENT ON COLUMN propuestas.fecha_inicio IS 'Fecha de inicio formal de la actividad.';
COMMENT ON COLUMN propuestas.fecha_fin IS 'Fecha de finalización estimada de la actividad.';
COMMENT ON COLUMN propuestas.maximo_alumnos IS 'Límite máximo de participantes permitidos.';
COMMENT ON COLUMN propuestas.cantidad_horas IS 'Cantidad total de horas de la actividad.';
COMMENT ON COLUMN propuestas.importe_base IS 'Precio base para pago al contado.';
COMMENT ON COLUMN propuestas.cuotas IS 'Número de cuotas disponibles para pago fraccionado. Activa sistema de pagos.';
COMMENT ON COLUMN propuestas.concepto_pago IS 'Código interno para configuración de pagos.';
COMMENT ON COLUMN propuestas.email_encargado IS 'Email del responsable de la propuesta.';
COMMENT ON COLUMN propuestas.plan_estudio_pdf IS 'Ruta o nombre del archivo PDF con el plan de estudios.';
COMMENT ON COLUMN propuestas.lugar_realizacion IS 'Lugar físico donde se desarrollará la actividad.';
COMMENT ON COLUMN propuestas.estado IS 'Estado activo/inactivo de la propuesta (true=activa, false=inactiva).';
COMMENT ON COLUMN propuestas.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN propuestas.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla docentes
COMMENT ON TABLE docentes IS 'Registro de docentes, disertantes y profesores que participan en las propuestas académicas.';
COMMENT ON COLUMN docentes.id IS 'ID único autoincremental.';
COMMENT ON COLUMN docentes.nombre IS 'Nombre(s) del docente.';
COMMENT ON COLUMN docentes.apellido IS 'Apellido(s) del docente.';
COMMENT ON COLUMN docentes.dni IS 'Documento Nacional de Identidad (único).';
COMMENT ON COLUMN docentes.profesion IS 'Título profesional o formación principal.';
COMMENT ON COLUMN docentes.especialidad IS 'Especialización o área de expertise.';
COMMENT ON COLUMN docentes.biografia IS 'Resumen curricular y trayectoria profesional.';
COMMENT ON COLUMN docentes.telefono IS 'Teléfono de contacto.';
COMMENT ON COLUMN docentes.email IS 'Correo electrónico (único).';
COMMENT ON COLUMN docentes.linkedin IS 'URL del perfil de LinkedIn (opcional).';
COMMENT ON COLUMN docentes.estado IS 'Estado activo/inactivo (true=activo, false=inactivo).';
COMMENT ON COLUMN docentes.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN docentes.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla propuesta_docente
COMMENT ON TABLE propuesta_docente IS 'Relación muchos a muchos entre propuestas y docentes, con información del rol en cada propuesta.';
COMMENT ON COLUMN propuesta_docente.id IS 'ID único autoincremental.';
COMMENT ON COLUMN propuesta_docente.propuesta_id IS 'ID de la propuesta académica (FK a propuestas.id).';
COMMENT ON COLUMN propuesta_docente.docente_id IS 'ID del docente/disertante (FK a docentes.id).';
COMMENT ON COLUMN propuesta_docente.rol IS 'Rol del docente en la propuesta: Titular, Ayudante, Adjunto.';
COMMENT ON COLUMN propuesta_docente.orden_web IS 'Orden de aparición en la web (para ordenar docentes).';
COMMENT ON CONSTRAINT propuesta_docente_propuesta_id_fkey ON propuesta_docente IS 'Foreign key a la tabla propuestas.';
COMMENT ON CONSTRAINT propuesta_docente_docente_id_fkey ON propuesta_docente IS 'Foreign key a la tabla docentes.';
COMMENT ON CONSTRAINT propuesta_docente_propuesta_id_docente_id_key ON propuesta_docente IS 'Restricción única que evita duplicados en la relación.';

-- Tabla auspiciantes
COMMENT ON TABLE auspiciantes IS 'Registro de organizaciones, empresas e instituciones que auspician propuestas académicas.';
COMMENT ON COLUMN auspiciantes.id IS 'ID único autoincremental.';
COMMENT ON COLUMN auspiciantes.nombre IS 'Nombre de la organización auspiciante.';
COMMENT ON COLUMN auspiciantes.logo IS 'URL o ruta del archivo del logo institucional (opcional).';
COMMENT ON COLUMN auspiciantes.sitio_web IS 'Sitio web oficial de la organización (opcional).';
COMMENT ON COLUMN auspiciantes.estado IS 'Estado activo/inactivo (true=activo, false=inactivo).';
COMMENT ON COLUMN auspiciantes.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN auspiciantes.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla propuesta_auspiciantes
COMMENT ON TABLE propuesta_auspiciantes IS 'Relación muchos a muchos entre propuestas y auspiciantes, con orden de aparición.';
COMMENT ON COLUMN propuesta_auspiciantes.id IS 'ID único autoincremental.';
COMMENT ON COLUMN propuesta_auspiciantes.propuesta_id IS 'ID de la propuesta académica (FK a propuestas.id).';
COMMENT ON COLUMN propuesta_auspiciantes.auspiciante_id IS 'ID de la organización auspiciante (FK a auspiciantes.id).';
COMMENT ON COLUMN propuesta_auspiciantes.orden IS 'Orden de aparición en la web (para ordenar logos de auspiciantes).';
COMMENT ON CONSTRAINT propuesta_auspiciantes_propuesta_id_fkey ON propuesta_auspiciantes IS 'Foreign key a la tabla propuestas.';
COMMENT ON CONSTRAINT propuesta_auspiciantes_auspiciante_id_fkey ON propuesta_auspiciantes IS 'Foreign key a la tabla auspiciantes.';
COMMENT ON CONSTRAINT propuesta_auspiciantes_propuesta_id_auspiciante_id_key ON propuesta_auspiciantes IS 'Restricción única que evita duplicados en la relación.';


-- Tabla actividades
COMMENT ON TABLE auspiciantes IS 'Registro de organizaciones, empresas e instituciones que auspician propuestas académicas.';
COMMENT ON COLUMN auspiciantes.id IS 'ID único autoincremental.';
COMMENT ON COLUMN auspiciantes.nombre IS 'Nombre de la organización auspiciante.';
COMMENT ON COLUMN auspiciantes.logo IS 'URL o ruta del archivo del logo institucional (opcional).';
COMMENT ON COLUMN auspiciantes.sitio_web IS 'Sitio web oficial de la organización (opcional).';
COMMENT ON COLUMN auspiciantes.estado IS 'Estado activo/inactivo (true=activo, false=inactivo).';
COMMENT ON COLUMN auspiciantes.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN auspiciantes.actualizado_en IS 'Fecha y hora de última actualización del registro.';


-- Tabla propuesta_plan_modulos
COMMENT ON TABLE propuesta_plan_modulos IS 'Módulos o unidades temáticas que componen el plan de estudio de una propuesta académica.';
COMMENT ON COLUMN propuesta_plan_modulos.id IS 'ID único autoincremental.';
COMMENT ON COLUMN propuesta_plan_modulos.propuesta_id IS 'ID de la propuesta académica a la que pertenece el módulo (FK a propuestas.id).';
COMMENT ON COLUMN propuesta_plan_modulos.titulo IS 'Título descriptivo del módulo temático.';
COMMENT ON COLUMN propuesta_plan_modulos.descripcion IS 'Descripción detallada del contenido del módulo.';
COMMENT ON COLUMN propuesta_plan_modulos.orden IS 'Orden secuencial del módulo dentro del plan de estudio.';
COMMENT ON COLUMN propuesta_plan_modulos.estado IS 'Estado activo/inactivo (true=activo, false=inactivo).';
COMMENT ON COLUMN propuesta_plan_modulos.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN propuesta_plan_modulos.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla propuesta_plan_items
COMMENT ON TABLE propuesta_plan_items IS 'Elementos o temas específicos que componen cada módulo del plan de estudio.';
COMMENT ON COLUMN propuesta_plan_items.id IS 'ID único autoincremental.';
COMMENT ON COLUMN propuesta_plan_items.modulo_id IS 'ID del módulo al que pertenece el item (FK a propuesta_plan_modulos.id).';
COMMENT ON COLUMN propuesta_plan_items.titulo IS 'Título del tema o contenido específico.';
COMMENT ON COLUMN propuesta_plan_items.detalle IS 'Detalle ampliado del contenido del tema.';
COMMENT ON COLUMN propuesta_plan_items.orden IS 'Orden secuencial del item dentro del módulo.';
COMMENT ON COLUMN propuesta_plan_items.estado IS 'Estado activo/inactivo (true=activo, false=inactivo).';
COMMENT ON COLUMN propuesta_plan_items.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN propuesta_plan_items.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla propuesta_pagos_info
COMMENT ON TABLE propuesta_pagos_info IS 'Opciones y modalidades de pago disponibles para cada propuesta académica.';
COMMENT ON COLUMN propuesta_pagos_info.id IS 'ID único autoincremental.';
COMMENT ON COLUMN propuesta_pagos_info.propuesta_id IS 'ID de la propuesta académica (FK a propuestas.id).';
COMMENT ON COLUMN propuesta_pagos_info.concepto IS 'Concepto o descripción de la opción de pago. Ej: Contado, 3 cuotas, Promo especial.';
COMMENT ON COLUMN propuesta_pagos_info.importe IS 'Importe total o valor de la cuota según corresponda.';
COMMENT ON COLUMN propuesta_pagos_info.cuotas IS 'Número de cuotas (NULL para pago contado).';
COMMENT ON COLUMN propuesta_pagos_info.observaciones IS 'Observaciones adicionales sobre la modalidad de pago.';
COMMENT ON COLUMN propuesta_pagos_info.estado IS 'Estado activo/inactivo (true=activo, false=inactivo).';
COMMENT ON COLUMN propuesta_pagos_info.creado_en IS 'Fecha y hora de creación del registro.';

-- Tabla propuesta_contactos
COMMENT ON TABLE propuesta_contactos IS 'Información de contacto específica para cada propuesta académica.';
COMMENT ON COLUMN propuesta_contactos.id IS 'ID único autoincremental.';
COMMENT ON COLUMN propuesta_contactos.propuesta_id IS 'ID de la propuesta académica (FK a propuestas.id).';
COMMENT ON COLUMN propuesta_contactos.nombre IS 'Nombre de la persona o área de contacto.';
COMMENT ON COLUMN propuesta_contactos.email IS 'Correo electrónico de contacto.';
COMMENT ON COLUMN propuesta_contactos.telefono IS 'Teléfono de contacto.';
COMMENT ON COLUMN propuesta_contactos.horario_atencion IS 'Horario de atención al público.';
COMMENT ON COLUMN propuesta_contactos.tipo IS 'Tipo de contacto: administrativo, académico, pagos, general.';
COMMENT ON COLUMN propuesta_contactos.orden IS 'Orden de aparición en la web para mostrar múltiples contactos.';
COMMENT ON COLUMN propuesta_contactos.estado IS 'Estado activo/inactivo (true=activo, false=inactivo).';
COMMENT ON COLUMN propuesta_contactos.creado_en IS 'Fecha y hora de creación del registro.';


-- Tabla portales
COMMENT ON TABLE portales IS 'Contenido y configuración específica para la publicación web de cada propuesta académica. Incluye información promocional, SEO y datos para llenar las páginas web.';
COMMENT ON COLUMN portales.id IS 'ID único autoincremental.';
COMMENT ON COLUMN portales.propuesta_id IS 'ID de la propuesta académica asociada (FK a propuestas.id). Relación 1:1.';
COMMENT ON COLUMN portales.titulo_web IS 'Título optimizado para la web, puede ser más atractivo o descriptivo que el título académico oficial.';
COMMENT ON COLUMN portales.slug IS 'URL amigable única para el portal web. Formato: nombre-curso-año. Ej: diplomatura-ortodoncia-2024.';
COMMENT ON COLUMN portales.banner_img IS 'URL o ruta de la imagen de cabecera/banner principal del portal web (recomendado 1200x400px).';
COMMENT ON COLUMN portales.acerca_de IS 'Descripción general y atractiva del curso (200-500 caracteres). Objetivos principales y beneficios.';
COMMENT ON COLUMN portales.perfil_estudiante IS 'Descripción del perfil ideal del participante (100-300 caracteres).';
COMMENT ON COLUMN portales.requisitos IS 'Requisitos de admisión y participación (100-300 caracteres).';
COMMENT ON COLUMN portales.destinatarios IS 'Público objetivo específico para el que está destinado el curso (100-300 caracteres).';
COMMENT ON COLUMN portales.fundamentacion IS 'Argumentos y razones por las que estudiar este curso (200-500 caracteres). Beneficios y valor agregado.';
COMMENT ON COLUMN portales.etiquetas IS 'Etiquetas o tags separados por coma para búsqueda interna y categorización. Ej: salud, tecnología, educación.';
COMMENT ON COLUMN portales.meta_og_title IS 'Título optimizado para compartir en redes sociales (Open Graph) - máximo 60 caracteres.';
COMMENT ON COLUMN portales.meta_og_image IS 'Imagen optimizada para compartir en redes sociales (Open Graph) - recomendado 1200x630px.';
COMMENT ON COLUMN portales.meta_description IS 'Meta descripción para motores de búsqueda (SEO) - ideal 150-160 caracteres.';
COMMENT ON COLUMN portales.meta_keywords IS 'Palabras clave para SEO separadas por coma - máximo 10-15 palabras clave relevantes.';
COMMENT ON COLUMN portales.visitas IS 'Contador de visitas al portal web para análisis de tráfico.';
COMMENT ON COLUMN portales.estado IS 'Estado de publicación del portal (true=publicado visible en web, false=no publicado).';
COMMENT ON COLUMN portales.creado_en IS 'Fecha y hora de creación del registro del portal.';
COMMENT ON COLUMN portales.actualizado_en IS 'Fecha y hora de última actualización del contenido del portal.';


-- Tabla inscripciones
COMMENT ON TABLE inscripciones IS 'Inscripciones a propuestas académicas o eventos. Contiene los datos personales, de contacto y estado actual de cada inscripto.';
COMMENT ON COLUMN inscripciones.id IS 'ID único autoincremental.';
COMMENT ON COLUMN inscripciones.propuesta_id IS 'ID de la propuesta a la que se inscribe (FK a propuesta.id).';
COMMENT ON COLUMN inscripciones.modalidad_id IS 'ID de la modalidad elegida (FK a modalidad.id).';
COMMENT ON COLUMN inscripciones.tipo_documento_id IS 'ID del tipo de documento (FK a tipo_documento.id).';
COMMENT ON COLUMN inscripciones.tipo_estado_inscripcion_id IS 'ID del estado actual de la inscripción (FK a tipo_estado_inscripcion.id).';
COMMENT ON COLUMN inscripciones.documento IS 'Número de documento del inscripto.';
COMMENT ON COLUMN inscripciones.apellido IS 'Apellido del inscripto.';
COMMENT ON COLUMN inscripciones.nombre IS 'Nombre del inscripto.';
COMMENT ON COLUMN inscripciones.apellido_nombre IS 'Apellido y nombre concatenados (derivado).';
COMMENT ON COLUMN inscripciones.fecha_nacimiento IS 'Fecha de nacimiento.';
COMMENT ON COLUMN inscripciones.sexo IS 'Sexo (M: Masculino, F: Femenino, O: Otro).';
COMMENT ON COLUMN inscripciones.edad IS 'Edad calculada.';
COMMENT ON COLUMN inscripciones.email IS 'Email de contacto.';
COMMENT ON COLUMN inscripciones.telefono IS 'Teléfono de contacto.';
COMMENT ON COLUMN inscripciones.domicilio IS 'Domicilio particular.';
COMMENT ON COLUMN inscripciones.codigo_postal IS 'Código postal.';
COMMENT ON COLUMN inscripciones.ciudad IS 'Ciudad de residencia.';
COMMENT ON COLUMN inscripciones.provincia IS 'Provincia de residencia.';
COMMENT ON COLUMN inscripciones.pais IS 'País de residencia.';
COMMENT ON COLUMN inscripciones.ciudad_nacimiento IS 'Ciudad de nacimiento.';
COMMENT ON COLUMN inscripciones.colegio IS 'Colegio o institución de procedencia.';
COMMENT ON COLUMN inscripciones.profesion IS 'Profesión u ocupación.';
COMMENT ON COLUMN inscripciones.lugar_trabajo IS 'Lugar de trabajo actual.';
COMMENT ON COLUMN inscripciones.numero_socio IS 'Número de socio institucional.';
COMMENT ON COLUMN inscripciones.es_socio IS 'Indica si es socio (SI/NO).';
COMMENT ON COLUMN inscripciones.fecha_inscripcion IS 'Fecha y hora de la inscripción.';
COMMENT ON COLUMN inscripciones.baja IS 'Indica si la inscripción está dada de baja (true=baja, false=activa).';
COMMENT ON COLUMN inscripciones.fecha_baja IS 'Fecha de baja de la inscripción.';
COMMENT ON COLUMN inscripciones.pago_mercadopago IS 'Indica si el pago se realizó por MercadoPago.';
COMMENT ON COLUMN inscripciones.codigo_concepto IS 'Código de concepto para pagos.';
COMMENT ON COLUMN inscripciones.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN inscripciones.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla certificaciones
COMMENT ON TABLE certificaciones IS 'Registro principal de certificaciones emitidas con control de versiones.';
COMMENT ON COLUMN certificaciones.id IS 'ID único autoincremental.';
COMMENT ON COLUMN certificaciones.inscripcion_id IS 'ID de la inscripción certificada (FK a inscripcion.id).';
COMMENT ON COLUMN certificaciones.tipo_estado_certificado_id IS 'ID del estado del certificado (FK a tipo_estado_certificado.id).';
COMMENT ON COLUMN certificaciones.uuid IS 'UUID4 único para identificación universal.';
COMMENT ON COLUMN certificaciones.token IS 'Token único para validación y acceso público.';
COMMENT ON COLUMN certificaciones.fecha_finalizacion IS 'Fecha de finalización del curso para el certificado.';
COMMENT ON COLUMN certificaciones.fecha_emision IS 'Fecha de emisión del certificado.';
COMMENT ON COLUMN certificaciones.metadata IS 'Metadatos adicionales en formato JSON.';
COMMENT ON COLUMN certificaciones.version IS 'Número de versión del certificado.';
COMMENT ON COLUMN certificaciones.es_version_actual IS 'Indica si esta es la versión actual del certificado.';
COMMENT ON COLUMN certificaciones.motivo_cambio IS 'Motivo del cambio de versión.';
COMMENT ON COLUMN certificaciones.estado IS 'Estado activo/inactivo del certificado (true=activo, false=inactivo).';
COMMENT ON COLUMN certificaciones.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN certificaciones.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla certificacion_autoridad
COMMENT ON TABLE certificacion_autoridad IS 'Relación muchos a muchos entre certificaciones y autoridades que las firman. Define el orden de firma.';
COMMENT ON COLUMN certificacion_autoridad.id IS 'ID único autoincremental.';
COMMENT ON COLUMN certificacion_autoridad.certificacion_id IS 'ID de la certificación (FK a certificacion.id).';
COMMENT ON COLUMN certificacion_autoridad.autoridad_id IS 'ID de la autoridad que firma (FK a autoridad.id).';
COMMENT ON COLUMN certificacion_autoridad.orden IS 'Orden de firma (0=primero, 1=segundo, etc.).';
COMMENT ON COLUMN certificacion_autoridad.creado_en IS 'Fecha y hora de creación del registro.';


/*
-- Tabla usuarios
COMMENT ON TABLE usuarios IS 'Tabla maestra de usuarios del sistema institucional.';
COMMENT ON COLUMN usuarios.id IS 'ID único autoincremental.';
COMMENT ON COLUMN usuarios.dni IS 'Número de documento único.';
COMMENT ON COLUMN usuarios.nombre IS 'Nombre del usuario.';
COMMENT ON COLUMN usuarios.apellido IS 'Apellido del usuario.';
COMMENT ON COLUMN usuarios.email IS 'Email único del usuario.';
COMMENT ON COLUMN usuarios.password IS 'Contraseña cifrada.';
COMMENT ON COLUMN usuarios.telefono IS 'Teléfono de contacto.';
COMMENT ON COLUMN usuarios.estado IS 'Estado activo/inactivo del usuario (true=activo, false=inactivo).';
COMMENT ON COLUMN usuarios.creado_en IS 'Fecha y hora de creación del registro.';
COMMENT ON COLUMN usuarios.actualizado_en IS 'Fecha y hora de última actualización del registro.';

-- Tabla modulos
COMMENT ON TABLE modulos IS 'Módulos funcionales del sistema de gestión académica.';
COMMENT ON COLUMN modulos.id IS 'ID único autoincremental.';
COMMENT ON COLUMN modulos.nombre IS 'Nombre del módulo. Ej: Inscripciones, Certificaciones, Reportes.';
COMMENT ON COLUMN modulos.descripcion IS 'Descripción del módulo.';
COMMENT ON COLUMN modulos.estado IS 'Estado activo/inactivo del módulo (true=activo, false=inactivo).';
COMMENT ON COLUMN modulos.orden IS 'Orden de aparición en menús.';

-- Tabla operaciones
COMMENT ON TABLE operaciones IS 'Operaciones o acciones específicas disponibles dentro de cada módulo.';
COMMENT ON COLUMN operaciones.id IS 'ID único autoincremental.';
COMMENT ON COLUMN operaciones.nombre IS 'Nombre de la operación. Ej: crear, leer, actualizar, eliminar.';
COMMENT ON COLUMN operaciones.descripcion IS 'Descripción de la operación.';
COMMENT ON COLUMN operaciones.codigo IS 'Código único para identificación programática.';
COMMENT ON COLUMN operaciones.modulo_id IS 'ID del módulo al que pertenece (FK a modulo.id).';

-- Tabla roles
COMMENT ON TABLE roles IS 'Catálogo de roles institucionales para asignación de permisos.';
COMMENT ON COLUMN roles.id IS 'ID único autoincremental.';
COMMENT ON COLUMN roles.nombre IS 'Nombre del rol. Ej: Administrador, Secretario, Docente.';
COMMENT ON COLUMN roles.descripcion IS 'Descripción del rol.';
COMMENT ON COLUMN roles.estado IS 'Estado activo/inactivo del rol (true=activo, false=inactivo).';
COMMENT ON COLUMN roles.creado_en IS 'Fecha y hora de creación del registro.';

-- Tabla rol_operacion
COMMENT ON TABLE rol_operacion IS 'Relación muchos a muchos entre roles y operaciones. Define qué operaciones puede realizar cada rol.';
COMMENT ON COLUMN rol_operacion.rol_id IS 'ID del rol (FK a rol.id).';
COMMENT ON COLUMN rol_operacion.operacion_id IS 'ID de la operación (FK a operacion.id).';

-- Tabla usuario_permiso
COMMENT ON TABLE usuario_permiso IS 'Asignación granular de permisos de usuarios por módulo y unidad académica.';
COMMENT ON COLUMN usuario_permiso.id IS 'ID único autoincremental.';
COMMENT ON COLUMN usuario_permiso.usuario_id IS 'ID del usuario (FK a usuario.id).';
COMMENT ON COLUMN usuario_permiso.rol_id IS 'ID del rol asignado (FK a rol.id).';
COMMENT ON COLUMN usuario_permiso.unidad_id IS 'ID de la unidad académica (FK a unidad.id).';
COMMENT ON COLUMN usuario_permiso.modulo_id IS 'ID del módulo (FK a modulo.id).';
COMMENT ON COLUMN usuario_permiso.estado IS 'Estado activo/inactivo del permiso (true=activo, false=inactivo).';
COMMENT ON COLUMN usuario_permiso.creado_en IS 'Fecha y hora de creación del registro.';

-- Tabla historial_estado_propuestas
COMMENT ON TABLE historial_estado_propuestas IS 'Tabla de trazabilidad de los estados por los que pasa una propuesta.';
COMMENT ON COLUMN historial_estado_propuestas.propuesta_id IS 'ID de la propuesta (FK a propuesta.id).';
COMMENT ON COLUMN historial_estado_propuestas.tipo_estado_propuesta_id IS 'ID del estado asignado (FK a tipo_estado_propuesta.id).';
COMMENT ON COLUMN historial_estado_propuestas.usuario_id IS 'ID del usuario que realizó el cambio (FK a usuario.id).';
COMMENT ON COLUMN historial_estado_propuestas.creado_en IS 'Fecha y hora del cambio de estado.';

-- Tabla historial_estado_inscripciones
COMMENT ON TABLE historial_estado_inscripciones IS 'Tabla de trazabilidad de los estados por los que pasa una inscripción.';
COMMENT ON COLUMN historial_estado_inscripciones.inscripcion_id IS 'ID de la inscripción (FK a inscripcion.id).';
COMMENT ON COLUMN historial_estado_inscripciones.tipo_estado_inscripcion_id IS 'ID del estado asignado (FK a tipo_estado_inscripcion.id).';
COMMENT ON COLUMN historial_estado_inscripciones.usuario_id IS 'ID del usuario que realizó el cambio (FK a usuario.id).';
COMMENT ON COLUMN historial_estado_inscripciones.creado_en IS 'Fecha y hora del cambio de estado.';

-- Tabla historial_estado_certificaciones
COMMENT ON TABLE historial_estado_certificaciones IS 'Tabla de trazabilidad de los estados por los que pasa una certificación.';
COMMENT ON COLUMN historial_estado_certificaciones.certificacion_id IS 'ID de la certificación (FK a certificacion.id).';
COMMENT ON COLUMN historial_estado_certificaciones.tipo_estado_certificado_id IS 'ID del estado asignado (FK a tipo_estado_certificado.id).';
COMMENT ON COLUMN historial_estado_certificaciones.usuario_id IS 'ID del usuario que realizó el cambio (FK a usuario.id).';
COMMENT ON COLUMN historial_estado_certificaciones.creado_en IS 'Fecha y hora del cambio de estado.';

*/