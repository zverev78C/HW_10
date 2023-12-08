namespace HW_10_1
{
    interface ILoadSave
    {
        /// <summary>
        /// Метод сохранения списка клиентов в файл  
        /// </summary>
        void Save();

        /// <summary>
        /// Метод загрузки данных в базу из файла  
        /// </summary>
        void Load();
       
    }
}
