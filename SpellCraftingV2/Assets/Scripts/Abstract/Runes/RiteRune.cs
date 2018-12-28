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



    #region GetSetters
    public ActivasionAspect Activasion
    {
        get
        {
            return activasion;
        }
        set
        {
            activasion = value;
        }
    }

    public CostAspect Cost
    {
        get
        {
            return cost;
        }
        set
        {
            cost = value;
        }
    }


    #endregion


    /// <summary>
    /// Starts casting the spell by using the Aim() of it's ActivasionAspect
    /// </summary>
    /// <param name="caster"></param>
    public void InciteSpell()
    {
        //Debug.Log("MethodRune InciteSpell() not implemented yet");
        Caster.CastState = LivingEntity.CasterState.AIMING;

        activasion.Aim(cost);
    }

    public override void UseItem()
    {
        Debug.Log("RiteRune UseItem not implemented yet");
    }
}
