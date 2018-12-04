using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoreModAspect : Aspect
{

    [HideInInspector] public CoreRune Rune;

    protected abstract void Effect();
    protected abstract void OnDestruction();
    protected abstract void OnCreate();

}
