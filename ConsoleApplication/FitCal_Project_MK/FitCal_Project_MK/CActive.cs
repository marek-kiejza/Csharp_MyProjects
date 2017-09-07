using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Active
{
    public static double BasalMetabolicRate(double weight, double height, int age, string gender)
    {
        double result = 0;

        if (gender == "MALE")
            result = (66 + ((6.23 * weight) + (12.7 * height)) - (6.8 * age));

        else
            result = (655 + ((4.35 * weight) + (4.7 * height)) - (4.7 * age));
        return result;
    }

    public static double ActivityLevel(double BMR)
    {
        int choise = 0;
        double DCR = 0;

        Console.WriteLine("Activity Level\n");
        Console.WriteLine("1.Sedentary ");
        Console.WriteLine("2.Light Exercise (1-3 days/week)");
        Console.WriteLine("3.Moderate Exercise (3-5 days/week)");
        Console.WriteLine("4.Intense Exercise (6-7 days/week)");
        Console.WriteLine("5.Very Intense Exercise (2 extreme workouts per day)");

        int limit = 5, error = 6;
        choise = TryInt.Try(limit, error);
        switch (choise)
        {
            case 1:
                DCR = BMR * 1.2;
                break;

            case 2:
                DCR = BMR * 1.375;
                break;

            case 3:
                DCR = BMR * 1.55;
                break;

            case 4:
                DCR = BMR * 1.725;
                break;

            case 5:
                DCR = BMR * 1.9;
                break;
            default:
                DCR = BMR * 1.2;
                break;
        }
        return DCR;
    }


}
