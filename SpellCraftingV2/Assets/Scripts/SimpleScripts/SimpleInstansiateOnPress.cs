using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInstansiateOnPress : MonoBehaviour {

    [SerializeField] private GameObject prefab;
    [SerializeField] private KeyCode key = KeyCode.Keypad2;
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(key))
        {
            Create();
        }
	}

    private void Create()
    {
        if (prefab != null)
        {
            GameObject obj = Instantiate(prefab, this.transform.position, Quaternion.identity);
        }
    }

}

