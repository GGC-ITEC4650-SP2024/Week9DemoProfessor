using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myBod;
    public float speed;
    public float jumpPower;
    public int maxJumps;

    int numJumps;

    // Start is called before the first frame update
    void Start()
    {
        myBod = GetComponent<Rigidbody2D>();
        numJumps = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        Vector2 v = myBod.velocity;
        v.x = h * speed;
        if(Input.GetButtonDown("Jump") && numJumps > 0) {
            v.y = jumpPower;
            numJumps--;
        }
        myBod.velocity = v;

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Ground") {
            numJumps = maxJumps;
        }
    }
}
