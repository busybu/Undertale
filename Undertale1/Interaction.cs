using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Undertale1
{
    public abstract class Interaction
    {
        public Rectangle Area {  get; set; }

    }

    public class Message : Interaction
    {
        public string Text {  get; set; }
    }

    public class MiniGame : Interaction
    {

    }
}
