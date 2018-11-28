using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LivingEntity : MonoBehaviour, IDamageable, IKnockbackable {

    [Header("Entity Variables")]

    [Space]

    #region Health
    [Header("Entity Health")]
    [SerializeField] protected int currentHealth;
    [SerializeField] protected int currentMaxHealth;
    [SerializeField] protected int baseMaxHealth;
    #endregion

    [Space]

    #region Movement
    [Header("Entity Movement")]
    [SerializeField] protected float currentMoveSpeed;
    [SerializeField] protected int baseMoveSpeed;
    #endregion
    
    [Space]

    #region Resource
    [Header("Entity Resource")]
    [SerializeField] protected ResourceType primaryResource = ResourceType.MANA;
    [SerializeField] protected int currentResourceAmount;
    [SerializeField] protected int currentMaxResourceAmount;
    [SerializeField] protected int baseMaxResourceAmount;

    public enum ResourceType { HEALTH, MANA }
    #endregion

    #region Interface Implementation
    //IDamageable
    public virtual void TakeDamage(int amount)
    {
        //Take the damage
        currentHealth -= amount;

        //Check for death
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GetKilled();
        }
    }
    public abstract void GetKilled();

    //IKnockbackable
    public abstract void AddKnockback(float amount, Vector3 direction);
    #endregion
}
