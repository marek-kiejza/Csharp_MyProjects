using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Threading;
using System.IO;

namespace WindowsFormsApplication7
{
    
    public partial class Form1 : Form
    {
        string type = "Write";
        string[] preposition;
        int points = 0,totalPoints=0,round=0;

        SpeechSynthesizer s = new SpeechSynthesizer();
        Random random = new Random();

        int num;

        //string[] preposition = { "about", "above", "according", "across", "after", "against", "along", "along with", "among", "apart from", "around", "as for", "because of", "before", "behind", "below", "beneath", "beside", "between", "beyond", "but", "by", "means", "concerning ", "despite", "down", "during", "except", "except for", "excepting", "for", "from", "addition to", "back of", "in case of", "front of", "place", "inside", "spite of", "instead", "into", "like", "near", "next", "onto", "on top of", "outside", "over", "past", "regarding", "round", "since", "through", "throughout", "till", "toward", "under", "underneath", "unlike", "until", "upon", "up to", "with", "within", "without" };

        int ctr = 0;
        Thread th;

        public Form1(string[] words)
        {
            
            s.SelectVoiceByHints(VoiceGender.Female,VoiceAge.Teen);
            s.Rate = 0;
            
            int randomNumber = random.Next(0, words.Length-1);
            num = randomNumber;
            InitializeComponent();

            preposition = words;
            //label3.Text = preposition.ToString();
          //  label3.Text = string.Join(", ", words);

        }
       
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {   
            
            s.Rate = -6;
            s.Speak(preposition[num]);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {   
            s.Rate = 0;
            if (textBox1.Text.ToString() == preposition[num])
            {
                
                s.Speak("correct");

                round++;
                textBox1.Clear();

                for (int i = 0; i < preposition[num].Length; i++)
                {
                points++;
                }
                totalPoints += (points - ctr);
                label1.Text = totalPoints.ToString();
                points = 0;
                ctr = 0;
                num = random.Next(0, preposition.Length-1);
                if (round==2)
                {

                    this.Close();
                    th = new Thread(openForm2);

                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }

            }
            else
            {
                textBox1.Clear();
                s.Speak("wrong answer");
                
                
                var chars = preposition[num].ToCharArray();
                

                for (int cou=0; cou<=ctr ; cou++)
                 {
                
                   textBox1.Text += chars[cou].ToString();

                    
                }

                if (ctr >= chars.Length)
                    ctr = chars.Length;
                else
                ctr++;
                

            }
        }
        private void openForm2(object obj)
        {

            Application.Run(new Form2(totalPoints, type));
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
