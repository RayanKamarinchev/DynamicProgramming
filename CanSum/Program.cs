Dictionary<int, bool> list = new Dictionary<int, bool>();
Console.WriteLine(CanSum(3000, new int[] { 7, 14, 36, 86, 93 }));
bool CanSum(int n, int[] arr)
{
    if (list.ContainsKey(n))
    {
        return list[n];
    }
    if (n == 0)
    {
        return true;
    }

    if (n < 0)
    {
        return false;
    }
    for (int i = 0; i < arr.Length; i++)
    {
        if (n >= arr[i])
        {
            list[n] = CanSum(n - arr[i], arr);
            if (list[n])
            {
                return true;
            }
        }
    }
    return false;
}