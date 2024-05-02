using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerAction : MonoBehaviour, IReceiveDamage
{   
    public static PlayerAction instance {get; private set;}
    [Header("Player Stats")]
    [SerializeField] private PlayerData playerData;

    [Header("Movement and Position")]
    [SerializeField] private VectorValueScript positionStart;
    private Rigidbody2D playerRb;
    private PlayerInput playerInput;
    private Vector2 input;
    private Animator playerAnim;

    [Header("Health Player")]
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient healthGradient;
    [SerializeField] private Image healthImage;

    //DashAbility/ Agregar Header.[Header("Dash Ability)]
    // [SerializeField] private float dashSpeed;
    // [SerializeField] private float dashDuration;
    // [SerializeField] private float DashCD;
    // private bool isDash;
    // private bool canDash;
    private void Awake() 
    {
        if (instance == null)
        {
            instance = this;  
        }   
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        playerAnim = GetComponent<Animator>();
        transform.position = positionStart.initialValue;
        if(playerData.currentHealth == 0 )
        {
            playerData.currentHealth = playerData.Health;
            
        }
        slider.value = playerData.currentHealth/playerData.Health;
        healthImage.color = healthGradient.Evaluate(slider.value);  
        playerAnim.SetBool("isHurt",false);    
        // canDash = true;
    }

   

    private void Update() 
    {
        input = playerInput.actions["Movement"].ReadValue<Vector2>().normalized;   
        AnimationPlayer();

        // if (isDash)
        // {
        //     return;
        // }
    }
    private void FixedUpdate() 
    {
        Move();   
    }
    private void Move()
    {
        playerRb.MovePosition(playerRb.position+input*playerData.speedMove*Time.fixedDeltaTime);
    }

    // public void Dash(InputAction.CallbackContext callbackContext)
    // {
    //     if (callbackContext.performed && canDash)
    //     {   
    //         StartCoroutine(Dashing());
    //     }
    // }
    public void AttackPlayer(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            AttackAnimation();
        }
    }
    private void AnimationPlayer()
    {
        if (input != Vector2.zero)
        {
            playerAnim.SetFloat("Horizontal",input.x);
            playerAnim.SetFloat("Vertical",input.y);
            playerAnim.SetBool("isMoving",true);
        }
        else
        {
            playerAnim.SetBool("isMoving",false);    
           
        }


    }
    private void AttackAnimation()
    {
        playerAnim.SetTrigger("isAttack");
    }

    // private IEnumerator Dashing()
    // {
    //     Debug.Log("Daaaaaashiiiiing");
    //     canDash = false;
    //     isDash = true;
    //     playerRb.velocity = input*dashSpeed;
    //     yield return new WaitForSeconds(dashDuration);
    //     isDash = false;

    //     yield return new WaitForSeconds(DashCD);
    //     canDash = true;
    // }
    public void ReceiveDamage(int takeDamage)
    {   
        playerData.currentHealth -= takeDamage;
        playerData.currentHealth = Mathf.Max(playerData.currentHealth,0);
        slider.value = playerData.currentHealth/playerData.Health;
        healthImage.color = healthGradient.Evaluate(slider.normalizedValue);
        playerAnim.SetTrigger("isHurt");
        if ( playerData.currentHealth <= 0)
        {   
            //Debug.Log("Has Muerto");    
            playerData.currentHealth = 0;
            slider.value = 0;
            playerAnim.SetTrigger("isDead");
        }
    } 

}