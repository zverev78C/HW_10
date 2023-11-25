using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace HW_10_1
{
    /// <summary>
    /// Класс для сохранения данныхф XML файл
    /// </summary>
    internal class LoadSave
    {
        #region Методы сериализации  
        /// <summary>
        /// Метод сохранения списка клиентов в файл  
        /// </summary>
        public static void SaveList()
        {
            List<Client> BasicListClients = Repository.OutPutList();


            XmlSerializer SX = new XmlSerializer(typeof(List<Client>));
            using (StreamWriter sw = new StreamWriter("BackUp.xml", false))
            {
                {
                    SX.Serialize(sw, BasicListClients);
                }
            }
        }
        /// <summary>
        /// Метод загрузки данных в базу из файла  
        /// </summary>
        public static void LoadList()
        {
            List<Client> BasicListClients = new List<Client>();
            XmlSerializer SX = new XmlSerializer(typeof(List<Client>));
            if (File.Exists("BackUp.xml")) // проверка на наличие файла попытка считывать происходит только при наличии файла Ы
            {
                using (StreamReader sr = new StreamReader("BackUp.xml"))
                {
                    BasicListClients = SX.Deserialize(sr) as List<Client>;
                }
            }
            Repository.InPutList(BasicListClients);
        }
        #endregion
    }
}
