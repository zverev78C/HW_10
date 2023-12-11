using System.Collections.Generic;
using System.Windows;

namespace HW_10_1
{

    delegate void CountsClient (int count); 

    /// <summary>
    /// Класс который знает о базе данных и умеет к ней обращаться
    /// </summary>
    class Repository : IRepos
    {
        /// <summary>
        /// Список клиентов общий
        /// </summary>
        private static List<Client> BasicListClients { get; set; }
        public  CountsClient CountsClientHandler { get; set; }
        
        public Repository ()
        {
            BasicListClients =  Load(new XmlLoadSave());
            
        }


        
        public void Save (ILoadSave save)
        {
            save.Save(BasicListClients);
        }
        public Client GetClient()
        {
            CountsClientHandler(BasicListClients.Count);  // выдает исключение отсутствие экземпляра  
            throw new System.NotImplementedException();
        }



        #region Методы для приема и выдачи инфо (инкапсуляция)

        /// <summary>
        /// Стартовый метод Для начала программы 
        /// </summary>
        /// <returns>Возврашает количество клиентов в базе</returns>
        public int GetListCount()
        {
            return BasicListClients.Count;  // возвращает общее количество клиентов в базе 
        }

        /// <summary>
        /// Возвращает конкретного клиента с индексом i
        /// </summary>
        /// <param name="i">индекс клиента в базе</param>
        /// <returns>клиент</returns>
        public Client GetClientInfo(int i)
        {
            Client client = new Client   // Создается новый экземпляр клиента что бы консультант не менял поля под себя в основной базе данных 
            {
                ID = BasicListClients[i].ID,
                LastName = BasicListClients[i].LastName,
                FirstName = BasicListClients[i].FirstName,
                MiddelName = BasicListClients[i].MiddelName,
                Phone = BasicListClients[i].Phone,
                Pasport = BasicListClients[i].Pasport,
                DateTimeLastChenging = BasicListClients[i].DateTimeLastChenging,
                LastChenger = BasicListClients[i].LastChenger,
                LastChengedField = BasicListClients[i].LastChengedField,
                LastChengedType = BasicListClients[i].LastChengedType
            };
            return client;
        }

        /// <summary>
        /// Добавляет нового клиента в список клиентов 
        /// </summary>
        /// <param name="newClient"></param>
        public void AddClient(Client newClient)
        {
            newClient.ID = BasicListClients.Count ==0 ? 1:  BasicListClients[BasicListClients.Count-1].ID + 1; // присвоение ID новому клиенту 
            BasicListClients.Add(newClient); // добавление нового клиента в основную базу данных  
        }


        internal void ChangeClient(Client concretClient, int indexClient)
        {
           // BasicListClients[indexClient] = concretClient;


            for (int i = 0; i < BasicListClients.Count; i++)
            {
                if (concretClient.ID == BasicListClients[i].ID)
                {
                    BasicListClients[i] = concretClient;
                    break;
                }
            }
        }

        

        #endregion

    }
}
