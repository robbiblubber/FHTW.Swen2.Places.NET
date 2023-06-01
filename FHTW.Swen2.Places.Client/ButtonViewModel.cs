using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FHTW.Swen2.Places.Client
{
    public class ButtonViewModel: INotifyPropertyChanged
    {
        public static readonly ButtonViewModel EMPTY = new ButtonViewModel(false);



        public event PropertyChangedEventHandler? PropertyChanged;


        public ButtonViewModel(bool visible, string text = "", ICommand? command = null)
        {
            Visibility = (visible ? Visibility.Visible : Visibility.Hidden);
            Text = text;
            Command = (command ?? new _EmptyCommand());

            PropertyChanged?.Invoke(this, new(nameof(Visibility)));
            PropertyChanged?.Invoke(this, new(nameof(Text)));
            PropertyChanged?.Invoke(this, new(nameof(Command)));
        }


        public Visibility Visibility
        {
            get; private set;
        }


        public string Text
        {
            get; private set;
        }


        public ICommand Command
        {
            get; private set;
        }


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
