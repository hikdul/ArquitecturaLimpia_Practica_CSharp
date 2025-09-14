
# Dientes Limpios


practica para trabajar el curso de Arquitectura Limpia de Felipe Gavilan. La idea de este curso es separar todo el trabajo por capas para asi en caso de crecer el trabajo de modificacion de codigo sea mas sencillo y modificable.

La diferencia entre este modelo de trabajo y los otros es que con este modelo antes de tener algo funcionando se lleva bastante tiempo pero luego si existen modificaciones lleva mucho menos trabajo.


## Capas

### API
describir capa

### Core

#### Capa de Dominio
Caracteristicas de esta capa de dominio es el corazon del sistema, modela el negocio de manera precisa sin preocuparse en como trabajo tecnicamente; algunas caracteristicas son:

* es donde se modelan conceptos, gegas o invariantes.
* No depende de nada externo, ni conoce base de datos, ni persistencia, ni tipo de aplicaicon.
* expresa correctamente el procedimiento del negocion

Cosas que contiete esta capa
* __Entidades__, objeton con identidad propia y que encapsulan comportamientos y reglas
* __Objetos de valor__, elementos que no tienen identidad pero encapsulan comportamientos necesarios para el negocio
* __Reglas del negocion__, donde se define que es y que no es valido para trabajar en el negocio.
* __Agregados__, conjunto de objetos de dominios que se tratan como unidad valida, siempre encabezado por una raiz. las invariantes son reglas del negocio que siempre se deben de cumplir.

Para las __excepciones del dominios__, generalmente se genera una regla de negocia que indica que una regla fue inflijida. la idea es que sea una excepcion personalizada que indique que se incumple una regla de negocio

Esta capa no debe de contener ningun detalles tecnico.

Evitar tener __entidades anemicas__, que son aquellas entidades creadas pero que aparte de las propiedades no ofrecen ningun tipo de logica sobre las actividades del negocio.

#### Capa De Aplicacion

Esta capa solo tendra comunicacion con la capa de dominio. de modo simple la capa de aplicacion se encarga de orquestar los casos de uso del sistema, donde a su ves los casos de uso son las acciones especificas que se realizan para cubrir las necesidades de los usuarios.

Esta capa no tiene con sigo los detalles de implementacion o detalles tecnicos; simplemente orquesta las acciones para el cumplimiento de tareas por medio de contratos, que en si los contratos son interfaces que permiten y ayudan a completar todas estas acciones.

#### se usara el patron CQRS para completar la capa de aplicacian 

 __CQRS__ (Command Query Responsibility Segregation o en espanol seria: separacion de responsabilidades entre comandos y consultas) es un patrón de arquitectura de software que separa la lógica de lectura (queries) de la lógica de escritura (commands) en un sistema. Permite optimizar estos dos modelos de datos de manera independiente, mejorando la escalabilidad, el rendimiento y la flexibilidad. Las ventajas incluyen la posibilidad de escalar subsistemas de lectura y escritura de forma independiente y utilizar tecnologías distintas, pero también introduce complejidad y posibles problemas de consistencia de datos. 
 
 * comando, es una accio que modifica el sistema. este puede devolver o no un valor pero si modifica el estado.
 * consulta, es una opecacion que busca una accion pero no modifica nada en el sistema. este no modifica el estado pero si devuelve algo(incluso vacio).
 
 porque se usa este patron:
- nos permita aplicar el principio de responsabilidad unica de manera explicita
- El codigo se organiza de manera organica
- simplifica la aplicacion de pruebas automaticas
- es muy util para el contexto de arquitectura de limpia.
- permite separa incluso elementos tecnicos como por ejemplos tener base de datos distintas para lectura(consultas) y escritura(comandos).

__Unit of work:__ este patron lo que hace es genera transaciones para que si todos los evento ocurren de manera positiva, pues todo se ejecute; y si no es asi o si al menos un elemento de la lista de tareas se cae, pues todo se caiga.


### Infraestructura

esta es la capa encargada de interaccioter con elementos externos; por ejempol bases de datos, envio de correo electronico y ese tipo de servicios. Viene a ser la capa mas externa de nuestra aplicacion.

Una de las nociones basicas es que esta capa no contienen ningun tipo de logica del negacio, su papel es hacer uno implementacion tecnica.

la **responsabilidad** principal es implementar los contratos definidos por las capas interiones; de otro modo es la encargada de ejecutar el _"como"_.

Para la comunicacion con las demas capas se usa el principio de **inversion de dependencias**

Mayormente se puede tener un solo proyecto para mantener esa capa, pero en este caso vamos a trabajar con varios como son:

#### Persistencia
Se encarga de acceso a dase de datos

#### General
Para la implementacion de diferentes servicios como el correos electronico

#### Identidad
Trabaja con todo lo relacionado con auteticacion.

### Pruebas

es la capa donde se generan las pruebas de todas las otras capas; asi de otro modo es donde se realizan las pruebas de cada elemento por separado y tiene conexion con todas las capas del sistema pero a su ves es una capa que se limita a solo realiza eso pruebas.