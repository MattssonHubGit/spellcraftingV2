using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Homebrew;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : LivingEntity
{

    //TODO: actually implement knockback and getting killed

    //Variables
    #region Movement
    [Foldout("Player movement keys")]
    [SerializeField]
    private KeyCode moveForwardKey = KeyCode.W, moveBackKey = KeyCode.S, moveRightKey = KeyCode.D, moveLeftKey = KeyCode.A;

    [Header("Player rotation")]
    [SerializeField]
    private float rotationSpeed;
    #endregion

    #region myComponents
    private CharacterController cc;
    #endregion

    //Methods

    private void Awake()
    {
        //Set up refrences
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        MovementController();
        RotationController();
    }


    #region Movement
    private void MovementController()
    {
        Vector3 _move = Vector3.zero;
        float z = 0;
        float x = 0;
        float y = 0;

        if (Input.GetKey(moveForwardKey))
        {
            z++;
        }

        if (Input.GetKey(moveBackKey))
        {
            z--;
        }
        if (Input.GetKey(moveRightKey))
        {
            x++;
        }

        if (Input.GetKey(moveLeftKey))
        {
            x--;
        }

        //Apply gravity
        if (cc.isGrounded == false)
        {
            y = Physics.gravity.y;
        }

        _move = new Vector3(x, y, z) * currentMoveSpeed;

        cc.Move(_move * Time.deltaTime);

    }
    private void RotationController()
    {
        // Generate a plane that intersects the transform's position with an upwards normal.
        Plane playerPlane = new Plane(Vector3.up, transform.position);

        // Generate a ray from the cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Determine the point where the cursor ray intersects the plane.
        // This will be the point that the object must look towards to be looking at the mouse.
        // Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
        //   then find the point along that ray that meets that distance.  This will be the point
        //   to look at.
        float hitdist = 0.0f;
        // If the ray is parallel to the plane, Raycast will return false.
        if (playerPlane.Raycast(ray, out hitdist))
        {
            // Get the point along the ray that hits the calculated distance.
            Vector3 targetPoint = ray.GetPoint(hitdist);

            // Determine the target rotation.  This is the rotation if the transform looks at the target point.
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);

            // Smoothly rotate towards the target point.
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
    #endregion


    #region Interface Implementation
    //Getting Killed
    public override void GetKilled()
    {
        Debug.Log("Player should be killed!");
    }

    //Knockback
    public override void AddKnockback(float amount, Vector3 direction)
    {
        Debug.Log("Player takes: " + amount + "knockback!");
    }
    #endregion
}
