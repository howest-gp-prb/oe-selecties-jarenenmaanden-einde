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
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtYear.Text = DateTime.Now.Year.ToString();
            SeedMonths();
            if (IsLeapYear(int.Parse(txtYear.Text)))
                lblLeapYear.Content = txtYear.Text + " is een schrikkeljaar";
            else
                lblLeapYear.Content = txtYear.Text + " is GEEN schrikkeljaar";


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
        bool IsLeapYear(int year)
        {
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private void txtYear_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtYear.IsLoaded)
            {
                int year;
                int.TryParse(txtYear.Text, out year);
                DisplayLeapYearText(year);
            }
        }
        private void btnYearMin_Click(object sender, RoutedEventArgs e)
        {
            int year;
            int.TryParse(txtYear.Text, out year);
            year--;
            txtYear.Text = year.ToString();
            DisplayLeapYearText(year);

        }
        private void btnYearPlus_Click(object sender, RoutedEventArgs e)
        {
            int year;
            int.TryParse(txtYear.Text, out year);
            year++;
            txtYear.Text = year.ToString();
            DisplayLeapYearText(year);

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

            string season = "winter";
            int month = cmbMonths.SelectedIndex + 1;
            if (month >= 3 && month <= 5)
                season = "lente";
            else if (month >= 6 && month <= 8)
                season = "zomer";
            else if (month >= 9 && month <= 11)
                season = "herfst";

            lblSeason.Content = cmbMonths.SelectedItem.ToString() + " valt in de "+ season;

        }


    }
}
