using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHTW.Swen2.Places.ViewModel
{
    public class PlaceViewModel: INotifyPropertyChanged
    {
        public PlaceViewModel(MainViewModel parent) 
        {
            Parent = parent;
        }

        public MainViewModel Parent
        {
            get;
        }


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
