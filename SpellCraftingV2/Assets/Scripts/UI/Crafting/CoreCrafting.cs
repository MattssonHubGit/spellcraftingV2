using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreCrafting : MonoBehaviour {

    public InventorySlot objectSlot;
    public InventorySlot[] modSlots = new InventorySlot[0];
    public InventorySlot runeOutputSlot;
    public Sprite coreSprite;
    [SerializeField] private GameObject runePrefab;

    public void Craft()
    {
        bool _objectReady = false;
        bool _outputEmpty = false;

        //Check prerequisites
        if (objectSlot.myItem != null)
        {
            _objectReady = true;
        }
        if (runeOutputSlot.myItem == null)
        {
            _outputEmpty = true;
        }

        if (_objectReady && _outputEmpty)
        {
            //Generate new core data
            CoreRune _data = new CoreRune();
           
            _data.inventoryIcon = coreSprite;
            _data.name = "CoreRune: Unfoldered";
            _data.SpellObject = objectSlot.myItem.myItemData as ObjectAspect;
            for (int i = 0; i < modSlots.Length; i++)
            {
                if (modSlots[i].myItem != null)
                {
                    _data.Modifiers.Add(modSlots[i].myItem.myItemData as CoreModAspect);
                }
                else
                {
                    break;
                }
            }

            //Generate new item
            GameObject _itemObj = Instantiate(runePrefab, new Vector3(100000, 100000, 100000), Quaternion.identity);
            _itemObj.name = "CoreRune";
            InWorldRune _output = _itemObj.GetComponent<InWorldRune>();
            _output.myItemData = _data;
            _output.isInPlayerInventory = false;
            _output.GFXParent.gameObject.SetActive(false);
            _output.myCollider.enabled = false;
            _output.Object = objectSlot.myItem.myItemData as ObjectAspect;
            for (int i = 0; i < modSlots.Length; i++)
            {
                if (modSlots[i].myItem != null)
                {
                    _output.CoreMods.Add(modSlots[i].myItem.myItemData as CoreModAspect);
                }
                else
                {
                    break;
                }
            }

            //Put it into UI
            runeOutputSlot.myItem = _output;
            runeOutputSlot.myImage.sprite = _data.inventoryIcon;
            runeOutputSlot.myImage.color = Color.white;

            //Remove behaviouraspect
            objectSlot.myImage.color = new Color(1, 1, 1, 0);
            objectSlot.myImage.sprite = null;
            objectSlot.myItem = null;

            //Remove modifiers
            for (int i = 0; i < modSlots.Length; i++)
            {
                modSlots[i].myImage.color = new Color(1, 1, 1, 0);
                modSlots[i].myImage.sprite = null;
                modSlots[i].myItem = null;
            }
        }
    }

}
