using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHATOPIA.ViewModels
{
    class MessageStreamViewModel
    {
        ObservableCollection<string> _Messages;

        public ObservableCollection<string> Messages
        {
            get { return _Messages; }
            set { _Messages = value;  }
        }

    }
}
