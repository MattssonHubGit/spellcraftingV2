using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoreModAspect : Aspect
{

    //TODO: Either seperate from scriptableObject or find a way to serialize a monobehaivour script to apply

    [HideInInspector] public CoreRune Rune;

    protected abstract void Effect();
    protected abstract void OnDestruction();
    protected abstract void OnCreate();

}
