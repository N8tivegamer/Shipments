using System.Collections;
using UnityEngine;

public class weapon : MonoBehaviour
{
    // Reference to the bullet object (prefab) that will be spawned when shooting
    public GameObject bulletPrefab;

    // The position and rotation where the bullet will be created (usually the gun barrel)
    public Transform bulletSpawn;

    // The speed at which the bullet will travel after being fired
    public float bulletVelocity = 30;

    // How long the bullet will exist in the scene before being destroyed (in seconds)

    public float bulletPrefabLifeTime = 3f;


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position,transform.forward * 500f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireWeapon();
        }
    }

    private void FireWeapon()
    {
        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, Quaternion.identity);
        // Shoot the bullet
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);
        //Destroy the bullet after some time
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));

    }


    // A Coroutine that waits for a specified time before destroying the object
    private IEnumerator DestroyBulletAfterTime (GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
