using UnityEngine;

public class SideScrollAnimator : MonoBehaviour
{
    [SerializeField] private Animator animator;

    SideScrollPersonController personController;
    

    private void Awake()
    {
        personController = GetComponentInParent<SideScrollPersonController>();
    }

    private void Start()
    {
        personController.OnPlayerMove += PersonController_OnPlayerMove;
        personController.OnPlayerIdle += PersonController_OnPlayerIdle;
    }

    private void PersonController_OnPlayerIdle(object sender, System.EventArgs e)
    {
        animator.SetBool("IsWalk", false);
    }

    private void PersonController_OnPlayerMove(object sender, System.EventArgs e)
    {
        animator.SetBool("IsWalk", true);
        animator.SetFloat("Dir", personController.GetPlayerDir());
    }
}
