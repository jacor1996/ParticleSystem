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
        private Random random = new Random();
        private ParticleSystemManager manager;

        public MainForm()
        {
            InitializeComponent();
            DoubleBuffered = true;
            BackColor = Color.Black;
            manager = new ParticleSystemManager();
            manager.InitializeParticleSystems();
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
            manager.Draw(e);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeTimer();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            _elapsedTime = 0;
            manager.InitializeParticleSystems();
        }
    }
}