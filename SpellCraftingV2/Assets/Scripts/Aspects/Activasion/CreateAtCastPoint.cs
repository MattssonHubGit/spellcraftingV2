using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CreateAtCastPoint : ActivasionAspect {

    //TODO: Implement Cast() to create the Core and apply the Method scripts onto it.

    public override void Aim(CostAspect cost)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (cost.AttemptPay(Caster) == true)
            {
                Caster.CastState = LivingEntity.CasterState.CASTING;
                Cast(/*Rune.Page.Core, Rune.Page.Method*/);
            }
            else
            {
                Caster.CastState = LivingEntity.CasterState.NONE;
                Cancel();
            }
        }
    }

    protected override void Cast(/*CoreRune core, MethodRune method*/)
    {
        //Create the object in at the point of objectcreation

        GameObject _core = GenerateCoreObject();
        _core.transform.position = Caster.BaseCoreCreationPoint.position;

        Vector3 _dir = Caster.transform.eulerAngles;
        _core.transform.eulerAngles = new Vector3(0, _dir.y, 0);

        _core.SetActive(true);
    }

    protected override void Cancel()
    {
        Caster.CastState = LivingEntity.CasterState.NONE;
    }


}
