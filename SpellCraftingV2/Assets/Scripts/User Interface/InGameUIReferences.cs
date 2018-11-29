using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Homebrew;

public class InGameUIReferences : MonoBehaviour {

    #region Singleton
    public static InGameUIReferences Instance;
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

    [Foldout("Player UI Bars")]
    public Image healthBarSlowFill, healthBarFastFill, manaBarSlowFill, manaBarFastFill;

}
