using UnityEngine;
using System.Collections;

public class NpcActor : MovableActor
{
    public AIAction currentAiAction;

    // References
    public NavMeshAgent navMeshAgent;

    public virtual void OnCalculateAI()
    {
        if (currentAiAction != null)
        {
            
        }
    }

    protected override void Start()
    {
        InvokeRepeating("OnCalculateAI", 0, 1);
        base.Start();
    }
    protected override void Update()
    {
        navMeshAgent.speed = attributes[AttributeType.MovementSpeed];
        base.Update();
    }
}

public class AIAction
{
    // TODO: Create AI actions
}
