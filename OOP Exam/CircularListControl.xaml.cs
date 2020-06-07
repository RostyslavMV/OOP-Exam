using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            List.ItemsSource = MainWindow.mainWindow.SLcircularList;
        }

        private async void AddCollection_ClickAsync(object sender, RoutedEventArgs e)
        {
            int count = MainWindow.CloudStorages.Count;
            int current = 1;
            MainWindow.mainWindow.SLcircularList = new SLcircularList<CloudStorage>();
            List.BeginInit();
            MainWindow.mainWindow.StartMethod("Циклічний список, вставка елементів з поточних даних");
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
            List.EndInit();
            List.ItemsSource = null;
            List.ItemsSource = MainWindow.mainWindow.SLcircularList;
        }

        private void ClearTextBoxes()
        {
            NewPersonName.Clear();
            NewCompanyName.Clear();
            NewCatalogName.Clear();
            SearchResult.Text = "";
        }

        private async void AddButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            string personName = NewPersonName.Text;
            string providerName = NewCompanyName.Text;
            string catalogName = NewCatalogName.Text;
            List.BeginInit();
            MainWindow.mainWindow.StartMethod("Циклічний список, вставка елемента");
            await Task.Run(() =>
            {
                Dispatcher.Invoke(() =>
                {
                    MainWindow.mainWindow.SLcircularList.AddToEnd(new CloudStorage(personName, providerName, catalogName));
                });
            });
            MainWindow.mainWindow.EndMethod();
            List.EndInit();
            ClearTextBoxes();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
        }

        private async void SearchButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            string personName = NewPersonName.Text;
            string providerName = NewCompanyName.Text;
            string catalogName = NewCatalogName.Text;
            MainWindow.mainWindow.StartMethod("Циклічний список, пошук елемента");
            await Task.Run(() =>
            {
                if (MainWindow.mainWindow.SLcircularList.Search(new CloudStorage(personName, providerName, catalogName)) != null)
                {
                    Dispatcher.Invoke(()=> SearchResult.Text = "Знайдено");
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
            MainWindow.mainWindow.StartMethod("Циклічний список, видалення елемента");
            List.BeginInit();
            MainWindow.mainWindow.StartMethod("Циклічний список, вставка елемента");
            await Task.Run(() =>
            {
                Dispatcher.Invoke(() =>
                {
                    MainWindow.mainWindow.SLcircularList.Remove(new CloudStorage(personName, providerName, catalogName));
                });
            });
            MainWindow.mainWindow.EndMethod();
            List.EndInit();
            ClearTextBoxes();
        }
    }
}
