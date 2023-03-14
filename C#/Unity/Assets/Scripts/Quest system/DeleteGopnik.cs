using UnityEngine;

public class DeleteGopnik : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gopnik1"))
        {
            Destroy(GameObject.FindWithTag("Gopnik1"));
        }
    }
}
