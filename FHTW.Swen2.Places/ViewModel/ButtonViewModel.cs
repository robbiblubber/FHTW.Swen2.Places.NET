using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;



namespace FHTW.Swen2.Places.ViewModel
{
    public class ButtonViewModel: INotifyPropertyChanged
    {
        public ButtonViewModel(bool visible, string text = "", ICommand? command = null)
        {
            Visibility = (visible) ? Visibility.Visible : Visibility.Hidden;
            Text = text;
            Command = (command ?? new _EmptyCommand());
        }



        public Visibility Visibility 
        { 
            get; 
        }


        public string Text
        {
            get;
        }


        public ICommand Command
        {
            get;
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        private class _EmptyCommand: ICommand
        {
            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter)
            {
                return false;
            }

            public void Execute(object? parameter)
            {}
        }
    }
}
