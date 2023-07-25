using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Undertale1
{
    public class GraphicsControl
    {
        private Graphics g;
        private Bitmap bitmap;
        private PictureBox pb;
        public GraphicsControl(PictureBox pb)
                => this.pb = pb;

        public void InitGraphics()
        {
            bitmap = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(bitmap);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.Clear(Color.White);
            pb.Image = bitmap;
        }

        public void DrawRec(Rectangle rec) => g.DrawRectangle(Pens.Red, rec);

        //public void DrawImg(Image img) => g.DrawImage(img, 0, 0);

        public void DrawImg(Image img, Point point) => g.DrawImage(img, point.X, point.Y);

        public void DrawImgRec(Image img, Rectangle rec) => g.DrawImage(img, rec);
        
        public void DrawImgRec(Image img, Rectangle rec, Rectangle src) => g.DrawImage(img, rec, src, GraphicsUnit.Pixel);

        public void DrawFullScreen(Image img) => g.DrawImage(img, 0, 0, pb.Width, pb.Height);

        public void DrawFullScreenRec(Image img, Rectangle src) => g.DrawImage(img, new Rectangle(0,0, pb.Width, pb.Height), src, GraphicsUnit.Pixel);

        public void ClearAll()
        {
            g.Clear(Color.Black);
        }

        internal void Refresh()
        {
            pb.Refresh();
        }
    }

}
