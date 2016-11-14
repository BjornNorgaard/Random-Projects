using System.Collections.Generic;
using System.Linq;

namespace SecretAgent
{
    public class FindSecretAgent : IFindSecretAgent
    {
        public int StartSearch(IEnumerable<int> ids)
        {
            var query = ids
                // group the numbers by value.
                .GroupBy(i => i)
                // if a group has Count bigger than 1, we have found the traitor!
                .Where(g => g.Count() > 1)
                // create new list.
                .ToList();

            if (!query.Any())
            {
                return -1; // or throw an exception or something better depending on system.
            }

            return query[0].Key;
        }
    }
}
