using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HW_10_1
{
    /// <summary>
    /// Интерфейс загрузки и сохранения списка в файл 
    /// </summary>
    interface ILoadSave
    {
        /// <summary>
        /// Метод сохранения списка клиентов в файл  
        /// </summary>
        void Save(ObservableCollection<Client> clients);

        /// <summary>
        /// Метод загрузки данных в базу из файла  
        /// </summary>
        ObservableCollection<Client> Load();
       
    }
}
