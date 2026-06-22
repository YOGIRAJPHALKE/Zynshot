using UnityEngine;
using UnityEngine.AI;
using StarterAssets;

public class Robot : MonoBehaviour
{
    //[SerializeField] Transform target;
    FirstPersonController player;
    NavMeshAgent agent;

    const string PLAYER_STRING = "Player";

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
        
    }

    void Update()
    {
        if(!player) return;
        
        agent.SetDestination(player.transform.position);
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag(PLAYER_STRING))
        {
            EnemyHelth enemyHealth = GetComponent<EnemyHelth>();
            enemyHealth.SelfDestruct();   
        }
        
    }
}
