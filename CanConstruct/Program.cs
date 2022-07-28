Dictionary<string, bool> memo = new Dictionary<string, bool>();

Console.WriteLine(CanConstr("abcdef", new string[] {"ab", "abc", "cd", "def", "abcd"}));
Console.WriteLine(CanConstr("skateboard", new string[] {"bo", "rd", "ate", "t", "ska", "sk", "boar"}));
Console.WriteLine(CanConstr("eeeeeeeeeeeeeeeeeeeeeeeeeeeef", new string[]
{
    "e",
    "ee",
    "eee",
    "eeee"
}));

bool CanConstr(string word, string[] chars)
{
    if (memo.ContainsKey(word))
    {
        return memo[word];
    }
    if (word == "")
    {
        return true;
    }

    for (int i = 0; i < chars.Length; i++)
    {
        string val = chars[i];
        if (word.StartsWith(val))
        {
            memo[word] = CanConstr(word.Substring(val.Length), chars);
            if (memo[word])
            {
                return true;
            }
            continue;
        }
    }
    return false;
}