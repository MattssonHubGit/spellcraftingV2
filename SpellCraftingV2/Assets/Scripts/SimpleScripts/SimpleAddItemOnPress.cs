using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAddItemOnPress : MonoBehaviour {

    [SerializeField] private InventoryManager inventory;
    [SerializeField] private List<ItemData> itemsToAdd = new List<ItemData>();
    [SerializeField] private GameObject itemPrefab;

    [SerializeField] private KeyCode key = KeyCode.Keypad3;

    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            Add();
        }
    }

    private void Add()
    {
        if (inventory != null)
        {
            for (int i = 0; i < itemsToAdd.Count; i++)
            {
                GameObject _obj = Instantiate(itemPrefab, new Vector3(100000, 100000, 100000), Quaternion.identity, this.transform);
                Item _item = _obj.GetComponent<Item>();
                _item.myItemData = itemsToAdd[i];
                inventory.AddItem(_item, this.gameObject, false);
            }
        }
    }
}
