using System;
using System.Collections.Generic;
using System.Text;
using MvvmCross.Base;
using MvvmCross.ViewModels;

namespace ShelfDexMvx.Core.ViewModels.Main
{
    public class YesNoQuestion
    {
        public Action<bool> YesNoCallback { get; set; }
        public string Question { get; set; }
    }

    public class MainViewModel : BaseViewModel
    {
        
        private MvxInteraction<YesNoQuestion> _interaction = new MvxInteraction<YesNoQuestion>();
        public IMvxInteraction<YesNoQuestion> Interaction => _interaction;


        public void DoFinishProfilCommand()
        {
            var request = new YesNoQuestion
            {
                YesNoCallback = (ok) =>
                {
                    Console.WriteLine(ok ? "Yes" : "No");
                },
                Question = "This is a question"
            };

            _interaction.Raise(request);
        }

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
