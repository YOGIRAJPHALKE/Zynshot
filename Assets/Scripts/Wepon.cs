using UnityEngine;
using Unity.Mathematics;
using StarterAssets;

public class Wepon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO; 
    [SerializeField] GameObject hitVFXPrefab;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem muzzelFlash;
    //[SerializeField] int damageAmount= 1;

    StarterAssetsInputs starterAssetsInputs;

    const string SHOOT_STRING="Shoot";
    void Awake() 
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();

    } 
    void Update()
    {
        HandleShoot();
    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;

        muzzelFlash.Play();
        animator.Play(SHOOT_STRING, 0, 0f);
        
        starterAssetsInputs.ShootInput(false);

        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            Instantiate(hitVFXPrefab, hit.point, Quaternion.identity);
            EnemyHelth enemyHealth = hit.collider.GetComponent<EnemyHelth>();
            enemyHealth?.TakeDamage(weaponSO.Damage);


            // if(enemyHealth)
            // {
            //     enemyHealth.TakeDamage(damageAmount);
            // }

            //Debug.Log(hit.collider.name);
            //starterAssetsInputs.shoot=false;
        }
    }
}
