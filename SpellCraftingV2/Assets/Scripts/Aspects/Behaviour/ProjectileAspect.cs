using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ProjectileAspect : BehaviourAspect {

    //TODO: TakeVariableModification should be implemented to change personal variables

    [Header("Projectile Stats")]
    [SerializeField] private float speed;
    [SerializeField] private bool rotateOverTime = false;
    [SerializeField] private float rotationSpeedX;
    [SerializeField] private float rotationSpeedY;
    [SerializeField] private float rotationSpeedZ;
    //[SerializeField] private bool bounce = false;
    [SerializeField] private bool destroyOnFirstImpact = true;
    [SerializeField] private int destroyOnXthImpact = 0;
    [SerializeField] private float destroyAfterRealTime = 15f;

    #region GetSetters
    public float Speed
    {
        get
        {
            return speed;
        }
    }
    public bool RotateOverTime
    {
        get
        {
            return rotateOverTime;
        }
    }
    public float RotationSpeedX
    {
        get
        {
            return rotationSpeedX;
        }
    }
    public float RotationSpeedY
    {
        get
        {
            return rotationSpeedY;
        }
    }
    public float RotationSpeedZ
    {
        get
        {
            return rotationSpeedZ;
        }
    }
   /* public bool Bounce
    {
        get
        {
            return bounce;
        }
    }*/
    public bool DestroyOnFirstImpact
    {
        get
        {
            return destroyOnFirstImpact;
        }
    }
    public int DestroyOnXthImpact
    {
        get
        {
            return destroyOnXthImpact;
        }
    }

    public float DestroyAfterRealTime
    {
        get
        {
            return destroyAfterRealTime;
        }
    }


    #endregion
}
