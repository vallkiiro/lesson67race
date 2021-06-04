using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour
{
    Rigidbody player_rb;
    Transform player_tr;
    float horiz;
    float vert;

    int hp;
    public Text text_hp;

    int time;
    public Text text_timer;
    

    void Timer()
    {
        time = time - 1;
        text_timer.text = "Время: " + time;
    }

    void Start()
    {
        InvokeRepeating("Timer", 1f, 1f);

        player_rb = GetComponent<Rigidbody>();
        player_tr = GetComponent<Transform>();

        hp = 100;
        text_hp.text = "HP: " + hp;

        time = 30;
    }

    void Update()
    {
        horiz = Input.GetAxis("Horizontal") * 5f;
        vert = Input.GetAxis("Vertical");
        player_rb.AddForce(player_tr.forward * vert * 30f);
        player_tr.Rotate(0,horiz,0);

        if(time==0)
        {
            CancelInvoke();
        }
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="sign")
        {
            hp = hp - 10;
           text_hp.text = "HP: " + hp;
        }

        if (collision.gameObject.tag=="finish")
        {
            
            CancelInvoke();
            if(hp>0)
            {
                text_hp.text = "По очкам: ты выиграл";
            }
            else
            {
                text_hp.text = "По очкам: ты проиграл";
            }

            
            if(time>0)
            {
                text_timer.text = "По времени: ты выиграл";
            }
            else
            {
                text_timer.text = "По времени: ты проиграл";
            }
            
        }
    }
}
