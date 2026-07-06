using Unity.Mathematics;
using UnityEngine;

public class HighlightItem : MonoBehaviour
{
    public Transform holdReferance;

    [SerializeField] GameObject holdingObject;

    public void Highlight(GameObject _item)
    {
        holdingObject = Instantiate(_item);

        holdingObject.transform.SetParent(holdReferance, false);

        holdingObject.GetComponent<Collider>().isTrigger = false;
    }

    public void Hide()
    {
        Destroy(holdingObject);
    }
}