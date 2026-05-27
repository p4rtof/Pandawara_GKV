using UnityEngine;

public class FishMove : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = Random.Range(2f, 5f);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // baru destroy kalau jauh kanan
        if (transform.position.x > 20f)
        {
            Destroy(gameObject);
        }
    }
}