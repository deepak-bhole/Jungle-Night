using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot
    {
        public Ammotype ammoType;
        public int ammoAmount;
        public string ammoName;
    }
    public int GetCurrentAmmo(Ammotype ammoType)
    {
        return GetAmmoSlot(ammoType).ammoAmount;
    }

    public string GetAmmoName(Ammotype ammoType)
    {
        return GetAmmoSlot(ammoType).ammoName; 
    }

    public void ReduceCurrentAmmo(Ammotype ammoType)
    {
        GetAmmoSlot(ammoType).ammoAmount--;
    }

    public void IncreaseCurrentAmmo(Ammotype ammoType, int ammoAmount)
    {
        GetAmmoSlot(ammoType).ammoAmount += ammoAmount;
    }

    private AmmoSlot GetAmmoSlot(Ammotype ammoType)
    {
        foreach(AmmoSlot Slot in ammoSlots)
        {
            if(Slot.ammoType == ammoType)
            {
                return Slot;
            }
        }
        return null;
    }
}
