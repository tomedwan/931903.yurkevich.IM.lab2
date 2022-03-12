using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulation_lab_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double rateEuro, rateDollars;
        int days;
        bool switcher=false;

        const double k = 0.08;
        Random random = new Random();
        private void btPredict_Click(object sender, EventArgs e)
        {
            if(switcher)
            {
                btPredict.Text = "Start";
                timer1.Stop();
            }
            else
            {
                rateEuro = (double)edEuro.Value;
                rateDollars = (double)edDollars.Value;
                days = (int)chart1.ChartAreas[0].AxisX.Minimum;


                chart1.Series[0].Points.Clear();
                chart1.Series[0].Points.AddXY(0, rateEuro);

                chart1.Series[1].Points.Clear();
                chart1.Series[1].Points.AddXY(0, rateDollars);

                btPredict.Text = "Stop";
                timer1.Start();
            }
            switcher =! switcher;
            
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            rateEuro = rateEuro * (1 + k * (random.NextDouble() - 0.5));
            chart1.Series[0].Points.AddXY(days, rateEuro);

            rateDollars = rateDollars * (1 + k * (random.NextDouble() - 0.5));
            chart1.Series[1].Points.AddXY(days, rateDollars);

        }

    }
}
