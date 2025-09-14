using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmergencyManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] TextMeshProUGUI emergencyLabel;
    [SerializeField] GameObject evacuationPanel; // assign in inspector

    public FloodRiskDummy floodRiskDummy;   // drag FloodRiskDummy here
    private AudioSource sirenAudio;     // attach siren sound


    [Header("Thresholds")]
    public float rainfallThreshold = 50f;   // mm/h
    public float waterLevelThreshold = 120f; // cm
    public float floodRiskThreshold = 80f;  // %

    //private bool isSimulationActive = true;

    void Start()
    {
        emergencyLabel.text = "Status: Monitoring...";
        evacuationPanel.SetActive(false);
        
        // Add AudioSource dynamically if not already attached
        sirenAudio = gameObject.AddComponent<AudioSource>();

        // Load siren clip from Resources folder
        sirenAudio.clip = Resources.Load<AudioClip>("siren"); // siren.wav inside Assets/Resources/

        //sirenAudio.clip = clip;
        //sirenAudio.loop = true;       // repeat continuously
        sirenAudio.playOnAwake = false;
    }

    // ✅ Automatic Trigger based on Flood Risk
    public void TriggerEmergency()
    {
        float risk = floodRiskDummy.CurrentRisk; // ✅ get slider value

        if (risk >= 70) // High risk
        {
            emergencyLabel.text = "🚨 Siren Activated! Take immediate action!";
            Debug.Log("🚨 High Risk! Triggering Emergency Measures...");
            if (!sirenAudio.isPlaying)
                sirenAudio.Play();  // siren on
        }
        else if (risk >= 30) // Medium risk
        {
            emergencyLabel.text = "🚨 Proceed to evacuation route!";
            Debug.Log("⚠️ Medium Risk! Stay alert.");
            if (sirenAudio.isPlaying)
                sirenAudio.Stop();  // stop siren, just alert
        }
        else
        {
            emergencyLabel.text = "⚠️ ALERT: Flood risk detected! Stay alert.";
            Debug.Log("✅ Low Risk. Safe.");
            if (sirenAudio.isPlaying)
                sirenAudio.Stop();  // stop siren
        }
    }
}
