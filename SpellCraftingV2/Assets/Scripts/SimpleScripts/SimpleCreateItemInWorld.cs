using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCreateItemInWorld : MonoBehaviour {


    [SerializeField] private ItemData data;
    [SerializeField] private KeyCode key = KeyCode.Keypad4;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            Create();
        }
    }

    private void Create()
    {
        if (data != null)
        {
            Item.GenerateInWorldItem(data, this.transform.position);
        }
    }
}
