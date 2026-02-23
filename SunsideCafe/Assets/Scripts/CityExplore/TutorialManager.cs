using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;

    private void Awake()
    {
        instance = this;
    }



}
