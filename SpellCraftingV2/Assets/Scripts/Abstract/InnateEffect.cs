using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class should contain a effect/innate behaivour that applies to a gameobject it's script is applied to. Should be used on core objects
/// </summary>
[System.Serializable]
public abstract class InnateEffect : MonoBehaviour
{
    [SerializeField] public ScriptableObject data;
}
