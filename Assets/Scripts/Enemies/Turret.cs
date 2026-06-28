using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{   
   [SerializeField] GameObject projectilePrefab;
   [SerializeField] Transform turretHead;
   [SerializeField] Transform playerTagetPoint;
   [SerializeField] Transform projectileSpawnPoint;
   [SerializeField] float FireRate = 2f;

   PlayerHealth player;

   void Start() 
   {
    player = FindFirstObjectByType<PlayerHealth>();
    StartCoroutine(FireRoutine());
   }

   void Update() 
   {
        turretHead.LookAt(playerTagetPoint.position);
   }

   IEnumerator FireRoutine()
   {
        while (player)
        {
            yield return new WaitForSeconds(FireRate);
            Instantiate(projectilePrefab, projectileSpawnPoint.position, turretHead.rotation);
        }
   }
}
