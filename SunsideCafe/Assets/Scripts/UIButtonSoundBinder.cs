using UnityEngine;
using UnityEngine.UI;

public class UIButtonSoundBinder : MonoBehaviour
{
    [SerializeField] private string soundName = "SelectSFX";
    void Start()
    {
        Button[] buttons = FindObjectsOfType<Button>(true);

        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => PlaySound());
        }
    }

    void PlaySound()
    {
        GameEvents.OnPlaySFX?.Invoke(soundName);
    }
}
