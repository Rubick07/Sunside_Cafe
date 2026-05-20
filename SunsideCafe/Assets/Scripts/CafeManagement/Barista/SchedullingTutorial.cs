using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SchedullingTutorial : MonoBehaviour
{
    [SerializeField] private GameObject leftclickTutorialGameobject;
    [SerializeField] private GameObject rightclickTutorialGameobject;
    [SerializeField] private GameObject rotateTutorialGameobject;
    [SerializeField] private Image headerHighlightImage;

    [Header("Highlight REFERENCE")]
    [SerializeField] private GameObject leftClickHighlightGameobject;
    [SerializeField] private GameObject placeTutorialhighlightGameobject;
    [SerializeField] private GameObject rightClickHighlightGameobject;
    [SerializeField] private GameObject rotateClickHighlightGameobject;

    [SerializeField] private EmployeeData employeeData;

    private void Start()
    {
        leftclickTutorialGameobject.SetActive(true);
        rightclickTutorialGameobject.SetActive(false);
        rotateTutorialGameobject.SetActive(false);

        leftClickHighlightGameobject.SetActive(true);
        placeTutorialhighlightGameobject.SetActive(false);
        rightClickHighlightGameobject.SetActive(false);
        rotateClickHighlightGameobject.SetActive(false);

        ScheduleManager.instance.AssignEmployee(3, 2, employeeData);

        headerHighlightImage.fillAmount = 0;

        EmployeeCardUI.OnAnyCardBeginDrag += EmployeeCardUI_OnAnyCardBeginDrag;
        ScheduleManager.instance.OnAssignedEmployeeChanged += ScheduleManager_OnAssignedEmployeeChanged;

        //EmployeeListUI.instance.RemoveEmployeeCard(employeeData);
    }

    private void EmployeeCardUI_OnAnyCardBeginDrag(object sender, System.EventArgs e)
    {
        leftClickHighlightGameobject.SetActive(false);
        placeTutorialhighlightGameobject.SetActive(true);

        EmployeeCardUI.OnAnyCardBeginDrag -= EmployeeCardUI_OnAnyCardBeginDrag;
    }

    private void ScheduleManager_OnAssignedEmployeeChanged(object sender, EmployeeData e)
    {
        headerHighlightImage.DOFillAmount(1f, 1f).OnComplete(()=> 
        {
            leftclickTutorialGameobject.SetActive(false);
            rightclickTutorialGameobject.SetActive(true);

            placeTutorialhighlightGameobject.SetActive(false);
            rightClickHighlightGameobject.SetActive(true);

            ScheduleManager.instance.OnAssignedEmployeeChanged -= ScheduleManager_OnAssignedEmployeeChanged;

            ScheduleManager.instance.OnAssignedEmployeeChanged += DeleteTutorial;

            headerHighlightImage.fillAmount = 0;

        });
    }

    private void DeleteTutorial(object sender, EmployeeData e)
    {
        headerHighlightImage.DOFillAmount(1f, 1f).OnComplete(() =>
        {
            rightclickTutorialGameobject.SetActive(false);
            rotateTutorialGameobject.SetActive(true);

            rightClickHighlightGameobject.SetActive(false);
            rotateClickHighlightGameobject.SetActive(true);


            ScheduleManager.instance.OnAssignedEmployeeChanged -= DeleteTutorial;

            InputManager.Instance.GetInputActions().Player.RotateScheduleLeft.performed += RotateScheduleLeft_performed;
            InputManager.Instance.GetInputActions().Player.RotateScheduleRight.performed += RotateScheduleRight_performed;

            ScheduleManager.instance.OnAssignedEmployeeChanged += PlaceL;

            headerHighlightImage.fillAmount = 0;

        });

    }

    private void PlaceL(object sender, EmployeeData e)
    {
        rotateClickHighlightGameobject.SetActive(false);
        ScheduleManager.instance.OnAssignedEmployeeChanged -= PlaceL;

    }

    private void RotateScheduleRight_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        headerHighlightImage.DOFillAmount(1f, 1f).OnComplete(()=> 
        {
            rotateTutorialGameobject.SetActive(false);
            headerHighlightImage.fillAmount = 0;

        });


        InputManager.Instance.GetInputActions().Player.RotateScheduleLeft.performed -= RotateScheduleLeft_performed;
        InputManager.Instance.GetInputActions().Player.RotateScheduleRight.performed -= RotateScheduleRight_performed;
    }

    private void RotateScheduleLeft_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        headerHighlightImage.DOFillAmount(1f, 1f).OnComplete(() =>
        {
            rotateTutorialGameobject.SetActive(false);
            headerHighlightImage.fillAmount = 0;

        });

        InputManager.Instance.GetInputActions().Player.RotateScheduleLeft.performed -= RotateScheduleLeft_performed;
        InputManager.Instance.GetInputActions().Player.RotateScheduleRight.performed -= RotateScheduleRight_performed;
    }

}
