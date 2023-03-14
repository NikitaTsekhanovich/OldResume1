using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private float acceleration = 0.5f;
    public static Rigidbody2D hero;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        hero = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveNext(); 
        HandleClose();
    }

    private static void HandleClose()
    {
        var esc = Input.GetKey(KeyCode.Escape) ? 1 : 0;
        if (esc != 0)
        {
            ChangeLocations.ExitGame();
        }
    }

    private void MoveNext()
    {
        var w = Input.GetKey(KeyCode.W) ? 1 : 0;
        var s = Input.GetKey(KeyCode.S) ? 1 : 0;
        var a = Input.GetKey(KeyCode.A) ? 1 : 0;
        var d = Input.GetKey(KeyCode.D) ? 1 : 0;
        var shift = Input.GetKey(KeyCode.LeftShift) ? 1 : 0;
        var heroLookRight = GetComponent<SpriteRenderer>();

        GetAnimHero(w, s, a, d, heroLookRight);
        
        if (shift == 1)
        {
            shift = 3;
        }
        else
        {
            shift = 1;
        }
        var movementVector = new Vector2(d - a, w - s);
        hero.velocity = movementVector * acceleration * shift;
    }

    private void GetAnimHero(int w, int s, int a, int d, SpriteRenderer heroLookRight)
    {
        if (d == 1)
        {
            heroLookRight.flipX = false;
            anim.SetBool("IsRunning", true);
        }
        else if (a == 1)
        {
            heroLookRight.flipX = true;
            anim.SetBool("IsRunning", true);
        }
        else if (w == 1)
        {
            anim.SetBool("IsMoveFront", true);
        }
        else
        {
            anim.SetBool("IsMoveFront", false);
            anim.SetBool("IsRunning", false);
        }
    }
}