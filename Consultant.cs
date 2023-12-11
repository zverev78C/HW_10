using System.Collections.ObjectModel;

namespace HW_10_1
{
    /// <summary>
    /// Класс консультант который знает о репозитории и обращется к нему в пределах уровня доступа 
    /// </summary>
    class Consultant : User, IUserInterface
    {
        /// <summary>
        /// Имя класса на кирилице для сохранения в логи 
        /// </summary>
        public override string Name { get => "Консультант"; }

        public void Load(ILoadSave load)
        {
            Сlients = load.Load();
        }










        #region Методы  запросов в репазиторий



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

        public Client NewClient(params string[] args)
        {
            throw new System.NotImplementedException();
        }

        public void SaveClient()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
