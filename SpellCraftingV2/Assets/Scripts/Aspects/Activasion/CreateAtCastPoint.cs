using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAtCastPoint : ActivasionAspect {

    //TODO: Implement Cast() to create the Core and apply the Method scripts onto it.

    public override void Aim(CostAspect cost)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (cost.AttemptPay(Caster) == true)
            {
                Caster.CastState = LivingEntity.CasterState.CASTING;
                Cast(Rune.Page.Core, Rune.Page.Method);
            }
            else
            {
                Caster.CastState = LivingEntity.CasterState.NONE;
                Cancel();
            }
        }
    }

    protected override void Cast(CoreRune core, MethodRune method)
    {
        //Create the object in at the point of objectcreation
        Debug.Log("Cast() not implemented in CreateAtCastPoint");
    }

    protected override void Cancel()
    {
        Caster.CastState = LivingEntity.CasterState.NONE;
    }


}
