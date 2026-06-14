using UnityEngine;


public class Wepon : MonoBehaviour
{
    [SerializeField] ParticleSystem muzzelFlash;
    [SerializeField] LayerMask interactionLayers;

    public void Shoot(WeaponSO weaponSO)
    {
        muzzelFlash.Play();
        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity,interactionLayers,QueryTriggerInteraction.Ignore))
        {
            Instantiate(weaponSO.HitVFXPrefab, hit.point, Quaternion.identity);
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
