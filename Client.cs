using System;

namespace HW_10_1
{
    public class Client
    {
        #region поля свойства  

        /// <summary>
        /// Фамилия  
        /// </summary>
        private string lastName;
        /// <summary>
        /// Имя     
        /// </summary>
        private string firstName;
        /// <summary>
        /// Отчество    
        /// </summary>
        private string middelName;
        /// <summary>
        /// Номер телефона  
        /// </summary>
        private string phone;
        /// <summary>
        /// Номер паспорта  
        /// </summary>
        private string pasport;
        /// <summary>
        /// Время последнего изменения  
        /// </summary>
        private DateTime dateTimeLastChenging;
        /// <summary>
        /// Имя последнего кто менял поля   
        /// </summary>
        private string lastChenger;
        /// <summary>
        /// Последнее поле которое меняли   
        /// </summary>
        private string lastChengedField;
        /// <summary>
        /// Тип изменения ( создание или изменение)
        /// </summary>
        private string lastChengedType;



        /// <summary>
        /// Фамилия  
        /// </summary>
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        /// <summary>
        /// Имя     
        /// </summary>
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
        /// <summary>
        /// Отчество    
        /// </summary>
        public string MiddelName
        {
            get { return this.middelName; }
            set { this.middelName = value; }
        }
        /// <summary>
        /// Номер телефона  
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        /// <summary>
        /// Номер паспорта  
        /// </summary>
        public string Pasport
        {
            get { return pasport; }
            set { pasport = value; }
        }
        /// <summary>
        /// Время последнего изменения  
        /// </summary>
        public string DateTimeLastChenging
        {
            get { return this.dateTimeLastChenging.ToString(); }
            set { this.dateTimeLastChenging = Convert.ToDateTime(value); }
        }
        /// <summary>
        /// Имя последнего кто менял поля   
        /// </summary>
        public string LastChenger
        {
            get { return this.lastChenger; }
            set
            {
                this.lastChenger = value;
            }
        }
        /// <summary>
        /// Последнее поле которое меняли   
        /// </summary>
        public string LastChengedField
        {
            get { return this.lastChengedField; }
            set { this.lastChengedField = value; }
        }
        /// <summary>
        /// Тип изменения ( создание или изменение)
        /// </summary>
        public string LastChengedType
        {
            get { return this.lastChengedType; }
            set { this.lastChengedType = value; }
        }

        #endregion

        #region Конструкторы     

        /// <summary>
        /// пустой конструктор для сериализатора
        /// </summary>
        public Client() { }

        public Client(string lastName, string phone)
        {
            LastName = lastName;
            Phone = phone;
        }


        /// <summary>
        /// Конструктор создания нового клиента  
        /// </summary>
        /// <param name="args">5 аргументов (Фамиоия, имя, Отчество, телефон, паспорт)</param>
        public Client(params string[] args)
        {
            LastName = args[0];
            FirstName = args[1];
            MiddelName = args[2];
            Phone = args[3];
            Pasport = args[4];
            DateTimeLastChenging = args[5];
            LastChenger = args[6];
            LastChengedField = args[7];
            LastChengedType = args[8];
        }


        #endregion

    }
}
