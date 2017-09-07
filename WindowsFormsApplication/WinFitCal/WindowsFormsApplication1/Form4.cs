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
    public partial class Form4 : Form
    {
        Thread th;
        double weight, height;
        string gender;

        public static double BasalMetabolicRate(double weight, double height, int age, string gender)
        {
            double result = 0;

            if (gender == "Male")
                result = (66 + ((6.23 * weight) + (12.7 * height)) - (6.8 * age));

            else
                result = (655 + ((4.35 * weight) + (4.7 * height)) - (4.7 * age));
            return result;
        }

        public static double ActivityLevel(double BMR,string activ)
        {
            
            double DCR = 0;

                switch (activ)
            {
                case "1.Sedentary":
                    DCR = BMR * 1.2;
                    break;
                   
                case "2.Light Exercise(1-3 days / week)":
                    DCR = BMR * 1.375;
                    break;

                case "3.Moderate Exercise(3-5 days / week)":
                    DCR = BMR * 1.55;
                    break;

                case "4.Intense Exercise(6-7 days / week)":
                    DCR = BMR * 1.725;
                    break;

                case "5.Very Intense Exercise (2 extreme workouts per day)":
                    DCR = BMR * 1.9;
                    break;
                
            }
            return DCR;

        }
        public Form4(double weightReceive, double heightReceive, string genderReceive)
        {
            
            InitializeComponent();
            
            weight = weightReceive;
            height = heightReceive;
            gender = genderReceive;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int age;
            double BMR, DCR;
            string activ;

            if (!int.TryParse(textBox1.Text, out age))
                errorProvider1.SetError(this.textBox1, "Enter Number");

            else if (comboBox1.Text == "" || comboBox1.Text != "1.Sedentary" && comboBox1.Text != "2.Light Exercise(1-3 days / week)" && comboBox1.Text != "3.Moderate Exercise(3-5 days / week)" && comboBox1.Text != "4.Intense Exercise(6-7 days / week)" && comboBox1.Text != "5.Very Intense Exercise (2 extreme workouts per day)")
                errorProvider1.SetError(this.comboBox1, "Chose menu");
            

            else
            {

                age = Convert.ToInt32(textBox1.Text);
                BMR = BasalMetabolicRate(weight, height, age, gender);

                activ = comboBox1.SelectedItem.ToString();
                DCR = ActivityLevel(BMR, activ);

                ListViewItem item = new ListViewItem(BMR.ToString());
                item.SubItems.Add(DCR.ToString());
                listView1.Items.Add(item);
            }
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

    private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
