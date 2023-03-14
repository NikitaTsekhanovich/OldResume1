using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    private Animator anim;
    private int index;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        ChoseSlotForDrop();
        GetAnim();
    }

    private void ChoseSlotForDrop()
    {
        index = GetIndex(index);
        var q = Input.GetKey(KeyCode.Q);
        if (q)
        {
            DropItem(index);
        }
    }

    private static int GetIndex(int index)
    {
        if (Input.GetKey(KeyCode.Alpha1)) index = 0;
        if (Input.GetKey(KeyCode.Alpha2)) index = 1;
        if (Input.GetKey(KeyCode.Alpha3)) index = 2;
        if (Input.GetKey(KeyCode.Alpha4)) index = 3;
        if (Input.GetKey(KeyCode.Alpha5)) index = 4;
        if (Input.GetKey(KeyCode.Alpha6)) index = 5;
        if (Input.GetKey(KeyCode.Alpha7)) index = 6;
        return index;
    }

    private void DropItem(int index)
    {
        foreach (Transform child in transform)
        {
            if (transform.gameObject == inventory.slots[index])
            {
                inventory.isFull[index] = false;
                child.GetComponent<Drop>().SpawnDroppedItem();
                Destroy(child.gameObject);
            }
        }
    }

    private void GetAnim()
    {   
        if (index == 0)
        {
            anim.SetBool("OnFade2", false);
            anim.SetBool("OnFade3", false);
            anim.SetBool("OnFade4", false);
            anim.SetBool("OnFade5", false);
            anim.SetBool("OnFade6", false);
            anim.SetBool("OnFade7", false);
            anim.SetBool("OnFade1", true);
        }
        if (index == 1)
        {
            anim.SetBool("OnFade1", false);
            anim.SetBool("OnFade3", false);
            anim.SetBool("OnFade4", false);
            anim.SetBool("OnFade5", false);
            anim.SetBool("OnFade6", false);
            anim.SetBool("OnFade7", false);
            anim.SetBool("OnFade2", true);
        }
        if (index == 2)
        {
            anim.SetBool("OnFade1", false);
            anim.SetBool("OnFade2", false);
            anim.SetBool("OnFade4", false);
            anim.SetBool("OnFade5", false);
            anim.SetBool("OnFade6", false);
            anim.SetBool("OnFade7", false);
            anim.SetBool("OnFade3", true);
        }
        if (index == 3)
        {
            anim.SetBool("OnFade1", false);
            anim.SetBool("OnFade2", false);
            anim.SetBool("OnFade3", false);
            anim.SetBool("OnFade5", false);
            anim.SetBool("OnFade6", false);
            anim.SetBool("OnFade7", false);
            anim.SetBool("OnFade4", true);
        }
        if (index == 4)
        {
            anim.SetBool("OnFade1", false);
            anim.SetBool("OnFade2", false);
            anim.SetBool("OnFade3", false);
            anim.SetBool("OnFade4", false);
            anim.SetBool("OnFade6", false);
            anim.SetBool("OnFade7", false);
            anim.SetBool("OnFade5", true);
        }
        if (index == 5)
        {
            anim.SetBool("OnFade1", false);
            anim.SetBool("OnFade2", false);
            anim.SetBool("OnFade3", false);
            anim.SetBool("OnFade4", false);
            anim.SetBool("OnFade5", false);
            anim.SetBool("OnFade7", false);
            anim.SetBool("OnFade6", true);
        }
        if (index == 6)
        {
            anim.SetBool("OnFade1", false);
            anim.SetBool("OnFade2", false);
            anim.SetBool("OnFade3", false);
            anim.SetBool("OnFade4", false);
            anim.SetBool("OnFade5", false);
            anim.SetBool("OnFade6", false);
            anim.SetBool("OnFade7", true);
        }
    }
}