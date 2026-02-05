using UnityEngine;

public class ScheduleController : MonoBehaviour
{

    private void OnEnable()
    {
        InputManager.Instance.GetInputActions().Player.RotateSchedule.performed += RotateSchedule_performed;
        InputManager.Instance.GetInputActions().Player.DeleteSchedule.performed += DeleteSchedule_performed;
    }
    private void OnDisable()
    {
        InputManager.Instance.GetInputActions().Player.RotateSchedule.performed -= RotateSchedule_performed;
    }

    private void DeleteSchedule_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {

    }

    private void RotateSchedule_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {

    }
}
