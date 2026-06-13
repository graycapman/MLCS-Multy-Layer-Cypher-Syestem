using MLCS.Core;
using MLCS.Utilities;
namespace MLCS.Layers
{
    public class SubLayer : ICipherLayer
    {
        private int[] Map = new int[256];

        public SubLayer(int seed)
        {
            for (int i= 0; i<256; i++) 
            {
                Map[i] = i;
            }
            var rng = new SeededRandom(seed);
            for (int i=255; i>0; i--)
            {
                int k = rng.next(0 , i);
                int temp = Map[i];
                Map[i] = Map[k];
                Map[k] = temp;
            }
            for (int i = 0; i < 256; i++)
            {
                ReversMap[Map[i]] = i;
            }
        }
        public string Encrypt(string input)
        {
            char[] output = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = (char)Map[input[i] % 256] ;
            }
            return new string(output);
        }
        private int[] ReversMap = new int[256];
        public string Decrypt(string input)
        {
               char[] output = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = (char)ReversMap[input[i] % 256];
            }
            return new string(output);
        }
    }    
}