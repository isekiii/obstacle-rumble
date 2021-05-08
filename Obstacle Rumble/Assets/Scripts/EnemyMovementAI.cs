using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;


    private void Update () {
        
        agent.SetDestination(player.position);
            
    }
 
   
}
