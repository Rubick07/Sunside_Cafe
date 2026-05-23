using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class SideScrollPersonController : MonoBehaviour
{
    public enum playerState
    {
        NORMAL,
        DIALOG,
        OPENSHOP,
        JOURNAL,
        TUTORIAL
    }

    public event EventHandler OnPlayerMove;
    public event EventHandler OnPlayerIdle;

    [SerializeField] private float currentSpeed = 6f;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float runningSpeed = 10f;

    private playerState state;

    private CharacterController characterController;
    float horizontal;
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        horizontal = InputManager.Instance.GetMoveInputValue().x;

        Vector3 direction = new Vector3(horizontal, 0f, 0f);

        if (direction.magnitude >= 0.1f)
        {

/*
            if (horizontal > 0)        // ke kanan
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);

            else if (horizontal < 0)   // ke kiri
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);
*/
            OnPlayerMove?.Invoke(this, EventArgs.Empty);
            characterController.Move(direction * currentSpeed * Time.deltaTime);
        }

        //Debug.DrawRay(transform.position, Vector3.forward,Color.red);
    }

    public void SetControllerActive(bool enable)
    {
        this.enabled = enable;
    }

    public void SetControllerState(playerState playerstate)
    {
        state = playerstate;
    }

    public playerState GetControllerState() => state;

    private void Move_canceled(InputAction.CallbackContext obj)
    {
        if (state == playerState.NORMAL)
        {
            ExploreUI.instance.StartCountdown();
            ObjectiveManagerUI.instance.StartCountdown();
        }

        horizontal = 0;
        OnPlayerIdle?.Invoke(this, EventArgs.Empty);
    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        if (state == playerState.NORMAL)
        {
            ExploreUI.instance.Hide();
            ObjectiveManagerUI.instance.Hide();
        }

        var control = obj.control;

        if (control.name == "a")
        {
            horizontal = -1;
        }
        else if (control.name == "d")
        {
            horizontal = 1;
        }
        OnPlayerMove?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        InteractSystem.instance.SideScrollInteractCheck(transform);
    }

    private void Sprint_performed(InputAction.CallbackContext obj)
    {
        currentSpeed = runningSpeed;
    }
    private void Sprint_canceled(InputAction.CallbackContext obj)
    {
        currentSpeed = speed;
    }
    private void Pause_performed(InputAction.CallbackContext obj)
    {
        PauseSystem.instance.Pause();
    }
    private void Journal_performed(InputAction.CallbackContext obj)
    {
        if (state == playerState.NORMAL || state == playerState.JOURNAL)
            JournalUI.instance.ToggleJournal();


    }



    private void ActionSetUp()
    {
        InputManager.Instance.GetInputActions().Player.Move.performed += Move_performed;
        InputManager.Instance.GetInputActions().Player.Move.canceled += Move_canceled;
        InputManager.Instance.GetInputActions().Player.Interact.performed += Interact_performed;
        InputManager.Instance.GetInputActions().Player.Sprint.performed += Sprint_performed;
        InputManager.Instance.GetInputActions().Player.Sprint.canceled += Sprint_canceled;
        InputManager.Instance.GetInputActions().Player.Pause.performed += Pause_performed;
        InputManager.Instance.GetInputActions().Player.Journal.performed += Journal_performed;
    }
    private void ActionDisable()
    {
        horizontal = 0;

        InputManager.Instance.GetInputActions().Player.Move.performed -= Move_performed;
        InputManager.Instance.GetInputActions().Player.Move.canceled -= Move_canceled;
        InputManager.Instance.GetInputActions().Player.Interact.performed -= Interact_performed;
        InputManager.Instance.GetInputActions().Player.Sprint.performed -= Sprint_performed;
        InputManager.Instance.GetInputActions().Player.Sprint.canceled -= Sprint_canceled;
        InputManager.Instance.GetInputActions().Player.Pause.performed -= Pause_performed;
        InputManager.Instance.GetInputActions().Player.Journal.performed -= Journal_performed;

        OnPlayerIdle?.Invoke(this, EventArgs.Empty);
    }

    public float GetPlayerDir() => horizontal;

    [Yarn.Unity.YarnCommand("DisablePlayer")]
    public void Hide() => gameObject.SetActive(false);

    private void OnEnable()
    {
        ActionSetUp();
    }
    private void OnDisable()
    {
        ActionDisable();
    }


}
