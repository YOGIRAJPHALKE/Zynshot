using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{   
   [SerializeField] GameObject projectilePrefab;
   [SerializeField] Transform turretHead;
   [SerializeField] Transform playerTagetPoint;
   [SerializeField] Transform projectileSpawnPoint;
   [SerializeField] float FireRate = 2f;
   [SerializeField] int damage = 2;

   PlayerHealth player;

   void Start() 
   {
    player = FindFirstObjectByType<PlayerHealth>();
    StartCoroutine(FireRoutine());
   }

   void Update() 
   {
     if (playerTagetPoint == null) return;
        turretHead.LookAt(playerTagetPoint.position);
   }

   IEnumerator FireRoutine()
   {
        while (player)
        {
            yield return new WaitForSeconds(FireRate);
            Projectile newProjectile =Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity).GetComponent<Projectile>();
            newProjectile.transform.LookAt(playerTagetPoint);
            newProjectile.Init(damage);
        }
   }
}
