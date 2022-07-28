using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ShelfDexMvx.Core.ViewModels.Main;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using AndroidX.ConstraintLayout.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Base;
using MvvmCross.ViewModels;

namespace ShelfDexMvx.Droid.Views.Main
{
    [MvxFragmentPresentation(typeof(MainContainerViewModel), Resource.Id.content_frame)]
    public class MainFragment : BaseFragment<MainViewModel>
    {
        protected override int FragmentLayoutId => Resource.Layout.fragment_main;

        IMvxInteraction<YesNoQuestion> _interaction;
        IMvxInteraction<YesNoQuestion> Interaction
        {
            get => _interaction;
            set
            {
                if (_interaction != null)
                    _interaction.Requested -= OnInteractionRequested;

                _interaction = value;
                _interaction.Requested += OnInteractionRequested;
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = base.OnCreateView(inflater, container, savedInstanceState);

            TextView tvWelcome = view.FindViewById<TextView>(Resource.Id.txt_welcome);

            Button btnTest = view.FindViewById<Button>(Resource.Id.btn_test);

            var set = this.CreateBindingSet<MainFragment, MainViewModel>();
            set.Bind(tvWelcome).For(x => x.Text).To(vm => vm.Title).WithFallback("<MISSING STRING>").TwoWay();
            set.Bind(this).For(view => view.Interaction).To(viewModel => viewModel.Interaction).OneWay();
            //set.Bind(btnTest).For(x => x.Click).To(vm => vm.Interaction).OneWay();
            set.Apply();

            //ViewModel.Title = "Title";

            return view;
        }

        private async void OnInteractionRequested(object sender, MvxValueEventArgs<YesNoQuestion> eventArgs)
        {
            var yesNoQuestion = eventArgs.Value;
            // show dialog
            //var status = await this.Activity. ShowDialog(yesNoQuestion.Question);
            //var dialog = AlertDialog.Builder
            //yesNoQuestion.YesNoCallback(status == DialogStatus.Yes);
        }
    }
}
