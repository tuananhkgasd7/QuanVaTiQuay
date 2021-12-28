using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuanController : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;
    // Start is called before the first frame update
    [SerializeField]
    Rigidbody2D rigid;
    public float moveSpeed = 3.0f;
    private int waypointIndex = 0;
    Animator anim;
    float horizontal;
    float vertical;
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move(){
        if(waypointIndex <= waypoints.Length - 1){
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed*Time.deltaTime);
            anim.SetFloat("Move X", (waypoints[waypointIndex].transform.position.x - transform.position.x));
            anim.SetFloat("Move Y", (waypoints[waypointIndex].transform.position.y - transform.position.y));
            if(transform.position == waypoints[waypointIndex].transform.position){
                waypointIndex += 1;
            }
        }
    }
}
