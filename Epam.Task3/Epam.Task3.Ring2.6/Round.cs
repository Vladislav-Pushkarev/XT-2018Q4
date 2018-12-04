﻿using System;

public class Round
{
    private static int count;
    private int coordX;
    private int coordY;
    private double r;
    private double lenght;
    private double area;

    public Round(int coordX, int coordY, int r)
    {
        this.CoordX = coordX;
        this.CoordY = coordY;
        this.R = r;
        count++;
    }

    public static int Count { get => count; }

    public int CoordX { get => this.coordX; set => this.coordX = value; }

    public int CoordY { get => this.coordY; set => this.coordY = value; }

    public double R
    {
        get
        {
            return this.r;
        }

        set
        {
            if (value > 0)
            {
                this.r = value;
            }
            else
            {
                throw new ArgumentException("Radius cannot be negative");
            }
        }
    }

    public double Lenght()
    {
        if (this.lenght == 0)
        {
            this.lenght = 2 * Math.PI * this.r;
        }

        return this.lenght;
    }

    public double Area()
    {
        if (this.area == 0)
        {
            this.area = Math.PI * this.r * this.r;
        }

        return this.area;
    }
}
