🌊 Flood Risk Simulation – Unity + IoT Dummy Data

This Unity project simulates flood risk monitoring using a Flood Risk Bar, IoT dummy data (rainfall & water levels), and an Emergency Response System with siren alerts.
It’s designed as part of an immersive learning & disaster mitigation project (V-RASS: Virtual River Awareness Simulation System).

📖 Features
1. Flood Risk Bar (Slider + Label)
2. IoT Dummy Data Simulation (random rainfall & water levels)
3. Start / Pause / Reset Buttons to control simulation
4. Emergency Trigger Button → activates siren & emergency response
5. TextMeshPro Integration for modern UI text rendering

📂 Project Setup
1. UI Hierarchy (Canvas)
Inside your Canvas, create:
- Slider → rename to FloodRiskSlider
- Text (TMP) → rename to RiskLabel
- Button → StartButton, PauseButton, ResetButton
- Button → EmergencyButton

2. Scripts Setup
Create 3 GameObjects in the Hierarchy:
- FloodRiskManager → attach FloodRiskDummy.cs
- EmergencyManager → attach EmergencyManager.cs
- SimulationController → attach SimulationController.cs

3. Inspector References
- FloodRiskDummy.cs
Drag FloodRiskSlider into floodRiskSlider
Drag RiskLabel into riskLabel

- EmergencyManager.cs
Drag the FloodRiskManager GameObject into floodRiskDummy
Add an AudioSource → assign siren.mp3
Drag AudioSource into sirenAudio

- SimulationController.cs
Assign reference to FloodRiskDummy


🎵 Audio Setup
1. Create folder: Assets/Audio/
2. Place file: siren.mp3
3. Select EmergencyManager GameObject → add AudioSource:
  - 🔇 Uncheck Play On Awake
  - 🎶 Assign siren.mp3
  - 🔊 Set Volume ~0.8


▶️ How to Run
- Start Button → begins flood risk increase (dummy IoT data)
- Pause Button → freezes bar at current value
- Reset Button → returns simulation to Idle (0%)
- Emergency Button → triggers siren + logs emergency response

🛠 Troubleshooting
If you see NullReferenceException:
- Make sure all UI objects are dragged in Inspector
- Confirm FloodRiskDummy, EmergencyManager, and SimulationController exist in Hierarchy
- Use Debug.Log inside TriggerEmergency() to verify references



📌 Future Roadmap

🔗 Integration with real IoT data (rainfall sensors, water level meters)
🌐 Cloud dashboard for real-time flood monitoring
🎮 VR/AR immersive training for disaster awareness

📷 Screenshots (Optional)

Add screenshots or GIF demos here once UI is complete.



📄 License

This project is licensed under the MoedaTrace License.
Feel free to use, modify, and distribute with attribution.
