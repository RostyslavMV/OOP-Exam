using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitItems();
            DataContext = this;
        }

        public Collection<MenuItem> MenuItems { get; } = new Collection<MenuItem>();

        void InitItems()
        {
            MenuItems.Add(new MenuItem("Ввід даних", typeof(UserControl), "About"));
            MenuItems.Add(new MenuItem("Циклічний список", typeof(UserControl), "About"));
            MenuItems.Add(new MenuItem("Червоно-чорне дерево", typeof(UserControl), "About"));
            MenuItems.Add(new MenuItem("B+ Дерево", typeof(UserControl), "About"));
            MenuItems.Add(new MenuItem("Хеш, метод ланцюжків", typeof(UserControl), "About"));
            MenuItems.Add(new MenuItem("Хеш, квадратичне зондування", typeof(UserControl), "About"));
            MenuItems.Add(new MenuItem("Алгоритми сортування", typeof(UserControl), "About"));
            MenuItems.Add(new MenuItem("Контейнер", typeof(UserControl), "About"));
            MenuItems.Add(new MenuItem("Множина", typeof(UserControl), "About"));
        }

        Collection<int> data = new Collection<int>();
        private int _percentDone;

        int percentDone
        {
            get => _percentDone;
            set
            {
                _percentDone = value;
                Dispatcher.Invoke(() =>
                { pb.Value = value; });
            }
        }

        bool run = false;

        void generateCollection()
        {
            int count = 1000000;
            int percent = count / 100;
            Random random = new Random();
            int i;
            for (i = 1; i < 1000000; i++)
            {
                if (i % percent == 0)
                {
                    if (!run) return;
                    Thread.Sleep(100);
                    percentDone = i * 100 / count;
                }
                data.Add(random.Next());
            }
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            percentDone = 0;
            run = true;
            DateTime start = DateTime.Now;
            await Task.Run(() => generateCollection());
            Debug.WriteLine(DateTime.Now - start);
            run = false;
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            run = false;
        }
    }
}
