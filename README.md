# MLCS — Multi Layer Cypher System

I tried to fix some of the biggest cypher systems problems with this project.

## How it works

In simple words:

```
User text → XOR layer → Substitution → Permutation → Encrypted text
```

Decryption goes backwards.

Don't know what those mean? Here's a quick explanation:

- **XOR** — changes every character to a random one that some don't even exist on keyboards and need to be translated to Base64.
- **Substitution** — changes the characters' positions in the text.
- **Permutation** — rearranges the order of characters (like shuffling a deck of cards).

### Why this and not just another seed-based cypher?

One of the things my code uses is **chunks** (in advance mode). In simple words, it cuts the text into as many parts as you have seeds, with different seeds for each part.

You may ask why. Well, for fixing problems like:

| Problem | How MLCS helps |
|---------|----------------|
| Frequency analysis ([learn more](https://en.wikipedia.org/wiki/Frequency_analysis)) | Each chunk uses a different substitution table, so letter frequencies are blended across the message |
| Pattern detection | The same word in different chunks gets different treatment |
| Known plaintext attack | Attacker needs to know seed count + seed values + seed order — all three at once |
| Brute force | Each seed can be any `Int32` value (~4 billion), with multiple seeds the space grows fast |

## Installation and requirements

All you need to do is [install dotnet](https://dotnet.microsoft.com/en-us/download), [download the MLCS file](https://github.com/GREYCAPMAN/MLCS), unzip it and run `run.bat`.

That's it.

## Known issues

- No authentication — ciphertext can be modified without detection
- Ciphertext length equals plaintext length, which leaks message size
- Seed space is limited to `Int32` range (~4 billion per seed)

## License

[MIT](LICENSE)
