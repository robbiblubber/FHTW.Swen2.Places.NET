using System;
using System.Windows;
using System.Windows.Input;



namespace FHTW.Swen2.Places.ViewModel
{
    /// <summary>This class provides a configurable view model for a button.</summary>
    public sealed class ButtonViewModel
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="visible">Determines if the command is visible.</param>
        /// <param name="text">Button text.</param>
        /// <param name="command">Button command.</param>
        public ButtonViewModel(bool visible, string text = "", ICommand? command = null)
        {
            Visibility = (visible) ? Visibility.Visible : Visibility.Hidden;
            Text = text;
            Command = (command ?? new _EmptyCommand());
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Gets the button visibility.</summary>
        public Visibility Visibility 
        { 
            get; 
        }



        /// <summary>Gets the button text.</summary>
        public string Text
        {
            get;
        }


        /// <summary>Gets the button command.</summary>
        public ICommand Command
        {
            get;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // [class] _EmptyCommand                                                                                    //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>This class implements a command with no functionality.</summary>
        private class _EmptyCommand: ICommand
        {
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            // [interface] ICommand                                                                                 //
            //////////////////////////////////////////////////////////////////////////////////////////////////////////
            
            /// <summary>Occurs when the result returned from <see cref="CanExecute(object?)"/> has changed.</summary>
            public event EventHandler? CanExecuteChanged;


            /// <summary>Indicates if the command can be executed with the given parameter.</summary>
            /// <param name="parameter">Parameter.</param>
            /// <returns>Returns TRUE if the command can be executed, otherwise returns FALSE.</returns>
            public bool CanExecute(object? parameter)
            {
                return false;
            }


            /// <summary>Executes the command.</summary>
            /// <param name="parameter">Parameter.</param>
            public void Execute(object? parameter)
            {}
        }
    }
}
