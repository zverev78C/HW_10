﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json.Linq;

namespace HW_10_1
{
    class ViewModel
    {
        /// <summary>
        /// устанавливает уровень доступа к данным через класс пользователя
        /// </summary>
        public static IUserInterface _user;
        /// <summary>
        /// устанваливает сериализатор для наполнения модели 
        /// </summary>
        static ILoadSave _serialType;
        /// <summary>
        /// метод определяющий уровень доступа и сериализатор, 
        /// так же загружает основную и пробрасывает в отслеживаемую коллекции данные 
        /// </summary>
        /// <param name="value"></param>
        public  void UserSetup(int value)
        {
            _user = ProgrammVlidator.GetType(value);  // запрос экземпляра класса для _user. 
            _serialType = ProgrammVlidator.GetSerial(0); // запрос на класс сериализатор сейчас ноль потому что пока реализован только XML

            _user.Load(_serialType); // определяется сериализатор и загружается основная коллекция
            VmClients = new ReadOnlyObservableCollection<Client>(User.Сlients);
            //User.LoadBase(); // привязывается отслеживаемая коллекция
        }
        /// <summary>
        /// Коллекция клиентов для просмотра   
        /// </summary>
        public ReadOnlyObservableCollection<Client> VmClients { get; set; }





        private Client _selectedClient;
        /// <summary>
        /// Выбраный в окне клиент 
        /// </summary>
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                SelectedClient.ChangedProp += A => ChangeAnyFieldLoger(A);
            }
        }
        /// <summary>
        /// Метод добавления нового клиента в базу
        /// </summary>
        /// <param name="args"></param>
        public void NewClientShowWindow(params string[] args)
        {
            _user.NewClient(args);
        }

        public void ChangeAnyFieldLoger(string prop)
        {
            SelectedClient.DateTimeLastChenging = DateTime.Now.ToString();
            SelectedClient.LastChenger = _user.Name;   //берет значение поля класса 
            MessageBox.Show(prop);
            SelectedClient.LastChengedField = PropName[prop];
            SelectedClient.LastChengedType = "Редактирование";
            _user.ChangeAnyField(SelectedClient);
        }

        private Dictionary<string, string> PropName = new Dictionary<string, string>()
        {
            {"LastName", "Фамилия" },
            {"FirstName", "Имя" },
            {"MiddelName", "Отчество" },
            {"Phone", "Номер телефона" },
            {"Pasport", "Номер паспорта" },
        };

        /// <summary>
        /// Метод добавления системных полей в клиента
        /// </summary>
        /// <param name="concretClient">клиент</param>
        /// <param name="changeField">изменяемое поле</param>
        /// <param name="typeChenge">тип изменения</param>
        public void ChangeAnyField(string changeField, string typeChenge, string newValue)
        {
            //if (changeField == "Фамилия") { SelectedClient.LastName = newValue; }
            //if (changeField == "Имя") { SelectedClient.FirstName = newValue; }
            //if (changeField == "Отчество") { SelectedClient.MiddelName = newValue; }
            //if (changeField == "Телефон") { SelectedClient.Phone = newValue; }
            //if (changeField == "Паспорт") { SelectedClient.Pasport = newValue; }

            //SelectedClient.DateTimeLastChenging = DateTime.Now.ToString();
            //SelectedClient.LastChenger = _user.Name;   //берет значение поля класса 
            //SelectedClient.LastChengedField = changeField;
            //SelectedClient.LastChengedType = typeChenge;

            //_user.ChangeAnyField(SelectedClient);

        }


        /// <summary>
        /// метод контроля вводимых данных для номера телефона или паспорта  
        /// </summary>
        /// <param name="changedValue">введеная строка</param>
        /// <returns></returns>
        internal static string InsertNumber(string changedValue)
        {
            if (changedValue.Length == 10)
            {
                try
                {
                    double ControlNumbers = Convert.ToDouble(changedValue);
                }
                catch
                {
                    changedValue = "-1";
                }
            }
            else
            {
                changedValue = "-2";
            }
            return changedValue;
        }



    }
}
