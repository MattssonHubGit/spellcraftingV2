using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Behaviour {

    //TODO : Implement ModMyVariables()

    private ProjectileAspect myData;
    private int collisionCounter = 0;

    private void Start()
    {
        myData = (ProjectileAspect)data;

        //Destroy after time
        Destroy(this.gameObject, myData.DestroyAfterRealTime);
    }

    private void FixedUpdate()
    {
        Rotation();
        Movement();
    }

    private void Movement()
    {
        transform.position += transform.forward * myData.Speed * Time.deltaTime;
    }

    private void Rotation()
    {
        if (myData.RotateOverTime == true)
        {
            transform.eulerAngles += new Vector3(myData.RotationSpeedX, myData.RotationSpeedY, myData.RotationSpeedZ) * Time.deltaTime;
        }
    }

    /*private void BounceHandler(GameObject otherObject)
    {
        Vector3 newDirection = this.transform.eulerAngles;
        Debug.Log("Entered Bounce Handler");
        if (myData.Bounce == true)//Bounce by reflecting rotation
        {

            Debug.Log("myData.Bounce == true");
            Debug.Log("BEFORE newDirection" + newDirection);
            newDirection = this.transform.position - otherObject.transform.position;
            Debug.Log("AFTER newDirection" + newDirection);
        }

        this.transform.rotation.SetLookRotation(newDirection);
    }*/

    private void OnTriggerEnter(Collider col)
    {
        LivingEntity checkIgnore = col.gameObject.GetComponent<LivingEntity>();
        if (checkIgnore != null) //Is hitting a LivingEntity
        {
            if (checkIgnore != myData.Caster) //It's not the caster
            {
                //BounceHandler(col.gameObject);
                DestructionHandler();
            }
            else //Does not hit caster
            {

            }
        }
        else //Is not hitting a LivingEntity
        {
            //BounceHandler(col.gameObject);
            DestructionHandler();
        }
    }

    protected override void DestructionHandler()
    {
        collisionCounter++;
        if (myData.DestroyOnFirstImpact)//Just destroy on the first collision
        {
            Destroy(this.gameObject);
        }
        else if (collisionCounter >= myData.DestroyOnXthImpact)//Destroy if having colided with enough other things
        {
            Destroy(this.gameObject);
        }
    }

    public override void ModMyVariables(ScriptableObject modData)
    {
        Debug.Log("Projectile ModMyVariables() has no logic implemented");
    }
}
