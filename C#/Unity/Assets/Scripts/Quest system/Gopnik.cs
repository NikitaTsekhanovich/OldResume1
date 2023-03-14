using System;
using UnityEngine;

public class Gopnik : MonoBehaviour, INPC
{
    [SerializeField] private Transform trader_2;
    [SerializeField] private GameObject item1;
    [SerializeField] private GameObject item2;
    [SerializeField] private GameObject item3;
    private float speed = 0.01f;

    public void Update()
    {
        MoveTo();
    }

    public void MoveTo()
    {
        if (!QuestGopnik.pickUpBeer) 
            return;
        
        transform.position = Vector3.MoveTowards(transform.position, trader_2.position, speed);
        if (Math.Abs(transform.position.x - trader_2.position.x) < 0.01f)
        {
            Destroy(GameObject.FindWithTag("trader_2"));
            Instantiate(item1, new Vector3(-7.34f, -6.89f, 0.0197f), Quaternion.identity);
            Instantiate(item2, new Vector3(-7.24f, -6.89f, 0.0197f), Quaternion.identity);
            Instantiate(item3, new Vector3(-7.10f, -6.99f, 0.0197f), Quaternion.identity);
        }
    }
}
