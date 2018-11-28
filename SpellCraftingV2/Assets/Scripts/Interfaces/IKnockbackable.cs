using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKnockbackable
{
    /// <summary>
    /// Knockback used for moving things by force (not necessarily physics force)
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="direction"></param>
    void AddKnockback(float amount, Vector3 direction);	
}
