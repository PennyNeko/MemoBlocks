using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoBlocks
{
    public class Tile
    {
        public Tile(Image image, Button button, bool isTurned = false)
        {
            Button = button;
            Image = image;
            IsTurned = isTurned;
        }

        public Button Button { set; get; }
        public Image Image { set; get; }
        public bool IsTurned { set; get; }
        public void TurnTile()
        {
            if (IsTurned == false)
            {
                IsTurned = true;
                Button.Image = Image;
            }
            else
            {
                IsTurned = false;
                Button.Image = null;
            }
        }

    }
}
