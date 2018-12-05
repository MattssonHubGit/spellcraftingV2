using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnockbackOnImpact : InnateEffect {

    private KnockbackOnImpactAspect myData;

    private void Start()
    {
        myData = (KnockbackOnImpactAspect)data;
    }

    private void OnCollisionEnter(Collision col)
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
