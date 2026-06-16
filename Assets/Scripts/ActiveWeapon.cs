using UnityEngine;
using StarterAssets;
using Unity.Cinemachine;
using TMPro;

public class ActiveWeapon : MonoBehaviour
{
    
    [SerializeField] WeaponSO startingWeapon; 
    [SerializeField] CinemachineVirtualCamera playerFollowCamera; 
    [SerializeField] GameObject zoomVignette; 
    [SerializeField] TMP_Text ammoText; 

    WeaponSO weaponSO; 
    Animator animator;
    StarterAssetsInputs starterAssetsInputs;
    FirstPersonController firstPersonController;
    Wepon currentWeapon;

    const string SHOOT_STRING="Shoot";

    float timeSinceLastShoot= 0f;
    float defaultFOV;
    float defaultRotationSpeed;
    int currentAmmo;

    void Awake() 
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        firstPersonController = GetComponentInParent<FirstPersonController>();
        animator = GetComponent<Animator>();
        defaultFOV = playerFollowCamera.m_Lens.FieldOfView;
        defaultRotationSpeed = firstPersonController.RotationSpeed;
    } 
    void Start() 
    {
        SwitchWeapon(startingWeapon);
        AdjustAmmo(weaponSO.MagazineSize);
       // currentWeapon = GetComponentInChildren<Wepon>();  

    }
    void Update()
    {
        HandleShoot();
        HandleZoom();
    }

    public void AdjustAmmo(int amount)
    {
        currentAmmo += amount;
        if(currentAmmo > weaponSO.MagazineSize)
        {
            currentAmmo = weaponSO.MagazineSize;
        }

        ammoText.text =currentAmmo.ToString("D2");
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
        AdjustAmmo(weaponSO.MagazineSize);
    }

    void HandleShoot()
    {
        timeSinceLastShoot += Time.deltaTime;

        if (!starterAssetsInputs.shoot) return;

        if(timeSinceLastShoot >= weaponSO.FireRate && currentAmmo>0)
        {
            currentWeapon.Shoot(weaponSO);
            animator.Play(SHOOT_STRING, 0, 0f);
            timeSinceLastShoot = 0f;
            AdjustAmmo(-1);
        }

        if(!weaponSO.isAutomatic)
        {     
            starterAssetsInputs.ShootInput(false);
        }
    }
    void HandleZoom()
    {
        if(!weaponSO.CanZoom) return;

        if(starterAssetsInputs.zoom)
        {
            playerFollowCamera.m_Lens.FieldOfView = weaponSO.ZoomAmount;
            zoomVignette.SetActive(true);
            firstPersonController.ChangeRotationSpeed(weaponSO.ZoomRoatationSpeed);
        }
        else
        {
            playerFollowCamera.m_Lens.FieldOfView = defaultFOV;
            zoomVignette.SetActive(false);
            firstPersonController.ChangeRotationSpeed(defaultRotationSpeed);
        }
    }
}
