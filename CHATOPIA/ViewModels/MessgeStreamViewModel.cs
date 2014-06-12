using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CHATOPIA.ViewModels
{
    class MessageStreamViewModel : Screen , IHandle<AggEvents.SendMessageAggEvent>
    {
        IEventAggregator _EventAggregator;
        ObservableCollection<string> _Messages;

        public MessageStreamViewModel(IEventAggregator eventAggregator) 
        {
            _EventAggregator = eventAggregator;
            _EventAggregator.Subscribe(this);
        }

        public ObservableCollection<string> Messages
        {
            get { return _Messages; }
            set { _Messages = value;
            NotifyOfPropertyChange(() => Messages);
            }
        }


        public void Handle(AggEvents.SendMessageAggEvent message)
        {
            Messages.Add(message.Message);
        }
    }
}
