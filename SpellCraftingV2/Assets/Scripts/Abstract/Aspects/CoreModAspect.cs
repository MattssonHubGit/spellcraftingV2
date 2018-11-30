using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CoreModAspect : Aspect
{

    protected abstract void Effect();
    protected abstract void OnDestruction();
    protected abstract void OnCreate();

}
