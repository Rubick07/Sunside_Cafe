using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    private void Update()
    {
        if (Input.anyKeyDown && startMenu.activeInHierarchy)
        {
            startMenu.SetActive(false);
            MainMenu.instance.Show();
        }
    }
}
