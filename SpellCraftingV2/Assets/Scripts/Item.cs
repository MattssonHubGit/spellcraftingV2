using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    [SerializeField] public ItemData myItemData;
    [SerializeField] public MeshFilter meshFilter;
    [SerializeField] public MeshRenderer meshRenderer;
    [SerializeField] public Transform GFXParent;
    [SerializeField] public Collider myCollider;
    public bool isInPlayerInventory = false;

    public static GameObject GenerateInWorldItem(ItemData data, Vector3 position)
    {
        GameObject output = Instantiate(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().inWorldItemPrefab, position, Quaternion.identity);
        Item item = output.GetComponent<Item>();
        item.meshFilter.mesh = data.worldMesh;
        item.meshRenderer.material = data.worldMaterial;
        item.myItemData = data;

        return output;
    }

    private void Update()
    {
        myItemData.InWorldAnimation(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.PlayerInventory.AddItem(this, this.gameObject, false);
        }
    }

}
