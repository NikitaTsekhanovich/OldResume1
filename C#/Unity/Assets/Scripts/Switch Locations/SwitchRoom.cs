using UnityEngine;

public class SwitchRoom : MonoBehaviour, ISwitch
{
    public GameObject activeLocation;
    public GameObject nextLocation;
    public GameObject sky;
    public GameObject switchLocation_1;
    public GameObject switchLocation_2;
    
    public void OnTriggerStay2D(Collider2D other)
    {
        var space = Input.GetKeyUp(KeyCode.Tab);
        if (space)
        {
            activeLocation.SetActive(false);
            nextLocation.SetActive(true);
            sky.SetActive(true);
            switchLocation_1.SetActive(true);
            switchLocation_2.SetActive(true);
        }
    }
}