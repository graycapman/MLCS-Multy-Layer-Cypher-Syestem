using System.Security.Cryptography;

namespace MLCS.Utilities
{
    public class SeededRandom
    {
        private byte[] state;
        private byte[] buffer;
        private int position;

        public SeededRandom(int seed)
        {
            state = BitConverter.GetBytes(seed);
            Array.Resize(ref state, 32);
            buffer = Array.Empty<byte>();
            position = 0;
        }

        private void NextBlock()
        {
            buffer = SHA256.HashData(state);
            state = SHA256.HashData(state);
            position = 0;
        }

        public int next(int min, int max)
        {
            int range = max - min;
            if (range <= 0) return min;

            int value;
            do
            {
                if (position + 4 > buffer.Length) NextBlock();
                value = BitConverter.ToInt32(buffer, position) & 0x7FFFFFFF;
                position += 4;
            } while (value >= int.MaxValue - (int.MaxValue % range));

            return min + (value % range);
        }

        public double NextDouble()
        {
            if (position + 8 > buffer.Length) NextBlock();
            long bits = ((long)BitConverter.ToInt64(buffer, position) & 0x7FFFFFFFFFFFFFFF);
            position += 8;
            return bits / (double)(1L << 63);
        }
    }

}