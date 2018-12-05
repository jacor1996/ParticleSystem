using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace DiscsMFAK
{
    public class Disc
    {

        public Vector Location { get; set; }
        public Vector Velocity { get; set; }
        public Vector Acceleration { get; set; }

        public float Radius { get; set; }
        public float Mass { get; set; }

        public RectangleF Rectangle { get; set; }
        public Color DiscColor { get; set; }

        public float LifeTime { get; set; }
        public bool IsDead { get; set; }

        private const float MaxSpeed = 7.5f;

        public Disc()
        {
        }

        public Disc(Vector location, Vector velocity, float radius, float mass, Color discColor, float lifeTime)
        {
            Location = location;
            Velocity = velocity;
            Acceleration = new Vector(0,0);
            Radius = radius;
            DiscColor = discColor;
            Mass = mass;
            LifeTime = lifeTime;
            IsDead = false;

            UpdateRectangle();
        }

        public void UpdatePosition(Rectangle rectangle)
        {

            Velocity.Add(Acceleration);
            Velocity.Limit(MaxSpeed);
            Location.Add(Velocity);
            

            //CheckEdges(rectangle.Width, rectangle.Height, rectangle.Left, rectangle.Top);

            UpdateRectangle();
            Acceleration.Multiply(0);
        }

        public void CheckEdges(int width, int height, int left, int top)
        {
            if (Rectangle.Right + Velocity.X >= width)
            {
                Location.X = width - Radius;
                Velocity.X = Velocity.X * -1;
            }

            else if (Rectangle.Left + Velocity.X <= left)
            {
                Location.X = left + Radius;
                Velocity.X = Velocity.X * -1;
            }

            if (Rectangle.Bottom + Velocity.Y >= height)
            {
                Location.Y = height - Radius;
                Velocity.Y = Velocity.Y * -1;
            }

            else if (Rectangle.Top + Velocity.Y <= top)
            {
                Location.Y = top + Radius;
                Velocity.Y = Velocity.Y * -1;
            }
        }

        public bool IsOutOfBounds(Rectangle rectangle)
        {
            return (Rectangle.Right + Velocity.X >= rectangle.Width) ||
                   (Rectangle.Left + Velocity.X <= rectangle.Left) ||
                   (Rectangle.Bottom + Velocity.Y >= rectangle.Height) ||
                   (Rectangle.Top + Velocity.Y <= rectangle.Top);
        }

        public void ApplyForce(Vector force)
        {
            Vector f = force;
            f.Divide(Mass);
            Acceleration.Add(f);
        }

        public void UpdateRectangle()
        {
            Rectangle = new RectangleF(
                Location.X - Radius,
                Location.Y - Radius,
                Radius * 2,
                Radius * 2
            );
        }

        public void Draw(PaintEventArgs e)
        {
            Brush brush = new SolidBrush(DiscColor);
            e.Graphics.FillEllipse(brush, Rectangle);
        }

        public void Draw(PaintEventArgs e, Bitmap img)
        {
            Bitmap b = new Bitmap(img, new Size((int)Rectangle.Width, (int)Rectangle.Height));
            e.Graphics.DrawImage(b, Rectangle.Location);
        }
    }
}
