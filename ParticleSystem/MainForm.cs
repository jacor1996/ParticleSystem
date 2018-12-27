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
        private const int TimeConstant = 1000;
        private double _elapsedTime;
        private ParticleSystemManager _manager;
        

        public MainForm()
        {
            _elapsedTime = 0;
            InitializeComponent();
            DoubleBuffered = true;
            BackColor = Color.Black;
            _manager = new ParticleSystemManager();
            _manager.InitializeParticleSystems();
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
            _manager.Draw(e);
            if (_elapsedTime > 0.25d * TimeConstant)
            {
                _elapsedTime = 0;
                _manager.InitializeParticleSystems();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeTimer();
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            _elapsedTime = 0;
            _manager.InitializeParticleSystems();
        }
    }
}