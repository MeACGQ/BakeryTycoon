using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerAnimator animator;
    [SerializeField] private PlayerMovement playerMovement;

    public bool isRunning;

    private void Start()
    {
        animator = GetComponentInChildren<PlayerAnimator>();
    }

    public void MovePlayer(Vector3 _moveDirection)
    {
        playerMovement.MovePlayer(_moveDirection);
    }

    public void PlayRun()
    {
        isRunning = true;

        animator.RunPlayer();
    }

    public void StopRun()
    {
        isRunning = false;

        animator.StopPlayer();
    }
}
