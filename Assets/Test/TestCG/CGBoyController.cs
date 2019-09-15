using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowWaveEffect()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<WaterWaveEffect>().enabled = true;
    }
}
