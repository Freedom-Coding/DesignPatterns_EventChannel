using UnityEngine;
using UnityEngine.Events;

public abstract class AbstractEventListener<T> : MonoBehaviour
{
    public AbstractEvent<T> eventToListen;
    public UnityEvent<T> onEvent;

    private void OnEnable()
    {
        eventToListen.Register(this);
    }

    private void OnDisable()
    {
        eventToListen.Unregister(this);
    }

    public void Listen(T value)
    {
        onEvent?.Invoke(value);
    }
}