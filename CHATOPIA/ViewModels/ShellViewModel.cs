namespace CHATOPIA.ViewModels {
	using Caliburn.Micro;
	class ShellViewModel : Screen {
		MessageEntryViewModel _MessageEntry;
		MessageStreamViewModel _MessageStream;
		RoomListViewModel _RoomList;

		public ShellViewModel(MessageEntryViewModel messageEntry, MessageStreamViewModel messageStream, RoomListViewModel roomList) {
			this.MessageEntry = messageEntry;
			this.MessageStream = messageStream;
			this.RoomList = roomList;

			/// We call 'ActivateWith' here to say that when the main screen gets activated and the Activate() routine runs,
			/// that these other screens are activated at the same time.
			this.MessageEntry.ActivateWith(this);
			this.MessageStream.ActivateWith(this);
			this.RoomList.ActivateWith(this);
		}

		public MessageEntryViewModel MessageEntry {
			get { return _MessageEntry; }
			set {
				_MessageEntry = value;
				NotifyOfPropertyChange(() => MessageEntry);
			}
		}

		public MessageStreamViewModel MessageStream {
			get { return _MessageStream; }
			set {
				_MessageStream = value;
				NotifyOfPropertyChange(() => MessageStream);
			}
		}

		public RoomListViewModel RoomList {
			get { return _RoomList; }
			set {
				_RoomList = value;
				NotifyOfPropertyChange(() => RoomList);
			}
		}
	}
}