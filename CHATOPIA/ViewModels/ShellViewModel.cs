using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHATOPIA.ViewModels
{
    class ShellViewModel : Screen
    {
        MessageEntryViewModel _MessageEntry;
        MessageStreamViewModel _MessageStream;
        RoomListViewModel _RoomList;

        public MessageEntryViewModel MessageEntry
        {
            get { return _MessageEntry; }
            set
            {
                _MessageEntry = value;
                NotifyOfPropertyChange(() => MessageEntry);
            }
        }

        public MessageStreamViewModel MessageStream
        {
            get { return _MessageStream; }
            set
            {
                _MessageStream = value;
                NotifyOfPropertyChange(() => MessageStream);
            }
        }

        public RoomListViewModel RoomList
        {
            get { return _RoomList; }
            set
            {
                _RoomList = value;
                NotifyOfPropertyChange(() => RoomList);
            }
        }
    }
}
