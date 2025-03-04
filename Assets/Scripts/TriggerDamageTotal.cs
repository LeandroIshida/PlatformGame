/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
    public HeartSystem heart;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            heart.HP--;
        }
    }
}*/
using System.Collections;
using UnityEngine;

public class TriggerDamageTotal : MonoBehaviour
{
    public HeartSystem heart;
    public float blinkDuration = 2.0f;   // Duração total do efeito
    public float blinkInterval = 0.2f;   // Intervalo entre os pisca/pra não piscar

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            heart.HP = 0;

            // Tenta obter o SpriteRenderer do player
            SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                // Inicia a Coroutine para piscar o sprite
                StartCoroutine(BlinkSprite(sr, blinkDuration, blinkInterval));
            }
        }
    }

    private IEnumerator BlinkSprite(SpriteRenderer spriteRenderer, float duration, float blinkInterval)
    {
        float elapsedTime = 0f;
        bool isVisible = true;
        while (elapsedTime < duration)
        {
            isVisible = !isVisible;
            spriteRenderer.enabled = isVisible;
            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }
        // Garante que, ao final, o sprite fique visível
        spriteRenderer.enabled = true;
    }
}

