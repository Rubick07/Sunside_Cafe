using UnityEngine;

public class MindfullnessTutorial : MonoBehaviour
{
    int count;

    private void Start()
    {
        MindfulnessManager.instance.OnSuccessHit += MindfulnessManager_OnSuccessHit;    
    }

    private void MindfulnessManager_OnSuccessHit(object sender, System.EventArgs e)
    {
        count++;

        if(count == 2)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        MindfulnessManager.instance.OnSuccessHit -= MindfulnessManager_OnSuccessHit;

    }

}
