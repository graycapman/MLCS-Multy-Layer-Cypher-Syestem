using MLCS.Core;
using MLCS.Utilities;
namespace MLCS.Utilities
{
    public static class SeedParser
    {
        
        public static List<int> Parse(string input)
        {
            var result = new List<int>();
            string[] parts = input.Split('-');
            foreach(string part in parts)
            {
                result.Add(int.Parse(part));
            
            }
            
            
            return result;
            
        }
    }
}