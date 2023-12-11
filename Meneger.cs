using System;
using System.Collections.ObjectModel;

namespace HW_10_1
{
    /// <summary>
    /// Менеджер как класс   
    /// </summary>
    class Meneger : User, IUserInterface
    {
        /// <summary>
        /// Имя класса на кирилице для сохранения в логи 
        /// </summary>
        public override string Name { get => "Менеджер"; }
        /// <summary>
        /// метод загрузки списка клиентов в коллекцию 
        /// </summary>
        /// <param name="load"></param>
        public void Load(ILoadSave load)
        {
            Сlients = load.Load();
        }
        /// <summary>
        /// метод создания нового клиента для менеджера  
        /// </summary>
        /// <param name="args"></param>
        public  void NewClient(params string[] args)
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

            Сlients.Add(newClient);
            
        }






        public  void ChangeAnyField(Client concretClient, int indexClient)
        {
            throw new NotImplementedException();
        }

        public int Start()
        {
            throw new NotImplementedException();
        }

        public void SaveClient()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// метод возвращающий клиента согласно допуска для View
        /// </summary>
        /// <param name="i">индекс клиента</param>
        /// <returns></returns>
        public Client GetClient(int i)
        {
            throw new NotImplementedException();
        }



        


    }
}
