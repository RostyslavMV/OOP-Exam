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
    /// Interaction logic for SetControl.xaml
    /// </summary>
    public partial class SetControl : UserControl
    {
        public SetControl()
        {
            InitializeComponent();
            MainWindow.mainWindow.set1 = new Set<CloudStorage>(MainWindow.mainWindow.RedBlackTree);
            MainWindow.mainWindow.set2 = new Set<CloudStorage>(MainWindow.mainWindow.SLcircularList);
            DataGrid1.ItemsSource = MainWindow.mainWindow.set1.ToArray();
            DataGrid2.ItemsSource = MainWindow.mainWindow.set2.ToArray();
        }

        private async void Union_ClickAsync(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                MainWindow.mainWindow.set1 = new Set<CloudStorage>(MainWindow.mainWindow.RedBlackTree);
            });
            MainWindow.mainWindow.StartMethod("Об'єднання множин");
            await Task.Run(() =>
            {
                MainWindow.mainWindow.set1.UnionWith(MainWindow.mainWindow.set2);
            });
            MainWindow.mainWindow.EndMethod();
            DataGrid3.ItemsSource = null;
            DataGrid3.ItemsSource = MainWindow.mainWindow.set1.ToArray();
        }

        private async void Intersect_ClickAsync(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                MainWindow.mainWindow.set1 = new Set<CloudStorage>(MainWindow.mainWindow.RedBlackTree);
            });
            MainWindow.mainWindow.StartMethod("Перетин множин");
            await Task.Run(() =>
            {
                MainWindow.mainWindow.set1.IntersectWith(MainWindow.mainWindow.set2);
            });
            MainWindow.mainWindow.EndMethod();
            DataGrid3.ItemsSource = null;
            DataGrid3.ItemsSource = MainWindow.mainWindow.set1.ToArray();
        }

        private async void Except_ClickAsync(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                MainWindow.mainWindow.set1 = new Set<CloudStorage>(MainWindow.mainWindow.RedBlackTree);
            });
            MainWindow.mainWindow.StartMethod("Різниця множин червоно-чорного дерева та списку");
            await Task.Run(() =>
            {
                MainWindow.mainWindow.set1.ExceptWith(MainWindow.mainWindow.set2);
            });
            MainWindow.mainWindow.EndMethod();
            DataGrid3.ItemsSource = null;
            DataGrid3.ItemsSource = MainWindow.mainWindow.set1.ToArray();
        }

        private async void SymmetricExcept_ClickAsync(object sender, RoutedEventArgs e)
        {
            await Task.Run(() =>
            {
                MainWindow.mainWindow.set1 = new Set<CloudStorage>(MainWindow.mainWindow.RedBlackTree);
            });         
            MainWindow.mainWindow.StartMethod("Симетрична різниця множин");
            await Task.Run(() =>
            {
                MainWindow.mainWindow.set1.SymmetricExceptWith(MainWindow.mainWindow.set2);
            });
            MainWindow.mainWindow.EndMethod();
            DataGrid3.ItemsSource = null;
            DataGrid3.ItemsSource = MainWindow.mainWindow.set1.ToArray();
        }
    }
}
