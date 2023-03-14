using UnityEngine;

public class Block : MonoBehaviour
{
   private static GameObject block;
   private static GameObject quest1;

   public void Start()
   {
      block = GameObject.FindWithTag("BlockCar");
      quest1 = GameObject.FindWithTag("Quest1");
   }
   
   public static void ActiveBlock()
   {
      if (QuestGopnik.offBlock || QuestPoliceman.offBlock)
      {
         block.SetActive(false);
         quest1.SetActive(false);
      }
   }
}
