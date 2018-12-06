using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ResourceAmountCost : CostAspect {

    /// <summary>
    /// Check if the caster can pay the cost and subtract it if true
    /// </summary>
    /// <param name="caster"></param>
    /// <returns></returns>
    public override bool AttemptPay(LivingEntity caster)
    {
        if (caster.PrimaryResource == costType)
        {
            if (caster.CurrentResourceAmount >= costAmount)
            {
                caster.CurrentResourceAmount -= costAmount;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

}
