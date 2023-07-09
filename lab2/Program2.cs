using lab2;
class Program2
{
    static void Main(string[] args)
    {
        IEnumerable<int> numbers = new[] { 1, 2, 3 };

        // Генерация всех возможных сочетаний из n элементов по k
        var combinations = numbers.GenerateCombinations(2, EqualityComparer<int>.Default);
        foreach (var combination in combinations)
        {
            Console.WriteLine($"Combination: [{string.Join(", ", combination)}]");
        }

        // Генерация всех возможных подмножеств
        var subsets = numbers.GenerateSubsets(EqualityComparer<int>.Default);
        foreach (var subset in subsets)
        {
            Console.WriteLine($"Subset: [{string.Join(", ", subset)}]");
        }

        // Генерация всех возможных перестановок
        var permutations = numbers.GeneratePermutations(EqualityComparer<int>.Default);
        foreach (var permutation in permutations)
        {
            Console.WriteLine($"Permutation: [{string.Join(", ", permutation)}]");
        }
        //вызов исключения
        numbers = new[] { 1, 2, 2, 3 };
        permutations = numbers.GeneratePermutations(EqualityComparer<int>.Default);
        foreach (var permutation in permutations)
        {
            Console.WriteLine($"Permutation: [{string.Join(", ", permutation)}]");
        }
    }
}