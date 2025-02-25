using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoundCheck : MonoBehaviour
{

    Controller Player;  


    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject.GetComponent<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Player.isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Player.isJumping = true;
        }
    }
}
