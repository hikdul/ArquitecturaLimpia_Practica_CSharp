
# Dientes Limpios


practica para trabajar el curso de Arquitectura Limpia de Felipe Gavilan. La idea de este curso es separar todo el trabajo por capas para asi en caso de crecer el trabajo de modificacion de codigo sea mas sencillo y modificable.

La diferencia entre este modelo de trabajo y los otros es que con este modelo antes de tener algo funcionando se lleva bastante tiempo pero luego si existen modificaciones lleva mucho menos trabajo.


## Capas

### API
describir capa

### Core

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


### Infraestructura
describir capa

### Pruebas
describir capa