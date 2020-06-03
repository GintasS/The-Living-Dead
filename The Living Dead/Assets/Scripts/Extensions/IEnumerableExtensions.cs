using System;
using System.Collections.Generic;
using System.Linq;

public static class IEnumerableExtensions
{
    /// <summary>
    /// Get a pseudo-random element from the IEnumerable or the default value if the IEnumerable is null or empty.
    /// </summary>
    /// <returns>A pseudo-random element.</returns>
    public static T GetRandomElementOrDefault<T>(this IEnumerable<T> enumerable)
    {
        if (enumerable == null || enumerable.Count() == 0)
        {
            return default;
        }

        var randomIndex = RandomNumberGenerator.Generate(0, enumerable.Count());
        return enumerable.ElementAt(randomIndex);
    }

    /// <summary>
    /// Get a pseudo-random IEnumerable instance or the default value if the IEnumerable is null or empty.
    /// </summary>
    /// <returns>A pseudo-random IEnumerable.</returns>
    public static IEnumerable<T> RandomizeOrDefault<T>(this IEnumerable<T> enumerable)
    {
        if (enumerable == null || enumerable.Count() == 0)
        {
            return default;
        }

        var random = new Random();
        return enumerable.OrderBy(x => random.Next())
            .ToArray();
    }
}