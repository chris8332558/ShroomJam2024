using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
    public static UnityEvent GetElectron = new UnityEvent();
    public static UnityEvent GetBug = new UnityEvent();
    public static UnityEvent GameOver = new UnityEvent();
}
