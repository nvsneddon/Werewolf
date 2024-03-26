using Werewolf.Core.Interfaces;

namespace Werewolf.Core.Services;

public class RandomNumberGenerator : IRandomNumberGenerator
{
    private readonly Random _random = new Random();
    
    public int GenerateRandomNumber(int min, int max)
    {
        return _random.Next(min, max);
    }
}