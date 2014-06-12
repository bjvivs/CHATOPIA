using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHATOPIA.ViewModels
{
    class RoomListViewModel
    {
        ObservableCollection<string> _Users;

        public ObservableCollection<string> Users
        {
            get { return _Users; }
            set { _Users = value; }
        }
    }
}
