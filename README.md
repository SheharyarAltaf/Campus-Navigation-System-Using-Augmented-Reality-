# Campus-Navigation-System-Using-Augmented-Reality-
Final Year Project - Campus Navigation System using Augmented Reality . In this Project my Navigation System provide indoor and Outdoor Navigation of whole campus using 3D arrows and prefabs on real time camera feed.

> A Hybrid Augmented Reality Navigation Solution for Complex Educational Environments

**Final Year Project (2022–2026) — University of Engineering and Technology, Lahore**

Supervised by: **Dr. Irfan Yousuf**

---

## 📌 Overview

**Campus AR Nav** is a mobile application that provides real-time indoor and outdoor navigation across a university campus using Augmented Reality. Instead of traditional 2D maps, it projects 3D directional arrows and prefabs directly onto the live camera feed, guiding users through corridors, stairwells, labs, and open campus grounds seamlessly.

The system operates as a **hybrid engine** — switching between markerless SLAM-based indoor localization and GPS-based outdoor navigation — without requiring the user to restart or reconfigure anything.

---

## 🎯 Project Objectives

- **Hybrid Engine** — Smooth transition between indoor and outdoor navigation modes
- **GPS-Independent Indoor Navigation** — Uses spatial anchors and SLAM to map complex corridors
- **Optimal Pathfinding** — Real-time shortest path calculation using the A\* algorithm
- **Immersive AR UI** — 3D arrows and prefabs rendered flat on the floor plane in the real world
- **Dynamic Rerouting** — Instantly recalculates the path if the user deviates

---

## ✨ Features

### 🏫 Indoor Navigation
- Markerless localization powered by the **MultiSet SDK** — no QR codes needed
- Scans the environment's visual features for instant spatial recognition
- Navigates users to specific classrooms, labs, faculty offices, and washrooms
- Supports **floor-to-floor navigation**, understanding altitude and stairwell transitions
- AR arrows anchored to the real environment guide users naturally through corridors
- Custom **NavMesh** generation defines walkable surfaces and avoids obstacles

### 🌳 Outdoor Navigation
- GPS-based navigation integrated via the **Mapbox API**
- Covers departments, hostels, admin block, library, and open grounds
- AR waypoints remain stable even in bright sunlight
- Geofenced transition zones at building entrances enable seamless indoor ↔ outdoor handoff

### 🔁 Dynamic Rerouting
- Deviation detection triggers instant path recalculation from the user's new position
- Failsafe logic prevents users from getting stuck in dead ends

### 🗺️ Pathfinding Logic
- **A\* (A-Star) Algorithm** for guaranteed shortest route
- Campus mapped as an interconnected node graph (corridors, doors, stairs)
- Heuristic computation finds optimal paths in milliseconds

---

## 📱 App Screenshots

### Home Screen
| Home Screen | Select Destination | Localizing |
|---|---|---|
| ![Home](App%20Screenshots/Home(doc).png) | ![Select Destination](App%20Screenshots/Select_Destination(doc).png) | ![Localizing](App%20Screenshots/Localization.png) |

### Indoor Navigation
| Indoor Path | Destination Reached |
|---|---|
| ![Indoor Path](App%20Screenshots/PathShowing(doc).png) | ![Arrived](App%20Screenshots/Destination_Reach(Doc).png) |

### Outdoor Navigation
| Outdoor Path | Destination Pin |
|---|---|
| ![Outdoor Path](App%20Screenshots/OutdoorShowingpath.jfif) | ![Destination Pin](App%20Screenshots/Outdoor_DestinationPin.jpg) |

### Other Screens
| Department Selection | Pop-up Options |
|---|---|
| ![Pop-up Options](App%20Screenshots/Pop-up-Options.png) | ![Pop-up Options](App%20Screenshots/Pop-up-Options.png) |

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Platform | Unity (Android) |
| AR Framework | MultiSet SDK (Markerless SLAM) |
| Outdoor Maps | Mapbox API |
| Pathfinding | A\* Algorithm |
| Language | C# |
| 3D Assets | Custom Unity Prefabs & NavMesh |

---

## 🏗️ System Architecture

```
User Opens App
     │
     ├──► Indoor Mode
     │        │
     │        ├── MultiSet SDK scans environment
     │        ├── SLAM localizes user position
     │        ├── A* calculates shortest path via node graph
     │        ├── NavMesh defines walkable surfaces
     │        └── AR arrows rendered on floor plane
     │
     └──► Outdoor Mode
              │
              ├── GPS coordinates via Mapbox API
              ├── Polyline route overlay
              └── AR waypoints anchored in open space

Geofenced zones at building entrances trigger seamless mode switching
```

---

## 🚀 Getting Started

### Prerequisites
- Android device with ARCore support
- Android 8.0 (Oreo) or higher
- Camera permission enabled

### Installation

**Option 1 — APK Download**

Download the latest APK directly from the project portfolio:

🔗 [ar-nav-uet.vercel.app](https://ar-nav-uet.vercel.app)

**Option 2 — Build from Source**

```bash
# Clone the repository
git clone https://github.com/YOUR_USERNAME/Campus-Navigation-System-Using-Augmented-Reality.git

# Open the project in Unity (recommended: Unity 2022 LTS or later)
# Configure your Mapbox API key in Assets/Resources/MapboxConfig
# Build for Android via File > Build Settings
```

---

## 📂 Project Structure

```
Campus-Navigation-System/
├── Assets/
│   ├── Scripts/          # C# navigation, pathfinding, AR logic
│   ├── Prefabs/          # 3D arrows, waypoints, avatar prefabs
│   ├── Scenes/           # Indoor and Outdoor Unity scenes
│   └── Resources/        # Config files, NavMesh data
├── Packages/             # Unity package dependencies
├── ProjectSettings/
└── README.md
```

---

## 🔮 Future Work

- 🎙️ **Voice Assist** — Audio turn-by-turn directions
- ☁️ **Cloud Maps** — Remotely updatable campus maps without app reinstall
- ♿ **Accessibility Mode** — Wheelchair-friendly routing and larger AR indicators

---

## 🌐 Portfolio & Resources

Visit the project hub for the APK download, user guides, and team portfolio:

🔗 **[ar-nav-uet.vercel.app](https://ar-nav-uet.vercel.app)**

---

## 📄 License

This project was developed as a Final Year Project at UET Lahore. All rights reserved by the team members.

---

