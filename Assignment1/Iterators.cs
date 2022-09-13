namespace Assignment1;

public static class Iterators
{
    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)
    {
        foreach (var outer in items)
        {
            foreach (var inner in outer)
            {
                yield return inner;
            }
        }
    }

    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate) => throw new NotImplementedException();
}
