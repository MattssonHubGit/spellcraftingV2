using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiteCrafting : MonoBehaviour {

    public InventorySlot costSlot;
    public InventorySlot activationSlot;
    public InventorySlot runeOutputSlot;
    [SerializeField] private GameObject itemPrefab;

    public Sprite riteSprite;

    public void Craft()
    {
        bool _costReady = false;
        bool _activasionReady = false;
        bool _outputEmpty = false;

        //Check prerequisites
        if (costSlot.myItem != null)
        {
            _costReady = true;
        }
        if (activationSlot.myItem != null)
        {
            _activasionReady = true;
        }
        if (runeOutputSlot.myItem == null)
        {
            _outputEmpty = true;
        }

        if (_costReady && _activasionReady && _outputEmpty)
        {
            //Generate new rite rune data
            RiteRune _data = new RiteRune();
            _data.Cost = costSlot.myItem.myItemData as CostAspect;
            _data.Activasion = activationSlot.myItem.myItemData as ActivasionAspect;
            _data.inventoryIcon = riteSprite;
            _data.name = "RiteRune: Unfoldered";

            //Generate item
            GameObject _itemObj = Instantiate(itemPrefab, new Vector3(100000, 100000, 100000), Quaternion.identity);
            _itemObj.name = "RiteRune";
            Item _output = _itemObj.GetComponent<Item>();
            _output.myItemData = _data;
            _output.isInPlayerInventory = false;
            _output.GFXParent.gameObject.SetActive(false);
            _output.myCollider.enabled = false;

            //Put it into UI
            runeOutputSlot.myItem = _output;
            runeOutputSlot.myImage.sprite = _data.inventoryIcon;
            runeOutputSlot.myImage.color = Color.white;

            //Remove costaspect
            costSlot.myImage.color = new Color(1, 1, 1, 0);
            costSlot.myImage.sprite = null;
            costSlot.myItem = null;

            //Remove activasionaspect
            activationSlot.myImage.color = new Color(1, 1, 1, 0);
            activationSlot.myImage.sprite = null;
            activationSlot.myItem = null;
        }
    }
}
