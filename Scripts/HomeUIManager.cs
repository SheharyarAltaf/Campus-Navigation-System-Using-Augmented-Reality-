using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeUIManager : MonoBehaviour
{
    [Header("UI References")]
    public GameObject popupOverlayPanel;

    [Header("Scene Names")]
    public string ceradSceneName = "Cerad";
    public string mearSceneName = "Mechanical";
    public string libarSceneName = "Library";
    public string biomSceneName = "Biomedical";
    void Start()
    {
        if (popupOverlayPanel != null)
            popupOverlayPanel.SetActive(false);
    }

    // ============ POPUP CONTROLS ============

    public void ShowPopup()
    {
        popupOverlayPanel.SetActive(true);
    }

    public void HidePopup()
    {
        popupOverlayPanel.SetActive(false);
    }

    // ============ DEPARTMENT BUTTON FUNCTIONS ============

    public void LoadCerad()
    {
        Debug.Log("Loading CERAD...");
        SceneManager.LoadScene(ceradSceneName);
    }

    public void LoadMechanical()
    {
        Debug.Log("Loading Mechanical Department...");
        SceneManager.LoadScene(mearSceneName);
    }

    public void LoadMainLibrary()
    {
        Debug.Log("Loading Main Library...");
        SceneManager.LoadScene(libarSceneName);
    }

    public void LoadBiomedical()
    {
        Debug.Log("Loading Biomedical Department...");
        SceneManager.LoadScene(biomSceneName);
    }

  
}