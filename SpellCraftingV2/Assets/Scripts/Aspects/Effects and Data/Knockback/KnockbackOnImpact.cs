using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnockbackOnImpact : InnateEffect
{

    private KnockbackOnImpactData myData;

    private void Start()
    {
        SetupData();
    }

    private void OnTriggerEnter(Collider col)
    {
        LivingEntity checkIgnore = col.gameObject.GetComponent<LivingEntity>();
        IKnockbackable _kba = col.gameObject.GetComponent<IKnockbackable>();

        if (checkIgnore != null) //Is hitting a LivingEntity
        {
            if (checkIgnore != caster) //It's not the caster
            {
                AddKnockbackIfPossible(_kba, col);
            }
            else if (myData.ShouldHitCaster == true) //Doesn't care if hitting caster
            {
                AddKnockbackIfPossible(_kba, col);
            }
            else //Does not hit caster
            {

            }
        }
        else //Is not hitting a LivingEntity
        {
            AddKnockbackIfPossible(_kba, col);
        }
    }

    private void AddKnockbackIfPossible(IKnockbackable kba, Collider col)
    {
        if (kba == null) //There is not a knockbackable object, return.
        {
            return;
        }

        Vector3 _dir = col.transform.position - this.transform.position;
        kba.AddKnockback(myData.KnockBackAmount, _dir);
    }

    protected override void SetupData()
    {
        if (data is KnockbackOnImpactData == true)
        {
            myData = (KnockbackOnImpactData)data;
        }
        else
        {
            Debug.LogError("KnockbackOnImpact was fed the wrong data-class, it was fed: " + data.GetType());
        }
    }

}
