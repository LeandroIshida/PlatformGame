using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public int HP;
    public int HPMax;

    public Image[] heart;
    public Sprite HasHP;
    public Sprite DontHasHP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthLogic();
        DeadState();
    }

    void HealthLogic()
    {
        if (HP > HPMax)
        {
            HP = HPMax;
        }

        for (int i = 0; i < heart.Length; i++)
        {
            if (i < HP)
            {
                heart[i].sprite = HasHP;
            }
            else
            {
                heart[i].sprite = DontHasHP;
            }
        }

        for (int i = 0; i < heart.Length; i++)
        {
            if (i < HPMax)
            {
                heart[i].enabled = true;            
            }
            else
            {
                heart[i].enabled = false;
            }
        }
    }

    void DeadState()
    {
        if (HP <= 0)
        {
            GetComponent<Renderer>().enabled = false;
            Destroy(gameObject,1f);
        }
    }
}
