using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueMob : MonoBehaviour
{
    public Sprite profile;
    public string[] speechTxt;
    public string actorName;
    

    public string playerTag = "Player"; // Define a tag do jogador no Inspector
    public float radius;
    private DialogueControl dc;

    private bool onRadius;

    private void Start()
    {
        dc = FindAnyObjectByType<DialogueControl>();
    }

    private void FixedUpdate()
    {
        Interact();
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius);

        if (hit != null && hit.CompareTag(playerTag)) // Verifica se o Collider encontrado tem a Tag correta
        {
            if (!onRadius) // Só inicia o diálogo uma vez
            {
                dc.Speech(profile, speechTxt, actorName);
                onRadius = true;
            }
            
        }
        else
        {
            onRadius = false;
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
