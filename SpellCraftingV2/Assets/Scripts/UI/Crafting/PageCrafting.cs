using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageCrafting : MonoBehaviour {

    public InventorySlot riteSlot;
    public InventorySlot coreSlot;
    public InventorySlot methodSlot;
    public InventorySlot pageOutputSlot;
    public Sprite pageSprite;

    public void Craft()
    {
        bool _riteReady = false;
        bool _coreReady = false;
        bool _methodReady = false;
        bool _outputEmpty = false;

        //Check prerequisites
        if (riteSlot.myItem != null)
        {
            _riteReady = true;
        }
        if (coreSlot.myItem != null)
        {
            _coreReady = true;
        }
        if (methodSlot.myItem != null)
        {
            _methodReady = true;
        }
        if (pageOutputSlot == null)
        {
            _outputEmpty = true;
        }

        if (_riteReady && _coreReady && _methodReady && _outputEmpty)
        {
            //Generate new page
            SpellPage _output = new SpellPage();
            _output.Rite = riteSlot.myItem as RiteRune;
            _output.Core = coreSlot.myItem as CoreRune;
            _output.Method = methodSlot.myItem as MethodRune;
            _output.inventoryIcon = pageSprite;
            _output.name = "SpellPage: Unfoldered";

            //Put it into UI
            pageOutputSlot.myItem = _output;
            pageOutputSlot.myImage.sprite = _output.inventoryIcon;
            pageOutputSlot.myImage.color = Color.white;

            //Remove riterune
            riteSlot.myImage.color = new Color(1, 1, 1, 0);
            riteSlot.myImage.sprite = null;
            riteSlot.myItem = null;

            //Remove corerune
            coreSlot.myImage.color = new Color(1, 1, 1, 0);
            coreSlot.myImage.sprite = null;
            coreSlot.myItem = null;           
            
            //Remove methodrune
            methodSlot.myImage.color = new Color(1, 1, 1, 0);
            methodSlot.myImage.sprite = null;
            methodSlot.myItem = null;
        }
    }
}
