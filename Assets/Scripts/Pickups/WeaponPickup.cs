using UnityEngine;

public class WeaponPickup : Pickup
{
    [SerializeField] WeaponSO weaponSO;

    protected override void OnPickup(ActiveWeapon activeWeapon)
    {
        activeWeapon.SwitchWeapon(weaponSO);
    }
    

    // void OnTriggerEnter(Collider other) 
    // {
    //     if(other.CompareTag(PLAYER_STRING))
    //     {
    //         ActiveWeapon activeWeapon = other.GetComponentInChildren<ActiveWeapon>();
    //         activeWeapon.SwitchWeapon(weaponSO);
    //         Destroy(this.gameObject);
    //     }
        
    // }
}
