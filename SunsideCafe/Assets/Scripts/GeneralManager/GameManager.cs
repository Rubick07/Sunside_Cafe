using UnityEngine;
using System;
using Yarn.Unity;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        EXPLORE,
        BARISTA,
        SCHEDULE

    }

    public static GameManager instance;

    public event EventHandler<GameState> OnGameStateChanged;
    public event EventHandler OnGameSceneUnloadChanged;

    [SerializeField] private GameState gameState;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    public void ChangeGameState(GameState newgameState)
    {
        gameState = newgameState;

        OnGameStateChanged?.Invoke(this, gameState);
    }

    [YarnCommand("AddScene")]
    public void AddScene(string sceneName)
    {
        StartCoroutine(LoadMiniGame(sceneName));
    }
    [YarnCommand("RemoveScene")]
    public void ClearMinigamesScene()
    {
        RemoveScene();
    }

    IEnumerator LoadMiniGame(string sceneName)
    {
        ChangeGameState(GameState.BARISTA);

        yield return SceneManager.LoadSceneAsync(
            sceneName,
            LoadSceneMode.Additive
        );

        SceneManager.SetActiveScene(
            SceneManager.GetSceneByName(sceneName)
        );

        // optionally disable explore camera
    }

    public void RemoveScene()
    {
        ChangeGameState(GameState.EXPLORE);

        Scene cafeScene = SceneManager.GetActiveScene();

        SceneManager.SetActiveScene(
            SceneManager.GetSceneByName("City_Area")
        );

        SceneManager.UnloadSceneAsync(cafeScene);

        OnGameSceneUnloadChanged?.Invoke(this, EventArgs.Empty);
    }

}
