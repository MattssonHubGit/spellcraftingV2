using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAspect : Aspect
{
    [Header("Object Aspect")]
    [SerializeField] protected GameObject objectPrefab;


    [HideInInspector] public CoreRune Rune;

    protected abstract void InnateEffect();
    protected abstract void OnDestruction();
    protected abstract void OnCreate();

}
