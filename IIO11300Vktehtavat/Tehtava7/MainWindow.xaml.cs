using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

            int types = 0;
            if (upperTotal != 0) types++;
            if (lowerTotal != 0) types++;
            if (numberTotal != 0) types++;
            if (specialTotal != 0) types++;

            if (total == 0)
            {
                txtPassword_Strength.Background = Brushes.LightGray;
                txtPassword_Strength.Text = "Anna salasana";
            }
            else if (total < 8 || types == 1)
            {
                // BAD
                txtPassword_Strength.Background = Brushes.Orange;
                txtPassword_Strength.Text = "Bad";
            }
            else if (total < 12 && types >= 2)
            {
                // FAIR
                txtPassword_Strength.Background = Brushes.Yellow;
                txtPassword_Strength.Text = "Fair";
            }
            else if (total < 16 && types >= 3)
            {
                // MODERATE
                txtPassword_Strength.Background = Brushes.LightGreen;
                txtPassword_Strength.Text = "Moderate";
            }
            else if (total >= 16 && types == 4)
            {
                // GOOD
                txtPassword_Strength.Background = Brushes.Green;
                txtPassword_Strength.Text = "Good";
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
