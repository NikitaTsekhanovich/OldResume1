using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject item;
    
    public void SpawnDroppedItem()
    {
        var heroLookRight = Hero.hero.GetComponent<SpriteRenderer>();
        var playerPos = new Vector3();
        if (heroLookRight.flipX == false)
        {
            playerPos = new Vector3(Hero.hero.position.x + 0.08f, Hero.hero.position.y - 0.1f);
        }
        else
        {
            playerPos = new Vector3(Hero.hero.position.x - 0.08f, Hero.hero.position.y - 0.1f);
        }
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
