/*
412 Fizz Buzz
Runtime: 163 ms, faster than 79.76% of C# online submissions for Fizz Buzz.
Memory Usage: 53.9 MB, less than 12.45% of C# online submissions for Fizz Buzz.
*/
public class Solution
{
    public IList<string> FizzBuzz(int n)
    {
        var answer = new string[n];
        for (var i = 1; i <= n; i++)
        {
            var currentValue = string.Empty;
                
            if (i % 3 == 0)
                currentValue += "Fizz";
                
            if (i % 5 == 0)
                currentValue += "Buzz";
                
            if (string.IsNullOrEmpty(currentValue))
                currentValue = i.ToString();
            
            answer[i - 1] = currentValue;
        }
        
        return answer;
    }
}