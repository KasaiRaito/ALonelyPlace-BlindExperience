using System;
using UnityEngine;

public class IS_PlayerMove : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    private float _walkSpeed;
    private float _runSpeed;

    public void SetSpeeds(float walkSpeed, float runSpeed)
    {
        //スピード　- supiido (speed)
        _walkSpeed = walkSpeed;
        _runSpeed = runSpeed;
    }
    
    //動き - ugoki (move)
    public void Move(Vector2 input, bool isRunning)
    {
        if (!isRunning)
        {
            //歩く　- aruku (walk)
            Vector3 move = transform.right * input.x + transform.forward * input.y;
            _characterController.Move( move * (_walkSpeed * Time.deltaTime)); 
        }
        else
        {
            //走る - hashiru (run)
            Vector3 move = transform.right * input.x + transform.forward * input.y;
            _characterController.Move( move * (_runSpeed * Time.deltaTime));
        }
    }
    
}
