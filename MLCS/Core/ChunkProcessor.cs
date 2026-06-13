using System.Buffers;
using System.Security.Cryptography;
using MLCS.Core;
using MLCS.Layers;
namespace MLCS.Core
{
    
    public class ChunkProsses
    {
        private ICipherLayer xor = null!;
        private ICipherLayer sub = null!;
        private ICipherLayer perm = null!;

        public ChunkProsses(int seed)
        {
            xor = new XorLayer(seed);
            sub = new SubLayer(seed);
            perm = new PermLayer(seed); 
            
        }
        public string Process(string input)
        {
            string result = xor.Encrypt(input);
            result = sub.Encrypt(result);
            result = perm.Encrypt(result);
        return result;
        }
        public string UnProcess(string input)
        {
         string result = perm.Decrypt(input);
            result = sub.Decrypt(result);
            result = xor.Decrypt(result);
            return result;
        }

    }


}