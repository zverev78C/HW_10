using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HW_10_1
{
    /// <summary>
    /// Логика взаимодействия для NewClient.xaml
    /// </summary>
    public partial class NewClient : Window
    {
        ViewModel vm = new ViewModel();

        public NewClient()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Закрытие окна отмена операции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// меотд передачи новых данных в модуль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Phone1.Text) && !string.IsNullOrEmpty(Pasport1.Text))
            {
                vm.NewClientShowWindow(LastName1.Text, FirstName1.Text, FatherName1.Text, Phone1.Text, Pasport1.Text);
                Close();
            }
        }

        /// <summary>
        /// Метод проверки коректности ввода номера телефона 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Phone1_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            string result = ViewModel.InsertNumber(Phone1.Text);
            if (result == "-1")
            {
                Phone1.Text = "номер должен состоять только из цифр.";
                Phone1.Foreground = Brushes.Red;
                Phone1.BorderBrush = Brushes.Red;
            }
            else if (result == "-2")
            {
                Phone1.Text = "номер должен содержать десять цифр.";
                Phone1.Foreground = Brushes.Red;
                Phone1.BorderBrush = Brushes.Red;
            }
            else
            {
                Phone1.Foreground = Brushes.Black;
                Phone1.BorderBrush = Brushes.Silver;
                Phone1.Text = result;
            }
        }
        /// <summary>
        /// Метод проверки коректности ввода номера паспорта  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pasport1_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            string result = ViewModel.InsertNumber(Pasport1.Text);
            if (result == "-1")
            {
                Pasport1.Text = "номер должен состоять только из цифр.";
                Pasport1.Foreground = Brushes.Red;
                Pasport1.BorderBrush = Brushes.Red;
            }
            else if (result == "-2")
            {
                Pasport1.Text = "номер должен содержать десять цифр.";
                Pasport1.Foreground = Brushes.Red;
                Pasport1.BorderBrush = Brushes.Red;
            }
            else
            {
                Pasport1.Foreground = Brushes.Black;
                Pasport1.BorderBrush = Brushes.Silver;
                Pasport1.Text = result;
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }

    }
}

