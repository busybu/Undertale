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
        public string Title { get; set;  }
        public int CurrentIndex { get; set; } = -1;
        public List<string> Text {  get; set; } = new List<string>();
        public string Current => 
            CurrentIndex != -1 ? 
            Text[CurrentIndex] : 
            "";

        public virtual bool NextText()
        {
            CurrentIndex++;

            if (CurrentIndex >= Text.Count)
            {
                CurrentIndex = -1;
                return false;
            }

            return true;
        }
    }

    public class AutoMessage : Message
    {
     
    }
    public class MutableInteract : Message
    {
        public List<string> PostText { get; set; } = new List<string>();
        public Image Img { get; set; }

        public Image NewImg { get; set; }
        public void ChangeImg()
        {
            this.Img = NewImg;
            this.Text = PostText;
        }
        public override bool NextText()
        {
            CurrentIndex++;

            if (CurrentIndex >= Text.Count)
            {
                CurrentIndex = -1;
                ChangeImg();
                return false;
            }

            return true;
        }
    }

    public class MiniGame : Interaction
    {
        //public Enemy Enemy { get; set; }
        //public Puzzle Puzzle { get; set; }
        public Message Message { get; set; }

    }
}
