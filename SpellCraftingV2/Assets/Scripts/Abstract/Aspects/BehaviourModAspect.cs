using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviourModAspect : Aspect
{

    [Header("Behaviour Mod Aspect")]
    [SerializeField] protected BehaviourAspect.BehaviourType modForType;


    [HideInInspector] public MethodRune Rune;

}
