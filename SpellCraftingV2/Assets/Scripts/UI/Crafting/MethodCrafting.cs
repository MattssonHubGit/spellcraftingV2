using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MethodCrafting : MonoBehaviour {

    public InventorySlot behaviourSlot;
    public InventorySlot[] modSlots = new InventorySlot[0];
    public InventorySlot runeOutputSlot;
    public Sprite methodSprite;

    public void Craft()
    {
        bool _behaviourReady = false;
        bool _outputEmpty = false;

        //Check prerequisites
        if (behaviourSlot.myItem != null)
        {
            _behaviourReady = true;
        }
        if (runeOutputSlot == null)
        {
            _outputEmpty = true;
        }

        if (_behaviourReady && _outputEmpty)
        {
            //Generate new page
            MethodRune _data = new MethodRune();
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
            _data.inventoryIcon = methodSprite;
            _data.name = "MethodRune: Unfoldered";

            Item _output = new Item();
            _output.gameObject.name = "MethodRune";
            _output.myItemData = _data;

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
