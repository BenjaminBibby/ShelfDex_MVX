using System;
using System.Collections.Generic;
using System.Text;

namespace ShelfDexMvx.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                SetProperty(ref _title, value);
                RaisePropertyChanged(_title);
            }
        }
    }
}
