using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int CurrentWeapon = 0;

    void Start()
    {
        SetActiveWeapon();
    }

    void Update()
    {
        int previousWeapon = CurrentWeapon;

        ProcessInputKey();
        ProcessScrollWheel();

        if(previousWeapon != CurrentWeapon)
        {
            SetActiveWeapon();
        }

    }

    private void ProcessScrollWheel()
    {
        if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if(CurrentWeapon >= transform.childCount - 1)
            {
                CurrentWeapon = 0;
            }
            else
            {
                CurrentWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (CurrentWeapon <= 0)
            {
                CurrentWeapon = transform.childCount - 1;
            }
            else
            {
                CurrentWeapon--;
            }
        }

    }

    private void ProcessInputKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentWeapon = 2;
        }


    }

    private void SetActiveWeapon()
    {
        int WeaponIndex = 0;

        foreach(Transform weapon in transform)
        {
            if (CurrentWeapon == WeaponIndex)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }

            WeaponIndex++;

        }
        
        
    }

   
}
