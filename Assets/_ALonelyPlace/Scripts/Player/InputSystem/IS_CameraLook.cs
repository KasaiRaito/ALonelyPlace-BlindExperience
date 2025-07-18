using UnityEngine;

public class IS_CameraLook : MonoBehaviour
{
    private float _xRotation = 0.0f;
    private float _rotationSpeed;
    private GameObject _playerBody;

    public void SetSpeed(float speed)
    {
        _rotationSpeed = speed;
    }
    
    public void SetPlayerBody(GameObject playerBody)
    {
        _playerBody = playerBody;
    }
    
    public void Look(Vector2 input)
    {
        if(!_playerBody || _rotationSpeed <= 0f)
        {
            Debug.LogError("Player body not set or rotation speed is not positive.");
            return; // Ensure player body is set and rotation speed is positive
        }
        
        var dtX = input.x * _rotationSpeed * Time.deltaTime;
        var dtY = input.y * _rotationSpeed * Time.deltaTime;

        _xRotation -= dtY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);
        
        transform.localRotation = Quaternion.Euler(_xRotation, 0.0f, 0f);
        _playerBody.transform.Rotate(Vector3.up * dtX);
    }
}
