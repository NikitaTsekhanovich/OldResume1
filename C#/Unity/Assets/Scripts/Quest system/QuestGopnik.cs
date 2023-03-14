using UnityEngine;

public class QuestGopnik : MonoBehaviour, IQuest
{
    [SerializeField] private GameObject item;
    public static bool  offBlock;
    public static bool pickUpBeer;
    private int countKey;
    private Animator anim;
    private bool flag;

    private QuestManager MyQuest;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        CheckItems(other);
    }

    public void CheckItems(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key1"))
        {
            countKey++;
            ProcessItem(null, "Key1");
        }

        if (other.gameObject.CompareTag("Key2"))
        {
            countKey++;
            ProcessItem(null, "Key2");
        }

        if (countKey == 2)
        {
            offBlock = true;
            Block.ActiveBlock();
            flag = true;
            CompleteQuest();
        }

        if (other.gameObject.CompareTag("Document1"))
        {
            ProcessItem(item, "Document1");
            offBlock = true;
            Block.ActiveBlock();
            flag = false;
            CompleteQuest();
        }

        if (other.gameObject.CompareTag("Beer1"))
        {
            pickUpBeer = true;
            ProcessItem(null, "Beer1");
            anim.enabled = false;
        }
    }

    public void ProcessItem(GameObject item, string nameItem)
    {
        if (item != null)
        {
            Instantiate(item, new Vector3(-5.383857f, -6.89f, 0.0197f), Quaternion.identity);
        }
        if (nameItem != null)
        {
            Destroy(GameObject.FindWithTag(nameItem));
        }
    }

    public void CompleteQuest()
    {
        if (flag)
        {
            anim.SetBool("GoToCar", true);
        }
        else
        {
            anim.SetBool("DeleteGopnik", true);
        }
    }
}