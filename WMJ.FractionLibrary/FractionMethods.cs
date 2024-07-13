namespace WMJ.FractionLibrary;

public static partial class Fraction
{
    private static readonly int MaxDenominator = 100000;
    private static readonly int DecimalPlaces = 6;

    /// <summary>
    /// Adds two fractions together
    /// </summary>
    /// <param name="firstFraction"></param>
    /// <param name="secondFraction"></param>
    /// <returns></returns>
    public static FractionModel AddFraction(FractionModel firstFraction, FractionModel secondFraction)
    {
        _ = new FractionModel();
        long l_num =0, l_den=0;
        bool overflow =false;
        FractionModel result;
        if ((firstFraction.Denominator == 0) || (secondFraction.Denominator == 0))
        {
            return result = new FractionModel { Status = "Divide by 0" }; //new FractionModel { Status = "Divide by 0" };
        }
        else if (firstFraction.Denominator != secondFraction.Denominator)
        {
            l_num = ((long)firstFraction.Numerator * (long)secondFraction.Denominator) + ((long)secondFraction.Numerator * (long)firstFraction.Denominator);
            l_den = (long)firstFraction.Denominator * (long)secondFraction.Denominator;
            overflow = CheckOverflow(l_num) || CheckOverflow(l_den);
            //Console.WriteLine($"Cross multiply: l_num: {l_num}, l_den: {l_den} overflow: {overflow}");
        }
        else
        {
            l_num = (long)firstFraction.Numerator + (long)secondFraction.Numerator;
            l_den = (long)firstFraction.Denominator;
            overflow = CheckOverflow(l_num) || CheckOverflow(l_den);
            //Console.WriteLine($"Addition: l_num: {l_num}, l_den: {l_den} overflow: {overflow}");
        }

        if (overflow)
        {
            result = new FractionModel {Numerator= 0, Denominator=0, Status = "Integer Overflow", Err_Num = l_num, Err_Den = l_den };
        }
        else
        {
            result = new FractionModel { Numerator = (int)l_num, Denominator = (int)l_den, Status = "OK"};
        }

        return result;
    }

    /// <summary>
    /// Adds two fractions together
    /// </summary>
    /// <param name="FirstNumerator"></param>
    /// <param name="FirstDenominator"></param>
    /// <param name="SecondNumerator"></param>
    /// <param name="SecondDenominator"></param>
    /// <returns></returns>
    public static FractionModel AddFraction(int FirstNumerator, int FirstDenominator, int SecondNumerator, int SecondDenominator)
    {
        return AddFraction(new FractionModel { Numerator = FirstNumerator, Denominator = FirstDenominator }, new FractionModel { Numerator = SecondNumerator, Denominator = SecondDenominator });
    }

    /// <summary>
    /// Adds two fractions together
    /// </summary>
    /// <param name="FirstUnit"></param>
    /// <param name="FirstNumerator"></param>
    /// <param name="FirstDenominator"></param>
    /// <param name="SecondUnit"></param>
    /// <param name="SecondNumerator"></param>
    /// <param name="SecondDenominator"></param>
    /// <returns></returns>
    public static FractionModel AddFraction(int FirstUnit, int FirstNumerator, int FirstDenominator, int SecondUnit, int SecondNumerator, int SecondDenominator)
    {
        FractionModel FirstFraction = new();
        FractionModel SecondFraction = new();

        if (FirstDenominator == 0 || SecondDenominator == 0)
        {
            return new FractionModel { Status = "Divide by 0" };
        }
        
        // Build the fraction models 
        if (FirstUnit != 0)
        {
            FirstFraction = new FractionModel { Numerator = FirstUnit * FirstDenominator + FirstNumerator, Denominator = FirstDenominator };
            
        }
        else
        {
            FirstFraction = new FractionModel { Numerator = FirstNumerator, Denominator = FirstDenominator };
            
        }

        // Build the fraction models
        if (SecondUnit != 0)
        {
            SecondFraction = new FractionModel { Numerator = SecondUnit * SecondDenominator + SecondNumerator, Denominator = SecondDenominator };
        }
        else
        {
            SecondFraction = new FractionModel { Numerator = SecondNumerator, Denominator = SecondDenominator };
        }
        
        return AddFraction(FirstFraction, SecondFraction);
    }
    
