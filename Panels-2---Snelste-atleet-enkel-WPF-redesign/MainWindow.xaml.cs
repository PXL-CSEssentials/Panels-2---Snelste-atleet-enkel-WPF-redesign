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

namespace Panels_2___Snelste_atleet_enkel_WPF_redesign
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // We beginnen met de grootste waarde van een datatype. 
        // De traagste tijd zogezegd
        private int _fastestTime = int.MaxValue;
        private string _fastestAtlete;

        public MainWindow()
        {
            InitializeComponent();
            _fastestAtlete = nameTextBox.Text;
        }
        private void fastestButton_Click(object sender, RoutedEventArgs e)
        {
            int hours;
            int minutes;
            int seconds;
            int time;

            resultTextBox.Text = $"De snelste atleet is {_fastestAtlete}\r\ntotaal aantal seconden: {_fastestTime}\r\n\r\n";
            time = _fastestTime;
            //Gehele deling en uren, minuten worden uit de tijd gehaald
            hours = time / 3600; // tijd staat in seconden en er zijn 3600 seconden in een uur
            time -= (hours * 3600); // trek nu de uren van de tijd af (terug omzetten naar seconden omdat tijd in seconden staat)
            minutes = time / 60; // tijd staat in seconden en er zijn 60 seconden in een minuut
            time -= (minutes * 60); // trek nu de minuten van de tijd af (terug omzetten naar seconden omdat tijd in seconden staat)
            seconds = time; // het aantal seconden is de tijd die overblijft

            // Voeg deze tekst nog toe aan resultaat tekst (+=)
            // is hetzelfde als zeggen: TxtResultaat.Text = TxtResultaat + ... ;
            resultTextBox.Text += $"aantal uren: {hours}\r\naantal minuten: {minutes}\r\naantal seconden: {seconds}";
        }
        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            // Als tijd sneller dan de snelste tijd (tijd is kleiner dan snelsteTijd)
            // maak dan dit de nieuwe snelste atleet
            int numberOfSeconds = int.Parse(timeTextBox.Text);
            if (numberOfSeconds < _fastestTime)
            {
                _fastestAtlete = nameTextBox.Text;
                _fastestTime = numberOfSeconds;
            }

            nameTextBox.Text = string.Empty;
            timeTextBox.Text = string.Empty;
            nameTextBox.Focus();
        }
        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            _fastestAtlete = string.Empty;
            _fastestTime = int.MaxValue;  // Snelste tijd terug op de traagst mogelijke waarde zetten (int.MaxValue)
            resultTextBox.Clear();
            nameTextBox.Clear();
            timeTextBox.Clear();
            nameTextBox.Focus();
        }
        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
