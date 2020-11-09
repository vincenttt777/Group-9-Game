using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    public State currentState;
    public EnemyStats enemyStats;
    public Transform eyes;
    [HideInInspector] public NavMeshAgent navMeshAgent;
  //  [HideInInspector] public Complete.TankShooting tankshooting;
    [HideInInspector] public List<Transform> wayPointList;
    [HideInInspector] public int nextWayPoint;

    private bool aiActive;

    void Awake()
    {
      //  tankshooting = GetComponent<Complete.TankShooting>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void SetUpAI(bool aiActivationFromTankManager, List<Transform> wayPointFromTankManager)
    {
        wayPointList = wayPointFromTankManager;
        aiActive = aiActivationFromTankManager;
        if (aiActive)
        {
            navMeshAgent.enabled = true; 
        } else 
        {
            navMeshAgent.enabled = false;
        }
    }

    private void Update()
    {
        if (!aiActive)
            return;
        currentState.UpdateState(this);
    }

    private void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizemoColor;
            Gizmos.DrawWireSphere(eyes.position, enemyStats.lookSphereCastRadius);
        }
    }
}
