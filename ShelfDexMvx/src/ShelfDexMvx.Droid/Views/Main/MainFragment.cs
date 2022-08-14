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

        private IMvxInteraction<YesNoQuestion> _interaction;
        public IMvxInteraction<YesNoQuestion> Interaction
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
            btnTest.Click += BtnTest_Click;

            var set = this.CreateBindingSet<MainFragment, MainViewModel>();
            set.Bind(tvWelcome).For(x => x.Text).To(vm => vm.Title).WithFallback("<MISSING STRING>").TwoWay();
            set.Bind(this).For(view => view.Interaction).To(viewModel => viewModel.Interaction).OneWay();
            //set.Bind(btnTest).For(x => x.Click).To(vm => vm.Interaction).OneWay();
            set.Apply();

            //ViewModel.Title = "Title";

            return view;
        }

        private void BtnTest_Click(object sender, EventArgs e) => ViewModel.DoFinishProfilCommand();

        private void OnInteractionRequested(object sender, MvxValueEventArgs<YesNoQuestion> eventArgs)
        {
            var yesNoQuestion = eventArgs.Value;
            // show dialog
            //var status = await this.Activity.ShowDialog(yesNoQuestion.Question);
            //var dialog =
            var alert = new AlertDialog.Builder(Activity).Create();
            alert.SetTitle("QUESTION!");
            alert.SetMessage(yesNoQuestion.Question);
            alert.SetCancelable(false);
            alert.SetButton("Yes", (_, __) => yesNoQuestion.YesNoCallback(true));
            alert.SetButton2("No", (_, __) => yesNoQuestion.YesNoCallback(false));
            alert.Show();
            //yesNoQuestion.YesNoCallback(status == DialogStatus.Yes);
        }
    }
}
