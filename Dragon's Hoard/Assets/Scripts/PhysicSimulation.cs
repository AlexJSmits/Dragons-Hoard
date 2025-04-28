using UnityEngine;

public class PhysicSimulation : MonoBehaviour
{
    public int maxIterations = 1000;

    [ContextMenu ("Run Simulation")]
    public void RunSimulation()
    {
        Physics.simulationMode = SimulationMode.Script;
        for (int i = 0; i < maxIterations; i++)
        {
            Physics.Simulate(Time.fixedDeltaTime);
        }
        Physics.simulationMode = SimulationMode.FixedUpdate;
    }

}
