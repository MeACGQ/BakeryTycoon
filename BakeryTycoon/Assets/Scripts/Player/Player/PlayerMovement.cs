using Unity.Mathematics;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject playerObject;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    public void MovePlayer(Vector3 _moveDirection)
    {
        transform.position += _moveDirection.normalized * moveSpeed * Time.deltaTime;

        if (_moveDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_moveDirection);

            playerObject.transform.rotation = Quaternion.Slerp(
            playerObject.transform.rotation,
            targetRotation,
            rotateSpeed * Time.deltaTime);
        }
    }
}
