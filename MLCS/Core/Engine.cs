using MLCS.Core;
using MLCS.Layers;
using MLCS.Utilities;
namespace MLCS.Core
{
    public class Engine
    {
        private List<ChunkProsses> processors = new List<ChunkProsses>();
        public Engine(List<int> seeds)
        {
            foreach (int seed in seeds)
            {
                processors.Add(new ChunkProsses(seed));
            }
        }
        public string Encrypt(string input)
        {
            var chunks = ChunkHelper.Split(input, processors.Count);
            var results = new List<string>();
            for (int i = 0; i < processors.Count; i++)
            {
                results.Add(processors[i].Process(chunks[i]));
            }
            string joined = ChunkHelper.join(results);
            return Convert.ToBase64String(System.Text.Encoding.Latin1.GetBytes(joined));
        }
        public string Decrypt (string input)
        {
            input = System.Text.Encoding.Latin1.GetString(Convert.FromBase64String(input));
            var chunks = ChunkHelper.Split(input, processors.Count);
            var results = new List<string>();
            for (int i = 0; i < processors.Count; i++)
            {
                results.Add(processors[i].UnProcess(chunks[i]));
            }
            return ChunkHelper.join(results);
        }

    }

}