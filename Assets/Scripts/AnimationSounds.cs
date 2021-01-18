using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSounds : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void playSFX(string arg)
    {
        AkSoundEngine.PostEvent(arg, gameObject);
    }
}