    /// <summary>
    /// Subtracts two fractions
    /// </summary>
    /// <param name="firstFraction"></param>
    /// <param name="secondFraction"></param>
    /// <returns></returns>
    public static FractionModel SubtractFraction(FractionModel firstFraction, FractionModel secondFraction)
    {
        _ = new FractionModel();
        long l_num =0, l_den=0;
        bool overflow =false;
        FractionModel result;
        if ((firstFraction.Denominator == 0) || (secondFraction.Denominator == 0))
        {
            return result = new FractionModel { Status = "Divide by 0" }; //new FractionModel { Status = "Divide by 0" };
        }
        else if (firstFraction.Denominator != secondFraction.Denominator)
        {
            l_num = ((long)firstFraction.Numerator * (long)secondFraction.Denominator) - ((long)secondFraction.Numerator * (long)firstFraction.Denominator);
            l_den = (long)firstFraction.Denominator * (long)secondFraction.Denominator;
            overflow = CheckOverflow(l_num) || CheckOverflow(l_den);
            //Console.WriteLine($"Cross multiply: l_num: {l_num}, l_den: {l_den} overflow: {overflow}");
        }
        else
        {
            l_num = (long)firstFraction.Numerator - (long)secondFraction.Numerator;
            l_den = (long)firstFraction.Denominator;
            overflow = CheckOverflow(l_num) || CheckOverflow(l_den);
            //Console.WriteLine($"Addition: l_num: {l_num}, l_den: {l_den} overflow: {overflow}");
        }

        if (overflow)
        {
            result = new FractionModel {Numerator= 0, Denominator=0, Status = "Integer Overflow", Err_Num = l_num, Err_Den = l_den };
        }
        else
        {
            result = new FractionModel { Numerator = (int)l_num, Denominator = (int)l_den, Status = "OK"};
        }

        return result;
    }

    /// <summary>
    /// Subtracts two fractions
    /// </summary>
    /// <param name="FirstNumerator"></param>
    /// <param name="FirstDenominator"></param>
    /// <param name="SecondNumerator"></param>
    /// <param name="SecondDenominator"></param>
    /// <returns></returns>
    public static FractionModel SubtractFraction(int FirstNumerator, int FirstDenominator, int SecondNumerator, int SecondDenominator)
    {
        return SubtractFraction(new FractionModel { Numerator = FirstNumerator, Denominator = FirstDenominator }, new FractionModel { Numerator = SecondNumerator, Denominator = SecondDenominator });
    }

    /// <summary>
    /// Subtracts two fractions
    /// </summary>
    /// <param name="FirstUnit"></param>
    /// <param name="FirstNumerator"></param>
    /// <param name="FirstDenominator"></param>
    /// <param name="SecondUnit"></param>
    /// <param name="SecondNumerator"></param>
    /// <param name="SecondDenominator"></param>
    /// <returns></returns>
    public static FractionModel SubtractFraction(int FirstUnit, int FirstNumerator, int FirstDenominator, int SecondUnit, int SecondNumerator, int SecondDenominator)
    {
        FractionModel FirstFraction = new();
        FractionModel SecondFraction = new();

        if (FirstDenominator == 0 || SecondDenominator == 0)
        {
            return new FractionModel { Status = "Divide by 0" };
        }
        
        // Build the fraction models 
        if (FirstUnit != 0)
        {
            FirstFraction = new FractionModel { Numerator = FirstUnit * FirstDenominator + FirstNumerator, Denominator = FirstDenominator };
            
        }
        else
        {
            FirstFraction = new FractionModel { Numerator = FirstNumerator, Denominator = FirstDenominator };
            
        }

        // Build the fraction models
        if (SecondUnit != 0)
        {
            SecondFraction = new FractionModel { Numerator = SecondUnit * SecondDenominator + SecondNumerator, Denominator = SecondDenominator };
        }
        else
        {
            SecondFraction = new FractionModel { Numerator = SecondNumerator, Denominator = SecondDenominator };
        }
        
        return SubtractFraction(FirstFraction, SecondFraction);
    }

    /// <summary>
    /// Multiplies two fractions
    /// </summary>
    /// <param name="firstFraction"></param>
    /// <param name="secondFraction"></param>
    /// <returns></returns>
    public static FractionModel MultiplyFraction(FractionModel firstFraction, FractionModel secondFraction)
    {
        FractionModel result = new();
        long l_num =0, l_den=0;
        bool overflow =false;

        if ((firstFraction.Denominator ==0) || (secondFraction.Denominator ==0))
        {
            return result = new FractionModel { Status = "Divide by 0" };
        }
        else
        {
            l_num = (long)firstFraction.Numerator * (long)secondFraction.Numerator;
            l_den = (long)firstFraction.Denominator * (long)secondFraction.Denominator;
            overflow = CheckOverflow(l_num) || CheckOverflow(l_den);
            //Console.WriteLine($"Multiplication: l_num: {l_num}, l_den: {l_den} overflow: {overflow}");
        }

        if (overflow)
        {
            result = new FractionModel {Numerator= 0, Denominator=0, Status = "Integer Overflow", Err_Num = l_num, Err_Den = l_den };
        }
        else
        {
            result = new FractionModel { Numerator = (int)l_num, Denominator = (int)l_den, Status = "OK"};
        }

        return result;
    }

