using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Collection Class for all RuneTypes
/// </summary>
public abstract class Rune : ItemData {

    [HideInInspector] public LivingEntity Caster;
    [HideInInspector] public SpellPage Page;

}
