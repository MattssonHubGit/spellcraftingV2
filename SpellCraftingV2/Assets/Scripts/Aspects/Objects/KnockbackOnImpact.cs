using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class KnockbackOnImpact : ObjectAspect {
    
    [Header("Knockback")]
    [SerializeField] private float knockBackAmount = 500f;


    #region GetSetters
    public float KnockBackAmount
    {
        get
        {
            return knockBackAmount;
        }
    }
    #endregion

    protected override void OnCreate()
    {

    }

    protected override void OnDestruction()
    {

    }

}
