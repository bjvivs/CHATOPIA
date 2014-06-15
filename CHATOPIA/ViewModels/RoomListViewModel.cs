namespace CHATOPIA.ViewModels {
	using Caliburn.Micro;
	using System.Collections.ObjectModel;
	class RoomListViewModel : Screen {
		ObservableCollection<string> _Users;

		public ObservableCollection<string> Users {
			get { return _Users; }
			set {
				_Users = value;
				NotifyOfPropertyChange(() => Users);
			}
		}
	}
}