using UnityEngine;
using System.Collections;

public class WeaponItem : Item
{
    public WeaponAttachmentItem sight, muzzleExtension, bodyExtension;
    public Vector3 recoilStrength;

    public int damage,
        currentBullets, bulletsPerMagazine, availableBullets, maxAvailableBullets;
    public float shootSpeed, bulletSpeed, bulletDownfall;

    private float shootDeltaTime;

    public bool canShoot
    {
        get
        {
            if (shootDeltaTime != 0 || currentBullets == 0)
                return false;
            else return true;

        }
    }

    public void OnShoot()
    {
        currentBullets -= 1;
        shootDeltaTime = shootSpeed;
    }
    public void OnReload()
    {
        int neededBullets = bulletsPerMagazine - currentBullets;
        if (availableBullets < neededBullets)
            neededBullets = availableBullets;

        currentBullets += neededBullets;
        availableBullets -= neededBullets;
    }
    public void OnFillAmmo(int ammo)
    {
        if (availableBullets + ammo > maxAvailableBullets)
            availableBullets = maxAvailableBullets;
        else
            availableBullets += ammo;
    }
    public void Update()
    {
        if(shootDeltaTime > 0)
        {
            shootDeltaTime -= Time.deltaTime;
            if (shootDeltaTime <= 0)
                shootDeltaTime = 0;
        }
    }
}
