using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEvent<T> : ScriptableObject
{
    public T testingValue;
    private List<AbstractEventListener<T>> listeners;

    public void Register(AbstractEventListener<T> listener)
    {
        if (!listeners.Contains(listener))
        {
            listeners.Add(listener);
        }
    }

    public void Unregister(AbstractEventListener<T> listener)
    {
        if (listeners.Contains(listener))
        {
            listeners.Remove(listener);
        }
    }

    public void Invoke(T value)
    {
        foreach (AbstractEventListener<T> listener in listeners)
        {
            listener.Listen(value);
        }
    }
}