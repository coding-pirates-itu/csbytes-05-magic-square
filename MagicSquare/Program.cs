using MagicSquare;

Console.Write("Enter square size: ");
var line = Console.ReadLine();
if (line == null || string.IsNullOrWhiteSpace(line) || !int.TryParse(line, out var size)) return;

var numbers = new int[size * size];

// Initialize
for (var i = 0; i <  numbers.Length; i++)
    numbers[i] = i + 1;

// Search for solution
var start = DateTime.Now;
var found = false;
var generator = new MagicSquare.LehmerPermutations(size);

foreach (var perm in generator.Generate(numbers))
{
    if (IsSolution(perm, true))
    {
        PrintSquare(perm);
        found = true;
        break;
    }
}

if (!found)
    Console.WriteLine("Solution not found.");
Console.WriteLine($"Time used: {DateTime.Now - start}");


bool IsSolution(IList<int> numbers, bool checkDiagonal)
{
    var expected = size * (size * size + 1) / 2;

    for (var y = 0; y < size; y++)
    {
        var sum = 0;
        for (var x = 0; x < size; x++)
            sum += numbers[y * size + x];

        if (sum != expected) return false;
    }

    for (var x = 0; x < size; x++)
    {
        var sum = 0;
        for (var y = 0; y < size; y++)
            sum += numbers[y * size + x];

        if (sum != expected) return false;
    }

    if (checkDiagonal)
    {
        var sum1 = 0;
        var sum2 = 0;
        for (var c = 0; c < size; c++)
        {
            sum1 += numbers[c * size + c];
            sum2 += numbers[c * size + size - c - 1];
        }

        if (sum1 != expected) return false;
        if (sum2 != expected) return false;
    }

    return true;
}


void PrintSquare(IList<int> numbers)
{
    for (var y = 0; y < size; y++)
    {
        for (var x = 0; x < size; x++)
            Console.Write($"{numbers[y * size + x],3:0}");

        Console.WriteLine();
    }
}
