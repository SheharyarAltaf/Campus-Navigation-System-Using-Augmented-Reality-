using UnityEngine;

public class ArrowBounce : MonoBehaviour
{
    void Update()
    {
        transform.position += Vector3.up * Mathf.Sin(Time.time * 3f) * 0.002f;
    }
}