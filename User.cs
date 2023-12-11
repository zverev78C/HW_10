using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;

namespace HW_10_1
{

    /// <summary>
    /// Базовый класс для менеджера и консультанта 
    /// </summary>
    abstract class User 
    {
        protected static ObservableCollection<Client> Сlients = new ObservableCollection<Client>();


        public static  ReadOnlyObservableCollection<Client> MyPublicClients;


        public static void LoadBase ()
        {
            MyPublicClients = new ReadOnlyObservableCollection<Client>(Сlients);
        }
        

        public virtual string Name { get => Name; }

    }
}
