using UnityEngine;

public class CandyMove : MonoBehaviour
{
    public float speed = 2f;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= 5.15f)
        {
            Destroy(gameObject);
        }
    }
}