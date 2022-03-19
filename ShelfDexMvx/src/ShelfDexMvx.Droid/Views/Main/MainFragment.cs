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

namespace ShelfDexMvx.Droid.Views.Main
{
    [MvxFragmentPresentation(typeof(MainContainerViewModel), Resource.Id.content_frame)]
    public class MainFragment : BaseFragment<MainViewModel>
    {
        protected override int FragmentLayoutId => Resource.Layout.fragment_main;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = base.OnCreateView(inflater, container, savedInstanceState);//inflater.Inflate(FragmentLayoutId, container, false);

            TextView tvWelcome = view.FindViewById<TextView>(Resource.Id.txt_welcome);
            using (var set = this.CreateBindingSet<MainFragment, MainViewModel>())
            {
                set.Bind(tvWelcome).For(x => x.Text).To(vm => vm.Title).WithFallback("<MISSING STRING>");
            }
            //set?.Apply();

            ViewModel.Title = "Title";

            return view;
            //base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}
