using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using static UnityEngine.InputSystem.InputAction;

//BaseCharacter is the base of a character
public class PlayerMovements : MonoBehaviour
{
    private Vector2 movementInput;
    [SerializeField] private float movementSpeed;
    [Range(0,1)][SerializeField] private float slowedFactor;
    private bool isSlowed;
    private bool isPlayerPaused; 
    private bool isSprinting;
    public InputAction playerControls;
    private Vector3Int currentPosition;
    private Vector3Int lastEncounterPosition;
    private Animator animator;
    public InputAction sprintAction;
    

    /// <summary>
    /// returns the first found Tilemap in the scene (!!make sure all Tilemaps have the same Transform!!)
    /// </summary>
    public Tilemap tilemap
    {
        get
        {
            if (m_tilemap == null) m_tilemap = FindObjectOfType< Tilemap>();
            return m_tilemap; 
        }
    }
    private Tilemap m_tilemap;
    private void Awake()
    {
       animator = GetComponent<Animator>();
    }
    private void Start()
    {
        isSlowed = false;
        isPlayerPaused = false;
    }

    /// <summary>
    /// Movement is called by the input system when the player moves the joystick or presses the arrow keys
    /// </summary>
    /// <param name="ctx">Context provided by Unity Input</param>
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    /* public void Movement(CallbackContext ctx)
     {
         //movementInput is set by unity events
         movementInput = ctx.ReadValue<Vector2>(); //comment
     }*/

    //This is now a FIXEDupdate

    private void Update()
    {
        movementInput = playerControls.ReadValue<Vector2>();
        isSprinting = sprintAction.ReadValue<float>() > 0; //check if sprinting is pressed

        bool isMoving = movementInput.x != 0 || movementInput.y != 0;
        animator.SetBool("movementInput", isMoving);

        if (isMoving)
        {
            animator.SetFloat("X", movementInput.x);
            animator.SetFloat("Y", movementInput.y);
        }
        animator.SetBool("isSprinting", isSprinting); //set animator to sprinting
    }

    private void FixedUpdate()
    {
        float actualMovementSpeed = movementSpeed;
        //var actuallMovementSpeed = isSlowed ? movementSpeed * slowedFactor : movementSpeed;
        
        if(isSlowed) 
           actualMovementSpeed *= slowedFactor;

        if (isSprinting && !isSlowed)
            actualMovementSpeed *= 1.5f; 






        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * actualMovementSpeed);

        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Swamp"))
        {
            isSlowed = true;
        }
        else if (col.gameObject.CompareTag("FightEncounter"))
        {
            if (currentPosition != lastEncounterPosition)
            {
                lastEncounterPosition = currentPosition;
                PausePlayer(FightManager.Instance.CheckForEncounter(this));
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Swamp"))
        {
            isSlowed = false;
        }
    }

    public void PausePlayer(bool isPaused)
    {
       isPlayerPaused = isPaused;
    }
}
