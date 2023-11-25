namespace HW_10_1
{
    /// <summary>
    /// Класс консультант который знает о репозитории и обращется к нему в пределах уровня доступа 
    /// </summary>
    class Consultant : User
    {
        public override string Name { get => "Консультант"; }

        #region Методы  запросов в репазиторий

        /// <summary>
        /// метод возвращающий клиента согласно допуска для View
        /// </summary>
        /// <param name="i">индекс клиента</param>
        /// <returns></returns>
        public override Client GetClient(int i)
        {
            Client concretClient = rep.GetClientInfo(i);

            concretClient.Pasport = concretClient.Pasport != null ? "(****) ***-***" : "номера нет.";
            concretClient.DateTimeLastChenging = null;
            concretClient.LastChenger = null;
            concretClient.LastChengedField = null;
            concretClient.LastChengedType = null;

            return concretClient;
        }

        public override void ChangeAnyField(Client concretClient, int indexClient)
        {
            if (concretClient.LastChengedField == "Телефон")
            {
                Client tempClient = rep.GetClientInfo(indexClient);
                tempClient.Phone = concretClient.Phone;
                tempClient.DateTimeLastChenging = concretClient.DateTimeLastChenging;
                tempClient.LastChenger = concretClient.LastChenger;
                tempClient.LastChengedField = concretClient.LastChengedField;
                tempClient.LastChengedType = concretClient.LastChengedType;
                rep.ChangeClient(tempClient, indexClient);
            }
        }

        #endregion
    }
}
