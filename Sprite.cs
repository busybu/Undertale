using System;
using System.Drawing;
namespace Undertale1
{
    public class Sprite
    {
        public Rectangle Rec { get; set; }
        public Image Img { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; set; }

        public Sprite(Image img, Rectangle rec)
        {
            this.Img = img;
            this.Rec = rec;
        }
        public void WalkingLeft(GraphicsControl gc)
        {
            Rec.Y = 64;
            for (int i = 0; i < 3; i++)
            {

                gc.DrawImageRec(Img, Rec);
                
        }
        }

    }
}

