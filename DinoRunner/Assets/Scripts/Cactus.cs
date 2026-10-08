using UnityEngine;

public class Cactus : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;

    [SerializeField] private float positionXtoDestroy = -12.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if(transform.position.x < positionXtoDestroy)
        {
            Destroy(gameObject);
        }
    }
}
