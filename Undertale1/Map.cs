using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace Undertale1
{
    public class Map
    {
        public int X { get; set; }
        public GraphicsControl gc { get; set; }
        public int Y { get; set; }
        public List<Rectangle> RestricedArea { get; set; } = new List<Rectangle>();
        public List<Interaction> Interactions { get; set; } = new List<Interaction>();
        public (int x, int y) VerifyArea(int x, int y, Sprite sprite)
        {
            int value = 0;
            foreach(var rects in RestricedArea)
            {
                if (rects.Contains(x + 200, y + 125))
                {
                    switch (sprite.State)
                    {
                        case 0:
                            return (x, rects.Y + rects.Height - 124);

                        case 1:
                            return (rects.X - 201, y);

                        case 2:
                            return (rects.X + rects.Width - 199, y);

                        case 3:
                            return (x, rects.Y - 126);
                    }
                }
                
            }
            return (x, y);
        }
        public bool StartInteract(int x, int y)
        {
            foreach (var interaction in Interactions)
            {
                var area = interaction.Area;
                if (area.Contains(x + 200, y + 125))
                {
                    switch (interaction)
                    { 
                        case AutoMessage:
                            interactFrame = 0;
                            return true;

                        case MutableInteract change:
                            interactFrame = 0;
                            return change.NextText();

                        case Message message:

                            if (interactFrame < message.Current.Length)
                            {
                                interactFrame = int.MaxValue;
                                return true;
                            }

                            interactFrame = 0;
                            return message.NextText();


                        case MiniGame miniGame:
                            break;
                    }

                }
            }
            return false;
        }

        private int interactFrame = 0;
        public void InteractArea(int x, int y, int wid, int hei)
        {
            if (interactFrame != int.MaxValue)
                interactFrame++;
            
            foreach (var interaction in Interactions)
            {
                var area = interaction.Area;
                if(area.Contains(x + 200, y + 125))
                {
                    switch (interaction)
                    {
                        case Message message:
                            gc.DrawMessageBox(new Rectangle(10, hei - 300, wid - 50 , 200), 
                                message.Current.Substring(0, message.Current.Length < interactFrame ? message.Current.Length : interactFrame), 
                                message.Title
                            );
                            break;

                        case MiniGame miniGame:
                            break;
                    }

                }
            }
        }

        public void DrawInteractions(int x, int y, int wid, int hei)
        {
            foreach (var interaction in Interactions)
            {
                var area = interaction.Area;
                var nonGloblaLocation = new Point((area.Location.X - x) * wid / 400, (area.Location.Y - y) * hei / 250);
                switch (interaction)
                {
                    case MutableInteract change:
                        gc.DrawImg(change.Img, nonGloblaLocation);
                        break;
                }
            }
        }

    }

}
