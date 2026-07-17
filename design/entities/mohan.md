# Ficha de Entidad — El Mohán (Poira)

> Documento narrativo + diseño de sistemas. Define reglas jugables, no implementación técnica. Ambientación: región Andina (MVP). Dominio: el río, límite sur del pueblo (ver `design/levels/pueblo-hub.md`).
> Verbo de resolución: **DAR / NEGOCIAR UN PACTO.**

---

## 1. Identidad narrativa

**Qué es, en la tradición y en este pueblo.** El Mohán no es un monstruo del río: es su *dueño*. Un ser antiguo, velludo, de ojos de brasa y cabellera y barba enredadas de musgo, que vive en los pozos profundos y las cuevas bajo las barrancas. Fuma tabaco, bebe aguardiente, toca música (tiple, guacharaca o flauta según quién cuente) y es un seductor incansable. No odia al pueblo: *cobra*. El río da pescado, da agua para el trapiche, da un cruce seguro por el vado — y todo eso, en la cosmovisión del pueblo, tiene dueño y tiene precio.

**El pacto ancestral local.** En este pueblo existe una costumbre concreta y todavía viva: sobre una **piedra plana junto al vado** (la llaman *la piedra del dueño* los viejos, *la piedra de las ánimas* los devotos, *esa bobada* los jóvenes) los pescadores dejan **tabaco mascado y un chorro de aguardiente** antes de las jornadas importantes, y las lavanderas no cantan ciertas coplas "para no llamarlo". Nadie recuerda haber pactado nada formalmente; el pacto se *hereda* como se hereda el oficio. Mientras la piedra se alimente, el río es generoso y el vado es seguro. El pacto es **tácito, relacional y frágil**: no protege a "el pueblo" en abstracto, sino a quienes lo honran y a sus familias.

**La leyenda cambia según a quién le preguntes** (esto es material de deducción, no color):

- **Los pescadores viejos** lo cuentan como un patrón justo pero severo: "él da y él cobra; el que no paga, que no se queje". Para ellos el Mohán es un hecho económico.
- **Las lavanderas de las piedras** lo cuentan como seductor: se llevó a fulana, la vieron "rejuvenecida y ausente", habla de cuevas de oro y juventud. Registro de advertencia femenina, transmitido de madre a hija.
- **El cura y los devotos** niegan al Mohán y lo reducen a superstición o a "el enemigo": para ellos alimentar la piedra es pecado, y hay una campaña reciente por acabar la costumbre.
- **Los niños de la escuela** lo mezclan con el coco: exageraciones útiles, algún detalle real enterrado en la fantasía.
- **El corregidor / gente nueva del barrio nuevo** tienden a la explicación racional: "es la creciente", "son cuentos", "alguien está robando".

Esta fractura de testimonios es deliberada: **ningún NPC tiene la verdad completa**, y el registro de quien habla sesga lo que dice (Pilar 5 — el jugador siempre decide con información incompleta).

---

## 2. La regla del pacto (el verbo jugable)

El error de diseño a evitar es que negociar degenere en "adivina el ítem del inventario". La solución estructural: **la ofrenda no es un objeto que se encuentra, es una composición que se deduce**. Tiene **tres componentes**, y las pruebas del caso determinan cada uno. Encontrar tabaco o aguardiente es trivial; saber *qué* ofrecer, *por qué* y *de parte de quién* es todo el juego.

### Componentes de una ofrenda válida

**A) El tributo base (la "renta").** Tabaco y aguardiente sobre la piedra. Es el mínimo relacional que reconoce que el río tiene dueño. Casi siempre presente; su ausencia (piedra barrida, costumbre abandonada) suele ser *la causa misma* del conflicto, no la solución.

