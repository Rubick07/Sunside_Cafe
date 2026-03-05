using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Testing : MonoBehaviour
{
    [SerializeField] private string statID;
    [SerializeField] private int amount = 1;
    [SerializeField] private TutorialTriggerType triggerType;
    [SerializeField] private DaySystemUI test;
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
            test.Hide();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            test.Show();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.UnloadSceneAsync("Cafe_Barista");
            SceneManager.SetActiveScene(
                SceneManager.GetSceneByName("City_Area")
            );
        }

    }

    public GameObject notePrefab;
    public Transform spawnPoint;

    public void SpawnNote()
    {
        Instantiate(notePrefab, spawnPoint.position, Quaternion.identity, spawnPoint);
    }
}
