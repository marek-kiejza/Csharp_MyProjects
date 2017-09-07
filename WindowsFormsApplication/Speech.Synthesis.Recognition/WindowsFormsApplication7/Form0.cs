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
    public partial class Form0 : Form
    {
        Thread th;
        string[] preposition = { "about", "above", "according", "across", "after", "against", "along", "along with", "among", "apart from", "around", "as for", "because of", "before", "behind", "below", "beneath", "beside", "between", "beyond", "but", "by", "means", "concerning ", "despite", "down", "during", "except", "except for", "excepting", "for", "from", "addition to", "back of", "in case of", "front of", "place", "inside", "spite of", "instead", "into", "like", "near", "next", "onto", "on top of", "outside", "over", "past", "regarding", "round", "since", "through", "throughout", "till", "toward", "under", "underneath", "unlike", "until", "upon", "up to", "with", "within", "without" };
      //string[] preposition;

        public Form0(string[] words)
        {
            
            InitializeComponent();
           // preposition = words;

            StreamReader sr = new StreamReader(@"words.txt");

           
            int lineCount = 0;// variable to accumulate numbers of lines in the scores.txt
            string lineIn;// will hold data that we read in

           
           
            lineIn = sr.ReadLine();// read in first line from file

            while (lineIn != null)// null signals end of the file
            {


                checkedListBox1.Items.Add(lineIn);// print to screen


                lineIn = sr.ReadLine();// read in the next line
                lineCount++;
            }
            sr.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
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

            Application.Run(new Form1(preposition));
        }

        private void openForm3(object obj)
        {

            Application.Run(new Form_START());
        }

        private void openForm4(object obj)
        {

            Application.Run(new Form4(preposition));
        }
      

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

     

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void AutoComleteText()
        {
            textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection coll = new AutoCompleteStringCollection();
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            //string[] colors = new string[] { "Red", "Blue", "Green", "Yellow" };
            //textBox1.AutoCompleteCustomSource.AddRange(colors);
            /*
            StreamReader sr = new StreamReader(@"words.txt");
           
            /while ((line = sr.ReadLine()) != null)
                { //add your lines here to the string array, whatever your criteria may be for each element in the array }
                }*/
                    textBox1.AutoCompleteCustomSource.AddRange(preposition);

                 
                    /*
                    InitializeComponent();
                    List<string> source = new List<string> { @"words.txt" };
                    TextBoxName.ItemSource = source;

                    StreamReader sr = new StreamReader(@"words.txt");

                    AutoCompleteStringCollection coll = new AutoCompleteStringCollection();

                    //coll = sr.Text;

                    DataView DV = new DataView();// dbdataset);
                    DV.RowFilter = string.Format("surname Like '%{0}%'", textBox1);
                   // dataGridView1.DataSource = DV;
                   */
                }

        private void button3_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add(textBox1.Text);

            StreamWriter stw = new StreamWriter(@"words.txt",true); // placed the file in the debug folder, so no path needed

            //write to file
            stw.WriteLine(textBox1.Text);//,after,against,along,among,apart,around,because,before,behind,below,beneath,beside,between,beyond,but,by,means,concerning,despite,down,during,except,excepting,addition,case,front,place,inside,spite,instead,into,like,near,onto,outside,over,past,regarding,round,since,through,throughout,till,toward,under,underneath,unlike,until,upon,with,within,without");

            // close the connection to the file
            stw.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
         checkedListBox1.Items.Remove(checkedListBox1.Items[checkedListBox1.SelectedIndex]);
            StreamWriter stw = new StreamWriter(@"words.txt");// placed the file in the debug folder, so no path needed
           // stw.WriteLine(checkedListBox1.Text);//,after,against,along,among,apart,around,because,before,behind,below,beneath,beside,between,beyond,but,by,means,concerning,despite,down,during,except,excepting,addition,case,front,place,inside,spite,instead,into,like,near,onto,outside,over,past,regarding,round,since,through,throughout,till,toward,under,underneath,unlike,until,upon,with,within,without");
                                                // close the connection to the file


            foreach (var aa in checkedListBox1.Items)
                stw.WriteLine(aa.ToString());
            stw.Close();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

      

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openForm4);

            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

      
        private void button7_Click_1(object sender, EventArgs e)
        {

            this.Close();
            th = new Thread(openForm_START);

            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }
        private void openForm_START(object obj)
        {

            Application.Run(new Form_START());
        }
    }
}
