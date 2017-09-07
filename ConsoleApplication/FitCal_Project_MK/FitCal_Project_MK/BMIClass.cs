using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


   
        class BMIClass
        {
            public static double BodyMassIndex(double height, double weight)
            {
                double result = 0;

                result = (weight / (Math.Pow(height, 2))) * 703;

                return result;
            }
            public static void BMIcategories(double mass)
            {

                if (mass < 18.5)
                {
                    Console.WriteLine("Underweight");
                }
                else if (mass >= 1 && mass < 25)
                {
                    Console.WriteLine("Normal Weight");
                }
                else if (mass >= 25 && mass < 30)
                {
                    Console.WriteLine("Overweight");
                }
                else
                {
                    Console.WriteLine("Obese");
                }

            }
        }
   
