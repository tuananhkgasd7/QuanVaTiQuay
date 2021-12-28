using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigController : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical;
    Rigidbody2D rigid;

    //Moving
    int direction = 1;
    float timer;
    public float changeTime = 3.0f;

    //Animator
    Animator anim;

    //Broken
    bool broken = true;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        timer = changeTime;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!broken){
            return;
        }
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction *= -1;
            timer = changeTime;
        }

        if(vertical)
        {
            anim.SetFloat("Move X", 0);
            anim.SetFloat("Move Y", direction);
        }
        else
        {
            anim.SetFloat("Move X", direction);
            anim.SetFloat("Move Y", 0);
        }
    }
    void FixedUpdate()
    {
        if(!broken){
            return;
        }
        Vector2 pos = rigid.position;
        if (vertical)
        {
            pos.y += (speed * Time.deltaTime * direction);
        }
        else
        {
            pos.x += (speed * Time.deltaTime * direction);
        }

        rigid.MovePosition(pos);
    }

    public void Fix(){
        broken = false;
        rigid.simulated = false;
    }
}
