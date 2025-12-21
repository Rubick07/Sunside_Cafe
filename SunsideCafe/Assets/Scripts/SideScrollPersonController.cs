using UnityEngine;
using UnityEngine.InputSystem;

public class SideScrollPersonController : MonoBehaviour
{
    [SerializeField] private float speed = 6f;

    private CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        InputManager.Instance.GetInputActions().Player.Interact.performed += Interact_performed;
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


            characterController.Move(direction * speed * Time.deltaTime);
        }


        Debug.DrawRay(transform.position, Vector3.forward,Color.red);

    }

    private void Interact_performed(InputAction.CallbackContext obj)
    {
        InteractSystem.instance.SideScrollInteractCheck(transform);
    }

}
