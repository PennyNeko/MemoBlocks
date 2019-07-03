using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MemoBlocks
{
    public partial class Scores : Form
    {
        public Scores()
        {
            InitializeComponent();
        }

        private void Scores_Load(object sender, EventArgs e)
        {
            string path = @"..\..\players.txt";
            List<Player> players = new List<Player>();
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] split = s.Split(';');
                    players.Add(new Player(split[0], int.Parse(split[1]), TimeSpan.Parse(split[2])));
                }
            }
            List<Player> sortedPlayers = players.OrderBy(o=>o.Duration).ToList();

            List<Label> labels = new List<Label>() { label2, label3, label4, label5, label6, label7, label8, label9, label10, label11 };
            for (int i = 0; i<Math.Min(sortedPlayers.Count,10); i++)
            {
                labels[i].Text = $"{i+1}. Player {sortedPlayers[i].Name} with time {sortedPlayers[i].Duration.Seconds} seconds and {sortedPlayers[i].Tries} tries.";
            }
        }
    }
}
