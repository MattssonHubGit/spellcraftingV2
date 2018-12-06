using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CostAspect : Aspect
{
    //TODO: Make the aspect enter/exit the crafting/inventory

        
    [Header("Cost Aspect")]
    [SerializeField] protected LivingEntity.ResourceType costType;
    [SerializeField] protected int costAmount;


    [HideInInspector] public RiteRune Rune;

    /// <summary>
    /// Return true and deduct pay from user if possible, otherwise return false.
    /// </summary>
    /// <param name="caster"></param>
    /// <returns></returns>
    public abstract bool AttemptPay(LivingEntity caster);


    public override void UseItem()
    {
        Debug.Log("UseItem() not implemented in ActivasionAspect");
    }

}
