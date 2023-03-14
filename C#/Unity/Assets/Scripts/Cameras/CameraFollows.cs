using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public float dumping = 2f;

    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;
    [SerializeField] float bottomLimit;
    [SerializeField] float upperLimit;

    void Update()
    {
        CameraFollowsPlayer();
    }

    private void CameraFollowsPlayer()
    {
        if (Hero.hero == null)
        {
            transform.position = new Vector3(-10.14f, -6.54f, -10);
        }
        else
        {
            Vector3 target = new Vector3(Hero.hero.position.x, Hero.hero.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
                transform.position.z);
        }
    }
}
