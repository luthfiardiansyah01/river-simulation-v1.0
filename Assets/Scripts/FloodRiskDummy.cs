using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FloodRiskDummy : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] Slider floodRiskSlider;
    [SerializeField] Image fillColor;
    [SerializeField] TextMeshProUGUI riskLabel;  // assign in inspector

    [Header("Risk Simulation")]
    public float currentRisk = 0f;
    private float timer = 0f;
    public float updateInterval = 3f; // every 3 seconds
    private System.Random random = new System.Random();

    void Start()
    {
        // ✅ Set idle/initial position at the start
        SetIdlePosition();
    }

    public void SetIdlePosition()
    {
        floodRiskSlider.value = 0f;
        riskLabel.text = "Flood Risk: Idle (0%)";
    }

    public void UpdateFloodBarUI(float newRiskValue = -1)
    {
        // run simulation each frame
        timer += Time.deltaTime;

        // Smoothly move slider toward target
        floodRiskSlider.value = Mathf.Lerp(floodRiskSlider.value, currentRisk, Time.deltaTime * 2);

        // Every interval, update target risk
        if (timer >= updateInterval)
        {
            timer = 0f;
            currentRisk = random.Next(0, 101);
            Debug.Log("New Flood Risk Target: " + currentRisk);
        }

        // Display based on actual slider position (not target)
        int displayValue = Mathf.RoundToInt(floodRiskSlider.value);

        if (displayValue < 30)
            riskLabel.text = $"Low Risk ({displayValue}%)";
        else if (displayValue < 70)
            riskLabel.text = $"Medium Risk ({displayValue}%)";
        else
            riskLabel.text = $"High Risk! ({displayValue}%)";

        Debug.Log($"Slider Value = {floodRiskSlider.value}, Text = {riskLabel.text}, Target = {currentRisk}");

        UpdateRiskLabel();
    }

    private void UpdateRiskLabel()
    {
        floodRiskSlider.value = currentRisk;
        riskLabel.text = "Flood Risk: " + Mathf.RoundToInt(currentRisk) + "%";
    }
}
