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
    Animator animator;

    //Inventory
    private Inventory inventory;
    [SerializeField] private UI_Inventory uiInventory;

    // private void Awake(){
    //     inventory = new Inventory();
    //     uiInventory.SetInventory(inventory);
    // }

    private void OnTriggerEnter2D(Collider2D collider) {
        ItemWorld itemWorld = collider.GetComponent<ItemWorld>();
        if(itemWorld != null){
            // if(Input.GetKey(KeyCode.Space)){
                inventory.AddItem(itemWorld.GetItem());
                itemWorld.DestroySelf();
            // }
        }
    
    }

    // Start is called before the first frame update
    void Start()
    {        
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        inventory = new Inventory();
        uiInventory.SetInventory(inventory);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 moving = new Vector2(horizontal, vertical);
        Vector2 direction = Vector2.zero;
        if(!Mathf.Approximately(moving.x, 0.0f) || !Mathf.Approximately(moving.y, 0.0f)){
            direction = moving.normalized;
        }
        animator.SetFloat("Move X", direction.x);
        animator.SetFloat("Move Y", direction.y);
        animator.SetFloat("Speed", moving.magnitude);

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
