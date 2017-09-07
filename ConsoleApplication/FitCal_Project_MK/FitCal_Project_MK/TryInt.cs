using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TryInt
{
    public static int Try(int limit, int error)//Menu printed on start of the program
    {

        string[] errors =
            {
                "Height in Feet is not a (valid) number:",
                "Height in inches is not a number between (0 – 11):",
                "Weight in Stones is not a (valid) number:",
                "Weight in Pounds is not a number between (0 - 13):",
                "Invalid Main Menu option is selected:",
                "Invalid Body Fat Percentage is entered:",
                "Invalid Activity Level Menu option is selected:"
            };
        string text;
        int[] nowy = { 0, 3, 2 };
        int num = 0;

        bool correct = false;

        while (correct == false)
        {

            text = Console.ReadLine();

            // catch errors

            try
            {
                num = int.Parse(text);
                if (num >= 0 && num <= limit)
                    correct = true;

                else
                    Console.Write(errors[error]);
            }

            catch (Exception)  // Get the error message out of the exception 
            {
                Console.Write(errors[error]);
            }

        }
        return num;
    }

}