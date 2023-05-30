using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DynamoDbApp.Repositories;

namespace DynamoDbApp.UI.Views.Login
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly IUserRepository _userRepository;
        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _password;

        public LoginViewModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [RelayCommand]
        public async Task Login()
        {
            try
            {
                var result = await _userRepository.Login(UserName, Password);
                if (result is not null)
                {
                    await Shell.Current.DisplayAlert("APP", "Congratulations you are logged in", "OK");
                }
                else
                {
                    await Shell.Current.DisplayAlert("APP", "Invalid username or password", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("ERROR", ex.Message, "OK");
            }
        }

        [RelayCommand]
        public async Task GoToRegister()
        {
            await Shell.Current.GoToAsync("//RegisterPage");
        }
    }
}
