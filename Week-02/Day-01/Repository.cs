using System;
using System.Collections.Generic;
using System.Linq;
//Restricts T to reference types only.
public class Repository<T> where T : class
{
    private readonly List<T> _items = new();
    public void Add(T item)
    {
        _items.Add(item);
    }

    public IReadOnlyList<T> GetAll()
    {
        return _items.AsReadOnly();
    }

    public T? Find(Func<T, bool> predicate)
    {
        return _items.FirstOrDefault(predicate);
    }
}