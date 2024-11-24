# **GDD (GAME DESIGN DOCUMENT)**

![Ilustración 0: Título del juego](Elementos%20de%20Diseño/Titulo%20del%20Juego/EchosOfXyphoriaLeteringFINAL.png)


*El espacio es un vasto océano de estrellas y misterio, donde la luz viaja por eternidades y los planetas giran en silenciosa armonía. Es un lienzo infinito, salpicado por galaxias lejanas, nebulosas brillantes, y la promesa de lo desconocido.* 

*En su inmensidad, nos recuerda lo pequeños que somos, y a la vez, lo grandes que pueden ser nuestros sueños cuando miramos hacia el cielo.*

*Cada rincón del espacio esconde secretos aún no desvelados: mundos lejanos, civilizaciones extintas, y fenómenos tan asombrosos que desafían nuestra comprensión.* 

*Es un lugar donde el tiempo parece detenerse, y a la vez, moverse a una escala inimaginable.* 

*Nos invita a soñar, a preguntarnos sobre nuestro lugar en este inmenso tapiz cósmico y a explorar lo inexplorado, recordándonos que, aunque pequeños frente a su grandeza, nuestras ansias de descubrimiento no tienen límite.*

![Ilustración 0.5: Logo de la empresa](Elementos%20de%20Diseño/Logo%20empresa/invLogo.png)

# **Índice de contenidos**

## Índice de Contenidos

