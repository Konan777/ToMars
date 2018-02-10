using ToMars.Model;
using ToMars.WPF.ViewModel;
using ToMars.Views;

namespace ToMars.WPF
{
    // Interface extension for ToMars.Model.GeneralFacade
    public static class GeneralFacadeExt
    {
        public static IEditViewModel GetEditView(this IGeneralFacade _IGeneralFacade, AnketaViewModel _anketaViewModel)
        {
            IEditViewModel ievm = new EditViewModel(_anketaViewModel, _IGeneralFacade.Keeper);
            EditView editview = new EditView(ievm);
            return ievm;
        }
    }
}
