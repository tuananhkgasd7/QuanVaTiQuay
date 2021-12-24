using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiQuayController : MonoBehaviour
{
    //Speed
    public float speed = 4.0f;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
  
    //Animator
    Animator anim;
    Vector2 direction = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector2 moving = new Vector2(horizontal, vertical);
        if(!Mathf.Approximately(moving.x, 0.0f) || !Mathf.Approximately(moving.y, 0.0f)){
            direction = moving.normalized;
        }
        anim.SetFloat("Move X", direction.x);
        anim.SetFloat("Move Y", direction.y);
        anim.SetFloat("Speed", moving.magnitude);
        // if(Input.GetKeyDown(KeyCode.Space)){
        //     Launch();
        // }
    }

    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        position.x += (speed * horizontal) * Time.deltaTime;
        position.y += (speed * vertical) * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }
}
