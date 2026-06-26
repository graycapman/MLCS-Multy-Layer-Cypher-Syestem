# MLCS — Multi Layer Cypher System

I was trying to solve some of the problems that people have with cypher systems when I made this project.

## How it works

User text → XOR layer → Substitution → Permutation → Encrypted text

When you want to decrypt the text it goes backwards.

Maybe you do not know what all these things mean. So here is an explanation:

- **XOR** — This changes every character to a random one that you might not even be able to type on your keyboard and it needs to be translated to Base64.
- **Substitution** — This replaces each character with another one using a special table that was made with a seed.
- **Permutation** — This rearranges the order of the characters like when you shuffle a deck of cards.

### Why I made this and not just another seed-based cypher

One of the things that my code uses is chunks. To put it simply it cuts the text into as many parts as you have seeds and each part uses a different seed.

You might wonder why I did this. Well it helps to fix problems like:

| Problem | How MLCS helps |
|---------|----------------|
| Frequency analysis ([learn more](https://en.wikipedia.org/wiki/Frequency_analysis)) | Each chunk uses a substitution table so the frequencies of the letters get mixed up across the message. |
| Pattern detection | When the same word is in different chunks it gets treated differently. |
| Known plaintext attack | The person trying to attack needs to know how many seeds there are, what the seeds are and the order of the seeds. All at the same time. |
| Brute force | Each seed can be any number up to about 4 billion. When you have multiple seeds the number of possibilities gets really big really fast. |

## Installation and requirements

All you have to do is [install dotnet](https://dotnet.microsoft.com/en-us/download), [download the MLCS file](https://github.com/graycapman/MLCS-Multy-Layer-Cypher-System), unzip it and run the run.bat file.

That is it.

## Known issues

- There is no authentication so someone could change the encrypted text without anyone noticing.
- The length of the encrypted text is the same as the length of the text, which means that someone could figure out how long the message is.
- The seeds can only be numbers up to about 4 billion which is a limit.

## License

[MIT](LICENSE)
