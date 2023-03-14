using UnityEngine;

public class QuestManager
{
    private static QuestManager instance;

    public static QuestManager Instance()
    {
        return instance ??= new QuestManager();
    }
    
    public bool OnCompletedHandle(string nameQuest)
    {
        if (nameQuest == "trader2GetKey1")
        {
            return true;
        }
        if (nameQuest == "trader2GetKey2")
        {
            return true;
        }
        if (nameQuest == "trader2GetCoin2")
        {
            return true;
        }
        if (nameQuest == "trader2GetCoin3")
        {
            return true;
        }
        if (nameQuest == "trader2GetCountKey2")
        {
            return true;
        }
        if (nameQuest == "trader2GetBeer1")
        {
            return true;
        }
        if (nameQuest == "policemanGetCoin2")
        {
            return true;
        }
        if (nameQuest == "policemanGetCoin3")
        {
            return true;
        }
        if (nameQuest == "getDocument2")
        {
            return true;
        }
        if (nameQuest == "policemanGetDocument1")
        {
            return true;
        }
        return false;
    }
}