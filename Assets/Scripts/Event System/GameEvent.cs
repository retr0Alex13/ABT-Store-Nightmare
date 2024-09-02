using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event", order = 52)]
public class GameEvent : ScriptableObject
{
    private HashSet<GameEventListener> listeners = new HashSet<GameEventListener>();

    public void Raise()
    {
        foreach (GameEventListener listener in listeners)
        {
            listener.OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
