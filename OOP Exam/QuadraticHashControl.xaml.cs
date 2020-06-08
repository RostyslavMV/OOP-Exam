using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OOP_Exam
{
    /// <summary>
    /// Interaction logic for QuadraticHashControl.xaml
    /// </summary>
    public partial class QuadraticHashControl : UserControl
    {
        public QuadraticHashControl()
        {
            InitializeComponent();
            DataGrid.ItemsSource = MainWindow.mainWindow.quadraticHashTable.ToCollection();
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

        private async void AddCollection_ClickAsync(object sender, RoutedEventArgs e)
        {
            int count = MainWindow.CloudStorages.Count;
            int current = 1;
            MainWindow.mainWindow.quadraticHashTable = new QuadraticHashTable<int, CloudStorage>();
            DataGrid.BeginInit();
            MainWindow.mainWindow.StartMethod("Хеш таблиця (метод ланцюжків), вставка елементів з поточних даних");
            await Task.Run(() =>
            {
                foreach (var storage in MainWindow.CloudStorages)
                {
                    MainWindow.mainWindow.quadraticHashTable.Add(current, storage);
                    MainWindow.percentDone = current * 100 / count;
                    current++;
                    if (!MainWindow.mainWindow.run) return;
                }
            });
            MainWindow.mainWindow.EndMethod();
            DataGrid.EndInit();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = MainWindow.mainWindow.quadraticHashTable.ToCollection();
        }

        private async void AddButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            string personName = NewPersonName.Text;
            string providerName = NewCompanyName.Text;
            string catalogName = NewCatalogName.Text;
            int key;
            if (!int.TryParse(KeyBox.Text, out key))
            {
                key = DataGrid.Items.Count + 1;
            }
            DataGrid.BeginInit();
            MainWindow.mainWindow.StartMethod("Хеш таблиця (метод ланцюжків), вставка елемента");
            await Task.Run(() =>
            {
                // Dispatcher.Invoke(() =>
                // {

                MainWindow.mainWindow.quadraticHashTable.Add(key, new CloudStorage(personName, providerName, catalogName));
                //}
                // }
                // );
            });
            MainWindow.mainWindow.EndMethod();
            DataGrid.EndInit();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = MainWindow.mainWindow.quadraticHashTable.ToCollection();
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
            MainWindow.mainWindow.StartMethod("Хеш таблиця (метод ланцюжків), пошук елемента");
            await Task.Run(() =>
            {
                CloudStorage resValue = MainWindow.mainWindow.quadraticHashTable.Get(key);
                if (resValue != null)
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
            MainWindow.mainWindow.StartMethod("Хеш таблиця (метод ланцюжків), видалення елемента");
            await Task.Run(() =>
            {
                Dispatcher.Invoke(() => MainWindow.mainWindow.quadraticHashTable.Remove(key));
            });
            MainWindow.mainWindow.EndMethod();
            DataGrid.EndInit();
            DataGrid.ItemsSource = null;
            DataGrid.ItemsSource = MainWindow.mainWindow.quadraticHashTable.ToCollection();
            ClearTextBoxes();
        }
    }
}
