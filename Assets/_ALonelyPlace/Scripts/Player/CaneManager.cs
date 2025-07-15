using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CaneManager : MonoBehaviour
{
    private Transform _caneTransform;
    public Vector3 startPosition;
    private float _rotSpeed;
    private float _angle;
    private bool _canMove = true;

    public void SetCane(float rSpeed, float angle)
    {
        _rotSpeed = rSpeed;
        _angle = angle;
    }

    public void Move()
    {
        if(!_canMove)
        {
            return; // Prevent moving if already in motion
        }
        
        Debug.Log("Moving Cane");
        
        _caneTransform = this.gameObject.transform;
        startPosition = _caneTransform.position;
        
        StartCoroutine(SenceCane());
    }
    
    IEnumerator SenceCane()
    {
        _canMove = false;
        
        Vector3 newPosition = _caneTransform.position + (Vector3.up * 1.0f);
        _caneTransform.position = newPosition;
        
        yield return new WaitForSeconds(.25f);
            
        newPosition = startPosition;
        _caneTransform.position = newPosition;
        
        _canMove = true;
    }
}
