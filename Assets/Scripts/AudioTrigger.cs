using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class AudioTrigger : MonoBehaviour
{
    #region Variables

    [Header("Trigger States")]
    
    [SerializeField] private bool DestroyOnExit;
    [SerializeField] private float DeleteDelay;

    private enum StartEventCondition { OnEnter, OnExit};
    private enum StopEventCondition { OnEnter, OnExit };

    [Header("Sound System")]
    [SerializeField] private WwiseAudioPlayer AudioPlayer;
    [SerializeField] private string StartSound;
    [SerializeField] StartEventCondition _StartCondition = StartEventCondition.OnEnter;
    [SerializeField] private string StopSound;
    [SerializeField] StopEventCondition _StopCondition = StopEventCondition.OnEnter;
   
    [SerializeField] private GameObject SoundObject;

    [HideInInspector]
    [Tooltip("Сейчас не работает, Триггер только для игрока")]
    [TagSelector] [SerializeField] private string CollisionTag;
    [SerializeField] private bool TriggerOnce;
    private string _tag;

    public bool SoundActivated = false;

    #endregion
    private void Start()
    {
        SoundActivated = false;
        // _tag = CollisionTag;
        if (!SoundObject)
        { SoundObject = this.gameObject; }

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
       //     SoundActive();
        //    if (SoundActivated == false)
       //     {

                if (_StartCondition == StartEventCondition.OnEnter)
                {


                    if (StartSound != null)
                    { AudioPlayer.playSFX(StartSound, SoundObject); }
                    else Debug.Log("no sfx found with name: " + StartSound);

                }
                if (_StopCondition == StopEventCondition.OnEnter)
                {
                    if (StopSound != null)
                    { AudioPlayer.playSFX(StopSound, SoundObject); }
                    else Debug.Log("no sfx found with name: " + StopSound);

                }
            }

       // }
    }

    private void OnTriggerExit(Collider other)
    {
      if (other.CompareTag("Player"))
        {
      //      SoundActive();
      //      if (SoundActivated == false)
      //      {
                if (_StartCondition == StartEventCondition.OnExit)
                {
                    if (StartSound != null)
                    { AudioPlayer.playSFX(StartSound, SoundObject); }
                    else Debug.Log("no sfx found with name: " + StartSound);

                }
                if (_StopCondition == StopEventCondition.OnExit)
                {
                    if (StopSound != null)
                    { AudioPlayer.playSFX(StopSound, SoundObject); }
                    else Debug.Log("no sfx found with name: " + StopSound);

                }
                if (DestroyOnExit == true)
                { StartCoroutine("Delete"); }
            }  
     //   }
        
    }

    private void SoundActive()
    {
        if (TriggerOnce == true) { SoundActivated = true; }
        else { return; }
    }

    


    //And function itself
    IEnumerator Delete()
    {
        //play your sound
        yield return new WaitForSeconds(DeleteDelay); //waits 3 seconds
        Destroy(gameObject); //this will work after 3 seconds.
    }

   
}





