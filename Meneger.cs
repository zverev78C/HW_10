using System;

namespace HW_10_1
{
    /// <summary>
    /// Менеджер как класс   
    /// </summary>
    class Meneger : User
    {
        public override string Name { get => "Менеджер"; }

        #region Методы для работы с репозиторием 

        /// <summary>
        /// метод возвращающий клиента согласно допуска для View
        /// </summary>
        /// <param name="i">индекс клиента</param>
        /// <returns></returns>
        public override Client GetClient(int i)
        {
            return rep.GetClientInfo(i);
        }
        /// <summary>
        /// метод создания нового клиента для менеджера  
        /// </summary>
        /// <param name="args"></param>
        public override Client NewClient(params string[] args)
        {
            Client newClient = new Client();
            newClient.LastName = args[0];
            newClient.FirstName = args[1];
            newClient.MiddelName = args[2];
            newClient.Phone = args[3];
            newClient.Pasport = args[4];
            newClient.DateTimeLastChenging = DateTime.Now.ToString();
            newClient.LastChenger = this.Name;
            newClient.LastChengedField = "Все обязательные поля";
            newClient.LastChengedType = "Создание нового клиента";

            rep.AddClient(newClient); // одновременно с возвратом клиента в отслеживаемую коллекцию добавляем в основную для сохранения
            return newClient;
        }

        public override void ChangeAnyField(Client concretClient, int indexClient)
        {
            rep.ChangeClient(concretClient, indexClient);
        }

        #endregion


    }
}
