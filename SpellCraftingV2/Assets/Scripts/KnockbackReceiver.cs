using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackReceiver : MonoBehaviour
{

    [SerializeField] private float mass = 1.0f; // defines the character mass
    private Vector3 impact = Vector3.zero;
    private CharacterController cc;
    private bool beingKnocked = false;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {     
        if (beingKnocked == true)
        {
            KnockbackExecution();
        }   
    }

    private void KnockbackExecution()
    {
        
        if (impact.magnitude > 0.2)
        {   
            cc.Move(impact * Time.deltaTime); // apply the impact force:
            impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime); // consumes the impact energy each cycle:
        }
        else
        {
            beingKnocked = false;
        }
    }


    /// <summary>
    /// Adds knockback in similar way to force
    /// </summary>
    /// <param name="dir"></param>
    /// <param name="force"></param>
    public void AddImpact(float force, Vector3 dir)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * (force * 0.1f) / mass;
        beingKnocked = true;
    }
}
