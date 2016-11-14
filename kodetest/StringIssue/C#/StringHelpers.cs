using System.Collections.Generic;

namespace StringIssue
{
    public static class StringHelpers
	{
		/// <summary>
		/// Method that does not perform well.
		/// </summary>
		/// <param name="strs"></param>
		/// <returns></returns>
		public static string MergeStrings(IEnumerable<string> strs)
		{
            return string.Join("", strs);
        }
    }
}

/* Explain why your solution is faster below this line
    The original solution is very slow because it is the same as writing:
    'toReturn = toReturn + str' which overwrites the entire string with
    itself, only with a minor addition, instead of just adding the new part.

    My solution is much faster because 'String.Join()' appends elements to
    the string without constantly accessing the entire string again. From what
    I understand, it does this in a way familiar to a linked link.
*/
