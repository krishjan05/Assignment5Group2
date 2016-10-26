using System;
using System.Collections.Generic;
using System.IO;
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

namespace Assignment5Group2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string DIRNAME = "Result";
        string FILENAME = "PopulationPredictor.txt";
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Calculate()
        {
            double percentIncrease;
            double numberOfDay;
            double totalPopulation;
            string path = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string fullPath = System.IO.Path.Combine(path, DIRNAME);
            Directory.CreateDirectory(fullPath);
            string filePath = System.IO.Path.Combine(fullPath, FILENAME);
            StreamWriter sw = File.CreateText(filePath);
            percentIncrease = double.Parse(txtPercent.Text);
            numberOfDay = double.Parse(txtDays.Text);
            totalPopulation = double.Parse(txtStartingNumber.Text);
            for(int i=1; i <= numberOfDay; i++)
            {
                totalPopulation += ((percentIncrease/100) * totalPopulation);
                string result = i + " " + totalPopulation;
                lstResult.Items.Add(result);
                sw.WriteLine(result);
            }
            sw.Close();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
        }
    }
}
