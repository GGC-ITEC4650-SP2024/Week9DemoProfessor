using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D myBod;
    Animator myAnim;
    Weapon[] myWeapons;

    InvManager invMgr;

    public float speed;
    public float jumpPower;
    public int maxJumps;

    int numJumps;

    // Start is called before the first frame update
    void Start()
    {
        myBod = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myWeapons = GetComponentsInChildren<Weapon>();
        invMgr = GameObject.Find("Inv").GetComponent<InvManager>();
        numJumps = 0;

        equipCurrentWeapon();
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

        //direction
        if(h > 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        } else if (h < 0) {
            transform.localScale = new Vector3(1, 1, 1);
        }

        // animations
        myAnim.SetBool("RUN", h != 0);
        myAnim.SetBool("ATTACK", Input.GetButtonDown("Fire1"));

        if(Input.GetButtonDown("Fire2")) {
            invMgr.selectNextItem();
            equipCurrentWeapon();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Ground") {
            numJumps = maxJumps;
        }
    }

    public void equipCurrentWeapon() {
        //turn off all weapons, except the current selected one
        Item item = invMgr.getSelectedItem();
        //loop through all weapons and check for matching name
        for(int i = 0; i < myWeapons.Length; i++) {
            if(myWeapons[i].name == item.name) {
                myWeapons[i].equip();
            }
            else {
                myWeapons[i].unequip();
            }
        }
    }
}
