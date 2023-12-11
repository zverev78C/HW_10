using System.Collections.ObjectModel;
using System.Windows;

namespace HW_10_1
{
    /// <summary>
    /// Класс консультант  
    /// </summary>
    class Consultant : User, IUserInterface
    {
        /// <summary>
        /// Имя класса на кирилице для сохранения в логи 
        /// </summary>
        public override string Name { get => "Консультант"; }
        /// <summary>
        /// метод загрузки списка клиентов в коллекцию 
        /// </summary>
        /// <param name="load"></param>
        public void Load(ILoadSave load)
        {
            Сlients = load.Load();
            LoadSave = load;  // не забыть обратится в регион "Костыли" 
        }
        /// <summary>
        /// Метод сохранения списка клиентов 
        /// </summary>
        /// <param name="save"></param>
        public void Save(ILoadSave save)
        {
            save.Save (Сlients);
        }





        public  void ChangeAnyField(Client concretClient, int indexClient)
        {
            //if (concretClient.LastChengedField == "Телефон")
            //{
            //    Client tempClient = rep.GetClientInfo(indexClient);
            //    tempClient.Phone = concretClient.Phone;
            //    tempClient.DateTimeLastChenging = concretClient.DateTimeLastChenging;
            //    tempClient.LastChenger = concretClient.LastChenger;
            //    tempClient.LastChengedField = concretClient.LastChengedField;
            //    tempClient.LastChengedType = concretClient.LastChengedType;
            //    rep.ChangeClient(tempClient, indexClient);
            //}
        }

        public ObservableCollection<Client> GetAllClients()
        {
            throw new System.NotImplementedException();
        }

        public int Start()
        {
            throw new System.NotImplementedException();
        }

        public void NewClient(params string[] args)
        {
            MessageBox.Show("У вас нет права создавать нового клиента");
        }

        #region Костыли которые потом надо убрать
        ILoadSave LoadSave { get; set; }

        #endregion
    }
}
