using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscsMFAK
{
    public partial class MainForm : Form
    {
        private double _elapsedTime = 0;
        private ParticleSystem[] particleSystems;
        private Color[] _colors;

        public MainForm()
        {
            InitializeParticleSystems();
            InitializeComponent();
            DoubleBuffered = true;
            BackColor = Color.Black;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _elapsedTime += timer.Interval;
            Refresh();
        }

        private void InitializeTimer()
        {
            timer.Interval = 10;
            timer.Start();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            foreach (ParticleSystem ps in particleSystems)
            {
                ps.DrawDiscs(_elapsedTime, e);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeTimer();

        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine($"Mouse click\nx:{e.X}, y:{e.Y}");
            _elapsedTime = 0;
            InitializeParticleSystems();

        }

        private void InitializeParticleSystems()
        {
            particleSystems = new ParticleSystem[]
            {
                new ParticleSystem(new Vector(150,120), 50),
                new ParticleSystem(new Vector(250,80), 100),
                new ParticleSystem(new Vector(360,30), 35),
                new ParticleSystem(new Vector(420, 180), 45)

            };
        }
    }
}