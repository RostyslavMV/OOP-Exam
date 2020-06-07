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

namespace OOP_Exam
{
    /// <summary>
    /// Interaction logic for InputControl.xaml
    /// </summary>
    public partial class InputControl : UserControl
    {
        public InputControl()
        {
            InitializeComponent();
        }

        private void AddDataFromFile(string fileName)
        {
            var lines = System.IO.File.ReadLines(fileName);
            int count = lines.Count();
            int current = 1;
            foreach (var line in lines)
            {
                string[] spearator = { "  " };
                string[] strlist = line.Split(spearator, 3,
               StringSplitOptions.RemoveEmptyEntries);
                MainWindow.CloudStorages.Add(new CloudStorage(strlist[0], strlist[1], strlist[2]));
                MainWindow.percentDone = current * 100 / count;
                current++;
            }
        }

        private async void LoadDataButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            MainWindow.percentDone = 0;
            await Task.Run(() => AddDataFromFile(@"..\..\TestData.txt"));
            MainWindow.percentDone = 100;
        }

        private async void ResetDataButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            MainWindow.percentDone = 0;
            await Task.Run(() => MainWindow.CloudStorages.Clear());
            MainWindow.percentDone = 100;
        }

        private void ClearTextBoxes()
        {
            PersonName.Clear();
            ProviderName.Clear();
            CatalogName.Clear();
        }

        private async void AddButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            string personName = PersonName.Text;
            string providerName = ProviderName.Text;
            string catalogName = CatalogName.Text;
            await Task.Run(() =>
            {
                MainWindow.CloudStorages.Add(new CloudStorage(personName, providerName, catalogName));
            }
            );
            ClearTextBoxes();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
        }
    }
}