**B) La restitución (el corazón de la deducción).** El Mohán se enoja por una **transgresión concreta**, y el tributo base no basta si la transgresión sigue abierta. La restitución debe *corresponder a lo que se rompió*:
- Si alguien **cortó el flujo** (represó el agua en el trapiche, tapó un pozo) → la restitución es *devolver el agua* / abrir el paso, no más aguardiente.
- Si alguien **pescó en tiempo o lugar vedado** (su pozo, en creciente, con barbasco/veneno) → restitución = renunciar a esa captura o compensarla.
- Si alguien **ensució o profanó** su dominio (basura, un ahogado sin honrar, ruido) → restitución = limpiar/honrar.
- Si el Mohán **retiene a una persona** (seducción) → la restitución cambia de naturaleza: no se le paga *por* la persona, se negocia un **sustituto de valor equivalente para él** (música, un objeto de deseo) o se descubre que **el pacto es con ella, no contigo** (ver §5).

**C) El portador legítimo (componente relacional — regla simplificada para el MVP).** El pacto es entre el Mohán y *personas*, no entidades abstractas. Para el MVP la regla es deliberadamente simple, sin excepciones ni linajes: **el Mohán reconoce únicamente a quien tiene una relación directa con la transgresión o con aquello que debe restituirse** (quien la cometió, o quien está más directamente afectado por ella). Cualquier otra persona que intente ofrendar es ignorada o cobrada de más. *Esta regla puede ampliarse en casos posteriores (herencia de oficio, representación) si el sistema demuestra funcionar en el MVP — no se compromete esa complejidad ahora.*

### Qué invalida una ofrenda

- **Ofrecer contra su naturaleza**: agua bendita, oraciones, cruces, amenazas, fuego → no es que "no funcione", es que *ofende* y transforma el encuentro a peor (§5). El Mohán no es un demonio a exorcizar; tratarlo como tal rompe el pacto en vez de restaurarlo.
- **Restitución que no corresponde**: pagar tributo cuando lo roto es el flujo del agua → él acepta el aguardiente y *sigue cobrando*, porque la causa real sigue abierta (falso positivo peligroso, ver §5).
- **Sobrepago**: dar de más "por si acaso" → el Mohán *fija ese nuevo precio* y lo esperará siempre (consecuencia permanente, §6).
- **Portador ilegítimo**: la ofrenda correcta dada por la persona equivocada → se degrada a tributo base y no cierra la transgresión.

### Cómo varía la ofrenda correcta según contexto (anti-memorización)

La regla que el jugador aprende **no es "dale tabaco y aguardiente"** — esa es la trampa de memorización. La regla real es: **"identifica la transgresión, haz que corresponda la restitución, y hazla dar por quien tiene relación directa con ella"**. Como la transgresión cambia en cada caso (represó / pescó vedado / profanó / sedujo), la ofrenda correcta cambia con ella. Un jugador que memorizó "tabaco+aguardiente" *fallará* el segundo caso del Mohán, porque ahí lo roto no era la renta. Esto sostiene el Pilar 3 (cada aparición rompe la regla aprendida) incluso dentro del mismo mito.

---

## 3. Señales observables (antes de la certeza)

Restricción clave: el Art Bible **prohíbe que el arte delate** al Mohán (nada de tratamiento visual "especial", nada de iluminación selectiva de peligro). Por tanto **todas** estas señales viven en **comportamiento de NPCs, testimonios, y patrones de eventos** — no en cómo se ve el mundo.

**Patrón económico asimétrico (la señal madre).** La desgracia del río **no es uniforme**: unos pescadores siguen con buenas jornadas, otros vuelven con las redes vacías o rotas. Esa asimetría es rastreable a *quién dejó de alimentar la piedra* o *quién ofendió al río*. (Una causa natural — creciente — golpearía a todos por igual; esta selectividad es la primera pista de que hay un dueño cobrando.)

**La piedra del vado.** Estado observable por inspección/testimonio: ¿está alimentada, barrida, o alguien la limpió a propósito? Un dato duro: si el cura o un converso "acabó con esa superstición" y el conflicto empezó *después*, hay correlación temporal.

**Música al crepúsculo.** Barks y testimonios (no audio-tell garantizado): pescadores que "oyeron un tiple del lado del río a la caidita de la tarde" y nadie lo tocaba. Correlaciona con el reloj real (crepúsculo/noche), lo cual también da una **regla de timing** al jugador sin codificar "modo peligro".

