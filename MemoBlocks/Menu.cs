using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace MemoBlocks
{
    public partial class Menu : Form
    {
        public string[] filePath = new string[8] { "..\\..\\data\\bunny.png", "..\\..\\data\\cat.png", "..\\..\\data\\dog.png", "..\\..\\data\\hedgehog.png", "..\\..\\data\\koala.png", "..\\..\\data\\mouse.png", "..\\..\\data\\panda.png", "..\\..\\data\\pawprint.png" };

        public Menu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserSettings userSettings = new UserSettings();
            userSettings.ShowDialog();
            Player player = new Player(userSettings.playerName, 0, TimeSpan.Zero);
            Game game = new Game
            {
                ImagePaths = filePath
            };
            game.ShowDialog();
            if(game.isFinished)
            {
                player.Duration = game.duration;
                player.Tries = game.tries;
                
                string path = @"..\..\players.txt";
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(string.Join(";", new string[] {player.Name, player.Tries.ToString(), player.Duration.ToString()}));
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Scores scores = new Scores();
            scores.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            while(true)
            {
                MessageBox.Show("Choose 8 pictures for the game.");
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = @"..\..\";
                    openFileDialog.Filter = "All files (*.*)|*.*";
                    openFileDialog.Multiselect = true;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileNames.Count() == 8)
                    {
                        filePath = openFileDialog.FileNames;
                        break;
                    }
                }
            } 
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click on the tiles to match the icons as fast as possible");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            while (true)
            {
                MessageBox.Show("Choose 8 pictures for the game.");
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = @"..\..\";
                    openFileDialog.Filter = "All files (*.*)|*.*";
                    openFileDialog.Multiselect = true;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileNames.Count() == 8)
                    {
                        filePath = openFileDialog.FileNames;
                        break;
                    }
                }
            }
        }
    }
}
