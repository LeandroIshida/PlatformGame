/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    private void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, player.position, 0.1f);
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 0.1f; // Velocidade de suaviza��o
    public Vector3 offset; // Ajuste manual da posi��o da c�mera em rela��o ao player

    private void FixedUpdate()
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed);
    }
}


