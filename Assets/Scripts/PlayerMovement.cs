using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

//BaseCharacter is the base of a character
public class PlayerMovements : MonoBehaviour
{
    private Vector2 movementInput;
    public InputAction playerControls;
    [SerializeField] private float movementSpeed;
    private Animator animator;
    [Range(0,1)][SerializeField] private float slowedFactor;
    private bool isSlowed;
    

    private void Awake()
    {
       animator = GetComponent<Animator>();
    }
    private void Start()
    {
        isSlowed = false;
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

        bool isMoving = movementInput.x != 0 || movementInput.y != 0;
        animator.SetBool("movementInput", isMoving);

        if (isMoving)
        {
            animator.SetFloat("X", movementInput.x);
            animator.SetFloat("Y", movementInput.y);
        }
    }

    private void FixedUpdate()
    {
        //var actuallMovementSpeed = isSlowed ? movementSpeed * slowedFactor : movementSpeed;
        var actualMovementSpeed = movementSpeed;
        if(isSlowed) actualMovementSpeed *= slowedFactor;

        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * actualMovementSpeed);

        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("FightEncounter"))
        {
            //CheckForEncouter();
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Swamp"))
        {
            isSlowed = true;
        }
        if (col.gameObject.CompareTag("TallGrass"))
        { 
            //      
        }
        else
        {
            Debug.LogError("Unknown trigger: " + col.gameObject.name);
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Swamp"))
        {
            isSlowed = false;
        }
    }
}
