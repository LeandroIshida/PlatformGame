/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogue;
    public Image profile;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;

    public void Speech(Sprite p, string[] txt, string actorName)
    {
        
        dialogue.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        actorNameText.text = actorName;
        StartCoroutine(TypeSentence());
        

    }

    IEnumerator TypeSentence()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        
        if (speechText.text == sentences[index])
        {
            if(index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                speechText.text = "";
                index = 0;
                dialogue.SetActive(false);
                
            }
        }
    }

}*/
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogue;
    public Image profile;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")]
    public float typingSpeed;
    private string[] sentences;
    private int index;

    private bool isTyping = false; // Evita chamadas repetidas
    private bool isDialogueActive = false; // Controla se o di�logo est� ativo

    private DialogueResponse dialogueResponse; // Refer�ncia ao sistema de resposta

    private void Start()
    {
        dialogueResponse = FindAnyObjectByType<DialogueResponse>();
    }

    public void Speech(Sprite p, string[] txt, string actorName)
    {
        if (isDialogueActive) return; // Evita reiniciar o di�logo se j� estiver ativo

        isDialogueActive = true;
        dialogue.SetActive(true);
        profile.sprite = p;
        sentences = txt;
        actorNameText.text = actorName;
        index = 0;
        speechText.text = "";
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        isTyping = true;
        speechText.text = "";

        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false; // Permite avan�ar para a pr�xima frase
    }

    public void NextSentence()
    {
        if (isTyping) return; // Evita pular enquanto digita

        if (index < sentences.Length - 1)
        {
            index++;
            StartCoroutine(TypeSentence());
        }
        else
        {
            dialogueResponse.ShowResponsePanel(); // Exibe as op��es de resposta
        }
    }

    public void EndDialogue()
    {
        dialogue.SetActive(false);
        speechText.text = "";
        isDialogueActive = false; // Permite iniciar novo di�logo depois
    }
}


