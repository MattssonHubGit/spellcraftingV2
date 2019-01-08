using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InWorldRune : Item {

    [Header("Rite")]
    public CostAspect Cost;
    public ActivasionAspect Activasion;

    [Header("Core")]
    public ObjectAspect Object;
    public List<CoreModAspect> CoreMods = new List<CoreModAspect>();

    [Header("Method")]
    public BehaviourAspect Behaviour;
    public List<BehaviourModAspect> BehaviourMods = new List<BehaviourModAspect>();
}
