using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace AwesomeApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private string _note = string.Empty;

        public MainPageViewModel()
        {
            AllNotes = new ObservableCollection<string>();

            EraseCommand = new Command(() => Note = string.Empty);

            ClearCommand = new Command(() => AllNotes.Clear());

            SaveCommand = new Command(() =>
            {
                Console.WriteLine(_note);
                if(_note != string.Empty)
                {
                    AllNotes.Add(_note);
                    Note = string.Empty;
                }
            });
        }

        public ObservableCollection<string> AllNotes { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Note { 
            get => _note; 
            set {
                _note = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Note)));
            }
        }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }
        public Command ClearCommand { get; }
    }
}
