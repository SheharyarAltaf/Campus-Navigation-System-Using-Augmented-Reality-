using UnityEngine;

public class ArrowLook : MonoBehaviour
{
    void Update()
    {
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0;
        transform.rotation = Quaternion.LookRotation(forward);
    }
}