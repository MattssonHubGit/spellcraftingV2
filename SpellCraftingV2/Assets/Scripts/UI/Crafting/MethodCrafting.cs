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
            MethodRune _output = new MethodRune();
            _output.Behaviour = behaviourSlot.myItem as BehaviourAspect;
            for (int i = 0; i < modSlots.Length; i++)
            {
                if (modSlots[i].myItem != null)
                {
                    _output.Modifiers.Add(modSlots[i].myItem as BehaviourModAspect);
                }
                else
                {
                    break;
                }
            }
            _output.inventoryIcon = methodSprite;
            _output.name = "MethodRune: Unfoldered";

            //Put it into UI
            runeOutputSlot.myItem = _output;
            runeOutputSlot.myImage.sprite = _output.inventoryIcon;
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
