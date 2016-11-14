package com.itminds;

public class StringHelpers {
    /// <summary>
    /// Method that does not perform well.
    /// </summary>
    /// <param name="strs"></param>
    /// <returns></returns>
    public static String mergeStrings(Iterable<String> strs) {
        String toReturn = "";
        for (String str : strs) {
            toReturn += str;
        }
        return toReturn;
    }
}