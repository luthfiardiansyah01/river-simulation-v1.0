using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloodRiskDummy : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] Slider floodRiskSlider;
    [SerializeField] Image fillColor;
    [SerializeField] TextMeshProUGUI riskLabel;  // assign in inspector

    [SerializeField] TextMeshProUGUI rainfallText;
    [SerializeField] TextMeshProUGUI waterLevelText;

    [Header("Dummy Sensor Data")]
    public float rainfall;      // mm/h
    public float waterLevel;    // cm
    private float floodRisk;    // %

    [Header("Risk Simulation")]
    // public float currentRisk = 0f;
    private float timer = 0f;
    public float updateInterval = 3f; // every 3 seconds
    private System.Random random = new System.Random();

    public EmergencyManager emergencyManager;

    public float CurrentRisk => floodRiskSlider.value;  // ✅ getter for flood risk value

    void Start()
    {
        // ✅ Set idle/initial position at the start
        SetIdlePosition();
    }

    public void SetIdlePosition()
    {
        floodRiskSlider.value = 0f;
        riskLabel.text = "Flood Risk: Idle (0%)";

        rainfallText.text = "Rainfall: 0 mm/h";
        waterLevelText.text = "Water Level: 0 cm";
    }

    public void UpdateFloodBarUI(float newRiskValue = -1)
    {
        // run simulation each frame
        timer += Time.deltaTime;
        // Every interval, update target risk
        if (timer >= updateInterval)
        {
            timer = 0f;

            // Generate dummy data
            rainfall = random.Next(0, 101);   // 0–100 mm/h
            waterLevel = random.Next(0, 201); // 0–200 cm

            // Calculate flood risk (weighted formula)
            float rainNorm = rainfall / 100f;
            float waterNorm = waterLevel / 200f;

            floodRisk = (0.4f * rainNorm + 0.6f * waterNorm) * 100f;
            Debug.Log("New Flood Risk Target: " + floodRisk);
        }

        // Update UI
        floodRiskSlider.value = floodRisk;
        UpdateRiskLabel();
    }

    private void UpdateRiskLabel()
    {
        // Display based on actual slider position (not target)
        // int displayValue = Mathf.RoundToInt(floodRiskSlider.value);

        if (floodRisk < 30)
            riskLabel.text = $"Low Risk ({floodRisk:0}%)";
        else if (floodRisk < 70)
            riskLabel.text = $"Medium Risk ({floodRisk:0}%)";
        else
            riskLabel.text = $"High Risk! ({floodRisk:0}%)";

        Debug.Log($"Slider Value = {floodRiskSlider.value}, Text = {riskLabel.text}, Target = {floodRisk}");

        // Sensor values
        rainfallText.text = $"Rainfall: {rainfall:0} mm/h";
        waterLevelText.text = $"Water Level: {waterLevel:0} cm";


        if (floodRisk >= emergencyManager.floodRiskThreshold || rainfall >= emergencyManager.rainfallThreshold || waterLevel >= emergencyManager.waterLevelThreshold)
        {
            emergencyManager.TriggerEmergency();
        }
        // floodRiskSlider.value = currentRisk;
        // riskLabel.text = "Flood Risk: " + Mathf.RoundToInt(currentRisk) + "%";
    }
}
