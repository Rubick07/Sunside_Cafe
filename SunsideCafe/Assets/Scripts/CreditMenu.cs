using UnityEngine;
using UnityEngine.UI;

public class CreditMenu : MonoBehaviour
{
    [SerializeField] private Button creditButton;

    private void Start()
    {
        creditButton.onClick.AddListener(()=> 
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });

        GameEvents.OnPlayMusic("ExploreNight");
    }
}
