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

namespace HW_10_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие выбор поля в ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cb1_Choose_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (Choose.SelectedIndex)
            {
                case 0: { ViewModel.user = new Meneger(); break; }
                case 1: { ViewModel.user = new Consultant(); break; }   // 
                case 2: { Environment.Exit(0); break; }                 // выход из программы
            }
            WorkWindow workWindow = new WorkWindow();                 // создание экземпляра рабочего окна программы
            workWindow.Show();                                        // открытие окна
            Close();                                                  // закрытие текущего окна
        }
    }
}
