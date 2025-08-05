using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class PlayerCore : MonoBehaviour
{
    public Animator animator;
    public float walk; // Speed of movement
    public float run; // Speed of movement
    public float turnSpeed; // Speed of Camera movement
    private Vector2 _lookInput; // Input for looking around
    private Vector2 _moveInput; // Input for moving around
    private bool _run;
    
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private IS_CameraLook cameraLook;
    [SerializeField] private IS_PlayerMove playerMove;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!animator)
        {
            Debug.LogError("PlayerCore: Animator is not assigned.");
        }

        Cursor.lockState = CursorLockMode.Locked;

        cameraLook.SetSpeed(turnSpeed);
        cameraLook.SetPlayerBody(this.gameObject);

        playerMove.SetSpeeds(walk, run);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //見て　の　カメラ　// mite no kamera(look camera)
        _lookInput = playerInput.actions["Camera"].ReadValue<Vector2>();
        cameraLook.Look(_lookInput);
        
        //動き　// ugoki (move)
        _moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        
        _run = playerInput.actions["Run"].ReadValue<float>() > 0.0f; // Check if the run action is pressed
        
        playerMove.Move(_moveInput, _run);
        
        CheckAnim(_moveInput);
    }

    private void CheckAnim(Vector2 moveInput)
    {
        animator.SetBool("RUN", _run);
        animator.SetBool("WALK", !_run);
        animator.SetFloat("WalkY", moveInput.y);
        animator.SetFloat("WalkX", moveInput.x);
    }
}
