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

namespace OOP_Exam
{
    /// <summary>
    /// Interaction logic for RedBlackTreeControl.xaml
    /// </summary>
    public partial class RedBlackTreeControl : UserControl
    {
        public RedBlackTreeControl()
        {
            InitializeComponent();
            DataGrid.ItemsSource = MainWindow.mainWindow.RedBlackTree.ToCollection();
        }

        private async void AddCollection_ClickAsync(object sender, RoutedEventArgs e)
        {
            int count = MainWindow.CloudStorages.Count;
            int current = 1;
            MainWindow.mainWindow.SLcircularList = new SLcircularList<CloudStorage>();
            DataGrid.BeginInit();
            MainWindow.mainWindow.StartMethod("Червоно-чорне дерево, вставка елементів з поточних даних");
            await Task.Run(() =>
            {
                foreach (var storage in MainWindow.CloudStorages)
                {
                    MainWindow.mainWindow.RedBlackTree.Add(storage);
                    MainWindow.percentDone = current * 100 / count;
                    current++;
                    if (!MainWindow.mainWindow.run) return;
                }
            });
            MainWindow.mainWindow.EndMethod();
            DataGrid.EndInit();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = MainWindow.mainWindow.RedBlackTree.ToCollection();
        }

        private void ClearTextBoxes()
        {
            NewPersonName.Clear();
            NewCompanyName.Clear();
            NewCatalogName.Clear();
            SearchResult.Text = "";
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
        }

        private async void AddButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            string personName = NewPersonName.Text;
            string providerName = NewCompanyName.Text;
            string catalogName = NewCatalogName.Text;
            DataGrid.BeginInit();
            MainWindow.mainWindow.StartMethod("Червоно-чорне дерево, вставка елемента");
            await Task.Run(() =>
            {
               // Dispatcher.Invoke(() =>
               // {
                        MainWindow.mainWindow.RedBlackTree.Add(new CloudStorage(personName, providerName, catalogName));
               // }
           // );
            });
            MainWindow.mainWindow.EndMethod();
            DataGrid.EndInit();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = MainWindow.mainWindow.RedBlackTree.ToCollection();
            ClearTextBoxes();
        }

        private async void SearchButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            string personName = NewPersonName.Text;
            string providerName = NewCompanyName.Text;
            string catalogName = NewCatalogName.Text;
            MainWindow.mainWindow.StartMethod("Червоно-чорне дерево, пошук елемента");
            await Task.Run(() =>
            {
                if (MainWindow.mainWindow.RedBlackTree.Search(new CloudStorage(personName, providerName, catalogName)) != null)
                {
                    Dispatcher.Invoke(() => SearchResult.Text = "Знайдено");
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
            string personName = NewPersonName.Text;
            string providerName = NewCompanyName.Text;
            string catalogName = NewCatalogName.Text;
            DataGrid.BeginInit();
            MainWindow.mainWindow.StartMethod("Червоно-чорне дерево, видалення елемента");
            await Task.Run(() =>
            {
                Dispatcher.Invoke(() =>
                {
                        MainWindow.mainWindow.RedBlackTree.Remove(new CloudStorage(personName, providerName, catalogName));
                });
            });
            MainWindow.mainWindow.EndMethod();
            DataGrid.EndInit();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = MainWindow.mainWindow.RedBlackTree.ToCollection();
            ClearTextBoxes();
        }
    }
}
