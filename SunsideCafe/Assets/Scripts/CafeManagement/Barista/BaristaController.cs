using UnityEngine;

public class BaristaController : MonoBehaviour
{
    private void Start()
    {
        InputManager.Instance.GetInputActions().Player.OpenMenu.performed += OpenMenu_performed;
        //InputManager.Instance.GetInputActions().Player.OpenMenu.canceled += OpenMenu_canceled; ;
    }

    private void OpenMenu_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        RecipeManagerUI.instance.Hide();
    }

    private void OpenMenu_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        RecipeManagerUI.instance.Toggle();
    }
}
