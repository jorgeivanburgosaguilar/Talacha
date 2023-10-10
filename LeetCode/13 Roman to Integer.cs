/*
13 Roman to Integer
Runtime: 91 ms, faster than 72.05% of C# online submissions for Roman to Integer.
Memory Usage: 36.9 MB, less than 49.07% of C# online submissions for Roman to Integer.
*/
public class Solution
{
    public int RomanToInt(string s)
    {
        var suma = 0;
        var ultimoIndice = s.Length - 1;

        for (var i = 0; i < s.Length; i++)
        {
            var esUltimoIndice = ultimoIndice == i;

            if (s[i] == 'M')
            {
                suma += 1000;
                continue;
            }

            if (s[i] == 'D')
            {
                suma += 500;
                continue;
            }

            if (s[i] == 'L')
            {
                suma += 50;
                continue;
            }

            if (s[i] == 'V')
            {
                suma += 5;
                continue;
            }

            if (s[i] == 'C')
            {
                if (esUltimoIndice)
                {
                    suma += 100;
                    break;
                }

                if (s[i + 1] == 'D')
                {
                    suma += 400;
                    i++;
                    continue;
                }
                else if (s[i + 1] == 'M')
                {
                    suma += 900;
                    i++;
                    continue;
                }
                else
                {
                    suma += 100;
                    continue;
                }
            }

            if (s[i] == 'X')
            {
                if (esUltimoIndice)
                {
                    suma += 10;
                    break;
                }

                if (s[i + 1] == 'L')
                {
                    suma += 40;
                    i++;
                    continue;
                }
                else if (s[i + 1] == 'C')
                {
                    suma += 90;
                    i++;
                    continue;
                }
                else
                {
                    suma += 10;
                    continue;
                }
            }

            if (s[i] == 'I')
            {
                if (esUltimoIndice)
                {
                    suma += 1;
                    break;
                }

                if (s[i + 1] == 'V')
                {
                    suma += 4;
                    i++;
                    continue;
                }
                else if (s[i + 1] == 'X')
                {
                    suma += 9;
                    i++;
                    continue;
                }
                else
                {
                    suma += 1;
                    continue;
                }
            }
        }

        return suma;
    }
}

Console.WriteLine(new Solution().RomanToInt("MCMXCIV"));