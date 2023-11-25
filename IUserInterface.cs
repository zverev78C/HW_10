namespace HW_10_1
{
    internal interface IUserInterface
    {
        /// <summary>
        /// Переменная задающая имя класса для сохранения имени класса в кирилице
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Метод запуска рабочего окна 
        /// </summary>
        /// <returns>Количество клиентов в главной базе</returns>
        int Start();

        void SaveClient();

        Client GetClient(int i);

        //Client NewClient(params string[] args);
        /// <summary>
        /// Метод частичного изменения клиента 
        /// </summary>
        /// <param name="concretClient"></param>
        /// <param name="indexClient"></param>
        void ChangeAnyField(Client concretClient, int indexClient);
    }
}
