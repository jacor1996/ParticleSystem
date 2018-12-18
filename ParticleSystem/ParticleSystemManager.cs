using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiscsMFAK
{
    public class ParticleSystemManager
    {
        private IList<ParticleSystem> particleSystemsList;
        private Random random;

        public ParticleSystemManager()
        {
            particleSystemsList = new List<ParticleSystem>();
            random = new Random();
        }

        public void InitializeParticleSystems()
        {
            ResetParticleSystem();
            int N = random.Next(3, 7);

            for (int i = 0; i < N; i++)
            {
                particleSystemsList.Add(new ParticleSystem(new Vector(random.Next(0, 600), random.Next(0, 280)),
                    random.Next(20, 200)));
            }
        }

        public void ResetParticleSystem()
        {
            particleSystemsList.Clear();
        }

        public void Draw(PaintEventArgs e)
        {
            foreach (ParticleSystem particleSystem in particleSystemsList)
            {
                particleSystem.DrawDiscs(particleSystem.ElapsedTime, e);
            }
        }
    }
}
