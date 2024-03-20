using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvManager : MonoBehaviour
{
    public Image leftBox;
    public Image centerBox;
    public Image rightBox;

    public Item[] allPossibleItems;
    public int selectedItemIndex;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        leftBox.enabled = false;
        centerBox.enabled = false;
        rightBox.enabled = false;

        int size = getInvSize();
        if(size > 0) {
            centerBox.enabled = true;
            centerBox.sprite = allPossibleItems[selectedItemIndex].iconSprite;
        }
        if(size > 1) {
            leftBox.enabled = true;
            //get the correct index
            int i = getPrevOwnedIndex();
            leftBox.sprite = allPossibleItems[i].iconSprite;
        }
        if(size > 2) {
            rightBox.enabled = true;
            //get the correct index
            int i = getNextOwnedIndex();
            rightBox.sprite = allPossibleItems[i].iconSprite;
        }
    }

    public int getInvSize()
    {
        int size = 0;
        for (int i = 0; i < allPossibleItems.Length; i++)
        {
            if (allPossibleItems[i].owned())
            {
                size++;
            }
        }
        return size;
    }

    public int nextIndex(int i)
    {
        if (i < allPossibleItems.Length - 1) { return i + 1; }
        else { return 0;}
    }

    public int prevIndex(int i)
    {
        if (i > 0) { return i - 1;}
        else { return allPossibleItems.Length - 1;}
    }

    public int getNextOwnedIndex()
    {
        int i = nextIndex(selectedItemIndex);
        while (!allPossibleItems[i].owned()) { 
            i = nextIndex(i); 
        }
        return i;
    }

    public int getPrevOwnedIndex()
    {
        int i = prevIndex(selectedItemIndex);
        while (!allPossibleItems[i].owned()) { 
            i = prevIndex(i); 
        }
        return i;
    }  

    public Item getSelectedItem()
    {
        if(getInvSize() > 0)
            return allPossibleItems[selectedItemIndex];
        else
            return null;
    }

    public void selectNextItem()
    {
        if (getInvSize() > 1)
        {
            selectedItemIndex = getNextOwnedIndex();
        }
    }

    public void selectPrevItem()
    {
        if (getInvSize() > 1)
        {
            selectedItemIndex = getPrevOwnedIndex();
        }
    }

    public void addItemByName(string n) {
        for(int i = 0; i < allPossibleItems.Length; i++) {
            if(allPossibleItems[i].name == n) {
                allPossibleItems[i].count++;
                if(getInvSize() == 1) {
                    selectedItemIndex = i;
                }
                break;
            }
        }
    }
}
