using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
namespace Undertale1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {

        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            Game.StartGame(this.pictureBox1, this);
            Game.Instance.Start();
        }
    }
}