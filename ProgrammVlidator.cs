using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10_1
{
    internal class ProgrammVlidator
    {       
        /// <summary>
        /// Список возможных пользователей 
        /// </summary>
        private static List<IUserInterface> users = new List<IUserInterface>()
        {
            new Meneger(),
            new Consultant(),
        };
              
        /// <summary>
        /// Метод устанавливающий уровень доступа к данным  
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Экземпляр класса пользовотеля</returns>
        public static IUserInterface GetType (int value)
        {
            return users[value];
        }

    }
}
