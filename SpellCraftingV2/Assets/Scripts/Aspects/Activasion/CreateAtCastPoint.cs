using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CreateAtCastPoint : ActivasionAspect {

    //TODO: Implement Cast() to create the Core and apply the Method scripts onto it.

    public override void Aim(CostAspect cost, LivingEntity caster, InWorldPage page)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (cost.AttemptPay(caster) == true)
            {
                caster.CastState = LivingEntity.CasterState.CASTING;
                Cast(caster, page);
            }
            else
            {
                caster.CastState = LivingEntity.CasterState.NONE;
                Cancel(caster);
            }
        }
    }

    protected override void Cast(LivingEntity caster, InWorldPage page)
    {
        //Create the object in at the point of objectcreation

        GameObject _core = GenerateCoreObject(caster, page);
        _core.transform.position = caster.BaseCoreCreationPoint.position;

        Vector3 _dir = caster.transform.eulerAngles;
        _core.transform.eulerAngles = new Vector3(0, _dir.y, 0);

        _core.SetActive(true);
    }

    protected override void Cancel(LivingEntity caster)
    {
        caster.CastState = LivingEntity.CasterState.NONE;
    }


}
