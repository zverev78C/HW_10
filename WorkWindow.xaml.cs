using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>

    public partial class WorkWindow : Window
    {
        ViewModel vm = new ViewModel();   // экземпляр класса ViewVodel

        public WorkWindow()
        {
            InitializeComponent();
            DataContext = vm;           // данные для View

            if (ViewModel._user.GetType() == typeof(Consultant))   // сокрытие кнопок от консультанта 
            {
                Button_Add.Visibility = Visibility.Hidden;              // кнопка добавить нового клиента
                Button_Save.Visibility = Visibility.Collapsed;          // кнопка сохранить изменения
                GroupSystemInfoClient.Visibility = Visibility.Hidden;   // скрыта область системных данных о клиенте
                GroupContactInfoClient.Visibility = Visibility.Hidden;  // скрыта область пока пустых данных о клиенте
                TBx_SelectedClientLastName.IsReadOnly = true;           // Поле Фамилия достуна только для чтения 
                TBx_SelectedClientFirstName.IsReadOnly = true;          // Поле Имя достуна только для чтения 
                TBx_SelectedClientMiddelName.IsReadOnly = true;         // Поле Отчество достуна только для чтения 
                TBx_SelectedClientPasport.IsReadOnly = true;            // Поле Паспорт достуна только для чтения 
            }
        }

        /// <summary>
        /// Реакция на нажатие кнопки Выход  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow(); // Создание экземпляра окна приветсвия 
            MW.Show();                        // открытие окна приветсвия 
            Close();                          // закрытие текущего окна 
        }
        /// <summary>
        /// реакция на нажатие кнопки Добавить    
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            NewClient newClient = new NewClient();  // создание окна новый клиент
            newClient.Show();                       // открытие созданого окна  
        }
        /// <summary>
        /// Возможность такскать окно по экрану 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        #region Методы добавляющие служебную информацию к клиенту 

        private void TBx_SelectedClientLastName_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            //vm.ChangeAnyField("Фамилия", "Изменение", TBx_SelectedClientLastName.Text);
        }
        private void TBx_SelectedClientFirstName_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            //vm.ChangeAnyField("Имя", "Изменение", TBx_SelectedClientFirstName.Text);
        }
        private void TBx_SelectedClientMiddelName_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            //vm.ChangeAnyField("Отчество", "Изменение", TBx_SelectedClientMiddelName.Text);
        }
        private void TBx_SelectedClientPhone_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            //FieldChanged("Телефон", TBx_SelectedClientPhone.Text, TBx_SelectedClientPhone);
        }
        private void TBx_SelectedClientPasport_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            //FieldChanged("Паспорт", TBx_SelectedClientPasport.Text, TBx_SelectedClientPasport);
        }

        #endregion

        private void FieldChanged(string nameField, string newValue, System.Windows.Controls.TextBox name)
        {
            string result = ViewModel.InsertNumber(newValue);
            if (result == "-1")
            {
                name.Text = "номер должен состоять только из цифр.";
                name.Foreground = Brushes.Red;
                name.BorderBrush = Brushes.Red;
            }
            else if (result == "-2")
            {
                name.Text = "номер должен содержать десять цифр.";
                name.Foreground = Brushes.Red;
                name.BorderBrush = Brushes.Red;
            }
            else
            {
                name.Foreground = Brushes.Black;
                name.BorderBrush = Brushes.Silver;
                name.Text = result;
                vm.ChangeAnyField(nameField, "Изменение", result);
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }

    }
}

