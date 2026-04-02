using UnityEngine;

public class Buller : MonoBehaviour
{
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.forward * 500f);
    }
}
