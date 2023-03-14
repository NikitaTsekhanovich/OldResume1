using UnityEngine;

public class ChangeLocations : MonoBehaviour
{
    public GameObject activeStreet;

    public void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
       {
           activeStreet.SetActive(true);
       }
    }

    public void OnTriggerExit2D(Collider2D other)
    {    
       if (other.CompareTag("Player"))
       {
           activeStreet.SetActive(false);
       }
    }

    public static void ExitGame()
    {
        Debug.Log("Game over");
        Application.Quit();
    }
}
