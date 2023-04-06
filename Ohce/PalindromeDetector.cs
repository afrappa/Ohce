namespace Ohce;

public class PalindromeDetector : IPalindromeDetector
{
    public bool IsPalindrome(string input)
    {
        for (int i = 0, j = input.Length - 1; i <= j; i++, j--)
            if (input[i] != input[j])
                return false;

        return true;
    }
}