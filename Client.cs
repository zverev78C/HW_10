using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HW_10_1
{
    /// <summary>
    /// Класс лписывающий клиента (Model) 
    /// </summary>
    public class Client : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Метод, который скажет ViewModel, что нужно передать View новые данные  
        /// </summary>
        /// <param name="prop"></param>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


        public event Action<string> ChangedProp;
        public void OnChangedProp(string name)
        {
            ChangedProp?.Invoke(name);
        }

        #region Поля 

        /// <summary>
        /// уникальный номер клиента 
        /// </summary>
        private int _id;
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

        #endregion

        #region Свойства 

        /// <summary>
        /// уникальный номер клиента  
        /// </summary>
        public int ID
        {
            get { return this._id; }
            set { this._id = value; }
        }
        /// <summary>
        /// Фамилия  
        /// </summary>
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                if (lastName != value)
                {
                    this.lastName = value;
                    OnPropertyChanged(nameof(this.LastName)); //Если свойство меняется, вызывается метод, который уведомляет об изменении модели
                    OnChangedProp(nameof(LastName));
                }
            }
        }
        /// <summary>
        /// Имя     
        /// </summary>
        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                if (firstName != value)
                {
                    this.firstName = value;
                    OnPropertyChanged(nameof(this.FirstName)); //Если свойство меняется, вызывается метод, который уведомляет об изменении модели
                    OnChangedProp(nameof(FirstName));
                }
            }
        }
        /// <summary>
        /// Отчество    
        /// </summary>
        public string MiddelName
        {
            get { return this.middelName; }
            set
            {
                if (middelName != value)
                {
                    this.middelName = value;
                    OnPropertyChanged(nameof(this.MiddelName)); //Если свойство меняется, вызывается метод, который уведомляет об изменении модели
                    OnChangedProp(nameof(MiddelName));
                }
            }
        }
        /// <summary>
        /// Номер телефона  
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set
            {
                if (phone != value)
                {
                    this.phone = value;
                    OnPropertyChanged(nameof(this.Phone)); //Если свойство меняется, вызывается метод, который уведомляет об изменении модели
                    OnChangedProp(nameof(Phone));
                }
            }
        }
        /// <summary>
        /// Номер паспорта  
        /// </summary>
        public string Pasport
        {
            get { return pasport; }
            set
            {
                if (pasport != value)
                {
                    this.pasport = value;
                    OnPropertyChanged(nameof(this.Pasport)); //Если свойство меняется, вызывается метод, который уведомляет об изменении модели
                    OnChangedProp(nameof(Pasport));
                }
            }
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

        /// <summary>
        /// Конструктор создания нового клиента  
        /// </summary>
        /// <param name="args">5 аргументов (Фамиоия, имя, Отчество, телефон, паспорт)</param>
        public Client(int id, params string[] args)
        {
            ID = id;
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
