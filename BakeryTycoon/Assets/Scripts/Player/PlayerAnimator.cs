using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    public void RunPlayer()
    {
        playerAnimator.SetFloat("speed", 3);
    }

    public void StopPlayer()
    {
        playerAnimator.SetFloat("speed", 1);
    }
}