**Conducta alterada de una persona (vector de seducción).** Una mujer (o quien sea el objeto de su deseo) que: se ve "más joven / radiante" según las lavanderas, se distrae, tararea una copla que no sabe de dónde sacó, baja al río sola al atardecer, guarda un objeto nuevo sin explicar su origen. Todo esto es **comportamiento reportado por terceros**, no un aura visual.

**El tipo de daño físico.** Redes *cortadas limpias* vs. *enredadas/desgarradas por palos*: distinguen "el dueño cobrando su parte" de una palizada sumergida natural. Aguardiente y tabaco que *desaparecen* de las reservas del trapiche o de las casas. Huellas o ausencia de huellas humanas en la orilla (separa al Mohán de un saboteador humano).

**El silencio de los que saben.** Los pescadores viejos *evitan* el tema o responden con evasivas ("no hay que nombrarlo"): el patrón de *quién no quiere hablar* es en sí una señal.

---

## 4. Candidatos de confusión (hipótesis rivales)

Los mismos síntomas — malas jornadas, redes rotas, alguien que desaparece o cambia — admiten al menos cuatro lecturas plausibles. El diseño de cada caso debe sembrar pistas para **2–4** de ellas.

**1) Causa natural (creciente / palizada sumergida).**
- *Pista malinterpretable*: redes desgarradas, agua turbia, un ahogamiento.
- *Por qué engaña*: es la explicación más económica y el corregidor la empuja.
- *Distinguidor*: lo natural es **uniforme y correlaciona con el clima** (lluvias aguas arriba, creciente que sube para todos). Si el daño es *selectivo* y sigue a las personas, no al caudal, no es natural. Una palizada deja restos físicos localizables; el Mohán no.

**2) La Madremonte (figura del monte, aguas arriba — tratada como red herring, no confrontable en el MVP).**
- *Pista malinterpretable*: agua súbitamente turbia, enfermedad de quien bebió, tormenta que "castiga".
- *Por qué engaña*: comparte el elemento agua y es una atribución folclórica común; algunos NPCs la nombran. Es una **confusión de dominio cruzado** valiosa: el monte (norte, Patasola) y el río (sur, Mohán) se tocan en el agua.
- *Distinguidor*: la ira de la Madremonte responde a **transgresión ambiental** (talar, ensuciar el monte, cazar de más) y **viene de arriba** con creciente y mal tiempo; es impersonal y colectiva. El Mohán es **transaccional y personal** (tributo, seducción), atado a los **pozos** y a individuos concretos. Ofrenda equivocada garantizada si se confunden: a la Madremonte no se le paga con tabaco.

**3) Brujería local (maleficio humano).**
- *Pista malinterpretable*: **la selectividad** — la desgracia cae sobre una familia concreta. (Este es el candidato peligroso, porque la selectividad también apunta al Mohán.)
- *Por qué engaña*: reproduce el mismo síntoma-madre (asimetría) por una causa totalmente distinta.
- *Distinguidor*: el maleficio tiene **motivo humano rastreable** (envidia, pleito de tierras, un desaire) y **sigue a la persona**, no al río — la víctima tiene mala suerte también lejos del agua. El "remedio" es un contrahechizo, no un pacto. Si el jugador va al río a negociar cuando era una bruja con rencor, negocia con nadie y el maleficio sigue.

**4) Estafador humano (racket de "protección del río").**
- *Pista malinterpretable*: alguien exige "hay que pagarle al río", la piedra aparece barrida, hay una demanda de bienes.
- *Por qué engaña*: **imita el pacto real casi a la perfección** — es el reverso oscuro de la costumbre. Puede ser el barquero del vado, un forastero de la fonda, incluso alguien que *sabotea las redes de los que no pagan* para sostener el miedo.
- *Distinguidor*: el tributo va a **un bolsillo humano** (dinero, no tabaco ritual); las demandas **escalan hacia el efectivo**; el sabotaje deja **rastro físico** (soga cortada con cuchillo, huellas, un cómplice). El Mohán no cobra en pesos.
- *Por qué es la trampa central*: aquí el error se vuelve doble filo. **Negociar con el Mohán cuando era un estafador** → pagas a la nada y el estafador prospera. **Romper la costumbre acusando de fraude cuando el pacto era real y funcionaba** → ofendes al dueño, se retira su protección y el río se vuelve *genuinamente* peligroso (ver §6). Distinguir mito de fraude es el núcleo deductivo de este mito.

