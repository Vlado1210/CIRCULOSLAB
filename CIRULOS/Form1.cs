using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace circulos
{
    public partial class Form1 : Form
    {
        Rectangle ball1 = new Rectangle(320, 110, 50, 50);
        Rectangle ball2 = new Rectangle(220, 110, 50, 50);
        public bool goingr = true, goingl = false, goingu = false, goingd = false;
        //ballSize = 2;
        public class Ball
        {
            public int ballSize;

            public Size ballVelocity;
            public int velocityRandom;


            public Point ballPosition;
            public int positionRandomX;
            public int positionRandomY;
            public Ball()
            {
                Random random = new Random();
                ballSize = random.Next(20, 50);
                velocityRandom = random.Next(3, 10);
                positionRandomX = random.Next(0, 803);
                positionRandomY = random.Next(0, 451);

                // Initialize the ball's position and velocity
                ballPosition = new Point(positionRandomX, positionRandomY);
                ballVelocity = new Size(velocityRandom, velocityRandom);
            }

            public void CheckMove()
            {
                ballPosition.X -= ballVelocity.Width;
                ballPosition.Y -= ballVelocity.Height;

                if (ballPosition.X < 0 || ballPosition.X + ballSize > 803)
                {
                    ballVelocity.Width = -ballVelocity.Width;
                }
                if (ballPosition.Y < 0 || ballPosition.Y + ballSize > 451)
                {
                    ballVelocity.Height = -ballVelocity.Height;
                }
            }

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, ball1);
            e.Graphics.FillEllipse(Brushes.Red, ball2);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ball1.Location.X < pictureBox1.Width || ball1.Location.X + 50 > 800)
            {
                goingr = true;
            }
            else
            {
                goingr = false;
                goingl = true;
            }
        }




        private void timer2_Tick(object sender, EventArgs e)
        {
            if (goingr == true)
            {
                ball1.Location = new Point(ball1.X + 10, ball1.Y);
            }
            if (goingl == true)
            {
                ball1.Location = new Point(ball1.X - 10, ball1.Y);
            }
            if (goingu == true)
            {
                ball1.Location = new Point(ball1.X, ball1.Y + 10);
            }
            if (goingd == true)
            {
                ball1.Location = new Point(ball1.X, ball1.Y - 10);
            }
            pictureBox1.Invalidate();
        }
    }


}
