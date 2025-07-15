using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCore : MonoBehaviour
{
    public float walk; // Speed of movement
    public float run; // Speed of movement
    public float turnSpeed; // Speed of Camera movement
    private Vector2 _lookInput; // Input for looking around
    private Vector3 _moveInput; // Input for moving around
    private bool _run;
    
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private IS_CameraLook _cameraLook;
    [SerializeField] private IS_PlayerMove _playerMove;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        _cameraLook.SetSpeed(turnSpeed);
        _cameraLook.SetPlayerBody(this.gameObject);
        
        _playerMove.SetSpeeds(walk, run);
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        if (!_cameraLook || !_playerMove)
        {
            Debug.LogError("PlayerCore: Missing CameraLook or PlayerMove component.");
            return;
        }
        
        //見て　の　カメラ　// mite no kamera(look camera)
        _lookInput = _playerInput.actions["Camera"].ReadValue<Vector2>();
        _cameraLook.Look(_lookInput);
        
        //動き　// ugoki (move)
        Vector3 temp = _playerInput.actions["Move"].ReadValue<Vector2>();
        _moveInput = new Vector3(temp.x, 0, temp.y);
        
        _run = _playerInput.actions["Run"].ReadValue<float>() > 0.0f; // Check if the run action is pressed
        
        _playerMove.Move(_moveInput, _run);
    }
}
