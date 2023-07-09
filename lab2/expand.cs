namespace lab2;
using System;
using System.Collections.Generic;
using System.Linq;


public static class EnumerableExtensions
{
    
    public static IEnumerable<IEnumerable<T>> GenerateCombinations<T>(this IEnumerable<T> source, int k, IEqualityComparer<T> comparer)
    {
        if (k == 0)
        {
            yield return Enumerable.Empty<T>();
        }
        else
        {
            //чек на предмет попарного неравенства по отношению эквивалентности
            var distinctSource = source.Distinct(comparer);
            if (distinctSource.Count() < source.Count())
            {
                throw new ArgumentException("Insufficient distinct elements in the input collection.");
            }

            var index = 0;
            foreach (var item in distinctSource)
            {
                foreach (var combination in distinctSource.Skip(index + 1).GenerateCombinations(k - 1, comparer))
                {
                    yield return combination.Prepend(item);
                }
                index++;
            }
        }
    }




    public static IEnumerable<IEnumerable<T>> GenerateSubsets<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
    {
        //чек на предмет попарного неравенства по отношению эквивалентности
        var distinctSource = source.Distinct(comparer);
        if (distinctSource.Count() < source.Count())
        {
            throw new ArgumentException("Insufficient distinct elements in the input collection.");
        }
        var list = source.ToList();
        var subsets = new List<List<T>> { new List<T>() };

        foreach (var item in list)
        {
            int count = subsets.Count;
            for (int i = 0; i < count; i++)
            {
                var subset = new List<T>(subsets[i]);
                subset.Add(item);
                subsets.Add(subset);
            }
        }

        return subsets;
    }

    public static IEnumerable<IEnumerable<T>> GeneratePermutations<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
    {
        //чек на предмет попарного неравенства по отношению эквивалентности
        var distinctSource = source.Distinct(comparer);
        if (distinctSource.Count() < source.Count())
        {
            throw new ArgumentException("Insufficient distinct elements in the input collection.");
        }
        var list = source.ToList();
        if (list.Count == 0)
        {
            yield return Enumerable.Empty<T>();
        }
        else
        {
            foreach (var item in list)
            {
                var remainingItems = list.Except(new[] { item });
                foreach (var permutation in remainingItems.GeneratePermutations(comparer))
                {
                    yield return permutation.Prepend(item);
                }
            }
        }
    }
}