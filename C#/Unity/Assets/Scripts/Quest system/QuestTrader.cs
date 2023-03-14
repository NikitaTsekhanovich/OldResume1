using UnityEngine;

public class QuestTrader : MonoBehaviour, IQuest
{
    [SerializeField] private GameObject item1;
    [SerializeField] private GameObject item2;
    [SerializeField] private GameObject item3;
    [SerializeField] private GameObject item4;
    private bool trader2GetKey1;
    private bool trader2GetKey2;
    private bool trader2GetCoin2;
    private bool trader2GetCoin3;
    private bool trader2GetCountKey2;
    private bool trader2GetBeer1;
    private int countCoin;

    public void OnTriggerEnter2D(Collider2D other)
    {
        CheckItems(other);
    }

    public void CheckItems(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key1") && !trader2GetKey1)
        {
            var nameQuest = "trader2GetKey1";
            ProcessItem(item1, "Key1");
            trader2GetKey1 = QuestManager.Instance().OnCompletedHandle(nameQuest);
        }

        if (other.gameObject.CompareTag("Key2") && !trader2GetKey2)
        {
            var nameQuest = "trader2GetKey2";
            ProcessItem(item2, "Key2");
            trader2GetKey2 = QuestManager.Instance().OnCompletedHandle(nameQuest);
        }

        if (other.gameObject.CompareTag("Coin2") && !trader2GetCoin2)
        {
            var nameQuest = "trader2GetCoin2";
            countCoin++;
            ProcessItem(null, "Coin2");
            trader2GetCoin2 = QuestManager.Instance().OnCompletedHandle(nameQuest);
        }

        if (other.gameObject.CompareTag("Coin3") && !trader2GetCoin3)
        {
            var nameQuest = "trader2GetCoin3";
            countCoin++;
            ProcessItem(null, "Coin3");
            trader2GetCoin3 = QuestManager.Instance().OnCompletedHandle(nameQuest);
        }

        if (countCoin == 2 && !trader2GetCountKey2)
        {
            var nameQuest = "trader2GetCountKey2";
            ProcessItem(item3, null);
            trader2GetCountKey2 = QuestManager.Instance().OnCompletedHandle(nameQuest);
        }

        if (other.gameObject.CompareTag("Beer1") && !trader2GetBeer1)
        {
            var nameQuest = "trader2GetBeer1";
            ProcessItem(item4, "Beer1");
            trader2GetBeer1 = QuestManager.Instance().OnCompletedHandle(nameQuest);
        }
    }
    
    public void ProcessItem(GameObject item, string nameItem)
    {
        if (item != null)
        {
            Instantiate(item, new Vector3(-7f, -6.89f, 0.0197f), Quaternion.identity);
        }
        if (nameItem != null)
        {
            Destroy(GameObject.FindWithTag(nameItem));
        }
    }
}