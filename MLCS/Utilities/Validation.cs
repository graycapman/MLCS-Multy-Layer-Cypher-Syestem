using MLCS.Utilities;
namespace MLCS.Utilities
{

    public static class Validation
    {
        public static bool Validatetext(string text)
        {
            return text.Length > 0;
        }

    }
}
