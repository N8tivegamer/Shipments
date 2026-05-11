using StarterAssets;
using UnityEngine;
using UnityEngine.Windows;

public class WeaponSwitching : MonoBehaviour
{
    private StarterAssetsInputs input;
    public int selectedWeapon = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = transform.parent.GetComponent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (input.switching)
        {
            Switching();
        }
    }


    private void Switching()
    {
        if (selectedWeapon >= 1)
            selectedWeapon = 0;
        else
            selectedWeapon++;

        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
