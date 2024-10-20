using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    // Constructores
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    public Fraction(int wholeNumber)
    {
        _numerator = wholeNumber;
        _denominator = 1;
    }

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.", nameof(denominator));
        }
        _numerator = numerator;
        _denominator = denominator;
        Simplify();
    }

    // Propiedades con getters y setters
    public int Numerator
    {
        get { return _numerator; }
        set { _numerator = value; Simplify(); }
    }

    public int Denominator
    {
        get { return _denominator; }
        set
        {
            if (value == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            _denominator = value;
            Simplify();
        }
    }

    // Métodos para representaciones
    public string GetFractionString()
    {
        return $"{_numerator}/{_denominator}";
    }

    public double GetDecimalValue()
    {
        return (double)_numerator / _denominator;
    }

    private void Simplify()
    {
        int gcd = CalculateGCD(Math.Abs(_numerator), Math.Abs(_denominator));
        _numerator /= gcd;
        _denominator /= gcd;

        if (_denominator < 0)
        {
            _numerator = -_numerator;
            _denominator = -_denominator;
        }
    }

    private int CalculateGCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public override string ToString()
    {
        return GetFractionString();
    }
}