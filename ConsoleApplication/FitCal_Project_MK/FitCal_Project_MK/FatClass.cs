using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FatClass
{
    public static double FatMass(double weight, double bodyFat)
    {

        double fatMassValue = 0;

        fatMassValue = (weight * bodyFat);

        return fatMassValue;
    }
    public static double LeanBodyMass(double fatMass, double weight)
    {

        double result = 0;

        result = (weight - fatMass);
        return result;
    }
}

