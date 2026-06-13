namespace MLCS.Core
{
    public interface ICipherLayer
    {
        string Encrypt(string input);
        string Decrypt(string input);
    }
}