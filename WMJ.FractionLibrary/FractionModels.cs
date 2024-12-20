﻿namespace WMJ.FractionLibrary;

/// <summary>
/// Fraction Model: Units & Numerator/Denominator
/// </summary>
public class FractionModel
{
    public int Unit { get; set; } = 0;
    public int Numerator { get; set; } = 0;
    public int Denominator { get; set; } = 0;
    public string Status { get; set; } = "";
    public long l_Unit { get; set; } = 0;
    public long l_Numerator { get; set; } = 0;
    public long l_Denominator { get; set; } = 0;
}
