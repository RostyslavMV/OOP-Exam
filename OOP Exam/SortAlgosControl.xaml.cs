using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OOP_Exam
{
    /// <summary>
    /// Interaction logic for SortAlgosControl.xaml
    /// </summary>
    public partial class SortAlgosControl : UserControl
    {
        public SortAlgosControl()
        {
            InitializeComponent();
            DataGrid.ItemsSource = MainWindow.mainWindow.sortedCollection;
        }

        private async void ResetCollection_ClickAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            int count = MainWindow.mainWindow.collectionForSort.Count;
            int current = 1;
            MainWindow.mainWindow.sortedCollection = new Collection<int>();
            //DataGrid.BeginInit();
            MainWindow.mainWindow.StartMethod("Перепризначення списку для сортування");
            await Task.Run(() =>
            {
                foreach (var element in MainWindow.mainWindow.collectionForSort)
                {
                    MainWindow.mainWindow.sortedCollection.Add(element);
                    MainWindow.percentDone = current * 100 / count;
                    current++;
                    if (!MainWindow.mainWindow.run) return;
                }
            });
            MainWindow.mainWindow.EndMethod();
            //DataGrid.EndInit();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = MainWindow.mainWindow.sortedCollection;
        }

        private async void InsertSort_ClickAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            //DataGrid.BeginInit();
            MainWindow.mainWindow.StartMethod("Insertion sort 10000 елементів");
            await Task.Run(() => InsertionSort<int>.Sort(MainWindow.mainWindow.sortedCollection));
            MainWindow.mainWindow.EndMethod();
            //DataGrid.EndInit();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = MainWindow.mainWindow.sortedCollection;
        }

        private async void HeapSort_ClickAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            //DataGrid.BeginInit();
            MainWindow.mainWindow.StartMethod("Heap sort 10000 елементів");
            await Task.Run(() => HeapSort<int>.Sort(MainWindow.mainWindow.sortedCollection));
            MainWindow.mainWindow.EndMethod();
            //DataGrid.EndInit();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = MainWindow.mainWindow.sortedCollection;
        }

        private async void MergeSort_ClickAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            //DataGrid.BeginInit();
            MainWindow.mainWindow.StartMethod("Merge sort 10000 елементів");
            await Task.Run(() => MergeSort<int>.Sort(MainWindow.mainWindow.sortedCollection));
            MainWindow.mainWindow.EndMethod();
            //DataGrid.EndInit();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = MainWindow.mainWindow.sortedCollection;
        }

        private async void RadixSort_ClickAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            //DataGrid.BeginInit();
            MainWindow.mainWindow.StartMethod("Radix sort 10000 елементів");
            await Task.Run(() => OOP_Exam.RadixSort.Sort(MainWindow.mainWindow.sortedCollection));
            MainWindow.mainWindow.EndMethod();
            //DataGrid.EndInit();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = MainWindow.mainWindow.sortedCollection;
        }
    }
}
