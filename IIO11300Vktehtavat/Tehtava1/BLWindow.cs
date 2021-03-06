﻿/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2016 Modified: 15.1.2016
* Authors: Ruben Laube-Pohto, Esa Salmikangas
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava1
{
    public class BusinessLogicWindow
    {
    /// <summary>
    /// CalculatePerimeter calculates the perimeter of a window
    /// </summary>
    public static double CalculatePerimeter(double widht, double height)
        {
            return 2 * widht + 2 * height;
        }
    public static double CalculateArea(double widht, double height)
        {
            return widht * height;
        }
    public static double CalculateBorderArea(double widht, double height, double borderWidth)
        {
            return CalculatePerimeter(widht, height) * borderWidth;
        }
    }
}