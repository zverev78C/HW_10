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

        






        private static int CountClients;

        public Meneger() { rep.CountsClientHandler = GetCount; }
        //public Meneger(IRepos repos) 
        //{
        //   // rep = repos;
        //    rep.CountsClientHandler = GetCount;
        //}
        


        public static void GetCount(int count)
        {
            CountClients = count;
        }


        #region Методы для работы с репозиторием 

        public ObservableCollection<Client> GetAllClients()
        {
            ObservableCollection<Client> tList = new ObservableCollection<Client>();
            for (int i = 0; i < CountClients; i++)
            {
                Client tClient = new Client();
                tClient = rep.GetClient();
                tList.Add(tClient);
            }
            return tList;
        }




        /// <summary>
        /// метод возвращающий клиента согласно допуска для View
        /// </summary>
        /// <param name="i">индекс клиента</param>
        /// <returns></returns>
        public  Client GetClient(int i)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// метод создания нового клиента для менеджера  
        /// </summary>
        /// <param name="args"></param>
        public  Client NewClient(params string[] args)
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

           // rep.AddClient(newClient); // одновременно с возвратом клиента в отслеживаемую коллекцию добавляем в основную для сохранения
            return newClient;
        }

        public  void ChangeAnyField(Client concretClient, int indexClient)
        {
            //rep.ChangeClient(concretClient, indexClient);
        }

        public int Start()
        {
            throw new NotImplementedException();
        }

        public void SaveClient()
        {
            throw new NotImplementedException();
        }

        



        #endregion


    }
}
