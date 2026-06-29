using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
   [Range(1,10)]
   [SerializeField] int startingHealth=7;
   [SerializeField] CinemachineCamera deathVirtualCamera;
   [SerializeField] Transform weaponCamera;
   [SerializeField] Image[] shildBars;
   [SerializeField] GameObject gameOverContainer;


    int currentHealth;
    // int gameOverVirtualCameraPriority = 20;

    
    void Awake()
    {
       currentHealth = startingHealth;
       AdjustSheildUI();
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        AdjustSheildUI();

        if(currentHealth <= 0 )
        {
            PlayerGameOver();
        }
    }

    void PlayerGameOver()
    {
        weaponCamera.parent = null;
            deathVirtualCamera.Priority = 20;
            // deathVirtualCamera.Priority = new PrioritySettings { Value = 20 };
            gameOverContainer.SetActive(true);
            Destroy(this.gameObject);
    }

    void AdjustSheildUI()
    {
        for (int i = 0; i < shildBars.Length; i++)
        {
            if(i<currentHealth)
            {
                shildBars[i].gameObject.SetActive(true);
            }
            else
            {
                shildBars[i].gameObject.SetActive(false);  
            }
            
        }

    }
}
