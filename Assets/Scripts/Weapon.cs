using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Collider2D myCol;
    Animator myAnim;

    public int damage;

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
            myCol.enabled = si.normalizedTime > 0.5f && si.normalizedTime < 0.75f;
        } else {
            myCol.enabled = false;
        }
    }

    public void equip() {
        gameObject.SetActive(true);
    }

    public void unequip() {
        gameObject.SetActive(false);
    }

}
