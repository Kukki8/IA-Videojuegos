using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    public Arrive Arrive;
    public LookWheUGoin LookWYG;
    private SteeringOutput m_steeringOutput;
    private Agent m_agent;
    protected void Start()
    {
        m_agent = GetComponentInParent<Agent>();
    }

    public override void OnEntry()
    {
        
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
        m_steeringOutput.Linear = Vector3.zero;
        m_steeringOutput.Angular = 0;

        SteeringOutput steeringOutput = Arrive.GetSteering(m_agent.KinematicData);
        m_steeringOutput.Linear += steeringOutput.Linear * Arrive.weight;
        m_steeringOutput.Angular += steeringOutput.Angular * Arrive.weight;

        steeringOutput = LookWYG.GetSteering(m_agent.KinematicData);
        m_steeringOutput.Linear += steeringOutput.Linear * LookWYG.weight;
        m_steeringOutput.Angular += steeringOutput.Angular * LookWYG.weight;
        
        m_agent.SetSteeringOutput(m_steeringOutput);
    }

}
