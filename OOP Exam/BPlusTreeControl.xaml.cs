using OOP_Exam.BPlusTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for BPlusTree.xaml
    /// </summary>
    public partial class BPlusTreeControl : UserControl
    {
        public BPlusTreeControl()
        {
            InitializeComponent();
            DataGrid.ItemsSource = MainWindow.mainWindow.BPTree.ToCollection();
        }

        private void ClearTextBoxes()
        {
            NewPersonName.Clear();
            NewCompanyName.Clear();
            NewCatalogName.Clear();
            KeyBox.Clear();
            SearchResult.Text = "";
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void AddButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            string personName = NewPersonName.Text;
            string providerName = NewCompanyName.Text;
            string catalogName = NewCatalogName.Text;
            int key;
            if (!int.TryParse(KeyBox.Text, out key))
            {
                key = MainWindow.mainWindow.BPTree.Count + 1;
            }
            DataGrid.BeginInit();
            MainWindow.mainWindow.StartMethod("В+ дерево, вставка елемента");
            await Task.Run(() =>
            {
                // Dispatcher.Invoke(() =>
                // {
                try
                {
                    MainWindow.mainWindow.BPTree.AddOrReplace(key, new CloudStorage(personName, providerName, catalogName));
                }
                catch
                {

                }
                // }
                // );
            });
            MainWindow.mainWindow.EndMethod();
            DataGrid.EndInit();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = MainWindow.mainWindow.BPTree.ToCollection();
            ClearTextBoxes();
        }

        private async void AddCollection_ClickAsync(object sender, RoutedEventArgs e)
        {
            int count = MainWindow.CloudStorages.Count;
            int current = 1;
            MainWindow.mainWindow.BPTree = new BPTree<int, CloudStorage>();
            DataGrid.BeginInit();
            MainWindow.mainWindow.StartMethod("В+ дерево, вставка елементів з поточних даних");
            await Task.Run(() =>
            {
                foreach (var storage in MainWindow.CloudStorages)
                {
                    MainWindow.mainWindow.BPTree.Add(current, storage);
                    MainWindow.percentDone = current * 100 / count;
                    current++;
                    if (!MainWindow.mainWindow.run) return;
                }
            });
            MainWindow.mainWindow.EndMethod();
            DataGrid.EndInit();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = MainWindow.mainWindow.BPTree.ToCollection();
        }

        private async void SearchButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            int key;
            if (!int.TryParse(KeyBox.Text, out key))
            {
                Dispatcher.Invoke(() => SearchResult.Text = "Не найдено");
                return;
            }
            MainWindow.mainWindow.StartMethod("В+ дерево, пошук елемента");
            await Task.Run(() =>
            {
                CloudStorage resValue;
                if (MainWindow.mainWindow.BPTree.TryGet(key, out resValue))
                {
                    Dispatcher.Invoke(() => SearchResult.Text = "Знайдено: " + resValue.Person.Name + ", " +
                    resValue.CompanyProvider.Name + ", " + resValue.Catalog.Name);
                }
                else
                {
                    Dispatcher.Invoke(() => SearchResult.Text = "Не найдено");
                }
            });
            MainWindow.mainWindow.EndMethod();
        }

        private async void DeleteButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            int key;
            if (!int.TryParse(KeyBox.Text, out key))
            {
                return;
            }
            DataGrid.BeginInit();
            MainWindow.mainWindow.StartMethod("В+ дерево, видалення елемента");
            await Task.Run(() =>
            {
                CloudStorage resValue;
                Dispatcher.Invoke(() => MainWindow.mainWindow.BPTree.Remove(key, out resValue));
            });
            MainWindow.mainWindow.EndMethod();
            DataGrid.EndInit();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = MainWindow.mainWindow.BPTree.ToCollection();
            ClearTextBoxes();
        }
    }
}
