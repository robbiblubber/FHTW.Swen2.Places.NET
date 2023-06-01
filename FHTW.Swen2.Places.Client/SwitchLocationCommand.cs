using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FHTW.Swen2.Places.Client
{
    public class SwitchLocationCommand: ICommand
    {
        internal PlaceDetailViewModel _Parent;


        public SwitchLocationCommand(PlaceDetailViewModel parent)
        {
            _Parent = parent;
            _Parent.PropertyChanged += (sender, e) =>
            {
                if(e.PropertyName == nameof(_Parent.Locked))
                {
                    CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                }
            };
        }


        public event EventHandler? CanExecuteChanged;


        public bool CanExecute(object? parameter)
        {
            return !_Parent.Locked;
        }


        public void Execute(object? parameter)
        {
            _Parent.AddressShowing = (!_Parent.AddressShowing);
        }
    }
}
