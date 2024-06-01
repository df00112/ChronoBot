using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    CharacterController characterController;
    Animator animator;
    WeaponManager weaponManager;
    PlayerData playerData;

    // Hashes for animator parameters
    int isWalkingHash;
    int isRunningHash;
    int isDashingHash;

    // Movement-related variables    
    Vector2 currentMovementInput;
    Vector3 currentMovement;
    Vector3 currentRunMovement;
    bool isMovementPressed;
    bool isRunPressed;
    
    // Action-related variables
    bool isDashPressed = false;

    // Other variables
    float rotationFactorPerFrame = 15.0f;
    float dashDuration = 0.25f;
    float dashSpeed = 10.0f;
    float dashTimer = 0.0f;

    void Awake()
    {
        playerInput = new PlayerInput();
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        weaponManager = GetComponent<WeaponManager>();
        playerData = GetComponent<PlayerData>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    
        playerInput.CharacterControls.Move.started += onMovementInput;
        playerInput.CharacterControls.Move.performed += onMovementInput;
        playerInput.CharacterControls.Move.canceled += onMovementInput;
        playerInput.CharacterControls.Run.started += onRun;
        playerInput.CharacterControls.Run.canceled += onRun;
        playerInput.CharacterControls.Dash.started += onDash;
        playerInput.CharacterControls.Attack.started += onAttack;
        playerInput.CharacterControls.SecondaryAttack.started += onSecondaryAttack;
        playerInput.CharacterControls.Skill.started += onSkill;
        playerInput.CharacterControls.SwitchWeapon.started += onSwitchWeapon;
    }

    void onSwitchWeapon(InputAction.CallbackContext context)
    {
        weaponManager.SwitchWeapon();
    }

    void onAttack(InputAction.CallbackContext context)
    {
        weaponManager.PerformAttack();
    }

    void onSecondaryAttack(InputAction.CallbackContext context)
    {
        weaponManager.PerformSecondaryAttack();
    }

    void onSkill(InputAction.CallbackContext context)
    {
        weaponManager.PerformSkill();
    }

    void onDash(InputAction.CallbackContext context)
    {
        isDashPressed = context.ReadValueAsButton();
    }

    void onMovementInput (InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        currentRunMovement.x = currentMovementInput.x * playerData.MovementSpeed;
        currentRunMovement.z = currentMovementInput.y * playerData.MovementSpeed;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;

        if (!isMovementPressed)
        {
            currentMovement = Vector3.zero;
            currentRunMovement = Vector3.zero;
        }
    }

    void onRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();
    }

    void handleGravity()
    {
        if (characterController.isGrounded)
        {
            float gravity = -0.5f;
            currentMovement.y = gravity;
            currentRunMovement.y = gravity;
        } else {
            float gravity = -9.8f;
            currentMovement.y += gravity;
            currentRunMovement.y += gravity;
        }
    }

    void handleRotation()
    {
        Vector3 positionToLookAt;
        
        positionToLookAt.x = currentMovement.x;
        positionToLookAt.y = 0.0f;
        positionToLookAt.z = currentMovement.z;

        Quaternion currentRotation = transform.rotation;
        if (isMovementPressed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame * Time.deltaTime);
        }
    }

    void handleAnimation()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        if (isMovementPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }
        else if (!isMovementPressed && isWalking)
        {
            animator.SetBool(isRunningHash, false);
        }

        if ((isMovementPressed && isRunPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if ((!isRunPressed || !isMovementPressed) && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }

        if (!isMovementPressed)
        {
            animator.SetBool(isWalkingHash, false);
            animator.SetBool(isRunningHash, false);
        }
    }

    void handleStamina(){
        if (isRunPressed && playerData.Stamina > 0)
        {
            float staminaToConsume = playerData.StaminaConsumeRate * Time.deltaTime * 15;
            playerData.Stamina -= (int)(staminaToConsume);
            playerData.Stamina = Mathf.Clamp(playerData.Stamina, 0, playerData.MaxStamina);
        }
        else
        {
            isRunPressed = false;
            if (playerData.Stamina < playerData.MaxStamina && playerData.StaminaRegenTimer >= playerData.StaminaRegenDelay)
            {
                playerData.Stamina += (int)(playerData.StaminaRegenRate * Time.deltaTime * 15);
                playerData.Stamina = Mathf.Clamp(playerData.Stamina, 0, playerData.MaxStamina);
            }
        }

        if (isRunPressed)
        {
            playerData.StaminaRegenTimer = 0;
        }
        else
        {
            playerData.StaminaRegenTimer += Time.deltaTime;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        handleRotation();
        handleAnimation();

        if (isDashPressed && dashTimer <= dashDuration)
        {
            characterController.Move(transform.forward * dashSpeed * Time.deltaTime);
            dashTimer += Time.deltaTime;
        }
        else
        {
            isDashPressed = false;
            dashTimer = 0.0f;

            if (isRunPressed)
            {
                characterController.Move(currentRunMovement * Time.deltaTime);
            }
            else
            {
                characterController.Move(currentMovement * Time.deltaTime);
            }
        }
        
        handleGravity();
        handleStamina();
    }

    void OnEnable()
    {
        playerInput.Enable();
    }

    void OnDisable()
    {
        playerInput.Disable();
    }
}
