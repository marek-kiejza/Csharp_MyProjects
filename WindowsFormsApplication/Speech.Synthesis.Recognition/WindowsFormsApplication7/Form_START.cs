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
using System.IO;

namespace WindowsFormsApplication7
{
    public partial class Form_START : Form
    {
        string type = "Write";
        int points = 0;
        string[] preposition;

        Thread th;
        public Form_START()
        {
            
            InitializeComponent();
            StreamReader sr = new StreamReader(@"words.txt");

            List<string> myList = new List<string>();
           
          
            string lineIn;// will hold data that we read in



            lineIn = sr.ReadLine();// read in first line from file
            myList.Add(lineIn);
            while (lineIn != null)// null signals end of the file
            {
                
                lineIn = sr.ReadLine();// read in the next line
                myList.Add(lineIn);
                
            }
            sr.Close();

             preposition = myList.ToArray();
        }

        private void Form_START_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            if (comboBox1.SelectedItem.ToString() == "Learn To Speak")
            {

                this.Close();
                th = new Thread(openForm4);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            if (comboBox1.SelectedItem.ToString() == "Learning To Write")
            {

                this.Close();
                th = new Thread(openForm1);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            if (comboBox1.SelectedItem.ToString() == "Words Library")
            {

                this.Close();
                th = new Thread(openForm0);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            if (comboBox1.SelectedItem.ToString() == "High Score Ranking")
            {

                this.Close();
                th = new Thread(openForm2);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }

        }
        private void openForm1(object obj)
        {

            Application.Run(new Form1(preposition));
        }
        private void openForm4(object obj)
        {

            Application.Run(new Form4(preposition));
        }
        private void openForm0(object obj)
        {

            Application.Run(new Form0(preposition));
        }
        private void openForm2(object obj)
        {

            Application.Run(new Form2(points,type));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
