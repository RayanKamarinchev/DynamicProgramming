Dictionary<string, int> memo = new Dictionary<string, int>();

Console.WriteLine(CountConstruct("abcdef", new string[] { "ab", "abc", "cd", "def", "abcd" }));
Console.WriteLine(CountConstruct("skateboard", new string[] { "bo", "rd", "ate", "t", "ska", "sk", "boar" }));
Console.WriteLine(CountConstruct("eeeeeeeeeeeeeeeeeeeeeeeeeeeee", new string[]
{
    "e",
    "ee",
    "eee",
    "eeee"
}));
int CountConstruct(string word, string[] chars) => (CountConstructHidden(word, chars) - 1);
int CountConstructHidden(string word, string[] chars)
{
    if (memo.ContainsKey(word))
    {
        return memo[word];
    }
    if (word == "")
    {
        return 1;
    }

    for (int i = 0; i < chars.Length; i++)
    {
        string val = chars[i];
        if (word.StartsWith(val))
        {
            memo[word] = CountConstructHidden(word.Substring(val.Length), chars);
            if (memo[word] > 0)
            {
                return memo[word] + 1;
            }
            continue;
        }
    }
    return 0;
}