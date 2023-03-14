using UnityEngine;

public class QuestTeacher : MonoBehaviour, IQuest
{
    private bool getDocument2;
    [SerializeField] private BoxCollider2D teacher;
    public void OnTriggerEnter2D(Collider2D other)
    {
        CheckItems(other);
    }

    public void CheckItems(Collider2D other)
    {
        if (other.CompareTag("Document2") && !getDocument2)
        {
            var nameQuest = "getDocument2";
            ProcessItem(null, "Document2");
            getDocument2 = QuestManager.Instance().OnCompletedHandle(nameQuest);
        }
        if (getDocument2)
        {
            teacher.enabled = false;
        }
    }

    public void ProcessItem(GameObject item, string nameItem)
    {
        if (nameItem != null)
        {
            Destroy(GameObject.FindWithTag(nameItem));
        }
    }
}