    /// <summary>
    /// Multiplies two fractions
    /// </summary>
    /// <param name="FirstNumerator"></param>
    /// <param name="FirstDenominator"></param>
    /// <param name="SecondNumerator"></param>
    /// <param name="SecondDenominator"></param>
    /// <returns></returns>
    public static FractionModel MultiplyFraction(int FirstNumerator, int FirstDenominator, int SecondNumerator, int SecondDenominator)
    {
        return MultiplyFraction(new FractionModel { Numerator = FirstNumerator, Denominator = FirstDenominator }, new FractionModel { Numerator = SecondNumerator, Denominator = SecondDenominator });
    }

    /// <summary>
    /// Multiplies two fractions
    /// </summary>
    /// <param name="FirstUnit"></param>
    /// <param name="FirstNumerator"></param>
    /// <param name="FirstDenominator"></param>
    /// <param name="SecondUnit"></param>
    /// <param name="SecondNumerator"></param>
    /// <param name="SecondDenominator"></param>
    /// <returns></returns>
    public static FractionModel MultiplyFraction(int FirstUnit, int FirstNumerator, int FirstDenominator, int SecondUnit, int SecondNumerator, int SecondDenominator)
    {
        FractionModel FirstFraction = new();
        FractionModel SecondFraction = new();

        if (FirstDenominator == 0 || SecondDenominator == 0)
        {
            return new FractionModel { Status = "Divide by 0" };
        }
        
        // Build the fraction models 
        if (FirstUnit != 0)
        {
            FirstFraction = new FractionModel { Numerator = FirstUnit * FirstDenominator + FirstNumerator, Denominator = FirstDenominator };
            
        }
        else
        {
            FirstFraction = new FractionModel { Numerator = FirstNumerator, Denominator = FirstDenominator };
            
        }

        // Build the fraction models
        if (SecondUnit != 0)
        {
            SecondFraction = new FractionModel { Numerator = SecondUnit * SecondDenominator + SecondNumerator, Denominator = SecondDenominator };
        }
        else
        {
            SecondFraction = new FractionModel { Numerator = SecondNumerator, Denominator = SecondDenominator };
        }
        
        return MultiplyFraction(FirstFraction, SecondFraction);
    }

    /// <summary>
    /// Divides two fractions
    /// </summary>
    /// <param name="firstFraction"></param>
    /// <param name="secondFraction"></param>
    /// <returns></returns>
    public static FractionModel DivideFraction(FractionModel firstFraction, FractionModel secondFraction)
    {
        FractionModel flippedFraction; // = new();

        if ((secondFraction.Numerator == 0) || (secondFraction.Denominator == 0))
        {
            return new FractionModel { Status = "Divide by 0" };
        }
        else
        {
            flippedFraction = new FractionModel { Numerator = secondFraction.Denominator, Denominator = secondFraction.Numerator };
        }

        return MultiplyFraction(firstFraction, flippedFraction);
    }

    /// <summary>
    /// Divides two fractions
    /// </summary>
    /// <param name="FirstNumerator"></param>
    /// <param name="FirstDenominator"></param>
    /// <param name="SecondNumerator"></param>
    /// <param name="SecondDenominator"></param>
    /// <returns></returns>
    public static FractionModel DivideFraction(int FirstNumerator, int FirstDenominator, int SecondNumerator, int SecondDenominator)
    {
        return DivideFraction(new FractionModel { Numerator = FirstNumerator, Denominator = FirstDenominator }, new FractionModel { Numerator = SecondNumerator, Denominator = SecondDenominator });
    }

    /// <summary>
    /// Divides two fractions
    /// </summary>
    /// <param name="FirstUnit"></param>
    /// <param name="FirstNumerator"></param>
    /// <param name="FirstDenominator"></param>
    /// <param name="SecondUnit"></param>
    /// <param name="SecondNumerator"></param>
    /// <param name="SecondDenominator"></param>
    /// <returns></returns>
    public static FractionModel DivideFraction(int FirstUnit, int FirstNumerator, int FirstDenominator, int SecondUnit, int SecondNumerator, int SecondDenominator)
    {
        FractionModel FirstFraction = new();
        FractionModel SecondFraction = new();

        if (FirstDenominator == 0 || SecondDenominator == 0)
        {
            return new FractionModel { Status = "Divide by 0" };
        }
        
        // Build the fraction models 
        if (FirstUnit != 0)
        {
            FirstFraction = new FractionModel { Numerator = FirstUnit * FirstDenominator + FirstNumerator, Denominator = FirstDenominator };
            
        }
        else
        {
            FirstFraction = new FractionModel { Numerator = FirstNumerator, Denominator = FirstDenominator };
            
        }

        // Build the fraction models
        if (SecondUnit != 0)
        {
            SecondFraction = new FractionModel { Numerator = SecondUnit * SecondDenominator + SecondNumerator, Denominator = SecondDenominator };
        }
        else
        {
            SecondFraction = new FractionModel { Numerator = SecondNumerator, Denominator = SecondDenominator };
        }
        
        return DivideFraction(FirstFraction, SecondFraction);
    }

