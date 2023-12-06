﻿namespace HW_10_1
{
    abstract class User : IUserInterface
    {
        protected Repository rep = new Repository(); // репозиторий 

        public virtual string Name { get => Name; }

        ///<summary>
        ///   метод запуска приложения  
        ///</summary>
        ///<returns>количество клиентов в списке</returns>
        public virtual int Start()
        {
            LoadSave.LoadList();
            int amountClients = rep.GetListCount();
            return amountClients;
        }
        /// <summary>
        /// Метод сохранения списка клиентов 
        /// </summary>
        public virtual void SaveClient()
        {
            LoadSave.SaveList();
        }
        public virtual Client NewClient(params string[] args)
        {
            Client newClient = new Client();
            return newClient;
        }


        #region Абстрактные Методы  для последующего переопределения 

        public abstract Client GetClient(int i);
        public abstract void ChangeAnyField(Client concretClient, int indexClient);

        #endregion
    }
}