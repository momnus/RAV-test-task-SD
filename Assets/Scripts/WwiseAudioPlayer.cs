
using UnityEngine;
using System.Collections;

public class WwiseAudioPlayer : MonoBehaviour
{
    [Header("MuteOnStart")]
   // [SerializeField] AK.Wwise.Event Mute;

    public WwiseAudioItems[] AudioList;
    
       // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        AkSoundEngine.PostEvent("Game_Start", gameObject);
    }

    public void playSFX(string name)
    {
        bool SFXFound = false;
        foreach (WwiseAudioItems s in AudioList)
        {
            if (s.name == name)
            {

                s.clip.Post(gameObject);

                SFXFound = true;
            }
        }
        if (!SFXFound) Debug.Log("no sfx found with name: " + name);

    }
    public void playSFX(string name, GameObject gameobject)
    {
        bool SFXFound = false;
        foreach (WwiseAudioItems s in AudioList)
        {
            if (s.name == name)
            {

              s.clip.Post(gameobject);

                SFXFound = true;
            }
        }
        if (!SFXFound) Debug.Log("no sfx found with name: " + name);

    }
    public void stopSFX(string name, GameObject gameobject)
    {
        bool SFXFound = false;
        foreach (WwiseAudioItems s in AudioList)
        {
            if (s.name == name)
            {

                    s.clip.Post(gameobject);

                SFXFound = true;
            }
        }
        if (!SFXFound) Debug.Log("no sfx found with name: " + name);
    }
    
}



