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

namespace Prb.JarenEnSeizoenen.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string input;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SeedMonths();
            txtYear.Text = DateTime.Now.Year.ToString();
        }

        private void SeedMonths()
        {
            cmbMonths.Items.Add("januari");
            cmbMonths.Items.Add("februari");
            cmbMonths.Items.Add("maart");
            cmbMonths.Items.Add("april");
            cmbMonths.Items.Add("mei");
            cmbMonths.Items.Add("juni");
            cmbMonths.Items.Add("juli");
            cmbMonths.Items.Add("augustus");
            cmbMonths.Items.Add("september");
            cmbMonths.Items.Add("oktober");
            cmbMonths.Items.Add("november");
            cmbMonths.Items.Add("december");
        }

        string GiveSeason(int numberOfMonth)
        {
            string season;
            if (numberOfMonth >= 3 && numberOfMonth <= 5) season = "lente";
            else if (numberOfMonth >= 5 && numberOfMonth <= 8) season = "zomer";
            else if (numberOfMonth >= 9 && numberOfMonth <= 11) season = "herfst";
            else season = "winter";
            return season;
        }

        bool IsValidYear(string number)
        {
            int convertedNumber = Convert.ToInt32(number);

            if (convertedNumber != 0) return true;

            else return false;
        }

        bool IsLeapYear(int year)
        {
            bool isLeapYear;
            if (year % 400 == 0) isLeapYear = true;
            else if (year % 100 == 0) isLeapYear = false;
            else if (year % 4 == 0) isLeapYear = true;
            else isLeapYear = false;
            return isLeapYear;
        }

        int AdaptTxtYear(int number)
        {
            int jaar;

            jaar = int.Parse(txtYear.Text);
            jaar += number;
            txtYear.Text = jaar.ToString();
            return jaar;
        }

        private void txtYear_TextChanged(object sender, TextChangedEventArgs e)
        {
            input = txtYear.Text;
            if(txtYear.IsLoaded)
            {
                if (IsValidYear(input))
                {
                    int year = int.Parse(input);
                    DisplayLeapYearText(year);
                }
                else
                {
                    lblLeapYear.Content = "Geef een geldig jaartal";
                }
            }

        }

        private void btnYearMinus_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidYear(input)) AdaptTxtYear(-1);

        }
        private void btnYearPlus_Click(object sender, RoutedEventArgs e)
        {
            if (IsValidYear(input)) AdaptTxtYear(1);
        }
        private void DisplayLeapYearText(int year)
        {
            if (IsLeapYear(year))
                lblLeapYear.Content = year.ToString() + " is een schrikkeljaar";
            else
                lblLeapYear.Content = year.ToString() + " is GEEN schrikkeljaar";
        }

        private void cmbMonths_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // meteoroligsche seizoenen
            /*
             * Lente: 1 maart t/m 31 mei
             * Zomer: 1 juni t/m 31 augustus
             * Herfst: 1 september t/m 30 november
             * Winter: 1 december t/m 28 februari
            */

            int monthNumber;
            string seasonFeedback = "";
            if (cmbMonths.SelectedItem != null)
            {
                monthNumber = cmbMonths.SelectedIndex;
                monthNumber++;
                seasonFeedback = GiveSeason(monthNumber);
            }
            lblSeason.Content = seasonFeedback;
        }
    }
}
