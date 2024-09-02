using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    private GameEvent gameEvent;
    [SerializeField]
    private UnityEvent response;

    private void Awake()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDestroy()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        response.Invoke();
    }
}
