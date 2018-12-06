using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnockbackOnImpact : InnateEffect
{

    private KnockbackOnImpactAspect myData;

    private void Start()
    {
        myData = (KnockbackOnImpactAspect)data;
    }

    /*private void OnCollisionEnter(Collision col)
    {        //Don't affect caster
        LivingEntity checkIgnore = col.gameObject.GetComponent<LivingEntity>();

        if (checkIgnore != null) //Was it a LivingEntity?
        {
            if (checkIgnore != myData.Caster) //Was it something other than the caster?
            {
                IKnockbackable _kba = col.gameObject.GetComponent<IKnockbackable>();
                if (_kba != null) //Can it be knocked back?
                {
                    Vector3 _dir = this.transform.position - col.transform.position;

                    _kba.AddKnockback(myData.KnockBackAmount, _dir);
                    Destroy(this.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
        else //It's not a living thing, but can it be knocked back?
        {
            IKnockbackable _kba = col.gameObject.GetComponent<IKnockbackable>();
            if (_kba != null)
            {
                Vector3 _dir = this.transform.position - col.transform.position;

                _kba.AddKnockback(myData.KnockBackAmount, _dir);
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }*/
    
    private void OnTriggerEnter(Collider col)
    {
        //Don't affect caster
        LivingEntity checkIgnore = col.gameObject.GetComponent<LivingEntity>();

        if (checkIgnore != null) //Was it a LivingEntity?
        {
            if (checkIgnore != myData.Caster) //Was it something other than the caster?
            {
                IKnockbackable _kba = col.gameObject.GetComponent<IKnockbackable>();
                if (_kba != null) //Can it be knocked back?
                {
                    Vector3 _dir = this.transform.position - col.transform.position;

                    _kba.AddKnockback(myData.KnockBackAmount, _dir);
                    Destroy(this.gameObject);
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
        else //It's not a living thing, but can it be knocked back?
        {
            IKnockbackable _kba = col.gameObject.GetComponent<IKnockbackable>();
            if (_kba != null)
            {
                Vector3 _dir = this.transform.position - col.transform.position;

                _kba.AddKnockback(myData.KnockBackAmount, _dir);
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
    
}
