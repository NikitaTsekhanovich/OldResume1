using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject itemInInventoty;
    private Inventory inventory;
    
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var e = Input.GetKey(KeyCode.E);
        if (other.CompareTag("Player") && e)
        { 
            for (var i = 0; i < inventory.slots.Length; i++)
            {
                if (!inventory.isFull[i])
                {
                    inventory.isFull[i] = true;
                    var b = Instantiate(itemInInventoty, inventory.slots[i].transform); 
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
