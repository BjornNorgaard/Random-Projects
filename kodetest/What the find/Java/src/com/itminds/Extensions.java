package com.itminds;

import java.util.function.Predicate;
import java.util.function.Function;

public class Extensions {
    /// <summary>
    /// Find any node in an object graph that satisfy a given predicate and return it.
    /// </summary>
    /// <typeparam name="T">Type of object.</typeparam>
    /// <param name="root">The root node.</param>
    /// <param name="predicate">The given condition to satisfy.</param>
    /// <param name="getChildren">Child selector.</param>
    /// <returns>Node satisfying the condtion, else null.</returns>

    public static <T> T findWhere(T root, Predicate<T> predicate, Function<T, Iterable<T>> getChildren) {
        // YOUR SOLUTION GOES HERE
        throw new UnsupportedOperationException();
    }
}