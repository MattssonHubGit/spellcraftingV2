using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodCrafting : MonoBehaviour {

    public InventorySlot behaviourSlot;
    public InventorySlot[] modSlots = new InventorySlot[0];
    public InventorySlot runeOutputSlot;
    public Sprite methodSprite;
    [SerializeField] private GameObject runePrefab;

    public void Craft()
    {
        bool _behaviourReady = false;
        bool _outputEmpty = false;

        //Check prerequisites
        if (behaviourSlot.myItem != null)
        {
            _behaviourReady = true;
        }
        if (runeOutputSlot.myItem == null)
        {
            _outputEmpty = true;
        }

        if (_behaviourReady && _outputEmpty)
        {
            //Generate new method rune data
            MethodRune _data = new MethodRune();
            _data.inventoryIcon = methodSprite;
            _data.name = "MethodRune: Unfoldered";
            _data.Behaviour = behaviourSlot.myItem.myItemData as BehaviourAspect;
            for (int i = 0; i < modSlots.Length; i++)
            {
                if (modSlots[i].myItem != null)
                {
                    _data.Modifiers.Add(modSlots[i].myItem.myItemData as BehaviourModAspect);
                }
                else
                {
                    break;
                }
            }

            //Genereate new item
            GameObject _itemObj = Instantiate(runePrefab, new Vector3(100000, 100000, 100000), Quaternion.identity);
            _itemObj.name = "CoreRune";
            InWorldRune _output = _itemObj.GetComponent<InWorldRune>();
            _output.myItemData = _data;
            _output.isInPlayerInventory = false;
            _output.GFXParent.gameObject.SetActive(false);
            _output.myCollider.enabled = false;
            _output.Behaviour = behaviourSlot.myItem.myItemData as BehaviourAspect;
            for (int i = 0; i < modSlots.Length; i++)
            {
                if (modSlots[i].myItem != null)
                {
                    _output.BehaviourMods.Add(modSlots[i].myItem.myItemData as BehaviourModAspect);
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
            behaviourSlot.myImage.color = new Color(1, 1, 1, 0);
            behaviourSlot.myImage.sprite = null;
            behaviourSlot.myItem = null;

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
