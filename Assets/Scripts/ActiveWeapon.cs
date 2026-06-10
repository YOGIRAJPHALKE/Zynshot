using UnityEngine;
using StarterAssets;

public class ActiveWeapon : MonoBehaviour
{
    
    [SerializeField] WeaponSO weaponSO; 
    Animator animator;

    StarterAssetsInputs starterAssetsInputs;
    Wepon currentWeapon;

    const string SHOOT_STRING="Shoot";

    float timeSinceLastShoot= 0f;

    void Awake() 
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    } 
    void Start() 
    {
        currentWeapon = GetComponentInChildren<Wepon>();  
    }
    void Update()
    {
        timeSinceLastShoot += Time.deltaTime;
        HandleShoot();
    }

    public void SwitchWeapon(WeaponSO weaponSO)
    {
        if(currentWeapon)
        {
            Destroy(currentWeapon.gameObject);
        }

        Wepon newWeapon = Instantiate(weaponSO.weaponePrefab, transform).GetComponent<Wepon>();
        currentWeapon = newWeapon;
        this.weaponSO= weaponSO;
    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;

        if(timeSinceLastShoot >= weaponSO.FireRate)
        {
            currentWeapon.Shoot(weaponSO);
            animator.Play(SHOOT_STRING, 0, 0f);
            timeSinceLastShoot = 0f;
        }

        if(!weaponSO.isAutomatic)
        {     
            starterAssetsInputs.ShootInput(false);
        }
    }
}
