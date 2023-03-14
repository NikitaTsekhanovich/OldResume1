using UnityEngine;

public class QuestPoliceman : MonoBehaviour, IQuest
{
    private int countCoin;
    public static bool pickUpCoins;
    private bool policemanGetCoin2;
    private bool policemanGetCoin3;
    private bool policemanGetDocument1;
    public static bool  offBlock;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        CheckItems(other);
    }

    public void CheckItems(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin2")  && !policemanGetCoin2)
        {
            var nameQuest = "policemanGetCoin2";
            ProcessItem(null, "Coin2");
            countCoin++;
            policemanGetCoin2 = QuestManager.Instance().OnCompletedHandle(nameQuest);
        }

        if (other.gameObject.CompareTag("Coin3") && !policemanGetCoin3)
        {
            var nameQuest = "policemanGetCoin2";
            ProcessItem(null, "Coin3");
            countCoin++;
            policemanGetCoin3 = QuestManager.Instance().OnCompletedHandle(nameQuest);
        }

        if (other.gameObject.CompareTag("Document1") && !policemanGetDocument1)
        {
            var nameQuest = "policemanGetDocument1";
            ProcessItem(null, "Document1");
            policemanGetDocument1 = QuestManager.Instance().OnCompletedHandle(nameQuest);
            offBlock = true;
            Block.ActiveBlock();
        }

        if (policemanGetCoin2 && policemanGetCoin3)
        {
            pickUpCoins = true;
        }
    }

    public void ProcessItem(GameObject item, string nameItem)
    {
        if (item != null)
        {
            Instantiate(item, new Vector3(-7.34f, -6.89f, 0.0197f), Quaternion.identity);
        }
        if (nameItem != null)
        {
            Destroy(GameObject.FindWithTag(nameItem));
        }
    }
}
