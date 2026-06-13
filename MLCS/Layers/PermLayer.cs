using System.Globalization;
using System.Net.WebSockets;
using MLCS.Core;
using MLCS.Utilities;
namespace MLCS.Layers
{
 public class PermLayer : ICipherLayer
    {

        private int[] order = Array.Empty<int>();
        private int _seed;
        
        public PermLayer(int seed)
        {
            _seed = seed;
        }
        public string Encrypt(string input)
        {
            int[] order = new int[input.Length];
            for (int i = 0; i < input.Length;i++ )
            {
                order[i] = i;
            }
            var rng = new SeededRandom(_seed);
            
            for (int i = order.Length - 1; i > 0; i--)
            {
                int j = rng.next(0, i);
                int temp = order[i];
                order[i] = order[j];
                order[j] = temp;
            }
            char[] output = new char[input.Length];
            for (int i = 0; i < input.Length;i++ )
            {
                output[i] = input[order[i]];
            }
            return new string(output);
        }
        public string Decrypt(string input)
        {
             int[] order = new int[input.Length];
            for (int i = 0; i < input.Length;i++ )
            {
                order[i] = i;
            }
            var rng = new SeededRandom(_seed);
            
            for (int i = order.Length - 1; i > 0; i--)
            {
                int j = rng.next(0, i);
                int temp = order[i];
                order[i] = order[j];
                order[j] = temp;
            }
            char[] output = new char[input.Length];
            for (int i = 0; i < input.Length;i++ )
            {
                output[order[i]] = input[i];
            }
            return new string(output);
        }
    }

}