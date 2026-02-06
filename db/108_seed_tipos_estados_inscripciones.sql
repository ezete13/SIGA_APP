INSERT INTO tipos_estado_inscripcion (codigo, nombre, descripcion) VALUES
('SOL', 'Solicitante', 'Estado inicial: el alumno completa el formulario web. La inscripción se registra automáticamente, descuenta cupo y aún no está validada por la universidad.'),
('PRE', 'Preinscripto', 'La inscripción se encuentra en revisión administrativa. Los datos del alumno pueden ser verificados y requerir correcciones. Aún no está confirmada de forma definitiva.'),
('INS', 'Inscripto', 'Inscripción aceptada por la universidad. El alumno forma parte oficialmente del curso, luego de confirmación administrativa y/o gestión de pago.'),
('BAJ', 'Baja', 'El alumno deja de formar parte del curso por decisión propia o causas administrativas. No continúa participando.'),
('FIN', 'Finalizado', 'El alumno completó el curso y está en condiciones de recibir certificado. La inscripción queda cerrada a modificaciones.');
