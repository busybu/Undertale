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
                            return (x, rects.Y + rects.Height - 127);

                        case 1:
                            return (rects.X - 202, y);

                        case 2:
                            return (rects.X + rects.Width - 202, y);

                        case 3:
                            return (x, rects.Y - 127);
                    }
                }
                
            }
            return (x, y);
        }

        public void InteractArea(int x, int y)
        {
            foreach(var interaction in Interactions)
            {
                var area = interaction.Area;
                if(area.Contains(x + 200, y + 125))
                {

                }
            }
        }
            
    }

}
