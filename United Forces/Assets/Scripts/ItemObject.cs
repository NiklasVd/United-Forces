using UnityEngine;
using System.Collections;

public class ItemObject : MonoBehaviour
{
    public Item representedItem;
    private GameObject itemGameObject;

    void Awake()
    {
        itemGameObject = CreateItemObject(representedItem.itemObject, transform.position);
    }

    public Item PickUp()
    {
        Destroy(this); // TODO: Check if this works (destroying and then returning the item clone)
        return Instantiate(representedItem);
    }

    public static GameObject CreateItemObject(GameObject gameobject, Vector3 position)
    {
        gameobject = (GameObject)Instantiate(gameobject, position, Quaternion.identity);
        Rigidbody itemRigidbody = gameobject.AddComponent<Rigidbody>();
        itemRigidbody.mass = 5;
        BoxCollider itemBoxCollider = gameobject.AddComponent<BoxCollider>();
        itemBoxCollider.size = gameobject.GetComponentInChildren<MeshRenderer>().bounds.size;

        return gameobject;
    }
}
