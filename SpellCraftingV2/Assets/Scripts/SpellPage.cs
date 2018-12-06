using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class SpellPage : Item {

    //TODO: Implement SpellPage UseItem() to add/remove from inventory
    //Add crafting functions for setting up runes
    //Add interaction with SpellBook

    [Header("Runes")]
    [SerializeField] private RiteRune rite;
    [SerializeField] private CoreRune core;
    [SerializeField] private MethodRune method;

    private LivingEntity caster;



    #region Getters
    public RiteRune Rite
    {
        get
        {
            return rite;
        }

        set
        {
            rite = value;
        }
    }
    public CoreRune Core
    {
        get
        {
            return core;
        }

        set
        {
            core = value;
        }
    }
    public MethodRune Method
    {
        get
        {
            return method;
        }

        set
        {
            method = value;
        }
    }
    #endregion


    //Debug
    public void SetCaster(LivingEntity _caster)
    {
        caster = _caster;
    }

    public void CastSpell(LivingEntity _caster)
    {
        rite.Page = this;
        core.Page = this;
        method.Page = this;

        rite.Caster = _caster;
        core.Caster = _caster;
        method.Caster = _caster;

       
        rite.Activasion.Caster = _caster;
        rite.Cost.Caster = _caster;
        rite.Activasion.Rune = rite;
        rite.Cost.Rune = rite;

        core.SpellObject.Caster = _caster;
        core.SpellObject.Rune = core;
        for (int i = 0; i < core.Modifiers.Count; i++)
        {
            core.Modifiers[i].Caster = _caster;
            core.Modifiers[i].Rune = core;
        }

        /*method.Behaviour.Caster = _caster;
          method.Behaviour.Rune = method;
        for (int i = 0; i < method.Modifiers.Count; i++)
        {
            method.Modifiers[i].Caster = _caster;
            method.Modifiers[i].Rune = method;
        }*/

        rite.InciteSpell();
    }

    #region Interface Implementation
    public override void UseItem()
    {
        Debug.Log("SpellPage UseItem not implemented yet");
    }
    #endregion

}
