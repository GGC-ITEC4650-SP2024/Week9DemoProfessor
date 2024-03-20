using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Collider2D myCol;
    Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myCol = GetComponent<Collider2D>();
        myAnim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo si = myAnim.GetCurrentAnimatorStateInfo(0);
        if(si.IsName("Attack")) {
            myCol.enabled = true;
        } else {
            myCol.enabled = false;
        }
    }
}
