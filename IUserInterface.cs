using System.Collections.ObjectModel;

namespace HW_10_1
{
    internal interface IUserInterface
    {
        /// <summary>
        /// Переменная задающая имя класса для сохранения имени класса в кирилице
        /// </summary>
        string Name { get; }

        void Load(ILoadSave load);

        void NewClient(params string[] args);

        void Save(ILoadSave save);

       

       
        /// <summary>
        /// Метод частичного изменения клиента 
        /// </summary>
        /// <param name="concretClient"></param>
        /// <param name="indexClient"></param>
        void ChangeAnyField(Client concretClient, int indexClient);
    }
}