- [0 Historial de versiones](#0-historial-de-versiones)
- [1 Introducción](#1-introducción)
  - [1.1 Concepto de juego](#11-concepto-de-juego)
  - [1.2 Descripción general](#12-descripción-general)
  - [1.3 Género y ambientación](#13-género-y-ambientación)
  - [1.4 Jugabilidad](#14-jugabilidad)
  - [1.5 Estilo visual](#15-estilo-visual)
  - [1.6 Alcance, propósito y público objetivo](#16-alcance-propósito-y-público-objetivo)
  - [1.7 Detalles técnicos](#17-detalles-técnicos)
  - [1.8 Licencia](#18-licencia)
  - [1.9 Motor de desarrollo](#19-motor-de-desarrollo)
- [2 Trasfondo](#2-trasfondo)
  - [2.1 Historia](#21-historia)
  - [2.2 Personajes](#22-personajes)
  - [2.3 Escenarios y lugares](#23-escenarios-y-lugares)
    - [2.3.1 Cuartel de la resistencia](#231-cuartel-de-la-resistencia)
    - [2.3.2 Ruinas de Xyphoria](#232-ruinas-de-xyphoria)
    - [2.3.3 Bahía de Arka](#233-bahía-de-arka)
    - [2.3.4 Ciudad Flotante de Aereth](#234-ciudad-flotante-de-aereth)
    - [2.3.5 Nido Tyrnax](#235-nido-tyrnax)
    - [2.3.6 Taller de Torko (Asignatura de comportamientos)](#236-taller-de-torko)
- [3 Mecánicas de juego](#3-mecánicas-de-juego)
  - [3.1 Flujo de juego (en qué consiste una partida)](#31-flujo-de-juego-en-qué-consiste-una-partida)
  - [3.2 Cámara](#32-cámara)
  - [3.3 Controles](#33-controles)
  - [3.4 Puntuación y competitivo](#34-puntuación-y-competitivo)
  - [3.5 Ventajas](#35-ventajas)
    - [3.5.1 Razas y sus ventajas](#351-razas-y-sus-ventajas)
  - [3.6 Mejoras](#36-mejoras)
  - [3.7 Enemigos](#37-enemigos)
    - [3.7.1 Tyrnaxiano Básico](#371-tyrnaxiano-básico)
    - [3.7.2 Tyrnaxiano Rápido](#372-tyrnaxiano-rápido)
    - [3.7.3 Tyrnaxiano Pesado](#373-tyrnaxiano-pesado)
    - [3.7.4 Tyrnaxiano Tóxico](#374-tyrnaxiano-tóxico)
    - [3.7.5 Jefe Tyrnaxiano](#375-jefe-tyrnaxiano)
- [4 Comportamiento de personajes](#4-comportamiento-de-personajes)
- [5 Interfaces](#5-interfaces)
  - [5.1 Interfaces del juego](#51-interfaces-del-juego)
    - [5.1.1 Pantalla de Inicio](#511-pantalla-de-inicio)
    - [5.1.2 Menú principal](#512-menú-principal)
    - [5.1.3 Menú de pausa](#513-menú-de-pausa)
    - [5.1.4 Pantalla de opciones](#514-pantalla-de-opciones)
    - [5.1.5 Pantalla de personalización](#515-pantalla-de-personalización)
    - [5.1.6 Pantalla de tutorial](#516-pantalla-de-tutorial)
    - [5.1.7 Pantalla de juego](#517-pantalla-de-juego)
    - [5.1.8 Pantalla de Fin de Partida](#518-pantalla-de-fin-de-partida)
    - [5.1.9 Pantalla de Tienda](#519-pantalla-de-tienda)
    - [5.1.10 Pantalla de Ranking](#5110-pantalla-de-ranking)
  - [5.2 Diagrama de flujo](#52-diagrama-de-flujo)
- [6 Arte](#6-arte)
  - [6.1 Estética general](#61-estética-general)
  - [6.2 Concept Art](#62-concept-art)
  - [6.3 Modelado 3D](#63-modelado-3d)
- [7 Animación](#7-animación)
  - [7.1 Escenario](#71-escenario)
  - [7.2 Personajes](#72-personajes)
    - [7.2.1 Rigging](#721-rigging)
    - [7.2.2 Skinning](#722-skinning)
- [8 Audio](#8-audio)
  - [8.1 Sonido ambiente y música](#81-sonido-ambiente-y-música)
  - [8.2 Efectos de sonido](#82-efectos-de-sonido)
- [9 Modelo de negocio y monetización](#9-modelo-de-negocio-y-monetización)
  - [9.1 Modelo de negocio](#91-modelo-de-negocio)
  - [9.2 Monetización](#92-monetización)
  - [9.3 Mapa de empatía](#93-mapa-de-empatía)
  - [9.4 Caja de herramientas](#94-caja-de-herramientas)
  - [9.5 Lienzo de modelo de negocio](#95-lienzo-de-modelo-de-negocio)
- [10 Marketing](#10-marketing)
  - [10.1 Relación con la competencia](#101-relación-con-la-competencia)
  - [10.2 Marketing Digital](#102-marketing-digital)
  - [10.3 Publicidad disruptiva](#103-publicidad-disruptiva)
  - [10.4 Posicionamiento de la marca y competitividad](#104-posicionamiento-de-la-marca-y-competitividad)
  - [10.5 Resumen de la estrategia](#105-resumen-de-la-estrategia)
- [11 Redes sociales](#11-redes-sociales)
  - [11.1 Misión](#111-misión)
  - [11.2 Meta](#112-meta)
  - [11.3 Objetivos](#113-objetivos)
  - [11.4 Tácticas](#114-tácticas)
  - [11.5 Control](#115-control)
  - [11.6 Resultados](#116-resultados)
- [12 Herramientas utilizadas](#12-herramientas-utilizadas)
  - [12.1 Herramientas para la comunicación del equipo](#121-herramientas-para-la-comunicación-del-equipo)
  - [12.2 Herramientas destinadas a la gestión del proyecto](#122-herramientas-destinadas-a-la-gestión-del-proyecto)
  - [12.3 Herramientas destinadas al diseño](#123-herramientas-destinadas-al-diseño)
  - [12.4 Herramientas de desarrollo](#124-herramientas-de-desarrollo)
  - [12.5 Inteligencia Artificial](#125-inteligencia-artificial)
- [13 Ludografía](#13-ludografía)
- [14 Webgrafía](#14-webgrafía)


# **Índice de figuras**

- [Ilustración 1: PEGI 12](#ilustración-1-pegi-12)
- [Ilustración 2: Beauty de Terry](#ilustración-2-beauty-de-terry)
- [Ilustración 3: Beauty de Torko](#ilustración-3-beauty-de-torko)
- [Ilustración 4: Beauty de Nimby](#ilustración-4-beauty-de-nimby)
- [Ilustración 5: Escenario Lobby](#ilustración-5-escenario-lobby)
- [Ilustración 6: Escenario Ruinas](#ilustración-6-escenario-ruinas)
- [Ilustración 7: Escenario Ciudad Flotante](#ilustración-7-escenario-ciudad-flotante)
- 
- [Ilustración 8: Beauty escenario mercader](#ilustración-8-beauty-escenario-mercader)
- [Ilustración 9: Concept primer enemigo](#ilustración-9-concept-primer-enemigo)
- [Ilustración 10: Enemigo Rápido](#ilustración-10-enemigo-rápido)
- [Ilustración 11: Enemigo Pesado](#ilustración-11-enemigo-pesado)
- [Ilustración 12: Enemigo Tóxico](#ilustración-12-enemigo-tóxico)
- [Ilustración 13: Enemigo Jefe](#ilustración-13-enemigo-jefe)
- [Ilustración 14: Mockup menú principal](#ilustración-14-mockup-menú-principal)
- [Ilustración 15: Menú de pausa](#ilustración-15-menú-de-pausa)
- [Ilustración 16: Menú de ajustes](#ilustración-16-menú-de-ajustes)
- [Ilustración 17: Mockup juego](#ilustración-17-mockup-juego)
- [Ilustración 18: Pantalla Elección de Mejoras](#ilustración-18-pantalla-de-elección-de-mejoras)
- [Ilustración 19: Diagrama de flujo](#ilustración-19-diagrama-de-flujo)
- [Ilustración 20: Siluetas personaje principal](#ilustración-20-siluetas-personaje-principal)
- [Ilustración 21: Desarrollo concepts personaje principal](#ilustración-21-desarrollo-concepts-personaje-principal)
- [Ilustración 22: Variación de color del personaje principal](#ilustración-22-variación-de-color-del-personaje-principal)
- [Ilustración 23: Concepts Armas](#ilustración-23-concepts-armas)
- [Ilustración 24: Escenario del mercader](#ilustración-24-escenario-del-mercader)
- [Ilustración 25: Render modelado final](#ilustración-25-render-modelado-final)
- [Ilustración 26: Skinning](#ilustración-26-skinning)
- [Ilustración 27: Mapa de Empatía](#ilustración-27-mapa-de-empatía)
- [Ilustración 28: Caja de herramientas](#ilustración-28-caja-de-herramientas)
- [Ilustración 29: Lienzo de modelo de negocio](#ilustración-29-lienzo-de-modelo-de-negocio)
- [Ilustración 30: Engagement rate individual](#ilustración-30-engagement-rate-individual)
- [Ilustración 31: Engagement rate total](#ilustración-31-engagement-rate-total)

## 0. Historial de versiones
En este apartado se reflejan las versiones del documento de diseño con sus respectivos cambios.

- **Versión 0.0.1**: Documento de diseño en el que explicamos en qué consistirá el juego, así como sus mecánicas principales, detalles técnicos y artísticos.
- **Versión 0.1.1**: Actualización del GDD. Se introducen cambios en el PEGI, ajustes en jugabilidad, ajustes en el funcionamiento del taller de Torko y nuevas imágenes.

## 1. Introducción
Este documento de diseño ha sido creado por **Unknova Studios** para detallar la visión, mecánicas y estructura de nuestro próximo videojuego, desarrollado para ser jugado en navegadores web. Actúa como la guía principal para todo el equipo de desarrollo, proporcionando una descripción clara de cada aspecto del juego, desde la jugabilidad y la narrativa hasta los elementos visuales y sonoros.  
Enfocado en una experiencia accesible y envolvente, este proyecto de Unknova Studio aprovecha la flexibilidad de los navegadores modernos para ofrecer un juego que puede disfrutarse desde múltiples dispositivos y sin instalaciones adicionales.  
Nuestro objetivo es no solo entretener, sino también empujar los límites de lo que es posible en el desarrollo de juegos para navegadores, entregando una experiencia rica y atractiva que capte la atención de jugadores de todas partes del mundo.

### 1.1. Concepto de juego
**Echoes of Xyphoria** es un videojuego original en el que los jugadores toman el control de un pequeño astronauta que, tras estrellarse en un planeta desconocido llamado Xyphoria, es rescatado por un grupo de simpáticos extraterrestres de diversas razas. Estos alienígenas le encomiendan la misión de salvar su planeta de los malvados Tyrnaxianos. Para cumplir esta misión, el protagonista deberá enfrentarse al implacable imperio Tyrnaxx derrotando todas sus temibles huestes y superando desafíos mortales. 

### 1.2. Descripción general
La esencia del juego se basa en los siguientes puntos clave:

- **Rejugabilidad**: El juego está diseñado para ofrecer partidas cortas pero intensas. Los jugadores desbloquearán nuevo contenido como armas, ventajas o logros, motivándolos a seguir jugando y mejorar sus marcas personales, avanzando hasta llegar al jefe final.
- **Sencillez**: Tanto la historia como las mecánicas del juego son fáciles de comprender, permitiendo que el jugador se centre en mejorar su habilidad sin perder de vista un objetivo claro.
- **Competitividad**: El juego fomenta la creación de una comunidad de jugadores donde todos puedan compartir sus partidas y puntuaciones. Esto incentivará un ambiente competitivo sano, animando a los jugadores a superarse unos a otros y batir récords.
- **Experimentación**: La posibilidad de probar diferentes combinaciones de armas y ventajas facilita la aparición de sinergias en las partidas, animando a los jugadores a probar todo tipo de builds.

### 1.3. Género y ambientación
**Echoes of Xyphoria** es un **roguelike** que combina elementos de acción, aventura y rol. Se caracteriza por la generación aleatoria de niveles y la **permadeath**, lo que significa que cada partida será diferente y desafiante. Los jugadores deberán adaptarse a nuevas situaciones en cada intento, lo que aumenta la rejugabilidad.  
La ambientación del juego es espacial y futurista, sumergiendo a los jugadores en un universo lleno de tecnologías desconocidas y razas alienígenas. Cada nivel ofrece no solo combates, sino también la oportunidad de descubrir recursos y secretos, creando una experiencia única en cada partida mientras luchan por derrotar al imperio Tyrnaxx.

### 1.4. Jugabilidad
En **Echoes of Xyphoria**, cada partida es infinita, es decir, la partida no acaba hasta que el jugador pierde. El primer nivel está compuesto por 4 salas. Con cada nuevo nivel, el número de salas aumentará en uno. El jugador deberá eliminar a todos los enemigos de una sala para elegir una ventaja para su arma. Finalmente, en cada sala más lejana al punto de aparición habrá un jefe de nivel que los jugadores tendrán que derrotar para conseguir una mejora especial.

### 1.5. Estilo visual
El estilo visual predominante en **Echoes of Xyphoria** es **cartoon** con ligeros detalles artísticos, creando una experiencia atractiva y visualmente llamativa.  
Este estilo cuenta con varios beneficios, como la claridad visual que aporta a las partidas, permitiendo a los jugadores distinguir fácilmente entre los elementos de esta. Además, los colores vibrantes y las formas estilizadas hacen que los enemigos, aliados y objetos sean identificables y recordables, mejorando la jugabilidad.  
Por último, el estilo **cartoon**, además de ser visualmente atractivo, es más ligero en términos de recursos gráficos. Esto es ideal para un juego de navegador, ya que permite mantener un alto rendimiento sin comprometer la calidad visual, asegurando una experiencia fluida en una amplia gama de dispositivos.

### 1.6. Alcance, propósito y público objetivo
El objetivo principal de **Echoes of Xyphoria** es proporcionar una experiencia de juego divertida y desafiante, combinando acción rápida con elementos de estrategia y rejugabilidad. Queremos que los jugadores se sumerjan en un universo espacial lleno de aventuras, enfrentándose a hordas de enemigos y explorando mundos desconocidos, mientras prueban diferentes builds y perfeccionan sus habilidades. El propósito es crear un juego accesible, pero con suficiente profundidad para mantener el interés a largo plazo.  
El juego está dirigido para jugadores que disfrutan de géneros como **roguelikes**, acción y aventura, tanto habituales como casuales, que puedan jugar en sesiones cortas o largas y que busquen experiencias accesibles pero desafiantes. Además, el componente competitivo, con la posibilidad de compartir puntuaciones y avances, atraerá a aquellos que disfrutan de medirse contra otros jugadores.
El juego ha sido clasificado como PEGI 12. Esto se debe a que el juego contiene acción, pero en ningún momento violencia extrema o explícita. Además, aunque el juego pueda tener algunos escenarios intimidantes, estos no causan terror extremo. Por último, no existe ningún tipo de contenido para adultos.

![Ilustración 1: PEGI 12](Elementos%20de%20Diseño/ElementosModeloNegocio/PEGI.jpg)

#### Ilustración 1: PEGI 12

La clasificación por edades para videojuegos varía según la región del mundo, y es importante asegurarse de que el juego esté clasificado correctamente para cada mercado. A continuación, se muestran algunas de las clasificaciones por edad de otros países o regiones:
- **Japón:** Según su sistema CERO, Echoes of Xyphoria sería CERO B, es decir, juego para personas de 12 años o más ya que incluye contenido que incluye acción moderada, enfrentamientos, y temáticas algo intensas, pero no gráficas.
- **América del Norte:** Según la escala ESRB, Echoes of Xyphoria sería E10+, es decir, recomendado para mayores de 10 años. Contenido con más acción, violencia animada moderada o lenguaje leve.
 
- **Australia:** Según la escala ACB, Echoes of Xyphoria sería PG, es decir, contenido moderado, puede no ser adecuado para niños pequeños sin supervisión.

- **Alemania:** Según la escala USK, Echoes of Xyphoria sería USK 6, es decir, contenido recomendado para mayores de 6 años. Puede incluir acción leve.


El juego está diseñado para ser jugado en navegadores web, lo que permite un amplio alcance en términos de dispositivos y plataformas. Además, habrá soporte para actualizaciones periódicas, con la inclusión de nuevos enemigos, armas y mejoras.

### 1.7. Detalles técnicos
**Echoes of Xyphoria** ha sido desarrollado para ser jugado en navegadores web, una plataforma que ofrece varias ventajas para tanto jugadores como desarrolladores.

- **Accesibilidad**: No es necesario realizar instalaciones adicionales ni descargar archivos pesados para jugar al juego. Se puede jugar desde cualquier dispositivo con acceso a Internet.
- **Multiplataforma**: Los juegos de navegador tienen la ventaja de que pueden jugarse desde la mayor parte de dispositivos (móviles, tabletas, PC, portátiles) sin tener en cuenta su sistema operativo.
- **Requisitos reducidos**: A diferencia de los juegos que requieren de componentes hardware potentes, **Echoes of Xyphoria** está optimizado para funcionar fluidamente en navegador, de tal forma que puede jugarse desde equipos que no cuenten con componentes potentes o antiguos.
- **Actualizaciones rápidas**: Las actualizaciones del juego pueden implementarse fácilmente en la web, lo que permite corregir errores, agregar contenido o realizar ajustes sin que los jugadores tengan que descargar parches.

### 1.8. Licencia
El juego utiliza una licencia original, lo que significa que todos los contenidos, personajes y mecánicas han sido creados por **Unknova Studios**. Esto garantiza que la propiedad intelectual del juego es completamente nuestra, dándonos la libertad de expandirlo, actualizarlo y compartirlo sin restricciones impuestas por terceros.

### 1.9. Motor de desarrollo
Por último, para el desarrollo del juego hemos escogido el motor de desarrollo **Unity**, uno de los motores más versátiles del mercado.  
Hemos decidido usar este motor debido a que es el que más conocemos y con el que más experiencia tenemos. Además, los juegos creados con **Unity** se pueden exportar a navegadores de forma sencilla y sin comprometer la calidad del juego, es totalmente gratuito y uno de los principales motores de desarrollo del mercado.

## 2. Trasfondo

### 2.1 Historia

Tras estrellar su nave en el misterioso y hostil planeta Xyphoria, Terry es rescatado por un grupo de alienígenas de diversas razas que habitan en las profundidades del planeta. A la cabeza de este grupo se encuentra Torko, un gigante de corazón noble, conocido por su fuerza y sabiduría. Malherido y al borde de la muerte, el protagonista es llevado a su guarida, donde los alienígenas cuidan de sus heridas con una combinación de tecnologías avanzadas y métodos curativos ancestrales. Durante varios días, permanece inconsciente, mientras sus salvadores trabajan sin descanso para sanarlo.

Pero la calma es efímera en Xyphoria. Una mañana, el protagonista despierta sobresaltado por el estruendo de un nuevo ataque. Los temidos Tyrnaxianos, una raza cruel y despiadada, han regresado para continuar su implacable conquista. El pintoresco grupo de alienígenas, liderados por Torko, luchan ferozmente para detener su avance. Con gran esfuerzo, logran repeler el ataque, pero la amenaza de los Tyrnaxianos aún persiste.

Es entonces cuando Torko, agotado pero determinado, se acerca al protagonista y le revela la verdad: Tyrnax, el imperio tiránico, tiene la ambición de conquistar todo el universo, y Xyphoria es solo una pieza más en su plan. Torko, quien una vez fue víctima de estos conquistadores, le confiesa que él es el último sobreviviente de su especie. Los Tyrnaxianos exterminaron a los suyos, y ahora, el destino del universo está en juego. Con una mirada llena de gravedad y esperanza, Torko le pide ayuda al protagonista. Es hora de unirse a la resistencia y luchar para derrotar al imperio Tyrnax, antes de que sea demasiado tarde.

La batalla por el futuro del universo ha comenzado, y Terry el terrícola es la última esperanza para poner fin a la ambición destructiva de Tyrnax.

### 2.2 Personajes

- **Terry**: Es el protagonista y el personaje jugable de nuestra historia. Aunque es una persona reservada y de pocas palabras, su verdadero carácter brilla en los momentos más tensos. Terry es increíblemente valiente y siempre está dispuesto a enfrentar cualquier desafío, sin importar lo peligroso que sea, si eso significa ayudar a los miembros de la resistencia. Está completamente decidido a hacer frente a los Tyrnaxianos para salvar a Xyphoria, su planeta natal y a todo el universo. No busca gloria ni reconocimiento, solo justicia y paz para sus nuevos amigos alienígenas, ya que este se siente en deuda con ellos. Su determinación silenciosa lo convierte en un pilar fundamental en la lucha contra el imperio Tyrnax.

![Ilustración 2: Beauty Terry](Elementos%20de%20Diseño/PersonajePrincipal/Personaje%20Principal%20Concept%20Art/BeautyPersonaje.jpg)

#### Ilustración 2: Beauty de Terry

- **Torko**: Líder indiscutible de la resistencia contra los tiránicos Tyrnaxianos, y el último sobreviviente de su especie. Su imponente presencia y vasto conocimiento del universo lo han convertido en una leyenda viva entre las razas aliadas. Aunque ha sufrido grandes pérdidas, su sabiduría y determinación serán esenciales para guiar al protagonista en la lucha final contra el imperio de Tyrnax. Su deseo de restaurar la paz es tan grande como su fuerza, y su liderazgo inspirará a todo aquel que luche a su lado.

![Ilustración 3: Beauty de Torko](Elementos%20de%20Dise%C3%B1o/ElementosNuevoGDD/Mercader%20Beauty.png)

#### Ilustración 3: Beauty de Torko

- **Nimby**: Pequeño, enérgico y soñador, Nimby es el inseparable aprendiz de Torko. Aunque es torpe y un poco holgazán, su ambición de convertirse en alguien tan fuerte y sabio como su mentor lo mantiene siempre lleno de entusiasmo. Pese a su tendencia a meterse en problemas, Nimby tiene un corazón puro y leal. Siempre dispuesto a ayudar, sus buenas intenciones y su inquebrantable fe en Torko lo convierten en un invaluable compañero, aunque sus travesuras a menudo traigan más problemas que soluciones.

![Ilustración 4: Beauty de Nimby](Elementos%20de%20Diseño/Aprendiz/Concept%20Art%20del%20Aprendiz/BeautyAprendiz.jpg)

#### Ilustración 4: Beauty de Nimby

### 2.3 Escenarios y lugares

En nuestro juego, utilizaremos generación procedimental para diseñar las salas en las que los jugadores se enfrentarán a los diferentes retos. Este sistema garantizará que cada partida ofrezca una experiencia única, al generar las salas y desafíos de manera aleatoria. A continuación, presentamos los principales escenarios pensados para el juego, cada uno con su propia estética y ambientación distintiva:

#### 2.3.1 Cuartel de la resistencia

Este escenario actúa como el lobby jugable del juego, donde los jugadores comenzarán su aventura. Se trata de una sala bien organizada y funcional, donde el jugador podrá elegir su arma entre varias opciones disponibles para la partida. Una vez que el arma sea seleccionada, las otras desaparecerán hasta el inicio de una nueva partida. En el centro de la sala se encuentra una puerta que, al cruzarla, iniciará el primer nivel de combate.

Además, en una pequeña sala lateral habrá un espejo interactivo donde el jugador podrá acceder a un menú para cambiar la skin de su personaje. Este espacio también ofrece la posibilidad de interactuar con otros personajes, que aportan detalles adicionales sobre la historia o ayudan a preparar al jugador para la misión. El Cuartel de la Resistencia es una sala bien organizada y minimalista, con un ambiente industrial y futurista, caracterizado por maquinaria, pantallas holográficas, y zonas de armamento.

![Ilustración 5: Escenario Lobby](Elementos%20de%20Dise%C3%B1o/ElementosNuevoGDD/LobbyEscenario.JPG)

#### Ilustración 5: Escenario Lobby


#### 2.3.2 Ruinas de Xyphoria

Las Ruinas de Xyphoria son los restos de una avanzada civilización, ahora en decadencia. Aquí, el jugador explorará un entorno lleno de edificios futuristas derruidos, con estructuras que alguna vez fueron majestuosas pero que ahora están parcialmente destruidas y cubiertas de vegetación alienígena. Las calles están llenas de escombros, y los enemigos se esconderán entre las ruinas, aprovechando el terreno. La atmósfera del lugar es sombría y melancólica, evocando una época pasada de esplendor que ya no existe.

![Ilustración 6: Escenario Ruinas](Elementos%20de%20Dise%C3%B1o/ElementosNuevoGDD/Ruinas_Escenario.JPG)

#### Ilustración 6: Escenario Ruinas

#### 2.3.3 Bahía de Arka

La Bahía de Arka es una tranquila y enigmática zona costera en la que predominan estructuras relacionadas con el mar. Este escenario está situado en las costas de un océano desconocido, donde las aguas brillan con tonos iridiscentes, dándole un toque de belleza exótica y, a la vez, misteriosa. Los bungalows están construidos con materiales extraños, propios de la tecnología de las razas que habitaron este lugar. Se pueden observar embarcaciones asoladas y faros caídos. La Bahía de Arka será un lugar donde la calma del océano contrasta con la amenaza constante de la guerra, creando una atmósfera cargada de tensión y maravilla.

#### 2.3.4 Ciudad Flotante de Aereth

La Ciudad Flotante de Aereth es un misterioso lugar suspendido en los cielos, una reliquia de una civilización extinta. Las estructuras que el jugador encontrará en este escenario incluyen hogares flotantes, plazas abandonadas y plataformas suspendidas, todas conectadas por puentes y caminos de piedra. Los edificios tienen una arquitectura elegante, con líneas curvas y detalles dorados que insinúan un tiempo de opulencia. La atmósfera es casi etérea, con nubes se divisan por debajo de la ciudad, pero también desierta, dándole al lugar una sensación de soledad y misterio.

![Ilustración 7: Escenario Ciudad Flotante](Elementos%20de%20Dise%C3%B1o/ElementosNuevoGDD/Ciudad_FlotanteEscenario.JPG)

#### Ilustración 7: Escenario Ciudad Flotante

#### 2.3.5 Nido Tyrnax

El Taller de Torko es un lugar clave en el juego, accesible a través de un puente que lleva a una pequeña estructura ubicada en una zona elevada, casi como un refugio en medio del caos que gobierna Xyphoria. Este escenario no solo ofrece un respiro entre las partidas, sino que es donde habitan Torko, el líder de la resistencia, y su fiel aprendiz Nimby. El entorno está lleno de actividad y parece tener vida propia, gracias a la implementación de comportamientos dinámicos de los personajes, lo que da la sensación de un ecosistema en constante movimiento.

En este lugar, podemos ver a Torko trabajando arduamente, organizando piezas de armas, ensamblando mejoras y consultando viejos manuales de tecnología alienígena. Su taller está lleno de herramientas, repuestos y planos esparcidos por las mesas, mientras una tenue luz ilumina su espacio de trabajo. Nimby, aunque algo torpe, corretea intentando ayudar, recogiendo piezas caídas o moviendo objetos de un lado a otro, reflejando su energía incansable y su deseo de ser tan útil como su mentor.

Además de su papel narrativo en la historia, el Taller de Torko es fundamental para el progreso del jugador. Aquí, Torko ofrecerá mejoras generales que los jugadores podrán adquirir usando la moneda del juego, la Xyphorita. Estas mejoras abarcan áreas como vida, armadura y daño, y son cruciales para que el jugador pueda mantenerse vivo durante más tiempo en el campo de batalla, ya que los enemigos escalan en poder de forma constante a lo largo de la partida. Torko, con su gran sabiduría, te ayudará a prepararte mejor para las inminentes luchas, ofreciéndote las herramientas necesarias para sobrevivir más tiempo y enfrentarte a los bosses y hordas de enemigos.


![Ilustración 8: Beauty escenario mercader](Elementos%20de%20Diseño/Escenario%20del%20Mercader/ConceptArt-Escenario%20del%20Mercader/Beauty_EscenarioMercader.jpg)

#### Ilustración 8: Beauty escenario mercader

## 3. Mecánicas de juego

A continuación, se describen en detalle las principales mecánicas que definen a **Echoes of Xyphoria**. En esta sección se explicará qué cosas puede hacer un jugador, así como estas afectan al juego.

### 3.1. Flujo de juego (en qué consiste una partida)

Al pulsar el botón para comenzar la partida, los jugadores aparecerán en una sala inicial tranquila donde se les presentarán cinco armas distintas, cada una con características únicas. El jugador debe seleccionar un arma para esa partida, que no podrá cambiar durante el transcurso del juego.

Además, se puede acceder al taller de Torko, lugar donde el jugador puede usar las monedas obtenidas en las partidas para aumentar estadísticas generales que permitan aumentar el tiempo que dura cada partida.

Una vez elegida el arma, se desbloqueará una puerta que llevará al jugador a la primera sala de combate. Al entrar, los enemigos atacarán al jugador de inmediato. El objetivo es eliminar a todos los enemigos de la sala, quienes al morir dejarán caer monedas (Xyphorita), las cuales podrán utilizarse más adelante en la partida.

Después de derrotar a los enemigos de cada sala, aparecerán tres alienígenas, seleccionados aleatoriamente entre cinco posibles razas, que ofrecerán al jugador una mejora especial. Si el jugador ya ha obtenido una mejora previamente, esta podrá aparecer nuevamente en forma de potenciación. Por ejemplo, si ya posee una mejora de quemadura, futuras mejoras podrían aumentar el daño de esa quemadura.

Además, en cada nivel, el jugador enfrentará a un boss o jefe más desafiante que aparece en la sala más alejada al punto de aparición. Tras derrotar al jefe, y si el jugador ha conseguido cinco mejoras de una misma raza, recibirá una súper mejora, y no podrá obtener más mejoras relacionadas con ese perk en esa partida. Si el jugador logra obtener dos súper mejoras de razas distintas, podrá elegir una mejora dual que combinará las ventajas de ambas razas para crear una nueva habilidad.

El juego está diseñado sin un final definido; los enemigos aumentarán su dificultad de manera progresiva, y la partida continuará hasta que el jugador muera. Al finalizar, se registrará el récord de salas completadas.


### 3.2. Cámara

El juego cuenta con una cámara con perspectiva isométrica fija, es decir, la cámara siempre sigue al jugador desde un ángulo ligeramente elevado. Esta elección se debe a que este tipo de cámara ofrece una sensación de profundidad visual sin demasiada complejidad en la que el jugador puede tener una visión clara del entorno.

### 3.3. Controles

Los controles están pensados para que el jugador se centre en la acción rápida y estratégica del juego. El esquema básico de control quedaría así:

- **Movimiento**: El jugador podrá moverse por el escenario utilizando las teclas W, A, S, D para desplazarse en las direcciones correspondientes:
  - **W**: Moverse hacia arriba.
  - **A**: Moverse hacia la izquierda.
  - **S**: Moverse hacia abajo.
  - **D**: Moverse hacia la derecha.
- **Disparo**: Para atacar, el jugador disparará con el clic izquierdo del ratón en la dirección del cursor. Esto permite disparar en cualquier dirección mientras se mueve con las teclas.
- **Interacción**: Para interactuar con personajes, objetos o elementos del entorno (como tiendas o NPCs), se utilizará la tecla **E**.
- **Elección de mejoras/tienda**: Para elegir qué mejora escoger o comprar, el jugador usará el movimiento del ratón y el click izquierdo para decidir.

### 3.4. Puntuación y competitivo

**Echoes of Xyphoria** está pensado no solo para ser un juego bueno y entretenido, sino también para ser un juego con una parte competitiva que pueda atraer a una gran comunidad de jugadores de alto nivel. Para ello, se ha implementado un sistema de puntos con ranking para decidir quién es el mejor de todos los jugadores de Echoes of Xyphoria.

La mecánica es sencilla: al ser un juego “infinito”, es decir, que no tiene final, ganará el jugador que más salas complete en una partida. Si los jugadores empatan en salas, entonces ganará el jugador que más enemigos haya derrotado y, si aún así están empatados, ganará el que menos tiempo haya consumido en llegar al final de su partida.

Esto nos permite asegurarnos de que siempre habrá un ganador.

### 3.5. Ventajas

En nuestro juego, después de completar cada sala de enemigos, el jugador tendrá la oportunidad de obtener una mejora de combate ofrecida por una de las razas alienígenas que habitan en Xyphoria. De un conjunto de cinco razas posibles, aparecerán tres de manera aleatoria para ofrecer sus mejoras únicas. Cada raza tiene un poder específico que puede potenciarse a lo largo de la partida, lo que permite a los jugadores personalizar su estilo de juego y adaptarse a los desafíos que enfrenten.

Si un jugador logra adquirir cinco mejoras consecutivas de una misma raza, desbloqueará una **Súper mejora**, una versión mucho más poderosa de la habilidad original que tendrá un impacto significativo en el juego. Estas super mejoras ofrecen al jugador un gran poder, pero también bloquean cualquier mejora adicional en esa habilidad específica.

Este sistema de mejoras y súper mejoras da lugar a partidas dinámicas, donde cada decisión puede cambiar radicalmente el curso del juego, permitiendo a los jugadores experimentar diferentes combinaciones y estrategias.

#### 3.5.1. Razas y sus ventajas

- **Lumii**: Las mejoras de los Lumii otorgan la capacidad de quemar a los enemigos, infligiendo daño prolongado con el tiempo. A medida que se mejora esta habilidad, aumentará la probabilidad de quemado, la duración del efecto o el daño que inflige.

  - **Super mejora**: “Lumi Lumi Naa”. Los disparos del jugador tienen una probabilidad del 100% de infligir quemaduras a todos los enemigos en una sala al inicio del combate, con un daño masivo de quemadura durante un periodo extendido.

- **Valkii**: Esta raza ralentiza a los enemigos, reduciendo su velocidad de movimiento y ataque. Al mejorar esta habilidad, aumentará la probabilidad de ralentización, la duración del efecto o la reducción de velocidad.

  - **Super mejora**: "Kii Val Kii". Los disparos del jugador tienen una probabilidad del 100% de paralizar por completo a los enemigos durante unos segundos, dejándolos vulnerables a los ataques.

- **Oranii**: Con cada disparo acertado, el jugador aumenta su velocidad de ataque y movimiento hasta cierto límite. Mejorar esta habilidad permite ganar más velocidad por cada golpe.

  - **Super mejora**: "Ora Ora Ora". La mejora permite fallar hasta cinco disparos sin perder las acumulaciones obtenidas de dar a todos los enemigos.

- **Lyraxii**: Aumenta el daño y la velocidad de movimiento del jugador cuando su salud es baja. Mejorar esta habilidad incrementa el porcentaje de salud que el jugador debe perder para activar el efecto, así como la cantidad de daño y velocidad ganados.

  - **Super mejora**: "Lyr Linry Xii". Cuando la salud del jugador cae por debajo de un umbral crítico, el jugador se vuelve invulnerable durante un corto periodo de tiempo.

- **Xenrii**: Esta raza proporciona la oportunidad de recuperar salud al eliminar enemigos. Al mejorar esta habilidad, se incrementa la probabilidad de recuperar salud y la cantidad de salud obtenida.

  - **Super mejora**: "Zen Xen Rii". Cada enemigo derrotado garantiza una recuperación de salud, pero, además, si el jugador mata a un enemigo mientras su salud está completa, la salud ganada se convierte en una sobrecarga de salud temporal (vida extra).

### 3.6. Mejoras

En nuestro juego, dado que las partidas son infinitas, los enemigos se vuelven cada vez más fuertes a medida que avanzas. Para equilibrar este aumento de dificultad, hemos creado la **zona del mercader**, donde el jugador también puede escalar en poder. Aquí podrás gastar las monedas obtenidas al derrotar enemigos, conocidas como Xyphorita, para adquirir mejoras permanentes que te ayudarán a sobrevivir más tiempo.

El mercader ofrece una serie de mejoras generales, que se centran en tres aspectos clave: **vida, armadura, daño**… Estas mejoras son esenciales para que el jugador pueda hacer frente a los enemigos más poderosos y prolongar su partida, permitiendo que, con cada compra, el personaje se vuelva más resistente y letal.

La implementación de la zona del mercader añade una capa estratégica, ya que los jugadores deberán gestionar sus recursos y decidir qué mejoras priorizar para adaptarse a la dificultad creciente del juego.

### 3.7. Enemigos

En nuestro juego, los jugadores se enfrentarán a una variedad de enemigos Tyrnaxianos, cada uno con características únicas que exigirán diferentes estrategias para ser derrotados. A continuación, se detallan los tipos de enemigos que aparecerán durante las partidas:

#### 3.7.1. Tyrnaxiano Básico

El enemigo estándar. Este Tyrnaxiano se acercará directamente al jugador con el único objetivo de golpearlo cuerpo a cuerpo. Aunque no es muy rápido ni resistente, en grandes números puede convertirse en una amenaza considerable si no se le presta atención.

![Ilustración 9: Concept primer enemigo](Elementos%20de%20Dise%C3%B1o/ElementosNuevoGDD/Enemigo%20B%C3%A1sico.jpeg)

#### Ilustración 9: Concept primer enemigo

#### 3.7.2. Tyrnaxiano Rápido

Este enemigo es más ágil que el Tyrnaxiano básico, moviéndose rápidamente hacia el jugador para intentar golpearlo. Aunque tiene menos salud, su velocidad lo convierte en una prioridad para ser eliminado rápidamente antes de que pueda hacer mucho daño.

![Ilustración 10: Enemigo Rápido](Elementos%20de%20Dise%C3%B1o/ElementosNuevoGDD/Enemigo%20%C3%81gil.jpeg)

#### Ilustración 10: Enemigo Rápido


#### 3.7.3. Tyrnaxiano Pesado

Un enemigo corpulento y resistente, este Tyrnaxiano tiene una gran cantidad de salud, lo que lo convierte en un verdadero desafío a la hora de derrotarlo. Aunque es más lento, su capacidad para absorber daño puede desestabilizar al jugador, ya que deberá dedicar más tiempo y esfuerzo en eliminarlo. Representa una barrera que puede complicar la estrategia si no se gestiona bien.

![Ilustración 11: Enemigo Pesado](Elementos%20de%20Dise%C3%B1o/ElementosNuevoGDD/EnemigoTanque.JPG)

#### Ilustración 11: Enemigo Pesado

#### 3.7.4. Tyrnaxiano Tóxico

Este enemigo no solo atacará al jugador, sino que dejará un rastro de daño a lo largo del tiempo si logra acertar un golpe. Su ataque envenena al jugador, lo que significa que incluso después de evitar el contacto, el jugador seguirá perdiendo salud durante un corto período de tiempo. Esto añade una capa extra de dificultad, ya que necesitarás mantener la distancia para evitar el veneno y mantener la calma si te alcanza.

![Ilustración 12: Enemigo Tóxico](Elementos%20de%20Dise%C3%B1o/ElementosNuevoGDD/EnemigoToxico.JPG)

#### Ilustración 12: Enemigo Tóxico

#### 3.7.5. Jefe Tyrnaxiano
El jefe final en algunas salas especiales será una versión mejorada de los Tyrnaxianos. Este boss combina las habilidades de todos los tipos de enemigos anteriores:
- Tiene la resistencia del Tyrnaxiano Pesado, por lo que será difícil eliminarlo rápidamente.
- Se moverá con la velocidad del Tyrnaxiano Rápido, acercándose al jugador con rapidez.
- Infligirá daño de veneno como el Tyrnaxiano Tóxico, obligando al jugador a estar alerta constante.
- Además, este jefe tendrá la capacidad de disparar proyectiles a distancia, añadiendo un nuevo desafío, ya que el jugador deberá esquivar tanto ataques cuerpo a cuerpo como los disparos.

![Ilustración 13: Enemigo Jefe](Elementos%20de%20Dise%C3%B1o/ElementosNuevoGDD/EnemigoBoss.JPG)

#### Ilustración 13: Enemigo Jefe

## 4. Comportamiento de personajes
Para dar vida a la zona del mercader, hemos decidido implementar un sistema dinámico que refleje un ecosistema vivo lleno de detalles y comportamientos que aporten realismo y profundidad al entorno. Para incluir comportamiento de personajes en nuestro proyecto, hemos pensado usar máquinas de estados finitos, árboles de comportamiento y sistemas de utilidad.

En este espacio, el mercader no será un simple NPC estático, sino un personaje con rutinas Las acciones que tomará el mercader variarán según sea de día o de noche. 

Por el día realizará ciertas acciones como dibujar planos, fabricar armas (solo podrá hacerlo si hay materiales) y organizar armas (solo si hay armas en el armario). Siempre y cuando la necesidad de limpiar no esté presente, en el caso de que lo esté, el mercader procederá a limpiar. La suciedad irá aumentando a medida que el mercader vaya realizando tareas.

En cambio, por la noche, como es su momento de descanso sin trabajar, cambiará la necesidad de limpiar por la de dormir, siempre que no esté cansado, el mercader podrá leer y rezar. Estas dos actividades aumentarán el cansancio y cuando este haya aumentado lo suficiente se irá a dormir.

Cuando el jugador decide interactuar con él, este deja de hacer la tarea que está haciendo para dar prioridad al jugador, primero caminará hasta donde se encuentre el jugador y una vez llegue se le ofrecerán las mejoras a elegir. Una vez elegidas, el mercader volverá a hacer la tarea que dejó a medias.

Las acciones que tomará el aprendiz variarán según sea de día o de noche, al igual que con el mercader. Por el día, seguirá al mercader hasta que sienta cierto aburrimiento, entonces este empezará a dar saltos por el escenario, rodar por el escenario y cantar. El aburrimiento irá aumentando a medida que vaya pasando el tiempo siguiendo al mercader, y las ganas de aprender aumentarán cuando más tiempo pase haciendo actividades que le entretengan.

En cambio, por la noche, cambiará el sentimiento de aburrimiento por el de cansancio, siempre que no esté cansado, el aprendiz podrá vaciar el armario, ver la tele y estudiar. Estas actividades harán aumentar el dato de cansancio y cuando este haya aumentado lo suficiente se irá a dormir.

Cuando el mercader va a buscar los materiales del arma y no los encuentra, el aprendiz dejará de hacer la tarea que está haciendo para dar prioridad a reponer los materiales, primero caminará hasta donde se encuentren las cajas con los materiales y luego los dejará en el cajón, una vez repuestos el aprendiz volverá a la tarea en la que estaba anteriormente.

Este sistema de comportamiento no solo añade un nivel de detalle visual y narrativo a la experiencia del jugador, sino que también crea un entorno inmersivo que refuerza la sensación de que el mundo está vivo y en constante movimiento, incluso cuando el jugador no está interactuando directamente con él.


## 5. Interfaces
Las interfaces de usuario (UI) en un videojuego son uno de los elementos más cruciales para brindar una experiencia de juego fluida, accesible y atractiva. En nuestro juego, nos aseguraremos de que las interfaces sean intuitivas, fáciles de navegar y estéticamente coherentes con la temática de ciencia ficción y aventura espacial. A continuación, se describe la estructura de las principales pantallas e interfaces junto con algunos mockups que sirvan como referencia visual, así como un diagrama de flujo que ilustra el recorrido típico de un jugador a través de las diversas secciones del juego.

### 5.1. Interfaces del juego
En este apartado, abordaremos todas las pantallas principales que componen la experiencia del jugador dentro del juego, detallando sus funcionalidades y cómo interactúan entre sí. Cada pantalla ha sido diseñada con el objetivo de ofrecer una navegación clara, intuitiva y eficiente, permitiendo a los jugadores centrarse en la acción y progresar de manera fluida. Aquí describiremos pantallas clave como la de **Inicio**, **Menú Principal**, **Opciones**, **Pantalla de Juego**, **Pantalla de Pausa**, entre otras, explicando cómo cada una cumple su papel dentro del sistema general del juego y qué opciones ofrece al jugador.

#### 5.1.1. Pantalla de inicio
Interfaz transitoria cuya única opción será la de pulsar en jugar. Tras esto, aparecerá una cinemática de presentación del juego y de su historia.

#### 5.1.2. Menú principal
Esta será la primera interfaz con la que los jugadores interactuarán al abrir el juego. La pantalla de inicio será minimalista y atractiva, con un fondo que refleje la temática espacial y alienígena. Los elementos clave serán:
- **Botón de Jugar**: Lleva al jugador directamente al juego.
- **Acceso a Opciones**: Permite al jugador ajustar configuraciones de sonido, gráficos y controles.
- **Acceso a Ranking**: Posibilidad de visualizar el ranking semanal/mundial.
- **Tutorial**: Lleva la pantalla del tutorial.
- **Acceso a Tienda**: Permite al jugador acceder a las compras de cosméticos o moneda del juego (Cristal Tyrnax).

![Ilustración 14: Mockup menú principal](Elementos%20de%20Dise%C3%B1o/ElementosNuevoGDD/InterfazMenu.JPG)

#### Ilustración 14: Mockup menú principal

#### 5.1.3. Menú de pausa
El menú principal aparece después de la pantalla de inicio o cuando el jugador presiona "pausa" durante el juego. En este menú, el jugador tendrá varias opciones:
- **Continuar Partida**: Esta opción estará disponible si el jugador ha dejado una partida en curso.
- **Nueva Partida**: Inicia una nueva sesión de juego, llevando al jugador a la pantalla de selección de armas.
- **Opciones**: Lleva a la interfaz de ajustes del juego (sonido, controles, gráficos, etc...).
- **Salir**: Vuelve a la pantalla de inicio o cierra el juego si está en pausa.

![Ilustración 15: Menú de pausa](Elementos%20de%20Diseño/Interfaces/Mockups/MenúDePausa/MenuDePausaFinal.png)

#### Ilustración 15: Menú de pausa

#### 5.1.4. Pantalla de opciones
El apartado de "Opciones" será fundamental para que el jugador pueda ajustar el juego a su gusto. Las opciones estarán divididas en varias secciones:
- **Sonido**: Volumen de la música, efectos y voces (si las hay).
- **Idiomas**: Selección de idioma en el que se mostrará la interfaz.
- **Salir**: Vuelve al menú principal o a la partida.
Esta pantalla será accesible tanto desde el menú principal como dentro del juego.

![Ilustración 16: Menú de ajustes](Elementos%20de%20Dise%C3%B1o/ElementosNuevoGDD/ajustesinterfaz.JPG)
### Ilustración 16: Menú de ajustes

#### 5.1.5. Pantalla de personalización
Interfaz desde la que los jugadores pueden personalizar a su personaje. Accesible desde el inicio de la propia partida. Los jugadores pueden elegir que aspecto usar antes de comenzar. Las opciones de este menú son:
- **Ver la siguiente skin**: Previsualización de la skin en el personaje.
- **Botón de equipar aspecto**: El jugador se equipa el cosmético seleccionado.
- **Botón de salir**: Devuelve al jugador a la partida.
  
#### 5.1.6. Pantalla de tutorial
Interfaz de ayuda en la que se explica al jugador las mecánicas y nociones principales del juego. Desde esta pantalla se puede hacer lo siguiente:
- **Botón de salir**: Te devuelve al menú principal.
- **Botón de siguiente**: Muestra la siguiente parte del tutorial.
  
#### 5.1.7. Pantalla de juego
Esta es la interfaz con la que los jugadores interactuarán durante la partida. Debe ser lo más limpia posible, para que la acción del juego sea el foco principal. Sin embargo, contendrá algunos elementos clave:
- **Botón de Vida y Armadura**: Indicador visual del estado del personaje.
- **Indicador de Monedas**: Para saber cuántas monedas ha acumulado el jugador hasta el momento.
- **Barra de Habilidades/Mejoras**: Mostrar las habilidades obtenidas durante la partida, así como sus potenciaciones.
- **Botón de Pausa**: Lleva al menú de pausa para opciones adicionales o salir del juego.
- **Pantalla de Personalización**: Accesible al inicio de la partida tocando un espejo.

![Ilustración 17: Mockup juego](Elementos%20de%20Dise%C3%B1o/ElementosNuevoGDD/PartidaInterfaz.jpg)

#### Ilustración 17: Mockup juego

![Ilustración 18: Pantalla Elección de Mejoras](Elementos%20de%20Dise%C3%B1o/ElementosNuevoGDD/MejorasInterfaz.png)

#### Ilustración 18: Pantalla de Elección de Mejoras

#### 5.1.8. Pantalla de fin de partida
Al final de cada partida, aparecerá una pantalla de resumen que muestra el progreso del jugador:
- **Número de Salas Completadas**: La cantidad de salas recorridas antes de ser derrotado.
- **Mejoras Obtenidas**: Un resumen de todas las mejoras conseguidas durante la partida.
- **Monedas Acumuladas**: Total de monedas recolectadas y disponibles para usar en la tienda.
- **Opciones de Reintento**: Permite al jugador comenzar una nueva partida o regresar al menú principal.
  
#### 5.1.9. Pantalla de tienda
La tienda es accesible desde el menú principal o en algunos momentos especiales dentro de la partida. Aquí, el jugador puede gastar su moneda Cristal Tyrnax para adquirir cosméticos, mejoras o incluso opciones para la partida:
- **Skins y Cosméticos**: Opciones de compra para personalización del personaje.
- **Moneda del Juego**: Opción para comprar Cristal Tyrnax a través de microtransacciones.
  
#### 5.1.10. Pantalla de ranking
Esta interfaz muestra las clasificaciones semanales y globales de los jugadores en base a su progreso en las partidas.
- **Ranking Semanal**: Un ranking que se resetea cada semana, con recompensas para los jugadores que ocupen los primeros lugares.
- **Ranking Mundial**: Un ranking global de todos los tiempos.

### 5.2. Diagrama de flujo
En este apartado, abordaremos todas las pantallas principales que componen la experiencia del jugador dentro del juego, detallando sus funcionalidades y cómo interactúan entre sí. Cada pantalla ha sido diseñada con el objetivo de ofrecer una navegación clara, intuitiva y eficiente, permitiendo a los jugadores centrarse en la acción y progresar de manera fluida. Aquí describiremos pantallas clave como la de Inicio, Menú Principal, Opciones, Pantalla de Juego, Pantalla de Pausa, entre otras, explicando cómo cada una cumple su papel dentro del sistema general del juego y qué opciones ofrece al jugador.

![Ilustración 19: Diagrama de flujo](Elementos%20de%20Diseño/DiagramadeFlujo.jpg)

#### Ilustración 19: Diagrama de flujo
  
## 6. Arte
### 6.1. Estética general
El arte de **Echoes of Xyphoria** sigue un estilo 2.5D chibi, que combina gráficos en 2D con una sensación de profundidad y perspectiva propia de los juegos en 3D. Esta elección estética ofrece lo mejor de ambos mundos: la claridad visual y el encanto estilizado de los gráficos 2D, junto con una mayor inmersión visual gracias al uso de capas, sombras y efectos tridimensionales.

Los personajes, enemigos y escenarios están diseñados con texturas detalladas y colores vibrantes que resaltan en pantalla, manteniendo la fluidez necesaria para un juego de acción rápida. Este enfoque visual permite un diseño creativo y estilizado, ideal para destacar la diversidad de razas alienígenas y paisajes espaciales.

### 6.2. Concept Art
El concept art es la base visual del juego, donde se diseñan los personajes, escenarios y elementos clave. Esta fase sirve para visualizar ideas, definir estilos artísticos y establecer la atmósfera general que tendrá el juego. A continuación, se muestran algunos concepts de personajes, enemigos, armas… 

![Ilustración 20: Siluetas personaje principal](Elementos%20de%20Diseño/PersonajePrincipal/Personaje%20Principal%20Concept%20Art/SiluetasPersonaje.jpg)

#### Ilustración 20: Siluetas personaje principal

![Ilustración 21: Desarrollo concepts personaje principal](Elementos%20de%20Diseño/PersonajePrincipal/Personaje%20Principal%20Concept%20Art/DesarrolloPersonaje.jpg)

#### Ilustración 21: Desarrollo concepts personaje principal

![Ilustración 22: Variación de color del personaje principal](Elementos%20de%20Diseño/PersonajePrincipal/Personaje%20Principal%20Concept%20Art/EstudioColoresPersonaje.jpg)

#### Ilustración 22: Variación de color del personaje principal

![Ilustración 23: Concepts Armas](Elementos%20de%20Diseño/ConceptArmas.JPG)

#### Ilustración 23: Concepts Armas

### 6.3. Modelado 3D
En la etapa de modelado 3D, las ideas del concept art toman forma tridimensional. Aquí, se crean los modelos de personajes, objetos y escenarios con detalles precisos para ser usados en el juego. Cada modelo refleja las características definidas previamente en los conceptos visuales. Estos son algunos renders de modelos 3D que se están desarrollando.

![Ilustración 24: Escenario del mercader](Elementos%20de%20Diseño/Escenario%20del%20Mercader/Modelos3D-%20Escenario%20del%20Mercader/ModeladoEscenarioMercader.jpg)

#### Ilustración 24: Escenario del mercader

## 7. Animación
La animación da vida a los modelos 3D, permitiendo que los personajes y elementos del juego se muevan e interactúen con el entorno. Los movimientos, ataques y acciones son creados para transmitir fluidez y dinamismo durante el juego. Queremos crear animaciones perfectamente pulidas para que el jugador se sienta dentro de la historia y del juego.

### 7.1. Escenario
La animación de escenarios introduce movimiento a los fondos y ambientes del juego, añadiendo dinamismo y profundidad. Elementos como luces, sombras, objetos interactivos y fenómenos naturales ayudan a que el mundo del juego se sienta más vivo.

### 7.2. Personajes
En la animación de personajes, se diseñan los movimientos y acciones que llevarán a cabo los protagonistas de la historia y enemigos. Desde caminatas hasta combates, esta etapa se enfoca en crear movimientos fluidos y realistas que conecten con la jugabilidad.

![Ilustración 25: Render modelado final](Elementos%20de%20Diseño/PersonajePrincipal/Personaje%20Principal%20Modelado/RenderModeladoFinal.jpg)

#### Ilustración 25: Render modelado final

#### 7.2.1. Rigging
El esqueleto de los personajes y algunos objetos hacen que estos puedan moverse de manera articulada, estableciendo una base para las animaciones y los movimientos complejos.

#### 7.2.2. Skinning
El skinning permite que, al mover los huesos del rig, la malla se deforme correctamente y el personaje se mueva de forma natural, respetando el diseño original y asegurando coherencia visual en los movimientos.

![Ilustración 26: Skinning](Elementos%20de%20Diseño/PersonajePrincipal/Personaje%20Principal%20Skinning%20y%20Animaciones/PersonajePrincipal_Esqueleto.JPG)

#### Ilustración 26: Skinning

## 8. Audio
El audio en **Echoes of Xyphoria** juega un papel fundamental en la inmersión del jugador en el universo espacial. La banda sonora tendrá una mezcla de música electrónica y espacial que acompaña el ritmo frenético de las partidas, intensificándose durante los momentos clave del combate.

### 8.1. Sonido ambiente y música
La música y el sonido ambiente que utilizaremos en el juego serán cuidadosamente seleccionados de plataformas que ofrezcan música sin copyright y libre de regalías (free for profit). Esto nos permitirá ofrecer una experiencia auditiva atractiva y de calidad sin infringir derechos de autor, respetando siempre las licencias de los creadores originales.

Nuestra prioridad es garantizar que el juego cuente con un entorno sonoro inmersivo y envolvente, que complemente la jugabilidad. De esta manera, buscaremos sonidos y composiciones que se alineen con la atmósfera espacial y aventurera del juego, desde melodías que acompañen momentos de exploración hasta canciones para las batallas y escenas clave.

Todas las piezas de audio que se integrarán en el juego provendrán de sitios especializados en ofrecer música y efectos bajo licencias Creative Commons u otras licencias que permitan su uso comercial sin costo. Además, en la medida de lo posible, daremos crédito a los creadores de las obras en los apartados correspondientes del juego, reconociendo así su trabajo y creatividad.

Esta estrategia no solo nos permite reducir costos, sino también contribuir a la comunidad de creadores independientes, brindando visibilidad a sus obras dentro de nuestro proyecto.

### 8.2. Efectos de sonido
Todos los efectos de sonido de los personajes en **Echoes of Xyphoria** han sido creados y editados internamente por el equipo de **Unknova Studios**, con el objetivo de generar una atmósfera única y misteriosa que envuelva al jugador en este universo alienígena. Hemos diseñado los sonidos para que, sin necesidad de diálogos hablados, los personajes y criaturas transmitan personalidad y carisma a través de los efectos auditivos.

Cada personaje tiene un sonido distintivo, cuidadosamente editado para capturar su esencia. Por ejemplo, las risas, gruñidos o chillidos de los alienígenas están diseñados para ser memorables y darles identidad propia, haciendo que el jugador sienta que está interactuando con seres vivos e interesantes. 

Para los efectos de sonido propios de armas o escenarios se usarán tanto sonidos de librerías con uso libre y sin copyright como sonidos propios creados por nuestro equipo.

## 9. Modelo de negocio y monetización
### 9.1. Modelo de negocio
Nuestro modelo de negocio se trata de un freemium, ya que los clientes pueden acceder a nuestros productos gratuitamente, pero si quieren conseguir todas las opciones que se ofrece, es decir, un mayor número de características (cosméticos u otros), deberán de pagar un coste monetario.

### 9.2. Monetización
Nuestro juego sigue un modelo free-to-play que ofrece una experiencia accesible para todos, sin barreras de entrada, pero con múltiples opciones para mejorar la jugabilidad y personalización mediante la participación de los jugadores o pequeñas inversiones.

Uno de los pilares clave es la moneda del juego, llamada Cristal Tyrnax, que tiene una doble función. Esta moneda puede conseguirse de manera gratuita con algo de suerte durante las partidas, o como parte de recompensas diarias para los jugadores más constantes. Sin embargo, para aquellos que quieran avanzar más rápidamente o comprar aspectos exclusivos, también podrán adquirir Cristal Tyrnax mediante microtransacciones. De esta manera, cada jugador decide su propio ritmo y estilo de progresión, garantizando que todos tengan acceso a las mismas posibilidades.

La publicidad in-game será discreta pero efectiva, permitiendo a los jugadores acceder a beneficios adicionales sin necesidad de gastar dinero real. Estas publicidades se integrarán de forma orgánica dentro del juego, sin interferir en la experiencia general de los usuarios. Para ello, ya estamos en contacto con algunas empresas como Astex (empresa dedicada a la enseñanza idiomas) para incluir su marca dentro del juego, en la nave espacial donde Terry llega a Xyphoria. Además, tenemos pensado desarrollar una forma de cambiar esta textura de forma dinámica por si alguna otra empresa decidiera patrocinarnos.

Finalmente, el juego cuenta con rankings semanales que recompensarán a los mejores jugadores, incentivando una sana competitividad. Cada semana, el ranking se reiniciará, ofreciendo siempre nuevas oportunidades para que cualquier jugador pueda alcanzar la cima. Además, se añadirá un ranking mundial, donde los jugadores podrán medir sus habilidades contra los mejores del mundo, manteniendo vivo el interés y el desafío a largo plazo.

En resumen, se plantea que una de las principales opciones de monetización del juego sea las microtransacciones. Se creará una moneda del juego que puede adquirirse con dinero para comprar cosméticos. Por último, usaremos publicidad in-game para dar visibilidad a ciertas marcas a cambio de un coste monetario. 

### 9.3. Mapa de empatía
Para decidir cómo se desarrollará nuestro producto, hemos realizado un mapa de empatía para entender mejor las expectativas, frustraciones y deseos de los jugadores en torno al videojuego desarrollado por nosotros. 

Los jugadores tienen ciertas inquietudes relacionadas con la duración de las partidas, lo que puede afectar su nivel de compromiso con el juego. Por lo tanto, ofrecer un juego capaz de adaptarse tanto a jugadores casuales como asiduos hace que ambos tipos de jugadores puedan sentirse atraídos por el juego. También sienten que la monotonía puede aparecer después de varias sesiones si no hay suficiente variabilidad o mucha personalización. Para hacer frente a esto, pensamos en hacer un juego regulable y con posibilidad de obtener cosméticos que personalicen a tu personaje. 

Para atraer a la mayor cantidad de jugadores, nos centramos en que ven hoy en día los jugadores. Estos están constantemente expuestos a streamers/youtubers que juegan y dan sus opiniones acerca de un juego, pensamos que ser publicitado por algún influencer podría hacer que nuestro juego llegase a muchos jugadores. Además, uno de los sectores del gaming más reconocido es el mundo competitivo. Nuestro juego no solo tendrá una parte competitiva, sino que además fomentaremos la creación de una comunidad que anime a este tipo de jugadores a compartir su récord o superar el de los demás. 

Los jugadores son nuestros usuarios y valorar sus opiniones a la hora de crear un producto fue uno de nuestros pilares fundamentales a la hora de diseñar y desarrollar **Echoes of Xyphoria**. Los jugadores mencionan que, al disponer de poco tiempo libre, prefieren a jugar a juegos sencillos de entender con partidas cortas. Por ello, que el juego sea precisamente para navegador web facilita que se puede jugar en cualquier rato libre mientras dispongas de un dispositivo móvil con acceso a Internet. 

Para hacer conocido nuestro juego no solo podemos depender de streamers e influencers, por ello hemos queremos usar las redes sociales como principal canal de comunicación entre usuarios y empresa, intentando alcanzar la mayor cantidad de gente posible. Además, que el juego tenga una parte competitiva y una parte casual favorece la exposición boca a boca del juego. 

Los jugadores se enfrentan a varios problemas que dificultan su experiencia de juego. Algunos juegos no son intuitivos y no ofrecen una manera clara de aprender sus mecánicas. Otros se quejan de la dificultad elevada desde el principio, lo que puede frustrar a los nuevos jugadores. Además, la falta de instrucciones claras o tutoriales efectivos hace que algunos jugadores se sientan perdidos al inicio. Nuestros principales esfuerzos se centran en crear tutoriales efectivos con interfaces visibles y claras para que los jugadores puedan entender perfectamente las mecánicas del juego. También, estamos trabajando en el balanceo del juego para que su dificultad este correctamente ajustada. 

Tras tener todo esto en cuenta, queremos conseguir los siguientes resultados: 

- Crear una comunidad estable entre jugadores que ponga en el foco a nuestro juego y anime a los jugadores a seguir jugando. 
- Fomentar la parte competitiva de los juegos para atraer a todas aquellas personas amantes de los juegos competitivos. 
- Crear una experiencia entrañable para todo tipo de jugadores, tanto casuales como asiduos, con mecánicas únicas, divertidas y fáciles de entender. 
- Permitir a los jugadores dar rienda suelta a su imaginación creando cosméticos que alteren el aspecto de partes del juego, actualizando el juego con contenidos nuevos cada vez.

![Ilustración 27: Mapa de Empatía](Elementos%20de%20Diseño/ElementosModeloNegocio/MapadeEmpatia.jpg)

#### Ilustración 27: Mapa de Empatía

### 9.4. Caja de herramientas
A continuación, se muestra la caja de herramientas de Unknova:

![Ilustración 28: Caja de herramientas](Elementos%20de%20Diseño/ElementosModeloNegocio/CajadeHerramientas.jpg)

#### Ilustración 28: Caja de herramientas

### 9.5. Lienzo de modelo de negocio
A continuación, se muestra el lienzo de modelo de Unknova:

![Ilustración 29: Lienzo de modelo de negocio](Elementos%20de%20Diseño/ElementosModeloNegocio/LienzoModeloNegocio.jpg)

#### Ilustración 29: Lienzo de modelo de negocio

## 10. Marketing
El marketing será clave para destacar en un mercado competitivo. El foco estará en la exploración de mercado, el análisis de los requisitos de los usuarios y una estrategia de entrada disruptiva que permita que **Echoes of Xyphoria** sobresalga desde el inicio. El objetivo es crear una imagen de marca sólida y generar interés antes de su lanzamiento.

### 10.1. Relación con la competencia 
Respetamos el trabajo de otras compañías y creemos que una relación sana con la competencia es vital para fomentar el crecimiento de la industria. Aprender de los demás impulsa un mercado más fuerte y colaborativo.

### 10.2. Marketing digital
Nuestro enfoque principal será el uso de redes sociales para expandir nuestra audiencia. Desde el inicio, se creará contenido de calidad que destaque y fomente la viralidad, permitiendo a nuestros seguidores actuar como promotores del producto. Utilizaremos estas plataformas para interactuar directamente con los jugadores, conocer sus inquietudes y ajustar nuestra estrategia en base a su feedback.

### 10.3. Publicidad disruptiva
Optamos por una publicidad disruptiva y llamativa, diseñada para captar la atención desde el primer momento. Mediante tácticas innovadoras y visuales impactantes, buscaremos diferenciarnos de la competencia, haciendo que nuestra marca y juego sean inolvidables para los futuros jugadores.

### 10.4. Posicionamiento de la marca y competitividad
Nos centraremos en la calidad del producto como nuestro punto diferenciador. A diferencia de juegos con menos desarrollo gráfico, pero éxito comercial, se quiere que **Echoes of Xyphoria** sobresalga también por su profundidad y valor visual además de por sus mecánicas diferenciadoras. Desde el primer contacto, la presentación debe generar impacto.

### 10.5. Resumen de la estrategia
Esta estrategia de marketing se basa en destacar a través de innovación, interacción directa con los jugadores y contenido de calidad que haga que el juego sea atractivo desde su revelación inicial hasta su lanzamiento, asegurando un crecimiento sostenible y una marca reconocida.

## 11. Redes sociales
### 11.1. Misión
Como pequeña empresa, **Unknova** se centra en el desarrollo y diseño de videojuegos, combinando nuestra experiencia en Diseño Gráfico y Programación con el deseo de crear nuevas experiencias para los jugadores. Ofrecemos una experiencia única en el diseño y desarrollo de videojuegos, adaptada a las expectativas del mercado.

### 11.2. Meta
El objetivo principal es posicionar la marca **Unknova** en el mercado, construir una imagen sólida y generar interacciones con los jugadores. Buscamos que nuestra marca llegue al público objetivo a través de la creación de redes sociales, presentando nuestra identidad y siendo constantes en todas ellas.

### 11.3. Objetivos
Los objetivos clave son:
- Aumentar el alcance de la marca.
- Generar ingresos a través de microtransacciones/anuncios.
- Crear contenido audiovisual llamativo.
- Fomentar la interacción con la comunidad.
- Establecer una comunidad activa en diferentes plataformas.

### 11.4. Tácticas
Nos centraremos en redes sociales como Instagram y TikTok para expandir nuestra audiencia. Crearemos contenido audiovisual atractivo, adaptado a las tendencias, con el fin de generar viralidad y acercarnos a los usuarios. Utilizaremos Instagram y TikTok para mostrar el proceso de desarrollo y ofrecer contenido promocional, como descuentos o códigos exclusivos. 

Posteriormente, expandiremos nuestra presencia a Facebook y YouTube para alcanzar audiencias más amplias. YouTube servirá de escaparate para avances, tráileres y presentaciones finales. Vincularemos publicaciones entre plataformas para maximizar el alcance y optimizar el tiempo de gestión.

El uso de estas plataformas nos permitirá ajustar la estrategia de acuerdo con las respuestas del público, optimizando nuestras campañas y contenidos en función del rendimiento medido en cada red social.

### 11.5. Control
Monitorear el alcance y las interacciones será crucial para ajustar nuestra estrategia. Nos enfocaremos en el crecimiento orgánico y en las visitas del contenido, priorizando las opiniones y comentarios de los usuarios para afinar nuestra presencia en redes.

### 11.6. Resultados
Mediremos el engagement a través de herramientas de análisis en cada plataforma, evaluando la efectividad de nuestras publicaciones y ajustando la estrategia en función del rendimiento. Esto nos permitirá optimizar el crecimiento de la marca a largo plazo.

![Ilustración 30: Engagement rate individual](Elementos%20de%20Diseño/ElementosModeloNegocio/EngagementRateIndividual.jpg)

#### Ilustración 30: Engagement rate individual

![Ilustración 31: Engagement rate total](Elementos%20de%20Diseño/ElementosModeloNegocio/EngagementRateTotal.jpg)

#### Ilustración 31: Engagement rate total

**Enlace a redes sociales:** https://bento.me/unknova

## 12. Herramientas utilizadas
En el desarrollo de **Echoes of Xyphoria**, hemos empleado una variedad de herramientas que abarcan diferentes áreas del proyecto, desde la comunicación y gestión hasta el diseño y programación

### 12.1. Herramientas para la comunicación del equipo
- **WhatsApp**: Para mensajería rápida y coordinación diaria, facilitando la comunicación instantánea.

- **Discord** y **Microsoft Teams**: Para realizar llamadas grupales, videoconferencias y compartir pantallas en sesiones colaborativas. Estas herramientas han sido fundamentales en las reuniones semanales y revisiones de progreso.

- **Excel**: Se mantiene un registro de las llamadas y reuniones clave en hojas de Excel, asegurando un historial accesible para futuras referencias y seguimiento de decisiones.

### 12.2. Herramientas destinadas a la gestión del proyecto
- **Excel**: Al inicio del proyecto, se utilizó Excel para realizar una planificación preliminar y definir los requisitos iniciales.

- **GitHub**: Tras la planificación inicial, se adoptó **GitHub** como la plataforma principal de gestión del proyecto. Aquí, el **backlog** permite asignar tareas a los miembros del equipo según prioridades y roles específicos. La gestión del flujo de trabajo en GitHub facilita la integración continua y el seguimiento de los progresos del equipo.

### 12.3. Herramientas destinadas al diseño
- **3Ds Max** y **Blender**: Estas son nuestras herramientas principales para el modelado 3D, permitiendo crear personajes, escenarios y objetos.

- **Substance Painter**: Utilizada para la creación y aplicación de texturas en los modelos 3D, aportando realismo y detalles precisos a los objetos del juego. También se ha utilizado **Unity** para la generación de texturas de manera más integrada.

- **Photoshop**: Fundamental para la creación de contenido digital, concept art, bocetos y modelos 2D. Esta herramienta ha sido clave para el arte de redes sociales, así como para definir la estética visual del juego.

### 12.4. Herramientas de desarrollo
- **Unity**: El motor principal de desarrollo, que nos ha permitido crear el juego y gestionar sus aspectos gráficos, de física y lógica de juego.

- **Visual Studio**: Utilizado como entorno de desarrollo para escribir, editar y depurar el código. Visual Studio se ha integrado perfectamente con Unity para optimizar el flujo de trabajo.

### 12.5. Inteligencia Artificial
- **ChatGPT**: Utilizado para obtener apoyo en la programación y para la formalización de texto. ChatGPT ha ayudado a resolver problemas técnicos, generar ideas y asistir en la redacción de documentación técnica, como este Game Design Document. Además, ha sido una valiosa herramienta para afinar scripts complejos y para encontrar soluciones rápidas a problemas de desarrollo.

- **IAs para generación de imágenes**: Además, hemos utilizado herramientas de Inteligencia Artificial para la generación de imágenes y conceptos visuales, lo que ha facilitado la creación de concept art y ha servido como mera inspiración para definir estéticas alienígenas y paisajes futuristas. Estas IA han permitido acelerar el proceso de conceptualización y nos han brindado nuevas perspectivas artísticas que luego fueron refinadas por el equipo de diseño.

## 13. Ludografía
A continuación, se muestra una ludografía que cubre los aspectos esenciales de tres juegos que pueden haber servido de inspiración o referencia para el diseño del proyecto.

- **Hades (Supergiant Games, 2020)**
Hades es un roguelike de acción desarrollado por Supergiant Games. Los jugadores toman el rol de Zagreus, el hijo del dios del inframundo Hades, en su intento de escapar del inframundo y llegar al Monte Olimpo. Cada intento de escape lleva al jugador a través de varias salas llenas de enemigos, mejoras y jefes. Los niveles y enemigos son generados de forma procedural, y cada partida ofrece distintas combinaciones de armas y bendiciones otorgadas por los dioses olímpicos, lo que asegura variedad y rejugabilidad.

  Su estilo de combate rápido y basado en el control de habilidades especiales nos ha servido de inspiración a la hora de desarrollar las principales mecánicas de nuestro juego.

- **The Binding of Isaac (Edmund McMillen, 2011)**
The Binding of Isaac es un roguelike con elementos de "bullet hell" en el que el jugador controla a Isaac, un niño que intenta escapar de su madre, quien ha decidido sacrificarlo como prueba de fe. A lo largo del juego, el jugador explora niveles generados proceduralmente que recuerdan a mazmorras, luchando contra hordas de monstruos, recolectando ítems y derrotando jefes.

  La generación procedural de sus niveles junto con la creación de sinergias únicas en cada partida ha servido como ideas para dar a nuestro juego un enfoque único aportando rejugabilidad.

- **Archero (Habby, 2019)**
Archero es un juego de acción y rol para dispositivos móviles con mecánicas roguelike. El jugador controla a un arquero que debe avanzar a través de niveles generados de forma aleatoria, enfrentándose a oleadas de enemigos. El movimiento es clave, ya que solo puede disparar mientras está inmóvil, lo que obliga a los jugadores a moverse constantemente para evitar ataques enemigos mientras planean sus propios disparos.

  Este juego para dispositivos móviles nos ha servido como referencia para nuestro juego.  Buscamos adaptar nuestro juego igual de bien para todos aquellos jugadores que buscan una experiencia intensa y entretenida en dispositivos móviles. Además, la perspectiva de su cámara junto con su sistema de microtransacciones nos ha ayudado a pulir detalles de nuestro juego

## 14. Webgrafía
A continuación, se muestran listados enlaces de importancia usados en la creación del proyecto:
- [Información relevante acerca de GDDs](https://eldocumentalistaudiovisual.com/2015/02/06/documentacion-en-videojuegos-documento-de-diseno-gdd/)
- [Hades](https://es.wikipedia.org/wiki/Hades_(videojuego))
- [The Binding of Isaac](https://es.wikipedia.org/wiki/The_Binding_of_Isaac)
- [Archero](https://archero.fandom.com/wiki/Archero_Wiki)
- [ChatGPT](https://chatgpt.com/)
- [Copilot](https://copilot.microsoft.com/)
