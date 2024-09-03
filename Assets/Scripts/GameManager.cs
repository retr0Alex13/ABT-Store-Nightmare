using UnityEngine;
using Player.Controls;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private FirstPersonController playerControls;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    public void TogglePlayerCapabilities()
    {
        playerControls.SetIsFreezed(!playerControls.IsFreezed);
    }
}
