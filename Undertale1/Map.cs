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

        public int VerifyArea(int x, int y, Sprite sprite)
        {
            int value = 0;
            foreach(var rects in RestricedArea)
            {
                if (rects.Contains(x + 200, y + 125))
                {
                    switch (sprite.State)
                    {
                        case 0:
                            value = rects.Y + rects.Height - 125;
                            break;

                        case 1:
                            value = rects.Y + rects.Height - 200;
                            break;

                        case 2:
                            value = rects.X - 190;
                            break;

                        case 3:
                            value = rects.Y - 125;
                            break;
                            
                    }
                }
                
            }
            return value;
        }

            
    }

}
