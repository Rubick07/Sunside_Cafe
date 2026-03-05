using UnityEngine;

public class ScheduleController : MonoBehaviour
{

    private void OnEnable()
    {
        InputManager.Instance.GetInputActions().Player.RotateScheduleLeft.performed += RotateScheduleLeft_performed;
        InputManager.Instance.GetInputActions().Player.RotateScheduleRight.performed += RotateScheduleRight_performed;


        InputManager.Instance.GetInputActions().Player.DeleteSchedule.performed += DeleteSchedule_performed;
    }

    private void OnDisable()
    {
        InputManager.Instance.GetInputActions().Player.RotateScheduleLeft.performed -= RotateScheduleLeft_performed;
        InputManager.Instance.GetInputActions().Player.RotateScheduleRight.performed -= RotateScheduleRight_performed;

    }

    private void DeleteSchedule_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Vector2Int pos = ShiftSlotUI.currentHoverShiftSlotUI.GetPos();
        var employee = ScheduleManager.instance.GetEmployeeFromGrid(pos.x, pos.y);

        EmployeeCardUI employeeCardUI = EmployeeListUI.instance.GetEmployeeCardUI(employee);
        employeeCardUI.enabled = true;
        employeeCardUI.SetBlockerDisable();

        ScheduleManager.instance.Remove(employee);

    }

    private void RotateScheduleLeft_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        EmployeeCardUI.currentEmployeeCard.RotateLeft();

        ShiftSlotUI.currentHoverShiftSlotUI.RefreshPreview();
    }
    private void RotateScheduleRight_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        EmployeeCardUI.currentEmployeeCard.RotateRight();

        ShiftSlotUI.currentHoverShiftSlotUI.RefreshPreview();
    }

}
