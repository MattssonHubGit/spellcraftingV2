using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CostAspect : Aspect
{
    public enum CostType { HEALTH, MANA}
    [Header("Cost Aspect")]
    [SerializeField] protected CostType costType;
    [SerializeField] protected int costAmount;

    /// <summary>
    /// Return true and deduct pay from user if possible, otherwise return false.
    /// </summary>
    /// <param name="caster"></param>
    /// <returns></returns>
    public abstract bool AttemptPay(LivingEntity caster);

}
