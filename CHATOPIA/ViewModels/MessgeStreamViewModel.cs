namespace CHATOPIA.ViewModels {
	using Caliburn.Micro;
	using System.Collections.ObjectModel;
	class MessageStreamViewModel : Screen, IHandle<AggEvents.SendMessageAggEvent> {
		IEventAggregator _EventAggregator;
		ObservableCollection<string> _Messages;

		public MessageStreamViewModel(IEventAggregator eventAggregator) {
			_EventAggregator = eventAggregator;
			_EventAggregator.Subscribe(this);

			// We need to initialize the Messages property.
			Messages = new ObservableCollection<string>();
		}

		public ObservableCollection<string> Messages {
			get { return _Messages; }
			set {
				_Messages = value;
				NotifyOfPropertyChange(() => Messages);
			}
		}


		public void Handle(AggEvents.SendMessageAggEvent message) {
			Messages.Add(message.Message);
		}
	}
}