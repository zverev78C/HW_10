using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json.Linq;

namespace HW_10_1
{
    class ViewModel
    {
        /// <summary>
        /// устанавливает уровень доступа к данным через класс пользователя
        /// </summary>
        static IUserInterface _user;
        /// <summary>
        /// устанваливает сериализатор для наполнения модели 
        /// </summary>
        static ILoadSave _serialType;
        public static void UserSetup(int value)
        {           
            _user = ProgrammVlidator.GetType(value);  // запрос экземпляра класса для _user. 
            _serialType = ProgrammVlidator.GetSerial(0); // запрос на класс сериализатор сейчас ноль потому что пока реализован только XML

            _user.Load(_serialType);
            User.LoadBase();
        }

        public ViewModel()
        {

        }

        /// <summary>
        /// Коллекция клиентов для просмотра   
        /// </summary>
        public ReadOnlyObservableCollection<Client> VmClients { get; set; } = User.MyPublicClients;


        /// <summary>
        /// переменная количества клиентов списке 
        /// </summary>
        private static int amountClients;
        /// <summary>
        /// индекс клиента в коллекции короткой инфо
        /// </summary>
       public int SelectedIndex { get; set; } //{ selectedIndex = value; GetSelectedClient(value); } // ViewVodel узнает о View 


        
        
        /// <summary>
        /// Выбраный в окне клиент 
        /// </summary>
        public Client SelectedClient { get; set; }


        #region Конструкторы 



        #endregion

        #region Внешние Методы ViewModel 

        /// <summary>
        /// первый метод после выбора уровня доступа 
        /// </summary>
        /// <param name="accessLevel"></param>
        /// <summary>
        /// Метод добавления нового клиента в базу
        /// </summary>
        /// <param name="args"></param>
        public void NewClientShowWindow(params string[] args)
        {
            Client concretClient = _user.NewClient(args);
            amountClients++;
            //BaseClients.Add(concretClient);
            SaveClient();
        }
        /// <summary>
        /// Метод добавления системных полей в клиента
        /// </summary>
        /// <param name="concretClient">клиент</param>
        /// <param name="changeField">изменяемое поле</param>
        /// <param name="typeChenge">тип изменения</param>
        public void ChangeAnyField(string changeField, string typeChenge, string newValue)
        {
           // if (changeField == "Фамилия") { SelectedClient.LastName = newValue; BaseClients[SelectedIndex].LastName = newValue; }
            if (changeField == "Имя") { SelectedClient.FirstName = newValue; }
            if (changeField == "Отчество") { SelectedClient.MiddelName = newValue; }
           // if (changeField == "Телефон") { SelectedClient.Phone = newValue; BaseClients[SelectedIndex].Phone = newValue; }
            if (changeField == "Паспорт") { SelectedClient.Pasport = newValue; }

            SelectedClient.DateTimeLastChenging = DateTime.Now.ToString();
            SelectedClient.LastChenger = _user.Name;   //берет значение поля класса 
            SelectedClient.LastChengedField = changeField;
            SelectedClient.LastChengedType = typeChenge;

            _user.ChangeAnyField(SelectedClient, SelectedIndex);
            SaveClient();
        }

        internal void SaveClient()
        {
            _user.SaveClient();
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

        #endregion


        #region Внутренние методы ViewVodel 



        #endregion
    }
}
