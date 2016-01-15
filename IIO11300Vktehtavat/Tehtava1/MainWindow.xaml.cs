/*
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tehtava1
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            try
            {
                double width, height, borderWidth, result;
                width = double.Parse(tbWindowWidth.Text);
                height = double.Parse(tbWindowHeight.Text);
                borderWidth = double.Parse(tbBorderWidth.Text);

                result = BusinessLogicWindow.CalculateArea(width, height);
                lblDisplay_WindowArea.Content = result;

                result = BusinessLogicWindow.CalculatePerimeter(width, height);
                lblDisplay_BorderLength.Content = result;

                result = BusinessLogicWindow.CalculateBorderArea(width, height, borderWidth);
                lblDisplay_BorderArea.Content = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //yield to an user that everything okay
            }
        }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }
  }
}
