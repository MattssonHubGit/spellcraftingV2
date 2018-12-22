using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHealthOnImpact : InnateEffect {

    private DamageHealthOnImpactData myData;

    private void Start()
    {
        SetupData();
    }

    private void OnTriggerEnter(Collider col)
    {
        LivingEntity checkIgnore = col.gameObject.GetComponent<LivingEntity>();
        IDamageable _dama = col.gameObject.GetComponent<IDamageable>();

        if (checkIgnore != null) //Is hitting a LivingEntity
        {
            if (checkIgnore != caster) //It's not the caster
            {
                DealDamageIfPossible(_dama);
            }
            else if (myData.ShouldHitCaster == true) //Doesn't care if hitting caster
            {
                DealDamageIfPossible(_dama);
            }
            else //Does not hit caster
            {

            }
        }
        else //Is not hitting a LivingEntity
        {
            DealDamageIfPossible(_dama);
        }
    }

    private void DealDamageIfPossible(IDamageable dma)
    {
        if (dma == null) //There is not a damagable object, return.
        {
            return;
        }
        
        dma.TakeDamage(myData.DamageAmount);
    }

    protected override void SetupData()
    {
        if (data is DamageHealthOnImpactData == true)
        {
            myData = (DamageHealthOnImpactData)data;
        }
        else
        {
            Debug.LogError("DamageHealthOnImpact was fed the wrong data-class, it was fed: " + data.GetType());
        }
    }
}
