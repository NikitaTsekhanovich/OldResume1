using UnityEngine;

public class QuestDocument2 : MonoBehaviour
{
    [SerializeField] private BoxCollider2D fieldQuest;

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fieldQuest.enabled = false;
        }
    }
}
