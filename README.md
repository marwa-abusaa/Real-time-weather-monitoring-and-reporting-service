# 🌦️ Real-Time Weather Monitoring and Reporting Service

A C# console application that simulates a real-time weather monitoring and reporting system. The application processes weather data in different formats (JSON and XML) and activates weather bots (RainBot, SunBot, SnowBot) based on configurable thresholds.

## 🛠 Features

- ✅ Parses weather data in **JSON** and **XML** formats.
- ✅ Supports multiple weather bots:
  - **RainBot**: Activates when humidity exceeds a threshold.
  - **SunBot**: Activates when temperature rises above a threshold.
  - **SnowBot**: Activates when temperature drops below a threshold.
- ✅ Fully configurable via config.json.
- ✅ Designed using **Clean Code**, **SOLID principles**, and common **design patterns**:
  - **Strategy** for flexible data parsing
  - **Observer** for notifying bots of weather changes

## 🧩 Technologies Used

- C# (.NET 9)
- System.Text.Json for JSON handling


## 📄 Example Configuration (botsSettings.json)

```json
{
  "RainBot": {
    "Enabled": true,
    "Threshold": 70,
    "Message": "It looks like it's about to pour down!"
  },
  "SunBot": {
    "Enabled": true,
    "Threshold": 30,
    "Message": "Wow, it's a scorcher out there!"
  },
  "SnowBot": {
    "Enabled": false,
    "Threshold": 0,
    "Message": "Brrr, it's getting chilly!"
  }
}
```
## 📌 Notes

- You can easily extend this project by adding new bots or supporting more data formats.
- This application follows the **Open-Closed Principle**, making the system modular and easy to extend without modifying existing code.
