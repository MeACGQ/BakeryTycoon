using UnityEngine;

public class HighlightItem : MonoBehaviour
{
    public Transform holdReferance;
    [SerializeField] GameObject holdingObject;

    public void Highlight(ItemData _item)
    {
        holdingObject = Instantiate(_item.itemObject);

        holdingObject.transform.SetParent(holdReferance, false);

        holdingObject.GetComponent<Collider>().isTrigger = false;
    }

    public void Hide()
    {
        if (holdingObject != null)
        {
            Destroy(holdingObject);
        }
    }
}