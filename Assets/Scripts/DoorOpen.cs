using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] private Animator anim;

    [Header("Sounds")]
    [SerializeField] private WwiseAudioPlayer AudioPlayer;
    [SerializeField] private string OpenDoorSound;
    [SerializeField] private GameObject RoomPortal;

    [Header("Tooltips")]
    [SerializeField] private GameObject Canvas;
    [SerializeField] private float HelpDelay = 3.0f;
    private bool tooltip;
    private bool open;



    // Start is called before the first frame update
    void Start()
    {
        open = false;
        tooltip = false;
        Canvas.SetActive(false);
        RoomPortal.SetActive(false);
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (tooltip == false)
            {
                Canvas.SetActive(true);
                StopCoroutine("Tooltips");
                StartCoroutine("Tooltips");

            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                AudioPlayer.playSFX(OpenDoorSound);
                if (open == false)
                {
                    anim.SetBool("Door_open_state", true);
                    RoomPortal.SetActive(true);

                    StopCoroutine("Door");
                    StartCoroutine("Door");

                }
               if (open == true)
                {
                   anim.SetBool("Door_open_state", false);
                    RoomPortal.SetActive(false);
                    StopCoroutine("Door");
                   StartCoroutine("Door");

              }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Canvas.SetActive(false);
    }

    #region Coroutines
    IEnumerator Tooltips()
        {
            yield return new WaitForSeconds(HelpDelay);
            Canvas.SetActive(false);
            tooltip = true;
        }
        IEnumerator Door()
        {
            yield return new WaitForSeconds(1.1f);
        open = !open;
        }

    #endregion
}
