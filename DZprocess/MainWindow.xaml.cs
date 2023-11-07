using DZprocess.Models;
using System;
using System.Collections.Generic;
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
using System.Windows.Threading;

namespace DZprocess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ProcessRead processRead;
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            processRead = new ProcessRead();
            UpdateProcessList();

        //подключаем таймер для автомотического обновления
            timer = new DispatcherTimer();
            timer.Tick += timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateProcessList();
        }

        //обнавление списка
        private void UpdateProcessList()
        {
            try
            {
                //обновление списка объектов(можно придумать рациональный способ)
                List<ProcessItem> procList = processRead.getCurentProcesses();
                ResultListBox.Items.Clear();
                procList.ForEach(process => ResultListBox.Items.Add(process));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during select object list: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        //получение информации о процессе
        private void Result_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProcessItem selectItem = ResultListBox.SelectedItem as ProcessItem;
            MessageBox.Show(selectItem.ProcessInfo());
        }
        //обнавление списка по клику
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            UpdateProcessList();
        }

        private void AutoRefresh_Click(object sender, RoutedEventArgs e)
        {
            // изменение кнопки
            if (timer.IsEnabled)
            {
                AutoRefresh.Content = "AutoRefresh Disable";
                AutoRefresh.Background = Brushes.Red;
                timer.Stop();
            }
            else 
            {
                AutoRefresh.Content = "AutoRefresh Enable";
                AutoRefresh.Background = Brushes.LightGreen;
                timer.Start();
            }
        }
        //поиск по PID и вывод информации
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var process = processRead.getProcessById(Convert.ToInt32(SearchNumber.Text));
                MessageBox.Show(process.ProcessInfo());
            }
            catch
            {
                MessageBox.Show("Process not found");
            }
        }
    }
}
