using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for CircularListControl.xaml
    /// </summary>
    public partial class CircularListControl : UserControl
    {
        public CircularListControl()
        {
            InitializeComponent();
        }

        private async void AddCollection_ClickAsync(object sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.StartMethod("Циклічний список, вставка елементів з поточних даних");
            int count = MainWindow.CloudStorages.Count;
            int current = 1;
            MainWindow.mainWindow.SLcircularList = new SLcircularList<CloudStorage>();
            await Task.Run(() =>
            {
                foreach (var storage in MainWindow.CloudStorages)
                {
                    MainWindow.mainWindow.SLcircularList.AddToEnd(storage);
                    MainWindow.percentDone = current * 100 / count;
                    current++;
                    if (!MainWindow.mainWindow.run) return;
                }
            });
            MainWindow.mainWindow.EndMethod();
            List.ItemsSource = MainWindow.mainWindow.SLcircularList;
        }

        private void ClearTextBoxes()
        {
            NewPersonName.Clear();
            NewCompanyName.Clear();
            NewCatalogName.Clear();
        }

        private async void AddButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            string personName = NewPersonName.Text;
            string providerName = NewCompanyName.Text;
            string catalogName = NewCatalogName.Text;
            MainWindow.mainWindow.StartMethod("Циклічний список, вставка елемента");
            await Task.Run(() =>
            {
                MainWindow.mainWindow.SLcircularList.AddToEnd(new CloudStorage(personName, providerName, catalogName));
            }
            );
            MainWindow.mainWindow.EndMethod();
            ClearTextBoxes();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
        }
    }
}
