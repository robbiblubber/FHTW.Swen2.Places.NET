using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FHTW.Swen2.Places.Client
{
    /// <summary>This class implements a command to edit a place.</summary>
    public class EditPlaceCommand: ICommand
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // private members                                                                                          //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>Parent view model.</summary>
        internal PlaceDetailViewModel _Parent;

        internal EditPlaceCommand(PlaceDetailViewModel parent)
        {
            _Parent = parent;
        }


        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _Parent.StartEdit();
        }
    }
}
