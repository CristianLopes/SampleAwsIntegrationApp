using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DynamoDbApp.Repositories;

namespace DynamoDbApp.UI.Views.Register
{
    public partial class RegisterViewModel : ObservableObject
    {
        private readonly IUserRepository _userRepository;
        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _password;

        [ObservableProperty]
        private string _userId;

        public RegisterViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [RelayCommand]
        public async Task Register()
        {
            var userRegister = new Repositories.Entities.UserRegisterDb
            {
                UserId = UserId,
                Password = Password,
                PK = "#USERS#",
                SK = UserName
            };
            try
            {
                var userExists = await _userRepository.UserExists(UserName);
                if (userExists)
                {
                    await Shell.Current.DisplayAlert("APP", "User already exists", "OK");
                    return;
                }

                await _userRepository.Register(userRegister);
                await Shell.Current.DisplayAlert("APP", "Congratulations you are registered", "OK");
                await GoToLogin();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("APP", ex.Message, "OK");
            }
        }

        [RelayCommand]
        public async Task GoToLogin()
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
