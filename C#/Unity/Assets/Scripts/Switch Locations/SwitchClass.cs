using UnityEngine;

public class SwitchClass : MonoBehaviour, ISwitch
{
    public GameObject activeLocation;
    public GameObject nextLocation;

    public void OnTriggerStay2D(Collider2D other)
    {
        var space = Input.GetKeyUp(KeyCode.Tab);
        if (space)
        {
            activeLocation.SetActive(false);
            nextLocation.SetActive(true);
        }
    }
}
