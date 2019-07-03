using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Timers;
using System.Windows.Forms;

namespace MemoBlocks
{
    public partial class Game : Form
    {
        Random rng = new Random();
        private const int TILE_NUMBER = 16;
        List<Tile> tiles = new List<Tile>();
        List<Image> images = new List<Image>();
        public int tries = 0;
        public TimeSpan duration;
        public bool isFinished = false;
        DateTime startingTime;
        List<Tile> activeTiles = new List<Tile>();
        System.Timers.Timer timer;
        Random random = new Random();
        public string[] ImagePaths;

        public Game()
        {
            InitializeComponent();
        }

        private void SetImages(string[] imageLocation)
        {
            foreach (string loc in imageLocation)
            {
                Image image = Image.FromFile(loc);
                images.Add(image);
                images.Add(image);
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            
            startingTime = DateTime.Now;
            SetImages(ImagePaths);
            List<Image> shuffledImages = images.OrderBy(x => random.Next()).ToList();
            Size = new Size(4 * 120 + 70, 4 * 120 + 90);
            for (int i = 0; i < TILE_NUMBER; i++)
            {
                Button pictureButton = new Button
                {
                    BackColor = Color.Orange,
                    Location = new Point(10 + (i / 4) * 130, 10 + (i % 4) * 130),
                    Size = new Size(120, 120)
                };
                pictureButton.Click += button_click;
                Controls.Add(pictureButton);
                tiles.Add(new Tile(shuffledImages[i], pictureButton));
            }



        }
        public void button_click(object sender, EventArgs e)
        {
            if (activeTiles.Count <2) {
                timer = new System.Timers.Timer(1000)
                {
                    AutoReset = false,
                    Interval = 1000,
                    Enabled = false
                };
                timer.Elapsed += OnTimedEvent;
                Button button = (Button)sender;
                foreach (Tile t in tiles)
                {
                    if (button == t.Button)
                    {
                        if (!t.IsTurned)
                        {
                            t.TurnTile();
                            activeTiles.Add(t);
                        }
                    }

                }
                if (activeTiles.Count == 2)
                {
                    if (activeTiles[0].Image != activeTiles[1].Image)
                    {
                        timer.Start();
                    }
                    else
                    {
                        activeTiles.Clear();
                    }
                }
                if (CheckEnd())
                {
                    isFinished = true;
                    Close();
                }
            }

        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            activeTiles[0].TurnTile();
            activeTiles[1].TurnTile();
            tries++;
            activeTiles.Clear();
        }


        private bool CheckEnd()
        {
            foreach(Tile t in tiles)
            {
                if (!t.IsTurned)
                {
                    return false;
                }
            }
            duration = DateTime.Now - startingTime;
            MessageBox.Show($"Won in {(int)duration.TotalSeconds} seconds. Tries needed: {tries}.");
            return true;
        }
    }
}
