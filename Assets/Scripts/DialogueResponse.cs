using UnityEngine;
using UnityEngine.UI;

public class DialogueResponse : MonoBehaviour
{
    public GameObject responsePanel; // Painel para respostas
    public Button yesButton; // Botão "Sim"
    public Button noButton;  // Botão "Não"

    private DialogueControl dialogueControl; // Referência ao controlador de diálogo

    private void Start()
    {
        dialogueControl = FindAnyObjectByType<DialogueControl>();
        responsePanel.SetActive(false); // Começa desativado
    }

    public void ShowResponsePanel()
    {
        responsePanel.SetActive(true); // Ativa painel de opções
        yesButton.onClick.RemoveAllListeners();
        noButton.onClick.RemoveAllListeners();

        yesButton.onClick.AddListener(() => PlayerResponse(true));
        noButton.onClick.AddListener(() => PlayerResponse(false));
    }

    private void PlayerResponse(bool isYes)
    {
        if (isYes)
        {
            Debug.Log("Jogador respondeu: SIM");
            // Aqui você pode chamar outro diálogo ou ativar alguma mecânica do jogo
        }
        else
        {
            Debug.Log("Jogador respondeu: NÃO");
            // Outro comportamento caso escolha "Não"
        }

        responsePanel.SetActive(false); // Fecha painel de resposta
        dialogueControl.EndDialogue(); // Fecha o diálogo principal
    }
}
