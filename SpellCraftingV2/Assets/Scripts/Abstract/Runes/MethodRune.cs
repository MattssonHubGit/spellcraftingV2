using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MethodRune : Rune
{
    //TODO: Implement UseItem to add item into craftingUI

    [Header("Method Rune")]
    [SerializeField] private BehaviourAspect behaviour;
    [SerializeField] private List<BehaviourModAspect> modifiers = new List<BehaviourModAspect>();



    #region GetSetters
    public BehaviourAspect Behaviour
    {
        get
        {
            return behaviour;
        }
    }

    public List<BehaviourModAspect> Modifiers
    {
        get
        {
            return modifiers;
        }
    }
    #endregion

    public override void UseItem()
    {
        Debug.Log("MethodRune UseItem not implemented yet");
    }


}
