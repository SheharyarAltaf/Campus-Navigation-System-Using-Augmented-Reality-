using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeToAR : MonoBehaviour
{
    public void GoToOutdoorAR()
    {
        // Set a flag so the next scene knows to open the Outdoor UI
        PlayerPrefs.SetInt("ShowOutdoorUI", 1);
        SceneManager.LoadScene("ARNavigationScene");
    }
}