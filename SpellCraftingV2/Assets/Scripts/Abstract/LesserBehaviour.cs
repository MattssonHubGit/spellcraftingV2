﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LesserBehaviour : MonoBehaviour {

    [HideInInspector] public ScriptableObject data;
    [HideInInspector] public LivingEntity caster;

}
