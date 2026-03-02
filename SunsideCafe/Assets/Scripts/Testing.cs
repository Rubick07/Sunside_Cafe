using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Testing : MonoBehaviour
{
    [SerializeField] private string statID;
    [SerializeField] private int amount = 1;
    [SerializeField] private TutorialTriggerType triggerType;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DialogRunnerSingleton.instance.StartDialog("Placeholder");
            TutorialManager.instance.TriggerTutorial(triggerType);
            GameEvents.OnStatChanged?.Invoke(statID, amount);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log(DialogRunnerSingleton.instance);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(LoadMiniGame());
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.UnloadSceneAsync("Cafe_Barista");
            SceneManager.SetActiveScene(
                SceneManager.GetSceneByName("City_Area")
            );
        }

    }
    IEnumerator LoadMiniGame()
    {
        yield return SceneManager.LoadSceneAsync(
            "Cafe_Barista",
            LoadSceneMode.Additive
        );

        SceneManager.SetActiveScene(
            SceneManager.GetSceneByName("Cafe_Barista")
        );

        // optionally disable explore camera
    }
}
