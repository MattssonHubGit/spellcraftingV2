using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class RiteRune : Rune {

    //TODO: Implement UseItem to add item into craftingUI
    //Implement InciteSpell() to start casting

    [Header("Rite Rune")]
    [SerializeField] private ActivasionAspect activasion;
    [SerializeField] private CostAspect cost;


    /// <summary>
    /// Starts casting the spell by using the Aim() of it's ActivasionAspect
    /// </summary>
    /// <param name="caster"></param>
    public void InciteSpell(LivingEntity caster)
    {
        Debug.Log("MethodRune InciteSpell() not implemented yet");
    }

    public override void UseItem()
    {
        Debug.Log("MethodRune UseItem not implemented yet");
    }
}
