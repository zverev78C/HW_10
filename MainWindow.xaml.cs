﻿using System;
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
        ViewModel Vm = new ViewModel();   // экземпляр класса ViewVodel
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Choice_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (Choice.SelectedIndex == 2) { Environment.Exit(0); }
            Vm.UserSetup(Choice.SelectedIndex);

            WorkWindow workWindow = new WorkWindow();                 // создание экземпляра рабочего окна программы
            workWindow.vm = Vm;
            workWindow.Show();                                        // открытие окна
            Close();
        }

    }
}
