using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ContainerControl.xaml
    /// </summary>
    public partial class ContainerControl : UserControl
    {
        Collection<int> keys = new Collection<int>();
        public ContainerControl()
        {
            InitializeComponent();   
            var count = MainWindow.mainWindow.RedBlackTree.ToCollection().Count;
            for (int i = 1; i <= count; i++)
            {
                keys.Add(i);
            }
            MainWindow.mainWindow.container = new Container<int, CloudStorage>(MainWindow.mainWindow.RedBlackTree, keys);
            DataGrid.ItemsSource = MainWindow.mainWindow.container.ToDictionary();
        }

        private void ClearTextBoxes()
        {
            NewPersonName.Clear();
            NewCompanyName.Clear();
            NewCatalogName.Clear();
            KeyBox.Clear();
            SearchResult.Text = "";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void ResetCollection_ClickAsync(object sender, RoutedEventArgs e)
        {
            int count = MainWindow.mainWindow.collectionForSort.Count;
            int current = 1;
            MainWindow.mainWindow.sortedCollection = new Collection<int>();
            //DataGrid.BeginInit();
            MainWindow.mainWindow.StartMethod("Перепризначення даних контейнера");
            await Task.Run(() =>
            {
                MainWindow.mainWindow.container = new Container<int, CloudStorage>(MainWindow.mainWindow.RedBlackTree, keys);
            });
            MainWindow.mainWindow.EndMethod();
            //DataGrid.EndInit();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = MainWindow.mainWindow.container.ToDictionary();
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
            MainWindow.mainWindow.StartMethod("Контейнер, вставка елемента");
            await Task.Run(() =>
            {
                // Dispatcher.Invoke(() =>
                // {        
                    MainWindow.mainWindow.container.AddOrUpdate(key, new CloudStorage(personName, providerName, catalogName));
                // }
                // );
            });
            MainWindow.mainWindow.EndMethod();
            DataGrid.EndInit();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = MainWindow.mainWindow.container.ToDictionary();
            ClearTextBoxes();
        }

        private async void SearchButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            int key;
            if (!int.TryParse(KeyBox.Text, out key))
            {
                Dispatcher.Invoke(() => SearchResult.Text = "Не найдено");
                return;
            }
            MainWindow.mainWindow.StartMethod("Контейнер, пошук елемента");
            await Task.Run(() =>
            {
                CloudStorage resValue = MainWindow.mainWindow.container.GetValue(key);
                if (resValue!=null)
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
            MainWindow.mainWindow.StartMethod("Контейнер, видалення елемента");
            await Task.Run(() =>
            {
                Dispatcher.Invoke(() => MainWindow.mainWindow.container.RemoveByKey(key));
            });
            MainWindow.mainWindow.EndMethod();
            DataGrid.EndInit();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = MainWindow.mainWindow.container.ToDictionary();
            ClearTextBoxes();
        }
    }
}
