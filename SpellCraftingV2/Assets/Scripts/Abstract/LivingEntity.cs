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

    [Space]

    #region Spell prerequisites
    [Header("Spell prerequisites")]
    [SerializeField] protected Transform baseCoreCreationPoint;
    protected CasterState cs = CasterState.NONE;

    public enum CasterState {NONE, AIMING, CASTING };
    #endregion

    #region Getters
    //Health
    public int CurrentHealth
    {
        get { return currentHealth; }
    }
    public int CurrentMaxHealth
    {
        get
        {
            return currentMaxHealth;
        }
    }
    public int BaseMaxHealth
    {
        get
        {
            return baseMaxHealth;
        }
    }

    //Movement
    public float CurrentMoveSpeed
    {
        get
        {
            return currentMoveSpeed;
        }
    }
    public int BaseMoveSpeed
    {
        get
        {
            return baseMoveSpeed;
        }
    }

    //Resource
    public ResourceType PrimaryResource
    {
        get
        {
            return primaryResource;
        }
    }
    public int CurrentResourceAmount
    {
        get
        {
            return currentResourceAmount;
        }
    }
    public int CurrentMaxResourceAmount
    {
        get
        {
            return currentMaxResourceAmount;
        }
    }
    public int BaseMaxResourceAmount
    {
        get
        {
            return baseMaxResourceAmount;
        }
    }

    //Spell prerequisit
    public Transform BaseCoreCreationPoint
    {
        get
        {
            return baseCoreCreationPoint;
        }
    }
    public CasterState CastState
    {
        get
        {
            return cs;
        }

        ///Be very mindfull with this setter
        set
        {
            cs = value;
        }
    }

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
