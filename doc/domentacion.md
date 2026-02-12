## Preinscripciones

El sistema permite la gestión de **Preinscripciones** de aspirantes a través del portal web institucional. Esta entidad actúa como el disparador del proceso de admisión y regula la transición del aspirante hacia la formalización de su inscripción.

### Ciclo de Vida

El estado de una preinscripción determina las acciones permitidas y su relación con otras entidades del sistema:

1. **En Espera:** Toda preinscripción creada desde la página web asume este estado por defecto. En esta etapa, el registro es preventivo y no permite la vinculación de una **Inscripción** formal.
2. **Aprobada:** Tras la validación de un usuario administrativo, la preinscripción cambia a este estado. Este cambio es el **único habilitador** para que el registro se asocie a una **Inscripción**.
3. **Revocada:** Un administrativo puede dar por finalizado el proceso negando la solicitud. Una preinscripción en este estado queda inhabilitada para generar inscripciones.

### Reglas de Negocio

Para asegurar la integridad de los datos, se deben aplicar las siguientes validaciones:

* **Validación de Identidad Obligatoria:** No se puede transicionar una preinscripción al estado **"Aprobada"** si el aspirante no está registrado previamente como **Alumno** en el sistema. El administrativo deberá crear o vincular al alumno antes de proceder con la aprobación.
* **Restricción de Asociación:** Solo las preinscripciones con estado **"Aprobada"** pueden tener una **Inscripción** asociada. El sistema debe bloquear cualquier intento de crear una inscripción si el estado es "En Espera" o "Revocada".
* **Integridad de Datos:** La Preinscripción debe mantener integridad referencial con las entidades de **Alumno**, **Propuesta Académica** y **Estado de Preinscripción**.
* **Disparadores (Triggers):** Al confirmar la transición al estado **"Aprobada"**, el sistema debe:
1. Vincular permanentemente el `AlumnoId` al registro de Preinscripción.
2. Ejecutar la migración de datos hacia la entidad **Inscripciones**.
3. Notificar automáticamente al aspirante sobre su nueva condición.

---

## Alumnos

La entidad **Alumno** representa al individuo dentro del ecosistema académico. Su existencia es única y centralizada, permitiendo que un mismo sujeto posea múltiples trayectorias académicas a través de diversas inscripciones.

### Proceso de Conversión (Preinscripción a Alumno)

Cuando una **Preinscripción** transiciona al estado **"Aprobada"**, el sistema debe ejecutar un servicio de automatización de identidad bajo las siguientes reglas:

1. **Verificación de Identidad:** El sistema realizará una búsqueda mandatoria por **DNI** (o documento equivalente).
* **Si el Alumno no existe:** Se procede a la creación del registro maestro de Alumno con los datos provistos en la preinscripción.
* **Si el Alumno ya existe:** Se reutiliza el registro existente, evitando la duplicidad de datos.

2. **Generación de Inscripción:** Independientemente de si el alumno es nuevo o existente, el servicio creará una nueva entidad **Inscripción** vinculando el `AlumnoId` con la `PropuestaId` seleccionada.
3. **Relación Uno a Muchos:** El sistema debe garantizar que un Alumno pueda estar asociado a múltiples Inscripciones, pero un Alumno nunca debe duplicarse en la base de datos.

### Ciclo de Vida y Estados del Alumno

El estado del alumno regula su capacidad operativa dentro de la institución y depende de su situación académica o administrativa:

* **Activo:** El alumno posee al menos una inscripción vigente. Está habilitado para inscribirse a nuevas propuestas, solicitar certificados y participar en actividades institucionales.
* **Inactivo:** El alumno no posee inscripciones vigentes (por egreso, baja voluntaria o falta de actividad). No posee sanciones, pero tiene restringido el acceso a beneficios de alumno regular hasta que inicie un nuevo proceso.
* **Suspendido:** Estado de penalización temporal (ej. 6 meses). El alumno mantiene su historial, pero tiene bloqueada la creación de nuevas inscripciones y el cursado por un periodo determinado. Puede retornar al estado **Activo** de forma automática (por fecha) o manual.
* **Bloqueado:** Estado de veto permanente o por decisión administrativa grave (fraude, documentación apócrifa). El alumno pierde todo derecho a trámites, certificados o nuevas inscripciones.

