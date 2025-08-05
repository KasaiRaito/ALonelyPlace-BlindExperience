using UnityEngine;

public class GameCanvasManager : MonoBehaviour
{
    [SerializeField] private float waitTime;
    private float timer = 0f;
    
    public GameObject MoveImage;
    public GameObject LookImage;
    public GameObject RunImage;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            TurnOnUI();
            //Debug.Log("Turn on UI");
        }
    }

    void TurnOnUI()
    {
        MoveImage.SetActive(true);
        LookImage.SetActive(true);
        RunImage.SetActive(true);
    }
    
    void TurnOffUI()
    {
        MoveImage.SetActive(false);
        LookImage.SetActive(false);
        RunImage.SetActive(false);
    }
    
    public void MakeValidInput()
    {
        timer = waitTime; // Reset the timer when valid input is made
        TurnOffUI();
        //Debug.Log("Valid input made, resetting timer.");
    }
}