---

## 5. La confrontación de ingenio

No es combate. Es un **regateo ritual** en el pozo/cueva del Mohán, al que se llega **cruzando el río por el vado** (o adentrándose a su pozo). Cruzar es una decisión consciente (geografía fijada en `pueblo-hub.md`), y **el momento importa**: el Mohán aparece al **crepúsculo/noche** (reloj real). Ir a mediodía = la piedra está muda, viaje perdido o solo reconocimiento; el jugador debe *elegir la hora*, y esa elección es parte del plan. *(Pendiente de validación mecánica con `game-designer` — ver ambigüedades.)*

### Estructura del encuentro (decisiones en orden)

1. **La aproximación.** ¿Cómo te presentas? Con respeto y ofrenda en mano, o con hostilidad/objetos sagrados. La aproximación equivocada (agua bendita, amenaza, fuego) **no termina el encuentro**: el Mohán se ofende, se hunde más hondo, *sube el precio* o se lleva algo (un objeto, una promesa) antes de reabrir el trato en peores términos.

2. **Nombrar la transgresión.** El jugador **declara qué se rompió** (represa, pesca vedada, profanación, seducción). Aquí se pone a prueba la hipótesis. Nombrar mal la causa hace que el Mohán *juegue*: puede aceptar y callar, dejándote creer que acertaste mientras la causa real sigue abierta.

3. **Presentar la ofrenda compuesta** (tributo + restitución + portador, §2). Este es el acto central del verbo.

4. **El contra-ofrecimiento (la tentación).** El Mohán regatea. Puede pedir *más*, o **ofrecer un trato envenenado**: una jornada milagrosa, oro de su cueva, juventud. Aceptar la tentación **desplaza las consecuencias en vez de resolverlas** (ganas hoy, el río te cobra a ti o a un tuyo después). Rechazar la tentación es a menudo parte de la resolución correcta.

5. **Sellado del pacto.** Según lo anterior, el trato se cierra, se mal-cierra, o se cede.

### Ramas de resultado

**Hipótesis y ofrenda correctas** → el pacto se **restaura o renegocia**: el río vuelve a dar, la persona retenida es liberada o los términos quedan claros, el vado es seguro otra vez. El mundo mejora de forma visible y permanente. Puede quedar un costo justo (el pueblo *aprende* a mantener la costumbre).

**Hipótesis correcta, ofrenda incorrecta** (nombraste bien la causa pero restituiste mal, o portador ilegítimo) → el Mohán **acepta lo que puede y deja abierto el resto**: alivio parcial, la transgresión persiste, el problema **reaparece degradado** en un caso futuro.

**Hipótesis incorrecta** (era una bruja, o un estafador, o la creciente) → **no hay interlocutor o hay ofensa**. Si no había Mohán que negociara, gastas la ofrenda en la nada y la causa real avanza. Si el pacto era real y lo trataste como fraude/demonio, **lo rompes**: se retira la protección. En ningún caso hay pantalla de derrota — **el encuentro se transforma**, no se corta. El jugador sale del río habiendo *cambiado el trato*, para bien o para mal, y vive con ello.

**Sobrepago / tentación aceptada** → resolución aparente, deuda oculta: el precio queda fijado alto o la cuenta pasa a un tercero, y **eso reaparece** (§6, §7).

---

## 6. Consecuencias de fallar o no intervenir

Este mito genera consecuencias de **tipo económico-relacional y demográfico**: no mata al jugador, *vacía y encarece el mundo*. Tipos concretos (sin fijar todavía un caso):

- **El río se cierra para una familia** → una casa/puesto de pescadores queda **improductiva; el NPC y su familia se van del pueblo**. Su vivienda y su puesto quedan permanentemente vacíos en el hub; sus líneas de diálogo y su testimonio dejan de estar disponibles para casos futuros. El pueblo se siente medido, más pobre, más solo.

