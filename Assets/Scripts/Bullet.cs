using UnityEngine;

public class Buller : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("target"))
        {
            print("hit" + collision.gameObject.name + "!");
            Destroy(gameObject);
        }
    }
}
