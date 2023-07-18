using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;


ApplicationConfiguration.Initialize();

PictureBox pb = new PictureBox();
Graphics g = null;
Bitmap bmp = null;
Bitmap character = null;
var form = new Form();

var tm = new Timer();
tm.Interval = 100;

form.WindowState = FormWindowState.Maximized;
form.FormBorderStyle = FormBorderStyle.None;
pb.Dock = DockStyle.Fill;
form.Controls.Add(pb);


tm.Tick += delegate
{ 
    
};

form.Load += delegate
{
    
};

Application.Run(form);