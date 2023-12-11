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
            LoadSave = load;  // не забыть обратится в регион "Костыли" и исправить 
        }
        /// <summary>
        /// метод создания нового клиента для менеджера  
        /// </summary>
        /// <param name="args"></param>
        public  void NewClient(params string[] args)
        {
            Client newClient = new Client();
            newClient.ID = Сlients[Сlients.Count - 1].ID + 1;
            newClient.LastName = args[0];
            newClient.FirstName = args[1];
            newClient.MiddelName = args[2];
            newClient.Phone = args[3];
            newClient.Pasport = args[4];
            newClient.DateTimeLastChenging = DateTime.Now.ToString();
            newClient.LastChenger = this.Name;
            newClient.LastChengedField = "Все обязательные поля";
            newClient.LastChengedType = "Создание нового клиента";

            Сlients.Add(newClient);  //добавление нового клиента в список 

            Save(LoadSave);   //  сразу сохранение клиентского списка 
        }
        /// <summary>
        /// Метод сохранения списка клиентов 
        /// </summary>
        /// <param name="save"></param>
        public void Save(ILoadSave save)
        {
            save.Save(Сlients);
        }
        /// <summary>
        /// Метод редактирования клиеннта и сохранения после редактирования
        /// </summary>
        /// <param name="concretClient"></param>
        public  void ChangeAnyField(Client concretClient)
        {
            for (int i = 0; i < Сlients.Count; i++)
            {
                if (Сlients[i].ID == concretClient.ID)
                {
                    Сlients[i].LastName = concretClient.LastName;
                    Сlients[i].FirstName = concretClient.FirstName;
                    Сlients[i].MiddelName = concretClient.MiddelName;
                    Сlients[i].Phone = concretClient.Phone;
                    Сlients[i].Pasport = concretClient.Pasport;
                    Сlients[i].DateTimeLastChenging = concretClient.DateTimeLastChenging;
                    Сlients[i].LastChenger = concretClient.LastChenger;
                    Сlients[i].LastChengedField = concretClient.LastChengedField;
                    Сlients[i].LastChengedType = concretClient.LastChengedType;
                    break;
                }
            }
            Save(LoadSave);
        }

       




        #region Костыли которые потом надо убрать
        ILoadSave LoadSave { get; set; }

        #endregion




    }
}
