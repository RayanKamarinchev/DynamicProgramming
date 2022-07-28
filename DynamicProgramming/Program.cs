//int n = int.Parse(Console.ReadLine());
//long[] nums = new long[n + 1];
//nums[1] = 1;
//nums[2] = 1;
//Console.WriteLine(Fib(n));

//long Fib(long n)
//{
//    if (nums[n] != 0)
//    {
//        return nums[n];
//    }

//    nums[n] = Fib(n - 1) + Fib(n - 2);
//    return nums[n];
//}



int x = int.Parse(Console.ReadLine());
int y = int.Parse(Console.ReadLine());
Dictionary<string, int?> dictionary = new Dictionary<string, int?>();
Console.WriteLine(gridTraveller(x, y));

int? gridTraveller(int x, int y)
{
    string key = $"{x},{y}";
    if (y == 3)
    {
        return (x + 1) * x / 2;
    }

    if (x == 3)
    {
        return (y + 1) * y / 2;
    }
    if (dictionary.ContainsKey(key))
    {
        return dictionary[key];
    }
    dictionary[key] = gridTraveller(x, y - 1) + gridTraveller(x-1, y);
    return dictionary[key];
}