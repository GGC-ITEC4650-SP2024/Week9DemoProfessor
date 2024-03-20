using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public string name;
    public int count;
    public Sprite iconSprite;

    public bool owned() {
        return count > 0;
    }
}
