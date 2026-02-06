INSERT INTO tipos_estado_certificado (codigo, nombre, descripcion) VALUES
('NOG', 'No Generable', 'Estado inicial: el alumno aún no cumple requisitos. El certificado no puede generarse, editarse ni eliminarse.'),
('PEN', 'Pendiente', 'El alumno cumple requisitos. El certificado puede generarse pero aún no existe emitido. No permite edición.'),
('GEN', 'Generado', 'El certificado fue emitido y registrado. Solo puede modificarse mediante versionado y no puede eliminarse.'),
('APR', 'Aprobado', 'Certificado validado institucionalmente. No puede modificarse ni eliminarse y es plenamente oficial.'),
('INH', 'Inhabilitado', 'Certificado temporalmente no válido por revisión o inconsistencias. No puede editarse ni eliminarse. El QR refleja no validez.'),
('REV', 'Revocado', 'Certificado invalidado definitivamente. No puede modificarse ni eliminarse. El QR indica revocación y no validez.');
