using System.Collections.ObjectModel;
using System.Net.Sockets;
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
        /// <summary>
        /// Метод заглушка у консультанта нет прав на добавление клиентов 
        /// </summary>
        /// <param name="args"></param>
        public void NewClient(params string[] args)
        {
            MessageBox.Show("У вас нет права создавать нового клиента");
        }
        /// <summary>
        /// Метод редактирования клиеннта и сохранения после редактирования
        /// </summary>
        /// <param name="concretClient"></param>
        public void ChangeAnyField(Client concretClient)
        {
            if (concretClient.LastChengedField == "Телефон")
            {
                for (int i = 0; i < Сlients.Count; i++)
                {
                    if (Сlients[i].ID == concretClient.ID)
                    {
                        Сlients[i].Phone = concretClient.Phone;
                        Сlients[i].DateTimeLastChenging = concretClient.DateTimeLastChenging;
                        Сlients[i].LastChenger = concretClient.LastChenger;
                        Сlients[i].LastChengedField = concretClient.LastChengedField;
                        Сlients[i].LastChengedType = concretClient.LastChengedType;
                        break;
                    }
                }
                Save(LoadSave);
            }
        }

       

       
      

        #region Костыли которые потом надо убрать

        ILoadSave LoadSave { get; set; }

        #endregion
    }
}
