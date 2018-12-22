using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DamageHealthOnImpactData : ScriptableObject {

    [Header("Damage")]
    [SerializeField] private int damageAmount = 15;
    [SerializeField] private bool shouldHitCaster = false;


    #region GetSetters
    public int DamageAmount
    {
        get
        {
            return damageAmount;
        }
    }

    public bool ShouldHitCaster
    {
        get
        {
            return shouldHitCaster;
        }
    }
    #endregion
}
