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

namespace Tehtava7
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

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPassword.Text.Length <= 0)
            {
                txtLength.Text = ". . .";
                txtUppercase.Text = ". . .";
                txtLowercase.Text = ". . .";
                txtNumbers.Text = ". . .";
                txtSpecial.Text = ". . .";
                txtPassword_Strength.Text = "Anna salasana";
            }
            else
            {
                string password = txtPassword.Text;
                int total = password.Length;
                int upperTotal = CountUpper(password);
                int lowerTotal = CountLower(password);
                int numberTotal = CountNumber(password);
                int specialTotal = total - upperTotal - lowerTotal - numberTotal;

                txtLength.Text = "Merkkejä: " + total;
                txtUppercase.Text = "Isoja kirjaimia: " + upperTotal;
                txtLowercase.Text = "Pieniä kirjaimia: " + lowerTotal;
                txtNumbers.Text = "Numeroita: " + numberTotal;
                txtSpecial.Text = "Erikoismerkkejä: " + specialTotal;

                /*
                laske, kuinka monta 'ehtoa' täyttyy
                switch/case
                    maalaile tausta
                    päivitä teksti
                */
            }
        }

        private int CountUpper(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsUpper(s[i])) count++;
            }
            return count;
        }

        private int CountLower(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLower(s[i])) count++;
            }
            return count;
        }

        private int CountNumber(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsNumber(s[i])) count++;
            }
            return count;
        }
    }
}
