using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;

namespace HW_10_1
{
    /// <summary>
    /// Класс для сохранения данныхф XML файл
    /// </summary>
    internal class XmlLoadSave : ILoadSave
    {
        #region Методы сериализации  
        /// <summary>
        /// Метод сохранения списка клиентов в файл  
        /// </summary>
        public void Save(ObservableCollection<Client> clients)
        {
            XmlSerializer SX = new XmlSerializer(typeof(ObservableCollection<Client>));
            using (StreamWriter sw = new StreamWriter("BackUp.xml", false))
            {
                {
                    SX.Serialize(sw, clients);
                }
            }
        }
        /// <summary>
        /// Метод загрузки данных в базу из файла  
        /// </summary>
        public ObservableCollection<Client> Load()
        {
            ObservableCollection<Client> BasicListClients = new ObservableCollection<Client>();
            XmlSerializer SX = new XmlSerializer(typeof(ObservableCollection<Client>));
            if (File.Exists("BackUp.xml")) // проверка на наличие файла попытка считывать происходит только при наличии файла Ы
            {
                using (StreamReader sr = new StreamReader("BackUp.xml"))
                {
                    BasicListClients = SX.Deserialize(sr) as ObservableCollection<Client>;
                }
            }
            return BasicListClients;
        }

        #endregion
    }
}
