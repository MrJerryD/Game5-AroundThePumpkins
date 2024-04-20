using UnityEngine;

public class PumpkinsMove : MonoBehaviour
{
    public float speed = 2f;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= 7.15f)
        {
            Destroy(gameObject);
        }
    }
}
