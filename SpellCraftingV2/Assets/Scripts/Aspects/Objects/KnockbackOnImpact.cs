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
        #region pasta
        //Don't affect caster
        /* LivingEntity checkIgnore = col.gameObject.GetComponent<LivingEntity>();

         if (checkIgnore != null) //Was it a LivingEntity?
         {
             if (checkIgnore != myData.Caster) //Was it something other than the caster?
             {
                 IKnockbackable _kba = col.gameObject.GetComponent<IKnockbackable>();
                 if (_kba != null) //Can it be knocked back?
                 {
                     Vector3 _dir = this.transform.position - col.transform.position;

                     _kba.AddKnockback(myData.KnockBackAmount, _dir);
                     if (myData.DestroyOnFirstCollision == true) //If it should bestroyed on first collision, do so
                     {
                         Destroy(this.gameObject);
                     }
                 }
                 else if (myData.DestroyOnFirstCollision == true) //If it should bestroyed on first collision, do so
                 {
                     Destroy(this.gameObject);
                 }
             }
             else if (myData.DestroyOnFirstCollision == true) //If it should bestroyed on first collision, do so
             {
                 Destroy(this.gameObject);
             }
         }
         else //It's not a living thing, but can it be knocked back?
         {
             IKnockbackable _kba = col.gameObject.GetComponent<IKnockbackable>();
             if (_kba != null)
             {
                 Vector3 _dir = this.transform.position - col.transform.position;

                 _kba.AddKnockback(myData.KnockBackAmount, _dir); if (myData.DestroyOnFirstCollision == true) //If it should bestroyed on first collision, do so
                 {
                     Destroy(this.gameObject);
                 }
             }
             else if (myData.DestroyOnFirstCollision == true)//If it should bestroyed on first collision, do so
             {
                 Destroy(this.gameObject);
             }
         }*/
        #endregion

        LivingEntity checkIgnore = col.gameObject.GetComponent<LivingEntity>();
        IKnockbackable _kba = col.gameObject.GetComponent<IKnockbackable>();

        if(checkIgnore != null) //Is hitting a LivingEntity
        {
            if (checkIgnore != myData.Caster) //It's not the caster
            {
                AddKnockbackIfPossible(_kba, col);
                //DestructionHandler();
            }
            else if (myData.ShouldHitCaster == true) //Doesn't care if hitting caster
            {
                AddKnockbackIfPossible(_kba, col);
               //DestructionHandler();
            }
            else //Does not hit caster
            {

            }
        }
        else //Is not hitting a LivingEntity
        {
            AddKnockbackIfPossible(_kba, col);
            //DestructionHandler();
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

}
