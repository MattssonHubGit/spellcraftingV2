using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Homebrew;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : LivingEntity
{
    //TODO: Add interaction with spellbook
    //Smooth out resource regaining

    //Variables
    #region Movement
    [Foldout("Player movement keys")]
    [SerializeField] private KeyCode moveForwardKey = KeyCode.W, moveBackKey = KeyCode.S, moveRightKey = KeyCode.D, moveLeftKey = KeyCode.A;

    [Header("Player rotation")]
    [SerializeField] private float rotationSpeed;
    #endregion

    #region Resources
    [Header("Resources")]
    [SerializeField] private int regenAmount = 5;
    private float regenCooldown = 0;
    #endregion

    #region myComponents
    private CharacterController cc;
    private KnockbackReceiver kbr;
    #endregion

    #region Inventory
    [Header("Inventory")]
    [SerializeField] private InventoryManager playerInventory;
    [SerializeField] public GameObject inWorldItemPrefab;
    #endregion 

    #region Debugging
    [Header("Debugging")]
    [SerializeField] private bool debugMode = false;
    [SerializeField] private SpellPage mySpell;
    #endregion

    #region GetSetter
    public InventoryManager PlayerInventory
    {
        get
        {
            return playerInventory;
        }
    }
    #endregion

    //Methods
    private void Awake()
    {
        //Set up refrences
        cc = GetComponent<CharacterController>();
        this.gameObject.AddComponent<KnockbackReceiver>();
        kbr = GetComponent<KnockbackReceiver>();
    }

    private void Update()
    {
        //Movement
        MovementController();
        RotationController();

        //UI
        HealthAndManaBarDisplay();
        ToggleCraftingInterface();

        //Resources
        ManaRegen();

        #region Debug
        if (debugMode)
        {
            DebugControls();
        }
        #endregion
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

    #region UI
    private void HealthAndManaBarDisplay()
    {
        //Fast bars
        InGameUIReferences.Instance.healthBarFastFill.fillAmount = (float)CurrentHealth / (float)currentMaxHealth;
        InGameUIReferences.Instance.manaBarFastFill.fillAmount = (float)CurrentResourceAmount / (float)currentMaxResourceAmount;

        //Slow bars

        if (InGameUIReferences.Instance.healthBarSlowFill.fillAmount != (float)CurrentHealth / (float)currentMaxHealth) //Health
        {
            StartCoroutine(SlowFill(InGameUIReferences.Instance.healthBarSlowFill, (float)CurrentHealth / (float)currentMaxHealth));
        }

        if (InGameUIReferences.Instance.manaBarSlowFill.fillAmount != (float)CurrentResourceAmount / (float)currentMaxResourceAmount) //Mana
        {
            StartCoroutine(SlowFill(InGameUIReferences.Instance.manaBarSlowFill, (float)CurrentResourceAmount / (float)currentMaxResourceAmount));
        }
    }

    private IEnumerator SlowFill(Image img, float targerAmount)
    {
        float _startAmount = img.fillAmount;
        while (img.fillAmount != targerAmount)
        {
            img.fillAmount = Mathf.Lerp(_startAmount, targerAmount, 0.05f);
            yield return new WaitForEndOfFrame();
        }
    }

    /// <summary>
    /// This is temporary and should not be accesible in-game
    /// </summary>
    private void ToggleCraftingInterface()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            //If interface is closed, open it and vice versa
            if (CraftingPanels.CraftingUIEnabled == false)
            {
                CraftingPanels.CraftingUIEnabled = true;
                CraftingPanels.Instance.gameObject.SetActive(true);
                playerInventory.gameObject.SetActive(true);
            }
            else
            {
                CraftingPanels.CraftingUIEnabled = false;
                CraftingPanels.Instance.gameObject.SetActive(false);
                playerInventory.gameObject.SetActive(false);
            }
        }
    }
    #endregion

    #region Resources
    private void ManaRegen()
    {

        if (regenCooldown >= 1)
        {
            if (currentResourceAmount < currentMaxResourceAmount)
            {
                currentResourceAmount += regenAmount;
                if (currentResourceAmount > currentMaxResourceAmount)
                {
                    currentResourceAmount = currentMaxResourceAmount;
                }
            }
            regenCooldown = 0;
        }
        else
        {
            regenCooldown += Time.deltaTime;
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
        kbr.AddImpact(amount, direction);
    }
    #endregion

    #region Debugging
    private void DebugControls()
    {
        /*if (Input.GetKeyDown(KeyCode.Keypad0))
         {
             TakeDamage(50);
         }

         if (Input.GetKeyDown(KeyCode.Keypad1))
         {
             currentResourceAmount -= 50;
         }*/

        if (Input.GetMouseButtonDown(0))
        {
            mySpell.CastSpell((LivingEntity)this);
        }

    }
    #endregion
}
