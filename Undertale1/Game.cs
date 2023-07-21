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

        private Game(PictureBox pb, Form form)
        {
            gc = new GraphicsControl(pb);
            sprite = new Sprite(Image.FromFile("C:\\Users\\disrct\\source\\repos\\Undertale1\\sprites\\personagens\\spriteNoBG.png"), gc);
            bg = Image.FromFile("C:\\Users\\disrct\\source\\repos\\Undertale1\\sprites\\mapas\\map.png");
            forms = form;
            gc.InitGraphics();
        }

        public void Start()
        {
            int x = forms.Width / 2, y = forms.Height/2 ;

            tm.Interval = 20;
            tm.Start();

            tm.Tick += delegate
            {
                Rectangle recImg = new Rectangle(0, 3833, 400, 250);
                
                gc.DrawFullScreenRec(bg, recImg);
                sprite.Draw();
                gc.Refresh();
            };
            forms.KeyDown += (s, e) =>
            {
                if(e.KeyCode == Keys.Escape) 
                    Application.Exit();

                if (e.KeyCode == Keys.D)
                {
                    x++;
                    sprite.State = 1;
                }  
                if(e.KeyCode == Keys.W)
                    y--;
            };
        }

    }
}
