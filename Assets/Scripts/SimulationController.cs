using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SimulationController : MonoBehaviour
{

    public FloodRiskDummy floodRiskDummy; // Reference to FloodRiskDummy script
    public Slider floodRiskBar;              // Reference to Flood Risk Slider
    public TextMeshProUGUI riskLabel;        // Reference to Label
    private bool isRunning = false;

    private float simulatedValue = 0f;

    void Start()
    {
        // Make sure the bar is idle at launch
        ResetSimulation(); // start idle
    }
    void Update()
    {
        if (isRunning)
        {

            // Dummy simulation increase (0 → 100)
            simulatedValue += Time.deltaTime * 5f;
            simulatedValue = Mathf.Clamp(simulatedValue, 0, 100);

            // ✅ Call method in FloodRiskDummy
            // floodRiskBar.value = simulatedValue;
            // riskLabel.text = $"Flood Risk: {Mathf.RoundToInt(simulatedValue)}%";

            floodRiskDummy.UpdateFloodBarUI(simulatedValue);
        }
    }

    // ✅ Button Functions
    public void StartSimulation()
    {
        isRunning = true;
        simulatedValue = 0f;
        floodRiskDummy.UpdateFloodBarUI();
        Debug.Log("Simulation Started");
    }

    public void PauseSimulation()
    {
        isRunning = false;
        Debug.Log("Simulation Paused at " + riskLabel.text);
        // floodRiskDummy.SetIdlePosition();
        // Debug.Log("Simulation Paused");
    }

    public void ResetSimulation()
    {
        isRunning = false;
        simulatedValue = 0f;
        floodRiskBar.value = 0;
        riskLabel.text = "Flood Risk: 0%";
        Debug.Log("Simulation Reset");
    }
}
