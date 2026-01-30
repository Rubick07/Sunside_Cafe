using UnityEngine;
using UnityEngine.InputSystem;

public class SideScrollPersonController : MonoBehaviour
{
    [SerializeField] private float currentSpeed = 6f;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float runningSpeed = 10f;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontal = InputManager.Instance.GetMoveInputValue().x;

        Vector3 direction = new Vector3(horizontal, 0f, 0f);

        if (direction.magnitude >= 0.1f)
        {
            if (horizontal > 0)        // ke kanan
                transform.rotation = Quaternion.Euler(0f, 90f, 0f);

            else if (horizontal < 0)   // ke kiri
                transform.rotation = Quaternion.Euler(0f, -90f, 0f);


            characterController.Move(direction * currentSpeed * Time.deltaTime);
        }


        Debug.DrawRay(transform.position, Vector3.forward,Color.red);

    }

    public void SetControllerState(bool enable)
    {
        this.enabled = enable;
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

    private void OnEnable()
    {
        InputManager.Instance.GetInputActions().Player.Interact.performed += Interact_performed;
        InputManager.Instance.GetInputActions().Player.Sprint.performed += Sprint_performed;
        InputManager.Instance.GetInputActions().Player.Sprint.canceled += Sprint_canceled;
        InputManager.Instance.GetInputActions().Player.Pause.performed += Pause_performed;
    }

    private void OnDisable()
    {
        InputManager.Instance.GetInputActions().Player.Interact.performed -= Interact_performed;
        InputManager.Instance.GetInputActions().Player.Sprint.performed -= Sprint_performed;
        InputManager.Instance.GetInputActions().Player.Sprint.canceled -= Sprint_canceled;
        InputManager.Instance.GetInputActions().Player.Pause.performed -= Pause_performed;
    }

}
