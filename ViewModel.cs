using System;
using System.Collections.ObjectModel;

namespace HW_10_1
{
    class ViewModel
    {
        public static User user;
        /// <summary>
        /// переменная количества клиентов списке 
        /// </summary>
        private static int amountClients;
        /// <summary>
        /// Коллекция клиентов для просмотра    
        /// </summary>
        private static ObservableCollection<Client> clients = new ObservableCollection<Client>();
        /// <summary>
        /// свойство к которому биндится вьюшка для передачи индекса
        /// </summary>
        private static int selectedIndex;
        /// <summary>
        /// метод запроса клиента для отображения во View
        /// </summary>
        /// <param name="i"></param>
        /// <summary>
        /// Переменная для отслеживания выделения клиента в списке ListView 
        /// </summary>
        private Client _selectedClient;


        /// <summary>
        /// Коллекция клиентов для просмотра   
        /// </summary>
        public static ObservableCollection<Client> BaseClients
        {
            get { return clients; }
            set { clients = value; }
        }
        /// <summary>
        /// индекс клиента в коллекции короткой инфо
        /// </summary>
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; GetSelectedClient(value); } // ViewVodel узнает о View 
        }
        /// <summary>
        /// Выбраный в окне клиент 
        /// </summary>
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value; }
        }


        #region Внешние Методы ViewModel 

        /// <summary>
        /// первый метод после выбора уровня доступа 
        /// </summary>
        /// <param name="accessLevel"></param>
        public ViewModel()
        {
            amountClients = user.Start();   // команда загрузить базу данных в Репозиторий 
            GetBaseClients();               // заполняем базу краткой инфо о клиентах
        }
        /// <summary>
        /// Метод добавления нового клиента в базу
        /// </summary>
        /// <param name="args"></param>
        public void NewClientShowWindow(params string[] args)
        {
            Client concretClient = user.NewClient(args);
            amountClients++;
            BaseClients.Add(concretClient);
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
            if (changeField == "Фамилия") { SelectedClient.LastName = newValue; BaseClients[SelectedIndex].LastName = newValue; }
            if (changeField == "Имя") { SelectedClient.FirstName = newValue; }
            if (changeField == "Отчество") { SelectedClient.MiddelName = newValue; }
            if (changeField == "Телефон") { SelectedClient.Phone = newValue; BaseClients[SelectedIndex].Phone = newValue; }
            if (changeField == "Паспорт") { SelectedClient.Pasport = newValue; }

            SelectedClient.DateTimeLastChenging = DateTime.Now.ToString();
            SelectedClient.LastChenger = user.Name;   //берет значение поля класса 
            SelectedClient.LastChengedField = changeField;
            SelectedClient.LastChengedType = typeChenge;

            user.ChangeAnyField(SelectedClient, SelectedIndex);
            SaveClient();
        }

        internal void SaveClient()
        {
            user.SaveClient();
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

        /// <summary>
        /// Внутренний метод загружающий отслеживаемыю коллексцию 
        /// </summary>
        private void GetBaseClients()
        {
            for (int i = 0; i < amountClients; i++)
            {
                BaseClients.Add(user.GetClient(i));
            }
        }
        /// <summary>
        /// Метод обращается к классу согласно допуска для получения клиента 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private Client GetClient(int i)
        {
            Client client = user.GetClient(i);

            return client;
        }
        /// <summary>
        /// Метод заполняет переменную SelectedClient  
        /// </summary>
        /// <param name="i"></param>
        private void GetSelectedClient(int i)
        {
            if (SelectedIndex != -1)
            { SelectedClient = GetClient(i); }
        }

        #endregion
    }
}
