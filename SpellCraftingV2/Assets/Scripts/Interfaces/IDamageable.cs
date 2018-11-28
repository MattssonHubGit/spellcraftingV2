using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    /// <summary>
    /// Damagable things should have some sort of health variable or other damage state
    /// </summary>
    /// <param name="amount"></param>
    void TakeDamage(int amount);
    /// <summary>
    /// Damagable things should be destructable, or killable... or not.
    /// </summary>
    void GetKilled();	
}
