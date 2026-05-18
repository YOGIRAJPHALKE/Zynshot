using UnityEngine;
using StarterAssets;

public class Wepon : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInputs;
    [SerializeField] int damageAmount= 1;
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
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            EnemyHelth enemyHealth = hit.collider.GetComponent<EnemyHelth>();
            enemyHealth?.TakeDamage(damageAmount);

            starterAssetsInputs.ShootInput(false);

            // if(enemyHealth)
            // {
            //     enemyHealth.TakeDamage(damageAmount);
            // }

            //Debug.Log(hit.collider.name);
            //starterAssetsInputs.shoot=false;
        }
    }
}
