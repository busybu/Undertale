using System;
using System.Collections.Generic;
using System.Drawing;
namespace Undertale1
{
    public class Sprite
    {
        public Rectangle Rec { get; set; }
        public Image Img { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; set; } = 10;
        public int State { get; set; }
        public List<Rectangle> Sprites { get; set; } = new List<Rectangle>();
    
        public GraphicsControl gc { get; set; }
        public Sprite(Image img, GraphicsControl graf)
        {
            this.Img = img;
            this.gc = graf;
        }
       
        public void AddCharacter(int widthCharacter, int heightCharacter)
        {
            int x = 0;
            int y = 0;
            for(int i = 0; i < 12; i++)
            {
                this.Sprites.Add(new Rectangle(widthCharacter, heightCharacter, x, y));

                if (i % 3 == 0)
                {
                    x = 0;
                    y += heightCharacter;
                }
            }
        }
        public void Draw()
        {
            Rectangle rectangle = this.Rec;
            switch (State)
            {
                case 1:
                    WalkLeft();
                    break;

                default:
                    break;
            }
            gc.DrawImgRec(Img, new Rectangle(500, 500, 100, 100), rectangle);
        }
        public void WalkLeft()
        {
            X = gc.
            Y = height;
            gc.DrawImgRec(Img, new Rectangle(X, Y, 100, 100), this.Sprites[3]);
 
            
        }
        

    }
}

