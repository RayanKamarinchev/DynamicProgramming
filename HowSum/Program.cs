Dictionary<int, List<int>> memo = new Dictionary<int, List<int>>();
List<int> result = null;
int[] input = mergeSort(new int[] { 7, 14, 3 });
List<int> output = HowSum(3000, input);
if (output == null)
{
    Console.WriteLine("null");
    return;
}

Console.WriteLine(String.Join(',', output));

List<int> HowSum(int n, int[] arr)
{
    arr = mergeSort(arr);
    if (memo.ContainsKey(n))
    {
        return memo[n];
    }

    if (n == 0)
    {
        result = new List<int>();
        return result;
    }

    if (n < 0)
    {
        return null;
    }

    for (int i = arr.Length - 1; i >= 0; i--)
    {
        if (HowSum(n - arr[i], arr) != null)
        {
            result.Add(arr[i]);
            memo[n] = result;
            return result;
        }
    }

    memo[n] = null;
    return result;
}

static int[] mergeSort(int[] array)
{
    int[] left;
    int[] right;
    int[] result = new int[array.Length];
    if (array.Length <= 1)
        return array;
    int midPoint = array.Length / 2;
    left = new int[midPoint];
    right = array.Length % 2 == 0 ? new int[midPoint] : new int[midPoint + 1];
    for (int i = 0; i < midPoint; i++)
    {
        left[i] = array[i];
    }

    int x = 0;
    for (int i = midPoint; i < array.Length; i++)
    {
        right[x] = array[i];
        x++;
    }

    left = mergeSort(left);
    right = mergeSort(right);
    result = merge(left, right);
    return result;
}

static int[] merge(int[] left, int[] right)
{
    int resultLength = right.Length + left.Length;
    int[] result = new int[resultLength];
    int indexLeft = 0, indexRight = 0, indexResult = 0;
    while (indexLeft < left.Length || indexRight < right.Length)
    {
        if (indexLeft < left.Length && indexRight < right.Length)
        {
            if (left[indexLeft] <= right[indexRight])
            {
                result[indexResult] = left[indexLeft];
                indexLeft++;
            }
            else
            {
                result[indexResult] = right[indexRight];
                indexRight++;
            }

            indexResult++;
        }
        else if (indexLeft < left.Length)
        {
            result[indexResult] = left[indexLeft];
            indexLeft++;
            indexResult++;
        }
        else if (indexRight < right.Length)
        {
            result[indexResult] = right[indexRight];
            indexRight++;
            indexResult++;
        }
    }

    return result;
}