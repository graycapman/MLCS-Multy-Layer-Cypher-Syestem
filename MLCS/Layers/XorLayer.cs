using MLCS.Core;
using MLCS.Utilities;
namespace MLCS.Layers

{
         public class XorLayer : ICipherLayer
    {
        private int _seed;
        public XorLayer(int seed)
        {
            _seed = seed;
        }
        public string Encrypt(string input)
        {
            var rng = new SeededRandom(_seed);
            char[] output = new char[input.Length];
            for (int i =0; i < input.Length; i++)
            {
                int key = rng.next(0, 65535);
                output[i] = (char)(input[i] ^ key);
            }
            return new string(output);
        }
        public string Decrypt(string input)
        {
            return Encrypt(input);
        }
    }
}