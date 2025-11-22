
using Proekt.Models;
using Proekt.Models.Repository;

using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

namespace Proekt.ViewModel
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        private readonly UserRepository _userRepository;
        private MyCommand? _addCommand;
        private MyCommand? _updateCommand;
        private MyCommand? _deleteCommand;
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                if (value != null)
                {
                    _users = value;
                    OnPropertyChanged();
                }
            }
        }

        public MyCommand AddCommand
        {
            get => _addCommand ??= new MyCommand(
            (obj) =>
            {
                User user = new(0, "username", "6457474", "6747586809", 123);
                //_userRepository.Add(user);
                //GetUsersView();
                Users.Add(new(0, ",", "", "", 0));
            }, (obj) => true
            );
        }
        public MyCommand UpdateCommand
        {
            get => _updateCommand ??= new MyCommand(
            (obj) =>
            {
                var user = Users.Last();
                user.Information = "infoinfo";
                //_userRepository.Update(user.Id, user);
                //GetUsersView();
                Users[Users.Count - 1] = new(0, ",", "", "", 0);
            }, (obj) => Users.Count > 0
            );
        }
        public MyCommand DeleteCommand
        {
            get => _deleteCommand ??= new MyCommand(
            (obj) =>
            {
                var user = Users.Last();
                //_userRepository.Delete(user.Id);
                //GetUsersView();
                Users.RemoveAt(Users.Count - 1);
            }, (obj) => Users.Count > 0
            );
        }
        public MainWindowViewModel()
        {
            _userRepository = new();
            GetUsersView();
            Users.CollectionChanged += Users_CollectionChanged;
        }

        private void Users_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                if (e.NewItems != null)
                {
                    foreach (User user in e.NewItems)
                    {
                        _userRepository.Add(user);
                    }
                }
            }
            //Проверка других действий
            //if(e.Action == ...)
        }

        private void GetUsersView()
        {
            var collection = _userRepository.GetAll();
            Users = new ObservableCollection<User>(collection);
        }
    }
}
