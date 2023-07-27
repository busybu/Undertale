using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Undertale1
{
    public class Game
    {
        private static Game instance;
        public static Game Instance
        {
            get
            {
                if (instance is null)
                    throw new Exception("Jogo não inicializado ainda");

                return instance;
            }
        }

        public static void StartGame(PictureBox pb, Form form)
            => instance = new Game(pb, form);

        private Timer tm = new Timer();

        Image main;
        Image bg;
        Form forms;
        Sprite sprite;
        GraphicsControl gc;
        Map map;
        private Game(PictureBox pb, Form form)
        {
            gc = new GraphicsControl(pb);
            sprite = new Sprite(Image.FromFile("C:\\Users\\User\\source\\repos\\Undertale\\sprites\\personagens\\spriteNoBG.png"), gc);
            map = new Map();
            map.gc = gc;
            bg = Image.FromFile("C:\\Users\\User\\source\\repos\\Undertale\\sprites\\mapas\\map.png");
            forms = form;
            gc.InitGraphics();
        }

        public void Start()
        {
            int wid = 30, hei = 33;
            sprite.AddCharacter(wid, hei);
            sprite.AnimationSpeed = TimeSpan.FromMilliseconds(200);
            sprite.Rec = new Rectangle(
                forms.Width / 2 - 3 * wid / 2,
                forms.Height / 2 - 3 * hei / 2,
                3 * wid,
                3 * hei
            );

            map.RestricedArea.Add(new Rectangle(17, 3862, 367, 68));
            map.RestricedArea.Add(new Rectangle(375, 4015, 30, 50));
            map.RestricedArea.Add(new Rectangle(18, 3862, 8, 210));
            map.RestricedArea.Add(new Rectangle(384, 3995, 316, 9));
            map.RestricedArea.Add(new Rectangle(384, 3905, 296, 55));
            map.RestricedArea.Add(new Rectangle(10, 4034, 390, 14));
            map.RestricedArea.Add(new Rectangle(674, 3925, 31, 24));
            map.RestricedArea.Add(new Rectangle(821, 3279, 68, 88));
            map.RestricedArea.Add(new Rectangle(671, 3668, 30, 153));
            map.RestricedArea.Add(new Rectangle(814, 3728, 75, 102));
            map.RestricedArea.Add(new Rectangle(879, 3826, 50, 34));
            map.RestricedArea.Add(new Rectangle(690, 3647, 72, 53));

            map.Interactions.Add(new Message
            {
                Area = new Rectangle(150, 3915, 358, 40),
                Text =
                {
                    "Nessa parte do mundo, a grama do vizinho é menos verde",
                    "Na verdade, lá em cima nós nem temos grama"
                }
            });
            map.Interactions.Add(new Message
            {
                Area = new Rectangle(769, 3520, 24, 20),
                Text =
                {
                    "Nem todas as alavancas são ruins... Assim como nem todo mundo aqui é bom ou mau, ou toda história seja verdadeira ou falsa, veja com seus próprios olhos, ande com seus próprios passos. Os humanos e as máquinas tem mais em comum do que pensam."
                }
            });
            map.Interactions.Add(new Message
            {
                Area = new Rectangle(846, 3688, 10, 25),
                Text =
                {
                    "Essas avalancas dão medo... Já ouvi falar que eles usavam ela quando precisavam desligar uma parte da fábrica. Quando falavam algo sobre 'férias coletivas', um sinônimo para o fim do mundo...."
                }
            });
            map.Interactions.Add(new Message
            {
                Area = new Rectangle(795, 3728, 75, 102),
                Text =
                {
                    "Aqui é onde costumavam vir os funcionários que foram forçados a entrar na fábrica, não parece ser um lugar muito atrativo...",
                    "Uma pena que os humanos não dessem conta do quanto esses ambientes dão sono."
                }
            }); ;
            map.Interactions.Add(new Message
            {
                Area = new Rectangle(455, 3915, 39, 60),
                Text =
                {
                    "Essa imagem lembra alguma coisa que aprendi quando era apenas uma jovem máquina",
                    "No século passado esse tipo de barba e vestimenta ainda era muito utilizado",
                    "Talvez seja algum homem importante",
                    "Aqui diz: Certamente não é o Stati"
                }
            });
            map.Interactions.Add(new MutableInteract
            {
                Img = Image.FromFile("C:\\Users\\User\\source\\repos\\Undertale\\sprites\\personagens\\heart.jpg"),
                NewImg = Image.FromFile("C:\\Users\\User\\source\\repos\\Undertale\\sprites\\personagens\\heartBrok.png"),
                Area = new Rectangle(59, 3902, 28, 32),
                Title = "Coração",
                Text =
                {
                    "'É preciso passar pela dor para sobreviver aqui'",
                    "..."
                },
                PostText =
                {
                    "Apenas um coração quebrado"
                }
            });

            map.Interactions.Add(new Message
            {
                Title = "Zé maria",
                Area = new Rectangle(840, 3920, 22, 34),
                Text =
                {
                    "Ei, cuidado por onde anda!",
                    "Esses últimos anos esse lugar tem estado muito perigoso.",
                    "Nosso último recorde sem acidentes era 1604 dias :(", 
                    "Vou te ensinar algumas coisas a NÃO serem feitas aqui ok?!"
                }
            });
            map.Interactions.Add(new MutableInteract
            {
                Img = Image.FromFile("C:\\Users\\User\\source\\repos\\Undertale\\sprites\\personagens\\instruction.png"),
                NewImg = Image.FromFile("C:\\Users\\User\\source\\repos\\Undertale\\sprites\\personagens\\bloodinstruction.png"),
                Area = new Rectangle(720, 3672, 35, 35),
                Size = new Size(94, 94),
                Title = "Eles",
                Text =
                {
                    "Eles não querem que saibam a verdade sobr..394Q2QWQISSASAQ123O55OFG.. ÇEW~~]64]~~"
                },

            });

            tm.Interval = 20;
            tm.Start();

            int x = 0;
            int y = 3850;
            bool interacting = false;
            bool inMiniGame = false;


            tm.Tick += delegate
            {
                Rectangle recImg = new Rectangle(x, y, 400, 250);
                Rectangle recTeste = new Rectangle(100, 100, 300, 300);

                gc.ClearAll();
                if (inMiniGame)
                {

                }
                else
                {
                    gc.DrawFullScreenRec(bg, recImg);
                    map.DrawInteractions(x, y, forms.Width, forms.Height);
                    if (interacting)
                        map.InteractArea(x, y, forms.Width, forms.Height);
                    sprite.Draw();

                }

                gc.Refresh();
            };
            forms.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                    Application.Exit();

                switch (e.KeyCode)
                {
                    case Keys.W:
                        if (interacting)
                            break;

                        sprite.State = 0;
                        y -= 3;
                        (x, y) = map.VerifyArea(x, y, sprite);
                        break;

                    case Keys.D:
                        if (interacting)
                            break;

                        sprite.State = 1;
                        x += 3;
                        (x, y) = map.VerifyArea(x, y, sprite);
                        break;

                    case Keys.A:
                        if (interacting)
                            break;

                        sprite.State = 2;
                        x -= 3;
                        (x, y) = map.VerifyArea(x, y, sprite);
                        break;

                    case Keys.S:
                        if (interacting)
                            break;

                        sprite.State = 3;
                        y += 3;
                        (x, y) = map.VerifyArea(x, y, sprite);
                        break;

                    case Keys.Space:
                        interacting = map.StartInteract(x, y);
                        break;
                }
            };
            forms.KeyUp += (s, e) =>
            {
                switch (e.KeyCode)
                {
                    case Keys.W:
                        sprite.State = 4;
                        break;

                    case Keys.D:
                        sprite.State = 4;
                        break;

                    case Keys.A:
                        sprite.State = 4;
                        break;

                    case Keys.S:
                        sprite.State = 4;
                        break;
                }
            };   
        }

    }
}
