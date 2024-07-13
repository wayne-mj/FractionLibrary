namespace WMJ.FractionLibrary;

/// <summary>
/// Fraction Model: Units & Numerator/Denominator
/// </summary>
public class FractionModel
{
    public int Unit { get; set; } = 0;
    public int Numerator { get; set; } = 0;
    public int Denominator { get; set; } = 0;
    public string Status { get; set; } = "";
    public long Err_Num { get; set; } = 0;
    public long Err_Den { get; set; } = 0;
}