- **Una persona retenida se pierde o vuelve cambiada** → la mujer seducida queda **permanentemente ausente** (su familia altera su conducta y su rol), o **regresa "rejuvenecida y hueca"**: presente pero vaciada, un estado de NPC persistente que otros comentan y que reaparece como pista o como advertencia en casos posteriores.

- **Pacto mal fijado / sobrepago** → la piedra del vado ahora **exige tributo escalante**. Los casos futuros ligados al río **empiezan con una deuda**: menos margen, el trapiche produce menos, el pueblo entra más pobre a la siguiente crisis. La consecuencia es *acumulativa*, no un simple flag.

- **Pacto roto por acusación errónea** (lo trataste de fraude/demonio y era real) → el río pierde su dueño protector y se vuelve **genuinamente peligroso**: **más ahogamientos, el vado deja de ser seguro**. Un cruce que antes era una decisión tranquila se vuelve un riesgo diegético en escenarios posteriores.

- **Dejar prosperar al estafador** (no interviniste, o culpaste al mito) → el racket se **institucionaliza**: el estafador gana poder en el pueblo, aparece como obstáculo/autoridad corrupta en casos futuros.

En todos los casos la consecuencia es **visible en el hub** (una casa vacía, una persona cambiada, una piedra que exige más, un vado peligroso) y **modifica el estado inicial de casos posteriores** (Pilar 4).

---

## 7. Nota de reaparición

La segunda aparición del Mohán **no puede ser "otra vez arreglar el pacto roto"** — eso violaría el Pilar 3 y premiaría la memorización. La reaparición debe **invertir o reencuadrar el verbo**. Tres vectores válidos (elegir uno al diseñar el caso posterior):

**A) Invertir el verbo: de pagar a salir del pacto.** La primera vez el jugador *restaura* un pacto. La segunda, el problema *es* el pacto: un personaje quiere **salir** de un trato que hizo (una mujer que cambió años de vida por juventud y hoy quiere revertirlo; un pescador que "vendió" algo por buenas jornadas y ahora paga un precio insoportable). El verbo pasa de "dar tributo para apaciguar" a **"negociar una liberación / hallar el sustituto que lo suelte"**. Todo lo que el jugador aprendió — *alimenta la piedra* — ahora lo **desorienta**, porque más tributo solo *afirma* el pacto que la víctima quiere romper.

**B) Cambiar de bando: el Mohán como parte agraviada.** El humano es el villano — alguien lleva tiempo **robándole al río** (barbasco, dinamita, saqueo de su cueva) y el Mohán responde. El jugador debe negociar **del lado del Mohán contra un humano**, invirtiendo la simpatía: la entidad que aprendiste a temer/aplacar es ahora la víctima, y el "vecino razonable" es el ofensor.

**C) Recontextualizar por consecuencia previa.** Si en el primer caso el jugador **sobrepagó o aceptó la tentación**, la reaparición es el **cobro de esa deuda oculta** — la cuenta que se difirió vuelve, ahora sobre otra persona o sobre el propio investigador. El caso es genuinamente nuevo porque *lo sembró el jugador mismo*.

En los tres, la costumbre aprendida (la piedra, el tabaco, el aguardiente) sigue siendo *cierta* pero **insuficiente o engañosa** para el nuevo contexto — que es exactamente cómo el mito debe crecer sin repetirse.

---

## Notas de traspaso

- **Timing crepúsculo/noche (§5)**: pendiente de validación mecánica con `game-designer` — introduce una decisión de *cuándo* cruzar el río, que debe encajar limpiamente en el sistema de preparación general del juego.
- **Consecuencias permanentes (§6)**: alteran el estado del hub (`design/levels/pueblo-hub.md`) — casa vacía, vado peligroso, piedra escalante. Coordinar con `level-designer` al asignar casos concretos.
- **Señales observables (§3)**: confirmar con `art-audio` que pueden expresarse sin romper la regla de iluminación uniforme del Art Bible.
- **Portador legítimo (§2.C)**: regla simplificada para el MVP por decisión explícita — sin excepciones ni linajes. Revisar si ampliarla una vez el sistema esté probado.
