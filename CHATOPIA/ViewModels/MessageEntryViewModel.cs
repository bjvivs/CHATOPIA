namespace CHATOPIA.ViewModels {
	using Caliburn.Micro;
	using System;
	class MessageEntryViewModel : Screen {
		// member variable
		private string _Message;
		IEventAggregator _EventAggregator;

		public MessageEntryViewModel(IEventAggregator eventAggregator) {
			_EventAggregator = eventAggregator;
		}

		/// <summary>
		/// contains the text to be sent 
		/// </summary>
		/// property becaues it doesn't have a parameter list (not a function) and it can return a value
		public string Message {
			get { return _Message; }
			set {
				_Message = value;
				NotifyOfPropertyChange(() => Message);
			}
		}
		// method
		// TODO: fix bug
		public void Send() {

			if (_Message != string.Empty) {
				_EventAggregator.PublishOnUIThread(new AggEvents.SendMessageAggEvent { Message = this.Message });
			}

			_Message = String.Empty;

		}
	}
}