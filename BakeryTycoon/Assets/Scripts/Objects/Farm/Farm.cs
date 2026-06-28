using System.Collections;
using UnityEngine;

public class Farm : InteractbleBase
{
    [SerializeField] private float growTime;

    [SerializeField] Transform referance;
    [SerializeField] GameObject seed;
    [SerializeField] GameObject growedItem;

    GameObject currentCrop;

    FarmStates currentstate;

    private void Start()
    {
        StartCoroutine(Grow());
    }

    public enum FarmStates
    {
        Growing,
        Ready
    }

    public override void Interact()
    {
        if (currentstate == FarmStates.Growing)
            return;

        StartCoroutine(Grow());
    }

    public IEnumerator Grow()
    {
        currentCrop = Instantiate(seed, new Vector3(referance.transform.position.x,
            referance.transform.position.y,
            referance.transform.position.z), 
            Quaternion.identity, referance);

        yield return new WaitForSeconds(growTime);

        Destroy(currentCrop);

        currentCrop = Instantiate(growedItem, referance);

        currentstate = FarmStates.Ready;
    }
}
