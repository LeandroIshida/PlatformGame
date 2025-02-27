using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;

    public string playerTag = "Player"; // Define a tag do jogador no Inspector
    //public LayerMask playerLayer;
    public float radious;
    private DialogueControl dc;

    bool onRadious;


    private void Start()
    {
        dc = FindAnyObjectByType<DialogueControl>();
    }

    private void FixedUpdate()
    {
        Interact();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onRadious) 
        {
            dc.Speech(profile, speechTxt, actorName);
        }
    }

    public void Interact()
    {
        /*Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);

        if (hit != null)
        {
            dc.Speech(profile, speechTxt, actorName);
        }*/

        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious);

        if (hit != null && hit.CompareTag(playerTag)) // Verifica se o Collider encontrado tem a Tag correta
        {
            //dc.Speech(profile, speechTxt, actorName);
            onRadious = true;
        }
        else
        {
            onRadious = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, radious);
    }

}
