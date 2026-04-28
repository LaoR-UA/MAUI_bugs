using System.Collections.ObjectModel;

namespace TestMauiControls
{
    internal static class StaticDataContainer
    {
        public static ObservableCollection<string> Invocations = [];

        public static string SecondPageRoute = "secondPage";
        public static string ThirdPageRoute = "thirdPage";
    }
}
