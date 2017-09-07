using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Autor: Marek Kiejza 
 * 01/06/2017
*/
namespace FitCal_Project_MK

{
    
    class MainClass
    {
        static void Main(string[] args)
        {

            string myTable1 = "{0,-40 }{1:n2}";

            DateTime todDat = DateTime.Today;
            Console.WriteLine(myTable1, "", todDat.ToString("d"));

            Console.WriteLine("".PadLeft(30, '*'));
            Console.WriteLine("The Fitness Calculator Program");
            Console.WriteLine("".PadLeft(30, '*'));
            Console.WriteLine();


            double height = 0, weight = 0;
            string name = "", gender;
            Console.Write("Enter Your name:");
            do
            {
                name = Console.ReadLine();
                if (name == "")
                    Console.Write("A User name is ommitted:");
            } while (name == "");

            Console.WriteLine();

            Console.Write("Enter Your gender(male/female):");
            do
            {

                gender = Console.ReadLine();
                gender = gender.ToUpper();
                if (gender != "MALE" && gender != "FEMALE")

                    Console.Write("Invalid User gender is entered");
            } while (gender != "MALE" && gender != "FEMALE");

            Console.WriteLine();
            const int INCHES = 12, POUNDS = 14;
            Console.WriteLine("Enter Your height (feet and inches):");
            Console.Write("feet:");
            int limit1 = 999, error1 = 0;
            int feet = TryInt.Try(limit1, error1);

            int limit2 = 11, error2 = 1;
            Console.Write("inches:");
            int inches = TryInt.Try(limit2, error2);
            height = (feet * INCHES) + inches;
            Console.WriteLine();
            Console.WriteLine("Enter Your weight (stones and pounds):");
            Console.Write("stones:");
            int error3 = 2;
            int stones = TryInt.Try(limit1, error3);
            Console.Write("pounds:");
            int limit3 = 13, error4 = 3;
            int pounds = TryInt.Try(limit3, error4);
            weight = (stones * POUNDS) + pounds;

            Manu(height, weight, gender);
        }
        static void Manu(double height, double weight, string gender)
        {
            int age = 0, limit = 100, error = 6, agelimit = 150, error5 = 4, menuChoice;
            double fat = 0, BMI, fatMass = 0, leanBM = 0, BMR = 0, DCR = 0, fatPer = 0;
            const double HUNDRED = 100;

            menuChoice = PrintMenu();

            while (menuChoice != 4)  // in the case 4 is the exit option
            {
                // process choice

                switch (menuChoice)
                {
                    case 1:
                        Console.Clear();
                        BMI = BMIClass.BodyMassIndex(height, weight);// call appropriate method(s)
                        Console.WriteLine("BMI Result is {0:0.0}%", BMI);
                        BMIClass.BMIcategories(BMI);// call appropriate method(s)
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Enter Yours fat level(%) :");
                        fat = TryInt.Try(limit, error);
                        fatPer = fat / HUNDRED;
                        fatMass = FatClass.FatMass(weight, fatPer);// call appropriate method(s)
                        leanBM = FatClass.LeanBodyMass(fatMass, weight);
                        Console.WriteLine("Your Fat Mass value is {0} lb", fatMass);
                        Console.WriteLine("Your Lean Body Mass value is {0} lb", leanBM);

                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Enter Your age:");

                        age = TryInt.Try(agelimit, error5);
                        BMR = Active.BasalMetabolicRate(weight, height, age, gender);
                        DCR = Active.ActivityLevel(BMR);
                        Console.WriteLine("Your BasalMetabolicRate is : {0}", BMR);
                        Console.WriteLine("Your Daily Calorific Requirement is :{0}", DCR);
                        Console.ReadKey();
                        break;

                    default:  // something other than 1,2,3,4
                        Console.WriteLine("Invalid menu choice");
                        Console.ReadKey();
                        break;

                }//end switch

                menuChoice = PrintMenu();    //call menu again

            } // end while
        }
        static int PrintMenu()//Menu printed on start of the program
        {

            string result = "";
            int resultInt = 0;
            Console.Clear();
            Console.WriteLine("The Fitness Calculator Program Menu\n");
            Console.WriteLine("1.Calculate BMI");
            Console.WriteLine("2.Body Fat calculations");
            Console.WriteLine("3.BMR and DCR calculations");
            Console.WriteLine("4.Exit the Program");
            Console.WriteLine();
            Console.Write("Enter Choice : ");
            result = Console.ReadLine();

            // catch errors
            try
            {
                resultInt = int.Parse(result);
            }
            catch (Exception)// Get the error out of the exception 
            {
            }

            return resultInt;
        }


    }

}
