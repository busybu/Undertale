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
            sprite = new Sprite(Image.FromFile("C:\\Users\\disrct\\Desktop\\Undertale\\sprites\\personagens\\spriteNoBG.png"), gc);
            map = new Map();
            bg = Image.FromFile("C:\\Users\\disrct\\Desktop\\Undertale\\sprites\\mapas\\map.png");
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

            tm.Interval = 20;
            tm.Start();

            int x = 0;
            int y = 3833;
            tm.Tick += delegate
            {
                Rectangle recImg = new Rectangle(x, y, 400, 250);
                Rectangle recTeste = new Rectangle(100, 100, 300, 300);

                gc.ClearAll();
                gc.DrawFullScreenRec(bg, recImg);

                sprite.Draw();
                gc.Refresh();
            };
            forms.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape)
                    Application.Exit();

                switch (e.KeyCode)
                {
                    case Keys.W:
                        sprite.State = 0;
                        y -= 3;
                        y = map.VerifyArea();
                        break;

                    case Keys.D:
                        sprite.State = 1;
                        x += 3;

                        break;

                    case Keys.A:
                        sprite.State = 2;
                        x -= 3;

                        break;

                    case Keys.S:
                        sprite.State = 3;
                        y += 3;

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
