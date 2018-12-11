using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class KnockbackOnImpactAspect : ObjectAspect {
    
    [Header("Knockback")]
    [SerializeField] private float knockBackAmount = 500f;
    [SerializeField] private bool destroyOnFirstCollision = true;
    [SerializeField] private int destroyOnXthCollision = 0;
    [SerializeField] private bool shouldHitCaster = false;


    #region GetSetters
    public float KnockBackAmount
    {
        get
        {
            return knockBackAmount;
        }
    }

    public bool DestroyOnFirstCollision
    {
        get
        {
            return destroyOnFirstCollision;
        }
    }

    public int DestroyOnXthCollision
    {
        get
        {
            return destroyOnXthCollision;
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
