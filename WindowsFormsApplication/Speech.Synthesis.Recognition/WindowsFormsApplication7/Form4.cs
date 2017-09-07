using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Threading;

namespace WindowsFormsApplication7
{
    public partial class Form4 : Form
    {
        string[] preposition;

        SpeechRecognitionEngine recEngine = new SpeechRecognitionEngine();

        Thread th;

        Random random = new Random();

        int num;
        public Form4(string[] words)
        {
            preposition = words;
            int randomNumber = random.Next(0, words.Length - 1);
            num = randomNumber;
            InitializeComponent();
           
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Choices commands = new Choices();
           
            for (int i = 0; i < preposition.Length - 1; i++)
            {
                commands.Add(preposition[i]);
            }
            GrammarBuilder gBuilder = new GrammarBuilder();
            gBuilder.Append(commands);
            Grammar grammar = new Grammar(gBuilder);

            recEngine.LoadGrammarAsync(grammar);
            recEngine.SetInputToDefaultAudioDevice();
            recEngine.SpeechRecognized += recEngine_SpeechRecognized;
        }

        private void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            
            if (e.Result.Text== preposition[num])
             {
                label1.ForeColor = System.Drawing.Color.Yellow;
                label1.Text = "CORECT";
                recEngine.RecognizeAsyncStop();
                //btaDisable.Enabled = false;
                timer1.Stop();
                progressBar1.Value = 0;
                num = random.Next(0, preposition.Length - 1);
            }
          


       /*     switch (e.Result.Text)
            {

                case "means":
                    label1.Text = "Animal1";
                    break;


            }*/


            /*
            if (textBox1.Text.ToString() == preposition[0])
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
                num = random.Next(0, preposition.Length - 1);
                if (round == 2)
                {

                    this.Close();
                    th = new Thread(openForm2);

                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
                ///////////////////
                /*
             
                */
        }

        private void btaEnable_Click(object sender, EventArgs e)
        {
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Text = preposition[num].ToUpper();
            
            recEngine.RecognizeAsync(RecognizeMode.Multiple);
           // btaDisable.Enabled = true;

            //timer
            this.timer1.Start();
            progressBar1.Value = 0;

        }
        /*
        private void btaDisable_Click(object sender, EventArgs e)
        {
            recEngine.RecognizeAsyncStop();
            btaDisable.Enabled = false;
            timer1.Stop();
            progressBar1.Value = 0;
        }
        */

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = preposition[0];
            this.Close();
            th = new Thread(openForm_START);

            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }
        private void openForm_START(object obj)
        {

            Application.Run(new Form_START());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(1);

            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                label1.ForeColor = System.Drawing.Color.Red;
                label1.Text = "TIME UP !!!";
                
                recEngine.RecognizeAsyncStop();

            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }
        
       

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
