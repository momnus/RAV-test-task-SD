using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEmitter : MonoBehaviour
{
    [SerializeField] private WwiseAudioPlayer AudioPlayer;
    [SerializeField] private string StartEvent;
    [SerializeField] private string StopEvent;
    

    private void Start()
    {
        
        if (StartEvent != null)
        { AudioPlayer.playSFX(StartEvent, gameObject); }
        else Debug.Log("no sfx found with name: " + StartEvent);
    }
    private void OnDestroy()
    {
        if (StopEvent !=null)
        { AudioPlayer.playSFX(StopEvent, gameObject); }
        else Debug.Log("no sfx found with name: " + StopEvent);

    }
}
