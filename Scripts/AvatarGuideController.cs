using UnityEngine;
using System.Collections;

public class AvatarGuideController : MonoBehaviour
{
    [Header("Setup")]
    public Animator avatarAnimator;
    public Transform arCamera; // Drag your Main AR Camera here

    [Header("Settings")]
    public float spawnDistance = 2.0f; // How many meters in front of the user it spawns
    public float floorOffset = 1.5f;   // Adjust this so the avatar's feet touch the ground
    public float hideAfterSeconds = 4.0f; // How long before the avatar disappears

    private void Start()
    {
        // Hide the avatar when the app starts
        StartWelcomeSequence();
    }

    // Call this function from your UI Button / Destination Dropdown
    public void StartWelcomeSequence()
    {
        // 1. Position the avatar exactly in front of the user
        Vector3 spawnPosition = arCamera.position + (arCamera.forward * spawnDistance);

        // Lock the Y axis so the avatar doesn't float in the air
        spawnPosition.y = arCamera.position.y - floorOffset;
        transform.position = spawnPosition;

        // 2. Make the avatar turn around and look directly at the user
        Vector3 lookPosition = arCamera.position;
        lookPosition.y = transform.position.y; // Keep it level so it doesn't tilt up/down
        transform.LookAt(lookPosition);

        // 3. Show the avatar and trigger the Wave animation
        gameObject.SetActive(true);
        if (avatarAnimator != null)
        {
            avatarAnimator.SetTrigger("WaveTrigger");
        }

        // 4. (Optional) Hide the avatar after waving so it doesn't block the arrows
        StartCoroutine(HideAvatarRoutine());
    }

    IEnumerator HideAvatarRoutine()
    {
        yield return new WaitForSeconds(hideAfterSeconds);

        // You can add a particle effect here (like a smoke poof) before disabling!
        gameObject.SetActive(false);
    }
}