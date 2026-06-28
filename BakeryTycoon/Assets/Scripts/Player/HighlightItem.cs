using Unity.Mathematics;
using UnityEngine;

public class HighlightItem : MonoBehaviour
{
    public Transform holdReferance;

    [SerializeField] GameObject holdingObject;

    public void Highlight(GameObject _item)
    {
        holdingObject = Instantiate(_item, new Vector3(holdReferance.transform.position.x,
            holdReferance.transform.position.y,
            holdReferance.transform.position.z),
            new Quaternion(), holdReferance.transform);

        holdingObject.GetComponent<Collider>().isTrigger = false;
    }

    public void Hide()
    {
        Destroy(holdingObject);
    }
}