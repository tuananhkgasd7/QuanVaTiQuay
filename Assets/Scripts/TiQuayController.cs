using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiQuayController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 position = transform.position;
        position.x += (0.05f * horizontal);
        position.y += (0.05f * vertical);
        transform.position = position;
    }
}
