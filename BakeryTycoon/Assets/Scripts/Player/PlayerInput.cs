using Unity.VisualScripting;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputs inputs;
    [SerializeField] Player player;

    [SerializeField] private FloatingJoystick joystick;

    private void Awake()
    {
        inputs = new PlayerInputs();
    }

    private void OnEnable()
    {
        inputs.Enable();

        inputs.PlayerActionMap.TouchPress.performed += ctx => player.PlayRun();

        inputs.PlayerActionMap.TouchPress.canceled += ctx => player.StopRun();
    }

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        player.MovePlayer(new Vector3(joystick.Horizontal, 0f, joystick.Vertical));
    }
}