    /// <summary>
    /// Simplifies a fraction
    /// </summary>
    /// <param name="Numerator"></param>
    /// <param name="Denominator"></param>
    /// <returns></returns>
    public static FractionModel SimplifyFraction(int Numerator, int Denominator)
    {
        FractionModel result = new();

        if (Denominator == 0)
        {
            return result= new() { Status = "Divide by 0" };
        }
        else if (Numerator == 0)
        {
            return result =new() { Numerator = 0, Denominator = 0, Status = "OK" };
        }
        else
        {
            int gcd = GCDFunction(Numerator, Denominator);
            return result=new() { Numerator = Numerator / gcd, Denominator = Denominator / gcd, Status = "OK" };
        }        
    }
    
    /// <summary>
    /// Finds the Greatest Common Denominator
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static int GCDFunction(int x,int y)
    {
        if (x ==0)
        {
            return y;
        }
        else if (y == 0)
        {
            return x;
        }
        else
        {
            return GCDFunction(y, x % y);
        }
    }

    /// <summary>
    /// Converts a fraction to a mixed fraction
    /// </summary>
    /// <param name="Numerator"></param>
    /// <param name="Denominator"></param>
    /// <returns></returns>
    public static FractionModel MixedFraction(int Numerator, int Denominator)
    {
        FractionModel result = new();
        int unit = 0;
        int numerator = 0;
        int denominator = 0;

        if (Denominator == 0)
        {
            result = new FractionModel { Status = "Divide by 0" };
        }
        else if (Numerator == 0)
        {
            result = new FractionModel { Numerator = 0, Denominator = 0, Status = "OK" };
        }
        else
        {
            unit = Math.Abs(Numerator / Denominator);
            numerator = Numerator % Denominator;
            denominator = Denominator;
            result = new FractionModel { Unit = unit, Numerator = numerator, Denominator = denominator, Status = "OK" };
        }

        return result;
    }

    public static FractionModel MakeFraction(int Unit, int Numerator, int Denominator)
    {
        FractionModel result = new();
        long l_num =0, l_den=0;
        bool overflow =false;

        if ((Unit != 0) && (Denominator != 0))
        {
            l_num = (long)Unit * (long)Denominator + (long)Numerator;
            l_den = (long)Denominator;
            overflow = CheckOverflow(l_num) || CheckOverflow(l_den);
        }
        else if (Denominator == 0)
        {
            result = new FractionModel { Status = "Divide by 0" };
        }
        else
        {
            l_num = (long)Numerator;
            l_den = (long)Denominator;
            overflow = CheckOverflow(l_num) || CheckOverflow(l_den);
        }
        
        if (overflow)
        {
            result = new FractionModel {Numerator= 0, Denominator=0, Status = "Integer Overflow", Err_Num = l_num, Err_Den = l_den };
        }
        else
        {
            result = new FractionModel { Numerator = (int)l_num, Denominator = (int)l_den, Status = "OK"};
        }

        return result;
    }

    /// <summary>
    /// Converts a decimal to an approximate fraction (Simplest form)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static FractionModel DecimalToFractionApprox(double value)
    {
        FractionModel result = new();
        long l_num =0, l_den=(long)MaxDenominator;
        bool overflow =false;

        l_num = (long)(Math.Round(value,DecimalPlaces) * MaxDenominator);

        overflow = CheckOverflow(l_num) || CheckOverflow(l_den);
        if (overflow)
        {
            result = new FractionModel {Numerator= 0, Denominator=0, Status = "Integer Overflow", Err_Num = l_num, Err_Den = l_den };
        }
        else
        {
            result = SimplifyFraction((int)l_num, (int)l_den);
        }

        return result;
    }

    /// <summary>
    /// Checks for integer overflow by comparing the value to the (int.MaxValue - 1) and (int.MinValue + 1)
    /// </summary>
    /// <param name="Value"></param>
    /// <returns></returns>
    public static bool CheckOverflow(long Value)
    {
        if ((Value >= (int.MaxValue - 1) ) || (Value <= (int.MinValue +1)))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}