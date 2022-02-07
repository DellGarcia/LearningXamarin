using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using AwesomeApp.Models;
using AwesomeApp.Services;

namespace AwesomeApp.ViewModels
{
    public class TestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IUserService userService;

        public TestViewModel(IUserService userService)
        {
            AllUsers = new ObservableCollection<User>();
            this.userService = userService;

            GetUsers();
        }

        public ObservableCollection<User> AllUsers { get; set; }

        private string _text = "Nada";
        public string Text
        {
            get => _text;  
            set { 
                _text = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
            }
        }

        private async void GetUsers()
        {
            IEnumerable<User> users = await userService.GetUsers();
            AllUsers.Clear();
            foreach(User user in users)
                AllUsers.Add(user);
            Text = $"Aconteceu {AllUsers.Count}";
            //Console.WriteLine($"Aoba {Text}");
        }
    }
}
