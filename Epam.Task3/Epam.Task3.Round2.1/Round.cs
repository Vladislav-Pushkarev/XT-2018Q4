using System;

public class Round
{
    private static int count;
    private int coordX;
    private int coordY;
    private double r;
    private double lenght;
    private double area;


    public static int Count { get => count; }
    public int CoordX { get => coordX; set => coordX = value; }
    public int CoordY { get => coordY; set => coordY = value; }
    public double R
    {
        get
        {
            return r;
        }
        set
        {
            if (value > 0)
            {
                r = value;
            }
            else
            {
                throw new ArgumentException("Radius cannot be negative");
            }
        }
    }

    public Round(int coordX, int coordY, int r)
    {
        CoordX = coordX;
        CoordY = coordY;
        R = r;
        count++;
    }

    public double Lenght()
    {
        if (lenght == 0)
        {
            lenght = 2 * Math.PI * r;
        }
        return lenght;
    }

    public double Area()
    {
        if (area == 0)
        {
            area = Math.PI * r * r;
        }
        return area;
    }
}
