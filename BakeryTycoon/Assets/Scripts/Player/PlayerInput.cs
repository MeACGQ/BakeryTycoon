using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputs inputs;
    PlayerMovement playerMovement;

    [SerializeField] private FloatingJoystick joystick;

    private void Awake()
    {
        inputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        inputs.Enable();
    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        playerMovement.MovePlayer(new Vector3(
            joystick.Horizontal,
            0f,
            joystick.Vertical));
    }
}