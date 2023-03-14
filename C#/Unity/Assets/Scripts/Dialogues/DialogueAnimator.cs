using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnim;
    public DialogueManager dm;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            startAnim.SetBool("StartOpen", true);   
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        startAnim.SetBool("StartOpen", false);
        dm.EndDialogue(); 
    }
}
