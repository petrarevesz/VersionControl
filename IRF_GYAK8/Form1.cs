using IRF_GYAK8.Abstractions;
using IRF_GYAK8.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRF_GYAK8
{
    public partial class Form1 : Form
    {
        private List<Toy> _toys = new List<Toy>();
        private BallFactory _factory;
        public BallFactory IToyFactory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        public Form1()
        {
            InitializeComponent();
            IToyFactory = new BallFactory();
        }

        private void CreateTimer_Tick(object sender, EventArgs e)
        {
            var ball = IToyFactory.CreateNew();
            _toys.Add(ball);
            ball.Left = -ball.Width;
            mainPanel.Controls.Add(ball);
        }

        private void ConveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var ball in _toys)
            {
                ball.MoveToy();
                if (ball.Left > maxPosition)
                    maxPosition = ball.Left;
            }

            if (maxPosition > 1000)
            {
                var oldestBall = _toys[0];
                mainPanel.Controls.Remove(oldestBall);
                _toys.Remove(oldestBall);
            }
        }


        /* private void CreateTimer_Tick(object sender, EventArgs e)
         {
             
         }

       /*  private void ConveyorTimer_Tick_1(object sender, EventArgs e)
         {
             
         }*/
    }
}
