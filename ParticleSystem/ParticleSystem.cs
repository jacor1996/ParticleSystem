using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DiscsMFAK
{
    public class ParticleSystem
    {
        public List<Disc> Discs { get; set; }
        public Vector Origin { get; set; }

        private readonly Random _random = new Random();
        private const int TimeConstant = 1000;

        public ParticleSystem()
        {
            Discs = new List<Disc>();
            Origin = new Vector(150, 100);

            InitializeParticles(20);
        }

        public ParticleSystem(Vector origin, int numberOfParticles)
        {
            Discs = new List<Disc>();
            Origin = origin;

            InitializeParticles(numberOfParticles);
        }

        public void InitializeParticles(int numberOfParticles)
        {
            for (int i = 0; i < numberOfParticles; i++)
            {
                Discs.Add(
                    new Disc(
                        new Vector(Origin.X + i*0.1f, Origin.Y),
                        new Vector((float)Math.Pow(-1, i)*_random.Next(-4, 4), (float)Math.Pow(-1, i)*_random.Next(-4,4)),
                        _random.Next(1,5),
                        _random.Next(1,10),
                        GenerateColor(),
                        _random.Next(1,3)
                        )
                    );
            }
        }

        public void UpdateDiscs(double elapsedTime, PaintEventArgs e)
        {
            foreach (Disc disc in Discs)
            {
                if ( (elapsedTime / TimeConstant > disc.LifeTime) || disc.IsOutOfBounds(e.ClipRectangle) )
                {
                    disc.IsDead = true;
                }

                else
                {
                    disc.UpdatePosition(e.ClipRectangle);
                }
                    
            }
        }

        public void DrawDiscs(double elapsedTime, PaintEventArgs e)
        {
            foreach (Disc disc in Discs)
            {
                disc.ApplyForce(new Vector(0, 1.5f));
                if (!disc.IsDead)
                    disc.Draw(e);

            }
            UpdateDiscs(elapsedTime, e);
        }

        private Color GenerateColor()
        {
            int red = _random.Next(0, 255);
            int green = _random.Next(0, 255);
            int blue = _random.Next(0, 255);
            Color color = Color.FromArgb(red, green, blue);

            return color;
        }

    }
}
