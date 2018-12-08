using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class should contain a behaivour that applies to a gameobject it's script is applied to. Should be used on core objects
/// </summary>
public abstract class Behaviour : MonoBehaviour {

    /*[HideInInspector]*/ public ScriptableObject data;

    /// <summary>
    /// Include conditions for destroying the onbject
    /// </summary>
    protected abstract void DestructionHandler();
}
