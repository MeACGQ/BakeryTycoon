using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class HighlightItem : MonoBehaviour
{
    public GameObject holdReferance;

    [SerializeField] GameObject holdingObject;

    public void Highlight(GameObject item)
    {
        holdingObject = Instantiate(item, new Vector3(holdReferance.transform.position.x,
            holdReferance.transform.position.y,
            holdReferance.transform.position.z),
            new Quaternion(), holdReferance.transform);
    }

    public void Hide()
    {
        Destroy(holdingObject);
    }
}
