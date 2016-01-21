/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2016 Modified: 21.1.2016
* Authors: Ruben Laube-Pohto, Esa Salmikangas
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// namespace vaihdettu nimeämisohjeen mukaiseksi
namespace JAMK.IT.IIO11300
{
    public class Ikkuna
    {
        #region Muutuujat (variables)
        private double korkeus, leveys;
        #endregion

        // Voi lisätä nopeasti 'propfull' code snipet:llä
        #region Ominaisuudet (properties)
        public double Korkeus
        {
            get
            {
                return korkeus;
            }
            set
            {
                // Tässä voisi tehdä tarkistuksia
                korkeus = value;
            }
        }
        public double Leveys
        {
            get
            {
                return leveys;
            }
            set
            {
                // Tässä voisi tehdä tarkistuksia
                leveys = value;
            }
        }
        // On päätetty, että pinta-ala ja hinta ovat read-only ominaisuuksia
        public double PintaAla
        {
            get { return korkeus * leveys; }
        }
        public float Hinta
        {
            get { return LaskeHinta(); }
        }
        #endregion

        #region Konstruktorit (constructors)
        #endregion

        #region Metodit (methods)
        public double LaskePintaAla()
        {
            return korkeus * leveys;
        }
        private float LaskeHinta()
        {
            // Hinta lasketaan työn, materiaalin käytön ja katteen mukaan.
            float kate = 100;
            float tyo = 200;
            float materiaali = 100 * ((float)leveys * (float)korkeus / 1000000);

            return kate + tyo + materiaali;
        }
        #endregion
    }

    public class IkkunaVer0
    {
        // ei hyvä tapa käyttää julkisia muuttujia
        public double korkeus, leveys;

        public double LaskePintaAla()
        {
            return korkeus * leveys;
        }
    }

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