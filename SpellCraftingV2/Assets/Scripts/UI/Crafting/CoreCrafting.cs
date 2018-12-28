using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreCrafting : MonoBehaviour {

    public InventorySlot objectSlot;
    public InventorySlot[] modSlots = new InventorySlot[0];
    public InventorySlot runeOutputSlot;
    public Sprite coreSprite;

    public void Craft()
    {
        bool _objectReady = false;
        bool _outputEmpty = false;

        //Check prerequisites
        if (objectSlot.myItem != null)
        {
            _objectReady = true;
        }
        if (runeOutputSlot == null)
        {
            _outputEmpty = true;
        }

        if (_objectReady && _outputEmpty)
        {
            //Generate new page
            CoreRune _output = new CoreRune();
            _output.SpellObject = objectSlot.myItem as ObjectAspect;
            for (int i = 0; i < modSlots.Length; i++)
            {
                if (modSlots[i].myItem != null)
                {
                    _output.Modifiers.Add(modSlots[i].myItem as CoreModAspect);
                }
                else
                {
                    break;
                }
            }
            _output.inventoryIcon = coreSprite;
            _output.name = "CoreRune: Unfoldered";

            //Put it into UI
            runeOutputSlot.myItem = _output;
            runeOutputSlot.myImage.sprite = _output.inventoryIcon;
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
