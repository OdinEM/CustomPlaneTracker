AR Plane Tracking and Cube Placement Project

Description:
This project is built using Unity 6 and AR Foundation. It allows the user to track horizontal planes in the real world and place a cube prefab on the plane by tapping the screen.

Features:
- Plane tracking using AR Foundation
- Tap-to-place interaction for spawning a cube on a detected plane
- Cube instantiates exactly where the user taps, aligned to the plane

Setup Instructions:
1. Open the project in Unity 6.
2. Make sure the AR Foundation package is installed.
3. Ensure ARCore XR Plugin (for Android) or ARKit XR Plugin (for iOS) is installed, depending on your target platform.
4. In the scene, confirm that the following components are present:
   - AR Session
   - AR Session Origin
     - AR Camera (tagged as Main Camera)
     - AR Raycast Manager
     - AR Plane Manager with a valid plane prefab
5. Create or locate a Cube prefab and store it in the Project folder (e.g., under Assets/Prefabs).
6. Attach the TapToPlace.cs script to the AR Session Origin.
7. Assign the Cube prefab to the 'cubePrefab' field in the TapToPlace script via the Inspector.
8. Build and run the project on a physical device that supports AR.

How It Works:
- When the user taps the screen, the app performs a raycast from the touch position.
- If a plane is detected at the touch location, the cube prefab is instantiated at that position.
- Multiple cubes can be placed by tapping multiple times.


