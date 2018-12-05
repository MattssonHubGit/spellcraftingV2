using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KnockbackFist : InnateEffect {

    private KnockbackOnImpact myData;

    private void Start()
    {
        myData = (KnockbackOnImpact)data;
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
