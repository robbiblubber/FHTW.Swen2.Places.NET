using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHTW.Swen2.Places.ViewModel
{
    public sealed class SearchResultListViewModel: INotifyPropertyChanged
    {
        private int _SelectedIndex = -1;


        public SearchResultListViewModel(MainViewModel parent)
        {
            Parent = parent;
        }

        public MainViewModel Parent 
        { 
            get;
        }

        public ObservableCollection<SearchResultViewModel> Items
        {
            get;
        } = new();


        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                if(_SelectedIndex != value)
                {
                    _SelectedIndex = value;
                    PropertyChanged?.Invoke(this, new(nameof(SelectedIndex)));
                }
            }
        }


        public SearchResultViewModel SelectedResult
        {
            get { return Items[SelectedIndex]; }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
