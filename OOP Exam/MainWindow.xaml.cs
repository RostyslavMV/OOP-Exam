using OOP_Exam.BPlusTree;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public static MainWindow mainWindow { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            InitItems();
            DataContext = this;
            progressBar = pb;
            Random random = new Random();
            for (int i = 0; i < 10000; i++)
            {
                var newNumber = random.Next(0, 10000000);
                collectionForSort.Add(newNumber);
                sortedCollection.Add(newNumber);
            }
            mainWindow = this;
        }

        public static Collection<MenuItem> MenuItems { get; } = new Collection<MenuItem>();
        public static Collection<CloudStorage> CloudStorages { get; } = new Collection<CloudStorage>();

        public SLcircularList<CloudStorage> SLcircularList { get; set; } = new SLcircularList<CloudStorage>();

        public RedBlackTree<CloudStorage> RedBlackTree { get; set; } = new RedBlackTree<CloudStorage>();

        public BPTree<int, CloudStorage> BPTree { get; set; } = new BPTree<int, CloudStorage>();

        public HashTable<int, CloudStorage> chainingHashTable { get; set; } = new SeparateChainingHashTable<int, CloudStorage>();

        public QuadraticHashTable<int, CloudStorage> quadraticHashTable { get; set; } = new QuadraticHashTable<int, CloudStorage>();

        public Collection<int> collectionForSort { get; set; } = new Collection<int>();

        public Collection<int> sortedCollection { get; set; } = new Collection<int>();

        public static ProgressBar progressBar { get; private set; }

        private static string lastMethodName;
        public string LastMethodName
        {
            get => lastMethodName;
            set
            {
                lastMethodName = value;
                OnPropertyChanged();
            }
        }

        private DateTime LastMethodStart { get; set; }

        private string lastMethodTimeText;
        public string LastMethodTimeText
        {
            get => lastMethodTimeText;
            set
            {
                lastMethodTimeText = value;
                OnPropertyChanged();
            }
        }

        public void StartMethod(string menthodName)
        {
            run = true;
            percentDone = 0;
            LastMethodName = menthodName;
            LastMethodStart = DateTime.Now;
        }

        public void EndMethod()
        {
            TimeSpan time = DateTime.Now - LastMethodStart;
            run = false;
            percentDone = 100;
            LastMethodTimeText = ((int)time.TotalMilliseconds).ToString() + "ms";
        }

        void InitItems()
        {
            MenuItems.Add(new MenuItem("Ввід даних", typeof(InputControl), "About.html"));
            MenuItems.Add(new MenuItem("Циклічний список", typeof(CircularListControl), "List.html"));
            MenuItems.Add(new MenuItem("Червоно-чорне дерево", typeof(RedBlackTreeControl), "RB.html"));
            MenuItems.Add(new MenuItem("B+ Дерево", typeof(BPlusTreeControl), "BPlus.html"));
            MenuItems.Add(new MenuItem("Хеш, метод ланцюжків", typeof(ChainingHashControl), "ChainingHash.html"));
            MenuItems.Add(new MenuItem("Хеш, квадратичне зондування", typeof(QuadraticHashControl), "QuadraticHash.html"));
            MenuItems.Add(new MenuItem("Алгоритми сортування", typeof(SortAlgosControl), "SortAlgos.html"));
            MenuItems.Add(new MenuItem("Контейнер", typeof(UserControl), "About"));
            MenuItems.Add(new MenuItem("Множина", typeof(UserControl), "About"));
        }

        Collection<int> data = new Collection<int>();
        private static int _percentDone;

        public static int percentDone
        {
            get => _percentDone;
            set
            {
                _percentDone = value;
                Application.Current.Dispatcher.Invoke(() =>
                { progressBar.Value = value; });
            }
        }

        public bool run = false;

        public event PropertyChangedEventHandler PropertyChanged;

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
                    percentDone = i * 100 / count + 1;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            UIElement control = (UIElement)Activator.CreateInstance((button.DataContext as MenuItem).ControlType);
            CurrentControlBorder.Child = control;
            string curDir = Directory.GetCurrentDirectory();
            var path = "HTML/" + (button.DataContext as MenuItem).About;
            if (System.IO.File.Exists(path))
            {
                Browser.Navigate(String.Format("file:///{0}/" + path, curDir));
            }
            else Browser.Navigate("about:blank");
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