### Reglas de Negocio y Transiciones

Para mantener el control sobre la matrícula, se aplican las siguientes restricciones de estado:

* **Persistencia de Sanciones:** Un alumno en estado **Bloqueado** o **Suspendido** no puede transicionar a otros estados de forma automática por el sistema (por ejemplo, al aprobar una nueva preinscripción). Cualquier cambio de estos estados debe ser auditado y ejecutado por un usuario administrativo de alto rango.
* **Cálculo Automático de Actividad:** El sistema debe verificar periódicamente el estado de las inscripciones asociadas. Si un alumno cierra su última inscripción activa, su estado debe virar automáticamente a **Inactivo**.
* **Restricción de Egreso:** No se podrán emitir certificados analíticos finales o títulos si el alumno se encuentra en estado **Suspendido** o **Bloqueado**.

---

## Inscripciones

La entidad **Inscripción** formaliza el vínculo entre un **Alumno** y una **Propuesta Académica**. Es el resultado directo de una **Preinscripción Aprobada** y representa la trayectoria activa o histórica del estudiante en la institución.

### Ciclo de Vida de la Inscripción

El estado de una inscripción es determinante para la condición de "Regularidad" del alumno:

1. **Activa:** Representa el cursado vigente. Se genera automáticamente al aprobarse la preinscripción. Solo puede existir una inscripción activa por alumno para una misma propuesta.
2. **Finalizada:** Estado de cierre de ciclo (por aprobación total o cumplimiento de términos). Este estado es **irreversible**; una vez finalizada, la inscripción no puede retornar al estado Activa.
3. **Baja:** Cierre prematuro de la inscripción por solicitud del alumno o decisión administrativa. Invalida la cursada actual pero permite futuras preinscripciones a la misma propuesta.

### Reglas de Negocio y Validación

Para garantizar la consistencia del modelo académico, se deben cumplir las siguientes restricciones:

* **Unicidad y Restricción de Duplicidad:** El sistema debe impedir que un alumno se inscriba a una propuesta en la que ya posee una inscripción **Activa** o **Finalizada**.
* *Excepción:* Solo se permitirá una nueva inscripción a la misma propuesta si la anterior posee estado **Baja**.


* **Dependencia de Preinscripción:** No existe inscripción sin preinscripción. Toda **Inscripción** debe mantener una relación obligatoria  con una **Preinscripción** en estado **"Aprobada"**.
* **Gestión de Finalización:** La transición al estado **Finalizada** puede ejecutarse de dos formas:
1. **Manual:** Un administrador marca la inscripción como concluida.
2. **Programada:** El sistema ejecuta un proceso automático basada en una fecha de fin de vigencia preestablecida.


* **Impacto en el Estado del Alumno:** Al momento de cambiar una inscripción a **Finalizada** o **Baja**, el sistema debe verificar el resto de las inscripciones del alumno. Si no cuenta con ninguna otra en estado **Activa**, el **Alumno** debe transicionar automáticamente al estado **Inactivo**.

---

Claro que sí. He integrado el análisis de irregularidades directamente en el cuerpo del documento, presentándolas como **"Reglas de Validación de Integridad"**. Esto le da un carácter más normativo y técnico al requerimiento, ideal para que un desarrollador o arquitecto de software lo tome como base.

---

## Inscripciones

La entidad **Inscripción** formaliza el vínculo entre un **Alumno** y una **Propuesta Académica**. Es el resultado directo de una **Preinscripción Aprobada** y representa la trayectoria activa o histórica del estudiante en la institución.

