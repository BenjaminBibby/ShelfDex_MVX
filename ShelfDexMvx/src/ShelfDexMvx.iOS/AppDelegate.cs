using Foundation;
using MvvmCross.Platforms.Ios.Core;
using ShelfDexMvx.Core;

namespace ShelfDexMvx.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}
