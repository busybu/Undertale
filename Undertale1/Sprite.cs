using System;
using System.Collections.Generic;
using System.Drawing;
namespace Undertale1
{
    public class Sprite
    {
        private readonly DateTime start = DateTime.Now;

        public Rectangle Rec { get; set; }
        public TimeSpan AnimationSpeed { get; set; } = TimeSpan.FromSeconds(1);
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
                this.Sprites.Add(new Rectangle(x, y, widthCharacter, heightCharacter));
                x += widthCharacter;

                if (i % 3 == 2)
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
                case 0:
                    walkUp();
                    break;

                case 1:
                    walkRigth();
                    break;

                case 2:
                    walkLeft();
                    break;
                
                case 3:
                    walkDown();
                    break;

                case 4:
                    stop();
                    break;
                default:
                    break;
            }
        }
        private void walkRigth()
        {
            var frameOffsize = getFrame() % 3;
            gc.DrawImgRec(Img, this.Rec, this.Sprites[3 + frameOffsize]);
        }
        private void walkDown()
        {
            var frameOffsize = getFrame() % 3;
            gc.DrawImgRec(Img, this.Rec, this.Sprites[0 + frameOffsize]);
        }
        private void walkLeft()
        {
            var frameOffsize = getFrame() % 3;
            gc.DrawImgRec(Img, this.Rec, this.Sprites[6 + frameOffsize]);
        }
        private void walkUp()
        {
            var frameOffsize = getFrame() % 3;
            gc.DrawImgRec(Img, this.Rec, this.Sprites[9 + frameOffsize]);
        }
        private void stop()
        {
            gc.DrawImgRec(Img, this.Rec, this.Sprites[1]);
        }
        private int getFrame()
        {
            var final = DateTime.Now;
            var time = final - start;
            var frame = (int)(time / AnimationSpeed);
            return frame;
        }
    }
}

