using System.Collections;
using UnityEngine;

public class VisionDamageEnemy : MonoBehaviour
{
    public HeartSystem heart; // Refer�ncia ao sistema de vida do player
    public string playerTag = "Player"; // Tag do jogador
    public float visionRange = 5f; // Dist�ncia m�xima de vis�o
    public float visionAngle = 45f; // �ngulo de vis�o do inimigo (em graus)
    public Vector2 visionDirection = Vector2.right; // Dire��o inicial do campo de vis�o
    public float damageCooldown = 2f; // Tempo entre cada dano
    public float blinkDuration = 2.0f; // Dura��o do efeito de piscar
    public float blinkInterval = 0.2f; // Intervalo entre os piscares
    public LayerMask obstacleMask; // Camadas que bloqueiam a vis�o (ex: ch�o e paredes)

    private float lastDamageTime = 0f;

    private void Update()
    {
        CheckPlayerInVision();
    }

    private void CheckPlayerInVision()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player == null) return;

        Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        float angleToPlayer = Vector2.Angle(visionDirection.normalized, directionToPlayer);

        if (distanceToPlayer <= visionRange && angleToPlayer <= visionAngle / 2)
        {
            // **Realiza um Raycast para verificar se h� obst�culos**
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, visionRange, obstacleMask);

            if (hit.collider == null || hit.collider.CompareTag(playerTag)) // Se n�o h� obst�culos OU atinge o player
            {
                ApplyDamage(player);
            }
        }
    }

    private void ApplyDamage(GameObject player)
    {
        if (Time.time >= lastDamageTime + damageCooldown)
        {
            lastDamageTime = Time.time;
            heart.HP--; // Reduz a vida do jogador

            // Efeito de piscar
            SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
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
        spriteRenderer.enabled = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Vector3 rightLimit = Quaternion.Euler(0, 0, visionAngle / 2) * visionDirection.normalized;
        Vector3 leftLimit = Quaternion.Euler(0, 0, -visionAngle / 2) * visionDirection.normalized;

        Gizmos.DrawLine(transform.position, transform.position + rightLimit * visionRange);
        Gizmos.DrawLine(transform.position, transform.position + leftLimit * visionRange);
    }
}
