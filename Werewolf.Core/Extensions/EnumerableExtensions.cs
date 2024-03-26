namespace Werewolf.Core.Extensions;

public static class EnumerableExtensions
{
    private static Random _random = new Random();
    
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        var elements = source.ToArray();
        for (int i = elements.Length - 1; i >= 0; i--)
        {
            int swapIndex = _random.Next(i + 1);
            yield return elements[swapIndex];
            elements[swapIndex] = elements[i];
        }
    }
}