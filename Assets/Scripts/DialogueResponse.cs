using UnityEngine;
using UnityEngine.UI;

public class DialogueResponse : MonoBehaviour
{
    public GameObject responsePanel; // Painel para respostas
    public Button yesButton; // Bot�o "Sim"
    public Button noButton;  // Bot�o "N�o"

    private DialogueControl dialogueControl; // Refer�ncia ao controlador de di�logo

    private void Start()
    {
        dialogueControl = FindAnyObjectByType<DialogueControl>();
        responsePanel.SetActive(false); // Come�a desativado
    }

    public void ShowResponsePanel()
    {
        responsePanel.SetActive(true); // Ativa painel de op��es
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
            // Aqui voc� pode chamar outro di�logo ou ativar alguma mec�nica do jogo
        }
        else
        {
            Debug.Log("Jogador respondeu: N�O");
            // Outro comportamento caso escolha "N�o"
        }

        responsePanel.SetActive(false); // Fecha painel de resposta
        dialogueControl.EndDialogue(); // Fecha o di�logo principal
    }
}
