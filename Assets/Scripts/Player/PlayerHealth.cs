using UnityEngine;
using Unity.Cinemachine;


public class PlayerHealth : MonoBehaviour
{
   [SerializeField] int startingHealth=5;
   [SerializeField] CinemachineCamera deathVirtualCamera;
   [SerializeField] Transform weaponCamera;

    int currentHealth;
    int gameOverVirtualCameraPriority = 20;

    
    void Awake()
    {
       currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log(amount + "DamageTaken");

        if(currentHealth <= 0 )
        {
            weaponCamera.parent = null;
            deathVirtualCamera.Priority = 20;
            // deathVirtualCamera.Priority = new PrioritySettings { Value = 20 };
            Destroy(this.gameObject);
        }
    }
}
