using System.Collections.Generic;
using System.Linq;

namespace Basic.HashMap
{
    public static class FindFirstNonRepeatedCharacter
    {
        public static char Find(string arg)
        {
            var dictionary = new Dictionary<char, int>();
            
            foreach (var ar in arg.Where(x => x != ' '))
            {
                if (dictionary.ContainsKey(ar))
                    dictionary[ar] = dictionary[ar] + 1;
                else
                    dictionary.Add(ar, 1);
            }

            return dictionary.FirstOrDefault(x => x.Value == 1).Key;
        }
    }
}