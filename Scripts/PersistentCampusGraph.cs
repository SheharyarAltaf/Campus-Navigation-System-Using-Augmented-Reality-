using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class WaypointData
{
    public Vector3 localPosition;
}

[System.Serializable]
public class CampusGraphData
{
    public List<WaypointData> waypoints = new List<WaypointData>();
}

public class PersistentCampusGraph : MonoBehaviour
{
    [Header("Hierarchy References")]
    [Tooltip("Drag your XR Space GameObject here so points align with localized maps.")]
    public Transform xrSpace;

    [Tooltip("The prefab that represents a point on your path.")]
    public GameObject waypointPrefab;

    [Tooltip("Optional: An empty GameObject under XR Space to keep hierarchy clean.")]
    public Transform waypointContainer;

    private string savePath;

    void Start()
    {
        // On Android, this saves to: /storage/emulated/0/Android/data/<your-package-name>/files/
        savePath = Path.Combine(Application.persistentDataPath, "campus_routes.json");

        if (waypointContainer == null) waypointContainer = xrSpace;

        // Automatically attempt to load saved routes when the app starts
        LoadGraph();
    }

    // Connect this to a new "Save Path" UI Button
    public void SaveGraph()
    {
        CampusGraphData data = new CampusGraphData();

        // Finds all objects tagged as "Waypoint" in the scene
        GameObject[] currentPoints = GameObject.FindGameObjectsWithTag("Waypoint");

        foreach (GameObject wp in currentPoints)
        {
            WaypointData newWpData = new WaypointData();

            // CRITICAL: Convert to local space relative to the XR Maps
            newWpData.localPosition = xrSpace.InverseTransformPoint(wp.transform.position);
            data.waypoints.Add(newWpData);
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log("Successfully saved " + currentPoints.Length + " waypoints to device.");
    }

    public void LoadGraph()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            CampusGraphData data = JsonUtility.FromJson<CampusGraphData>(json);

            foreach (WaypointData wpData in data.waypoints)
            {
                GameObject wp = Instantiate(waypointPrefab, waypointContainer);

                // Restore the position relative to the map
                wp.transform.localPosition = wpData.localPosition;

                // Ensure it has the tag so it can be saved again later if edited
                wp.tag = "Waypoint";
            }

            Debug.Log("Loaded " + data.waypoints.Count + " waypoints from storage.");

            // TODO: Call your Navigation Graph update function here so it draws the blue line
        }
        else
        {
            Debug.Log("No previous campus routes found.");
        }
    }
}