### Ciclo de Vida de la Inscripción

El estado de una inscripción es determinante para la condición de actividad del alumno:

1. **Activa:** Representa el cursado vigente. Se genera automáticamente al aprobarse la preinscripción.
2. **Finalizada:** Estado de cierre de ciclo (por aprobación total o cumplimiento de términos). Este estado es **irreversible**.
3. **Baja:** Cierre prematuro por solicitud del alumno o decisión administrativa. Invalida la cursada actual.

### Reglas de Negocio y Validación

Para garantizar la consistencia del modelo académico, se deben cumplir las siguientes restricciones:

* **Dependencia de Preinscripción:** Toda **Inscripción** debe poseer una relación obligatoria  con una **Preinscripción** en estado **"Aprobada"**. No existen inscripciones huérfanas o creadas manualmente sin este disparador.
* **Unicidad y Restricción de Duplicidad:** El sistema debe impedir que un alumno se inscriba a una propuesta en la que ya posee una inscripción vigente.
* **Bloqueo:** No se puede crear una inscripción si el alumno ya tiene una inscripción **Activa** o **Finalizada** para la misma propuesta.
* **Excepción:** Solo se permitirá una nueva inscripción a la misma propuesta si la anterior posee estado **Baja**.


* **Gestión de Finalización:** La transición al estado **Finalizada** puede ser ejecutada por un administrativo o mediante un proceso programado. Una vez en este estado, la inscripción no puede retornar a **Activa**.
* **Impacto en el Alumno:** Al cambiar una inscripción a **Finalizada** o **Baja**, el sistema debe verificar el resto de las inscripciones del alumno. Si no cuenta con ninguna otra en estado **Activa**, el **Alumno** pasará automáticamente a **Inactivo**.

---

### Validación de Irregularidades y Casos de Borde

Para asegurar la robustez del servicio de conversión, se deben contemplar los siguientes escenarios críticos:

#### 1. Conflicto de Identidad y Sanciones Previas

Si al intentar crear la inscripción el sistema detecta mediante el DNI que el Alumno ya existe y posee un estado de **Bloqueado** o **Suspendido**:

* **Acción:** El sistema debe abortar el proceso de inscripción.
* **Regla:** Un alumno con sanciones vigentes no puede generar nuevas inscripciones aunque su preinscripción web haya sido aprobada inicialmente.

#### 2. Atomicidad del Proceso de Conversión

Existe el riesgo de que la preinscripción cambie a "Aprobada" pero el servicio de creación de Alumno o Inscripción falle.

* **Acción:** La actualización del estado de la Preinscripción, la búsqueda/creación del Alumno y el alta de la Inscripción deben ejecutarse dentro de una **transacción única**. Si falla un paso, se debe realizar un *rollback* completo.

#### 3. Validación de Vigencia Temporal

* **Regla:** El sistema debe impedir que la `Fecha de Finalización` (programada o manual) sea cronológicamente anterior a la `Fecha de Alta` de la inscripción.

#### 4. Reintentos de Inscripción post-Baja

* **Escenario:** Un alumno con una inscripción previa en estado **Baja** realiza una nueva preinscripción.
* **Regla:** El sistema debe permitir la nueva inscripción pero está estrictamente prohibido crear un nuevo registro de Alumno. Se debe reutilizar el `AlumnoId` original para mantener la trazabilidad histórica del sujeto.



3. Validación de Duplicidad (Nivel Servicio de Aplicación)
Aunque la entidad Inscripcion gestiona su estado, la regla de "No se puede inscribir si ya tiene una Activa o Finalizada" debe validarse en el servicio que coordina la inscripción (Service Layer), consultando el repositorio:

Regla Pro: "No permitas CrearDesdePreinscripcion si repo.Any(x => x.AlumnoId == id && x.PropuestaId == pid && x.Estado != Baja)".



