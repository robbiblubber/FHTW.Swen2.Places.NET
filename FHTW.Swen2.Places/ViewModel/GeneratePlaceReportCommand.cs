using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;



namespace FHTW.Swen2.Places.ViewModel
{
    /// <summary>This implements a command for generating a place report.</summary>
    public sealed class GeneratePlaceReportCommand: ICommand
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="parent">Parent view model.</param>
        public GeneratePlaceReportCommand(MainViewModel parent) 
        {
            Parent = parent;

            Parent.PropertyChanged += (sender, e) =>
            {
                if(e.PropertyName == nameof(Parent.PlaceControlVisibility))
                {
                    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                }
            };
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Gets the parent view model.</summary>
        public MainViewModel Parent 
        { 
            get;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // [interface] ICommand                                                                                     //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>This event occurs when the value returned by <see cref="CanExecute(object?)"/> has changed.</summary>
        public event EventHandler? CanExecuteChanged;


        /// <summary>Gets if the command can be executed with the given parameter.</summary>
        /// <param name="parameter">Parameter.</param>
        /// <returns>Returns TRUE if the command can execute, otherwise returns FALSE.</returns>
        public bool CanExecute(object? parameter)
        {
            return (Parent.PlaceControlVisibility == Visibility.Visible);
        }


        /// <summary>Executes the command with the given parameter.</summary>
        /// <param name="parameter">Parameter.</param>
        public void Execute(object? parameter)
        {
            if(Parent.PlaceDetails.Place is null) return;

            string tmp = System.IO.Path.GetTempPath() + '\\' + Guid.NewGuid().ToString() + ".pdf";

            ReportWriter.GeneratePlaceReport(Parent.PlaceDetails.Place, tmp);

            using Process p = new();
            p.StartInfo.FileName = tmp;
            p.StartInfo.UseShellExecute = true;
            p.Start();
        }
    }
}
