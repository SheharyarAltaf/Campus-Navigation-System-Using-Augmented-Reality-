using UnityEngine;
using TMPro; // For TextMeshPro
using System.Collections;
using UnityEngine.Android; // For asking Android Permissions

public class GPSDebugger : MonoBehaviour
{
    public TextMeshProUGUI debugText; // Drag your UI Text here

    IEnumerator Start()
    {
        debugText.text = "Starting GPS...";

        // 1. Ask Android for GPS Permission
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            yield return new WaitForSeconds(2); // Wait for user to click 'Allow'
        }

        // 2. Check if the user has GPS turned on in their phone settings
        if (!Input.location.isEnabledByUser)
        {
            debugText.text = "ERROR: Turn on GPS in Phone Settings!";
            yield break;
        }

        // 3. Start the Location Service (Update every 1 meter)
        Input.location.Start(5f, 1f);

        // 4. Wait for it to connect to satellites
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            debugText.text = "Searching for Satellites... " + maxWait;
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1 || Input.location.status == LocationServiceStatus.Failed)
        {
            debugText.text = "GPS Initialization Failed. Are you inside?";
            yield break;
        }
    }

    void Update()
    {
        // 5. If running, constantly update the text!
        if (Input.location.status == LocationServiceStatus.Running)
        {
            debugText.text = $"Lat: {Input.location.lastData.latitude}\nLon: {Input.location.lastData.longitude}";
        }
    }
}