using UnityEngine;

public interface IQuest
{
    void OnTriggerEnter2D(Collider2D other);

    void CheckItems(Collider2D other);

    void ProcessItem(GameObject item, string nameItem);
}