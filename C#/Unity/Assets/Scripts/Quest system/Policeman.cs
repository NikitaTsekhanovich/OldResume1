using System;
using UnityEngine;

public class Policeman : MonoBehaviour, INPC
{
    [SerializeField] private Transform gopnik;
    [SerializeField] private BoxCollider2D policeman;
    [SerializeField] private GameObject item1;
    private float speed = 0.02f;

    public void Update()
    {
        MoveTo();
    }

    public void MoveTo()
    {
        if (QuestPoliceman.pickUpCoins)
        {
            transform.position = Vector3.MoveTowards(transform.position, gopnik.position, speed);
            policeman.enabled = false;
            if (Math.Abs(transform.position.x - gopnik.position.x) < 0.01f)
            {
                Destroy(GameObject.FindWithTag("Gopnik1"));
                Instantiate(item1, new Vector3(-5.383857f, -6.89f, 0.0197f), Quaternion.identity);
            }
        }
    }
}
