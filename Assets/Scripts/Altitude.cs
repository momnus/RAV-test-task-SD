using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Altitude : MonoBehaviour
{
    
    GameObject Camera;
    public float _altitude;
    
    // Start is called before the first frame update
    void Start()
    {
        Camera = this.gameObject;
       
    }
        

    // Update is called once per frame
    void Update()
    {
        _altitude = Camera.transform.position.y;
        if (Camera.transform.position.y >= 0)
        { AkSoundEngine.SetRTPCValue("Altitude", Camera.transform.position.y); }
        else { AkSoundEngine.SetRTPCValue("Altitude", 0); print("LowAir"); }
        
       
    }
}
