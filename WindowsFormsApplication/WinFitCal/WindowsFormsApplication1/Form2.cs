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
  public partial class Form2 : Form
    {
        Thread th;
        public static double BodyMassIndex(double height, double weight)
        {
            double result = 0;

            result = (weight / (Math.Pow(height, 2))) * 703;

            return result;
        }
        public static string BMIcategories(double mass)
        {
            string massString;
           
            if (mass < 18.5)
            {
               
                massString = "Underweight";
            }
            else if (mass >= 1 && mass < 25)
            {
                massString="Normal Weight";
            }
            else if (mass >= 25 && mass < 30)
            {
                massString="Overweight";
            }
            else
            {
                massString="Obese";
            }

            return massString;
        }

       
        public Form2(double height, double weight ,string gender)
        {
            InitializeComponent();
            double BMI;
            string mass ,BMIResult;
            
            BMI = BodyMassIndex(height, weight);// call appropriate method(s)
            BMIResult="BMI Result is {0:0.0}% "+BMI;
            mass=BMIcategories(BMI);// call appropriate method(s)

      
            label1.Text = (mass);

            label2.Text = ("BMI Result is " + BMI);

            if (gender == "Male")
            {// underM normalM overM obesM
                if (mass == "Underweight")
                    pictureBox1.Image = Properties.Resources.underM;
                else if (mass == "Normal Weight")
                    pictureBox1.Image = Properties.Resources.normalM;
                else if (mass == "Overweight")
                    pictureBox1.Image = Properties.Resources.overM;
                else
                    pictureBox1.Image = Properties.Resources.obesM;
            }
            else
            {
                if (mass == "Underweight")
                    pictureBox1.Image = Properties.Resources.underF;
                else if (mass == "Normal Weight")
                    pictureBox1.Image = Properties.Resources.normalF;
                else if (mass == "Overweight")
                    pictureBox1.Image = Properties.Resources.overF;
                else
                    pictureBox1.Image = Properties.Resources.obesF;
            }
        }

       

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }
    }
}
