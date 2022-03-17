using MvvmCross.IoC;
using MvvmCross.ViewModels;
using ShelfDexMvx.Core.ViewModels.Main;

namespace ShelfDexMvx.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}
