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
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
       Thread th;
        double sendWeight ,sendHeight;
        string sendGender;

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void button3_Click(object sender, EventArgs e)
        {
            string gender;
            int inches, stones, pounds, feet;
            double height = 0, weight = 0;
            const int INCHES = 12, POUNDS = 14;

            

            errorProvider1.Clear();


            if (textBox1.Text == "")
                errorProvider1.SetError(this.textBox1, "enter UseName");
            else if (comboBox1.Text == "" || comboBox1.Text != "Male" && comboBox1.Text != "Female")
                errorProvider1.SetError(this.comboBox1, "Enter Gender");

            else if (!int.TryParse(textBox7.Text, out feet))
                errorProvider1.SetError(this.textBox8, "Enter Number");
            else if (!int.TryParse(textBox8.Text, out inches))
                errorProvider1.SetError(this.textBox8, "Enter Number");
            else if (!int.TryParse(textBox10.Text, out stones))
                errorProvider1.SetError(this.textBox11, "Enter Number");
            else if (!int.TryParse(textBox11.Text, out pounds))
                errorProvider1.SetError(this.textBox11, "Enter Number");

            

            else
            {
                feet = Convert.ToInt32(textBox7.Text);
                inches = Convert.ToInt32(textBox8.Text);
                stones = Convert.ToInt32(textBox10.Text);
                pounds = Convert.ToInt32(textBox11.Text);    
                if (inches > 11||inches<0)
                    errorProvider1.SetError(this.textBox8, "Number 0-11");
                
                else if (pounds > 13|| pounds<0)
                    errorProvider1.SetError(this.textBox11, "Number 0-13");

                else if (comboBox2.Text == "" || comboBox2.Text != "1.Calculate BMI" && comboBox2.Text != "2.Body Fat calculations" && comboBox2.Text != "3.BMR and DCR calculations")
                    errorProvider1.SetError(this.comboBox2, "Chose menu");
                else
                {
                    
                    height = (feet * INCHES) + inches;
                    weight = (stones * POUNDS) + pounds;
                    gender = comboBox1.SelectedItem.ToString();


                    sendWeight = weight;
                    sendHeight = height;
                    sendGender = gender;



                    if (comboBox2.SelectedItem.ToString() == "1.Calculate BMI")
                    {

                        this.Close();
                        th = new Thread(openForm2);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();

                        /* 
                         *Easy version 
                        Form2 form2 = new Form2(height, weight);
                        form2.Show();

                        */

                    }
                    if (comboBox2.SelectedItem.ToString() == "2.Body Fat calculations")
                    {

                        this.Close();
                        th = new Thread(openForm3);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();


                    }
                    if (comboBox2.SelectedItem.ToString() == "3.BMR and DCR calculations")
                    {

                        this.Close();
                        th = new Thread(openForm4);
                        th.SetApartmentState(ApartmentState.STA);
                        th.Start();


                    }
                }
            }
        }
        private void openForm2(object obj)
        {

            Application.Run(new Form2(sendHeight, sendWeight, sendGender));
        }
        private void openForm3(object obj)
        {

            Application.Run(new Form3(sendWeight));
        }

        private void openForm4(object obj)
        {

            Application.Run(new Form4(sendWeight, sendHeight,sendGender));
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox10.Clear();
            textBox11.Clear();
        }

       
        

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void aboutMyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("by Marek Kiejza");
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("by Marek Kiejza");
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("by Marek Kiejza");
        }
    }

   
}
