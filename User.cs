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
        public ObservableCollection<Client> Сlients { get; set; } = new ObservableCollection<Client>();


        public virtual string Name { get => Name; }

        /// <summary>
        /// Метод загрузки данных через интерфейс IloaddSave который определяет как и откуда будут загружены данные  
        /// </summary>
        /// <param name="load"></param>
        /// <returns></returns>
        public  void Load(ILoadSave load)
        {
            Сlients = load.Load();
        }


    }
}
