using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        Thread th;
        double weight;

        public static double FatMass(double weight, double bodyFat)
        {

            double fatMassValue = 0;

            fatMassValue = (weight * bodyFat);

            return fatMassValue;
        }
        public static double LeanBodyMass(double fatMass, double weight)
        {

            double result = 0;

            result = (weight - fatMass);
            return result;
        }


    public Form3(double weightReceive)
        {
            InitializeComponent();
            weight = weightReceive;
   
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            const double HUNDRED = 100;
            double bodyFat , fatMass, leanBM, fatPer;

            if (!double.TryParse(textBox1.Text, out bodyFat))
                errorProvider1.SetError(this.textBox1, "Enter Number");

            else 
            {
                bodyFat = Convert.ToDouble(textBox1.Text);
                if (bodyFat >= 100 || bodyFat < 1)
                    errorProvider1.SetError(this.textBox1, "Number 1-100");
                else
                {
                    //bodyFat = double.Parse(textBox1.Text);

                    fatPer = bodyFat / HUNDRED;
                    fatMass = FatMass(weight, fatPer);// call appropriate method(s)
                    leanBM = LeanBodyMass(fatMass, weight);

                    ListViewItem item = new ListViewItem(fatMass + " lb".ToString());
                    item.SubItems.Add(leanBM + " lb".ToString());
                    listView1.Items.Add(item);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openForm1);

            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
        private void openForm1(object obj)
        {

            Application.Run(new Form1());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
