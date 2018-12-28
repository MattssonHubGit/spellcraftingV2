using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAddItemOnPress : MonoBehaviour {

    [SerializeField] private InventoryManager inventory;
    [SerializeField] private Item itemToAdd;

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
        if (itemToAdd == null || inventory == null)
        {
            inventory.AddItem(itemToAdd, this.gameObject, false);
        }
    }
}
