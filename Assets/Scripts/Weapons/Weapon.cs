using UnityEngine;

public abstract class Weapon 
{

    protected float damage;
    protected int ammo;
    protected float fireRate;

    protected Transform weaponTip;
    
    public abstract void Shoot();

    public abstract void Reload();

    public bool HasAmmo()
    {
        return ammo > 0;
    }

    public Weapon(Transform tip)
    {
        weaponTip = tip;
    }
}
