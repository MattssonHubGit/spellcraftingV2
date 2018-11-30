using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CoreRune : Rune {

    //TODO: Implement UseItem to add item into craftingUI

    [Header("Core Rune")]
    [SerializeField] private ObjectAspect spellObject;
    [SerializeField] private List<CoreModAspect> modifiers = new List<CoreModAspect>();

    public override void UseItem()
    {
        Debug.Log("MethodRune UseItem not implemented yet");
    }
}
