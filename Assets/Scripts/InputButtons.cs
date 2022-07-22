using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputButtons : MonoBehaviour
{
    private bool isPause = false;

    [SerializeField] Canvas gameOverCanvas;

    bool isDead;

    void Start()
    {
        gameOverCanvas.enabled = false;

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && gameOverCanvas.enabled == true)
        {
            isPause = !isPause;
            Options(isPause);
            
        }
    }

    void Options(bool ispause)
    {
        if(ispause)
        {
            gameOverCanvas.enabled = true;
            Time.timeScale = 0;
            FindObjectOfType<WeaponSwitcher>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            gameOverCanvas.enabled = false;
            Time.timeScale = 1;
            FindObjectOfType<WeaponSwitcher>().enabled = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = false;

        }  
    }
}
