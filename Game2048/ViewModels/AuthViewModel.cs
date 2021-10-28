using Game2048.Infrastructure.Commands;
using Game2048.Models;
using Game2048.ViewModels.Base;
using Game2048.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Game2048.ViewModels
{
    internal class AuthViewModel : ViewModel
    {
        private string login;
        private string password;
        private readonly int duration = 500;

        public string Login { get => login; set => Set(ref login, value); }
        public string Password { get => password; set => Set(ref password, value); }

        public AuthModel AuthModel { get; } = new();

        #region Commands
        
        public ICommand LogInCommand { get; } 
        private bool CanLogInCommandExequte(object p) => true;
        private void OnLogInCommandExequted(object p) 
        {
            Update();
            if (AuthModel.Aythentication()) 
            {
                CloseAsync();
                new GameWindow().Show();
            }
        }
        #endregion

        private async void CloseAsync()
        {
            await Task.Run(() => 
            {
                Thread.Sleep(duration);
                Application.Current.Dispatcher.Invoke(new Action(() => Application.Current.MainWindow.Close()));
            });
        }

        public AuthViewModel()
        {
            LogInCommand = new RelayCommand(OnLogInCommandExequted, CanLogInCommandExequte);
        }

        private void Update()
        {
            AuthModel.Login = Login;
            AuthModel.Pass = Password;
        }
    }
}
