using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ScreenWrap : MonoBehaviour
{
    private Rigidbody2D myRigiBody;
    // Start is called before the first frame update
    void Start()
    {
        myRigiBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        float rightSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float leftSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).x;

       /* float topSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
        float bottomSideOfScreenInWorld = Camera.main.ScreenToWorldPoint(new Vector2(0f, 0f)).y;*/

        if (screenPos.x <= 0 && myRigiBody.velocity.x < 0)
        {
            transform.position = new Vector2(rightSideOfScreenInWorld, transform.position.y);
        }
        else if(screenPos.x >= Screen.width && myRigiBody.velocity.x > 0)
        {
            transform.position = new Vector2(leftSideOfScreenInWorld, transform.position.y);
        }
       /* else if(screenPos.y >= Screen.height && myRigiBody.velocity.y > 0)
        {
            transform.position = new Vector2(transform.position.x, bottomSideOfScreenInWorld);
        }
        else if(screenPos.y <= 0 && myRigiBody.velocity.y < 0)
        {
            transform.position = new Vector2(transform.position.x, topSideOfScreenInWorld);
        }*/
    }
}
