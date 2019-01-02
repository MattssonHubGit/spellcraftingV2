using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAddItemOnPress : MonoBehaviour {

    [SerializeField] private InventoryManager inventory;
    [SerializeField] private ItemData itemToAdd;
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
        if (itemToAdd != null || inventory != null)
        {
            GameObject _obj = Instantiate(itemPrefab, new Vector3(100000, 100000, 100000), Quaternion.identity, this.transform);
            Item _item = _obj.GetComponent<Item>();
            _item.myItemData = itemToAdd;

            inventory.AddItem(_item, this.gameObject, false);
        }
    }
}
