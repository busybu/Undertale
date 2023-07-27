using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
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

        public void DrawMessageBox(Rectangle rec, string message, string title = "")
        {
            g.FillRectangle(Brushes.Black, rec);
            g.DrawRectangle(Pens.White, rec);

            var pFontCollection= new PrivateFontCollection();
            pFontCollection.AddFontFile("C:\\Users\\disrct\\Desktop\\Undertale\\PixeloidSans-mLxMm.ttf");
            FontFamily family = pFontCollection.Families[0];
            var font = new Font(family, 18f);
            var tilteFont = new Font(family, 16f);

            g.DrawString(title, tilteFont, Brushes.White, rec, new StringFormat()
            {
                LineAlignment = StringAlignment.Near,
            });

            g.DrawString(message, font, Brushes.White, new Rectangle(30, rec.Y - 40, rec.Width - 100, 200), new StringFormat()
            {
                LineAlignment = StringAlignment.Center,
            });
        }

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
