using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoBlocks
{
    public partial class UserSettings : Form
    {
        public string playerName;
        public UserSettings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            playerName = textBox1.Text;
            Close();
        }

    }
}
