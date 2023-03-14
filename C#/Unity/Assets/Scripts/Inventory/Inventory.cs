using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots; 
    public GameObject inventory;
    // private bool inventoryOpen;
    //
    //  private void Update()
    //  {
    //      OpenBag();
    //  }
    //
    //  private void OpenBag()
    //  {
    //      inventoryOpen = Input.GetKey(KeyCode.Space);
    //      //if (Input.GetKey(KeyCode.Space)) inventoryOpen = true;
    //      if (inventoryOpen)
    //      {
    //          inventory.SetActive(true);
    //      }
    //      else
    //      {
    //          inventory.SetActive(false);
    //      }
    //  }
}
