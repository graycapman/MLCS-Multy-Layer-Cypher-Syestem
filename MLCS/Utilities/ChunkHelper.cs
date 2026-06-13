using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace MLCS.Utilities
{
    public static class ChunkHelper
    {   
        public static List<string> Split(string input, int ChunkCount)
        {
            if (ChunkCount <=0)
            {
                throw new ArgumentException("ChunkCount should be bigger that 0");
            }
            if (ChunkCount >input.Length)
            {
                throw new ArgumentException("Chunkcount cant be bigger that the text");
            }
            int basesize = input.Length / ChunkCount;
            int remainder = input.Length % ChunkCount;
            int index = 0;
            var chunks = new List<string>();
            for (int i = 0; i <ChunkCount; i++)
            {
                int size = basesize + (i < remainder ? 1:0);
                chunks.Add(input.Substring(index, size));
                index += size;
            }

             return chunks;
            
        }
        public static string join(List<string> chunks)
        {
            return string.Concat(chunks);
        }
        
    }


}