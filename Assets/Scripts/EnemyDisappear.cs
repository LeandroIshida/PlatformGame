using System.Collections;
using UnityEngine;

public class EnemyDisappear : MonoBehaviour
{
    public float disappearTime = 3f; // Tempo antes de desaparecer
    public float reappearTime = 5f;  // Tempo antes de reaparecer

    private SpriteRenderer spriteRenderer;
    private float originalVisionRange; // Armazena o valor original da visão do inimigo

    public VisionDamageEnemy visionDamageEnemy;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (visionDamageEnemy != null)
        {
            originalVisionRange = visionDamageEnemy.visionRange; // Salva o valor original
        }

        StartCoroutine(DisappearAndReappear());
    }

    private IEnumerator DisappearAndReappear()
    {
        while (true)
        {
            yield return new WaitForSeconds(disappearTime);
            SetEnemyVisible(false); // Faz o inimigo sumir          

            yield return new WaitForSeconds(reappearTime);
            SetEnemyVisible(true); // Faz o inimigo reaparecer
        }
    }

    private void SetEnemyVisible(bool isVisible)
    {
        spriteRenderer.enabled = isVisible;

        if (visionDamageEnemy != null)
        {
            if (isVisible)
            {
                visionDamageEnemy.visionRange = originalVisionRange; // Restaura o valor original
            }
            else
            {
                visionDamageEnemy.visionRange = 0; // Remove a visão enquanto está invisível
            }
        }
    }
}
