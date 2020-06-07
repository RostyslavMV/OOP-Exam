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
            MainWindow.percentDone = 0;
            DateTime start = DateTime.Now;
            int count = MainWindow.CloudStorages.Count;
            int current = 1;
            await Task.Run(() =>
            {
                foreach (var storage in MainWindow.CloudStorages)
                {
                    MainWindow.SLcircularList.AddToEnd(storage);
                    MainWindow.percentDone = current * 100 / count;
                    current++;
                }
            });
            TimeSpan time = DateTime.Now - start;
            AddCollectionTime.Text = ((int)time.TotalMilliseconds).ToString() + "ms";
            MainWindow.percentDone = 100;
        }
    }
}
