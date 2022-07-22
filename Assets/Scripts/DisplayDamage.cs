using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas ImpactCanvas;
    [SerializeField] float ImpactTime = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        ImpactCanvas.enabled = false;    
    }

    // Update is called once per frame
    public void ShowDamageImpact()
    {
        StartCoroutine(showSplatter());
    }

    IEnumerator showSplatter()
    {
        ImpactCanvas.enabled = true;
        yield return new WaitForSeconds(ImpactTime);
        ImpactCanvas.enabled = false;
    }
}

