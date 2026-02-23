using UnityEngine;
using System;

public class BaristaManager : MonoBehaviour
{
    public static BaristaManager instance;

    public event EventHandler<baristaGameState> OnGameStateChanged;


    public enum baristaGameState
    {
        NotStart,
        Open,
        FriendSession,
        Close
    }

    [SerializeField] private baristaGameState gameState;
    [SerializeField] private float timer;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        switch (gameState)
        {
            case baristaGameState.NotStart:
                break;

            case baristaGameState.Open:
                timer -= Time.deltaTime;

                if (timer <= 0)
                    ChangeBaristaManagerState(baristaGameState.FriendSession);


                break;

            case baristaGameState.FriendSession:

                break;

            case baristaGameState.Close:

                break;

        }
    }

    public void ChangeBaristaManagerState(baristaGameState b)
    {
        if (b == gameState)
            return;

        gameState = b;

        OnGameStateChanged?.Invoke(this, b);
    }

    public float GetTimer() => timer;
    public baristaGameState GetBaristaGameState() => gameState;
}
