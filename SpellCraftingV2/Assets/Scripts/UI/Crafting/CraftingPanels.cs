using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingPanels : MonoBehaviour {

    public CoreCrafting core;
    public RiteCrafting rite;
    public MethodCrafting method;
    public PageCrafting page;

    public static bool CraftingUIEnabled = true;

    #region Singleton
    //Singleton
    public static CraftingPanels Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    private void OnEnable()
    {
        CraftingUIEnabled = true;
    }

    private void OnDisable()
    {
        CraftingUIEnabled = false;
    }
}
