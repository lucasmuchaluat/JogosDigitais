# BirbSimulator

## Identidade do jogo (Conceito)

Flup, um pássaro biônico, deve enfrentar o seu medo de abelhas geneticamente alteradas para conseguir retornar ao seu bando e atualizá-los dos novos testes que estão fazendo com a sua raça!

## Descrição da mecânica (Core Mechanics / System design)

É um jogo no estilo side scroller e endless run. O objetivo é ganhar o maior número de pontos possível, controlando um pássaro sem deixá-lo colidir nos canos. Se o pássaro tocar em algum obstáculo - ou se for atingido pelo mel corrosivo da abelha inimiga - o jogo termina. Sempre que o personagem passa por um conjunto de canos, o jogador ganha um ponto. Durante o jogo, além de desviar dos obstáculos, o jogador tem a opção de atirar no inimigo, podendo causar dano nele ou explodir seu mel antes dele o atingir.

## Características (Mundo do jogo)

O jogo consiste em uma mistura de dois estilos muito conhecidos. O primeiro é uma espécie de Flappy Bird, no qual o pássaro deve desviar dos canos que surgirão em sua tela. O segundo se baseia no Shoot 'Em Up, no qual um Big Boss fica atirando nesse mesmo pássaro até ser morto por ele. A ideia é mostrar a evolução desses dois estilos em um ambiente favorável, mudando a forma como a jogabilidade pode ser usada e adicionando novas mecânicas core a medida que o jogo avança.

## Arte

O jogo é no formato 2D, com uma arte semelhante ao estilo do Mario Bros. Uma estética amigável e bem leve. A ideia é torná-la a mais simples e menos vulgar possível para que os fans dos dois estilos de jogo possam aproveitar ao máximo a experiência e relembrar seus tempos antigos de video game.

## Música/Trilha Sonora

Wii Sports Theme (https://youtu.be/d5c4KOopwLs) retirada da febre da primeira década de 2000, que acabou sendo um dos jogos mais jogados do mundo. Com sua competitividade íntriseca, nostalgia a milhão, a música do Wii Sports conforta todos aqueles jogadores que gostam de reviver suas lembranças e aproveitar um bom jogo de época.

## Interface

A interface adotada é a mais simples e intuitiva possível. Inicialmente, o jogador coloca seu nome de usuário. Depois ele clica no botão "INICIAR" para começar o jogo. Enquanto joga, na tela aparecerá a contabilização de quantos pontos estão sendo feitos e as vidas de ambos os personagens (passaro e abelha inimiga). Quando acabar, um Leaderboard surgirá a fim de mostrar a comparação de desempenho entre amigos!

## Controles

Suas teclas de comando são SPACE (para bater as asas e desviar dos tubos) e WASD (para atirar contra o inimigo). Ainda, se quiser pausar o jogo, basta pressionar ESC. Os controles simples e fáceis fazem com que a jogabilidade se diferencie de outras maneiras, como timing, expectativa, etc.

## Dificuldade

A dificuldade do jogo se baseia na evolução que o passaro vai enfrentando com o tempo. Existem algumas features que podem tanto facilitar quanto dificultar a jogabilidade. É possível potencializar seus ataques ou, até mesmo, se tornem inálvejável por um tempo. Além disso, o jogador terá que se preocupar constantemente em desviar dos tubos que surgem na tela de forma aleatória. 

## Fluxo do jogo

Tela de Menu ==> Tela do Jogo ==> Tela Final do Jogo

## Personagens

* Jogável:
    - Flup: Pássaro biônico controlado pelo jogador.

* Não Jogável:
    - Abelha Geneticamente Modificada: Inimiga principal do jogo. Com o tempo, vai ganhando novas "habilidades". Sua missão é atrapalhar e destruir o jogador, atirando nele constantemente seja qual for a sua posiçao na tela.

## Cronograma, Escopo e Requisitos

Após a versão beta do jogo, foi possível coletar alguns feedbacks interessantes:
* Colocar mais vidas e fazer o boss mais completo (mais vidas, features) LM
* Fazer score do jogador (por cano) LV Done
* Melhorar tela final (deixar claro se ganhou ou perdeu) LV Done
* Mudar o tiro para algo real (tirar a bola verde) LM
* Consertar os sons dos tiros e contatos LM
* Animar o boss LM
* Consertar o PAUSE LV Done
* Fazer GDD e colocar no README LM
* Limitar movimento do passaro nas extremidades da tela LM Done
* Canos serem HandMade (editor de fase) LV -- Hold
* Nivelar som do jogo padrão LM
* Acertar hitboxes do passaro com os canos LV Done
* Trocar background móvel LM

## Definições gerais

* Gênero: Endless Run / Side Scroller / Shoot 'Em Up;

* Plataformas: Unity 2D;

* Público alvo: Jogadores a partir de 3 anos, foco na nostalgia e nos fans dos dois estilos referência.
