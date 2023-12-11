using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10_1
{
    internal class JsonLoadSave : ILoadSave
    {
        public void Save(ObservableCollection<Client> clients)
        {
            throw new NotImplementedException();
        }

        ObservableCollection<Client> ILoadSave.Load()
        {
            throw new NotImplementedException();
        }
    }
}
