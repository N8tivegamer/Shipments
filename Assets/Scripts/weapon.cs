using StarterAssets;
using System.Collections;
using TMPro;
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

    private StarterAssetsInputs inputs;

    public AudioSource audioSource;
   

    public float reloadTime;
    public int magazineSize = 32, bulletsLeft;
    public bool isReloading;
    public float fireRate = 0.25f;
    public int totalAmmo = 64;

    private float shootTime = 0;

    private void Start()
    {
        inputs = transform.parent.parent.GetComponent<StarterAssetsInputs>();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position,transform.forward * 500f);
    }


    private void Awake()
    {
        bulletsLeft = magazineSize;
    }
    // Update is called once per frame
    void Update()
    {
        if (inputs.fire && shootTime <= 0)
        {
            FireWeapon();
        }

        if (inputs.reloading && isReloading == false && totalAmmo > 0 && bulletsLeft != magazineSize)
        {
            Reload();
        }

        if (shootTime > 0) 
        {
            shootTime -= Time.deltaTime;
        }


        if( AmmoManager.Instance.ammoDisplay != null)
        {
            AmmoManager.Instance. ammoDisplay.text = $"{bulletsLeft}/{totalAmmo}";
        }
        
         

    }

    private void OnTriggerEnter(Collider other)
    {
        if ( other.CompareTag("Ammo"))
        {
            Destroy(other.gameObject);
            totalAmmo += 30;
        }
    }

    private void FireWeapon()
    {
        if (bulletsLeft <= 0) {return; }

        shootTime = fireRate;
        bulletsLeft--;

        audioSource.Play();

        // Instantiate the bullet
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletPrefab.transform.rotation);
        // Shoot the bullet
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);
        //Destroy the bullet after some time
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletPrefabLifeTime));

    }

    private void Reload()
    {
        isReloading = true;
        Invoke("ReloadCompleted", reloadTime);
    }

    private void ReloadCompleted()
    {
        isReloading = false;
        if (totalAmmo < magazineSize)
        {
            bulletsLeft = totalAmmo;
            totalAmmo = 0;
        }
        else 
        { 
            bulletsLeft = magazineSize;
            totalAmmo -= magazineSize;
        }
        
    }

    // A Coroutine that waits for a specified time before destroying the object
    private IEnumerator DestroyBulletAfterTime (GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
