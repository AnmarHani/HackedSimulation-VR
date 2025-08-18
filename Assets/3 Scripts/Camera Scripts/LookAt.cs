using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Vector3 rotationOffset = new Vector3(90, 0, 0);

    void LateUpdate()
    {
        if (Camera.main == null) return;

        transform.LookAt(Camera.main.transform);
        transform.rotation *= Quaternion.Euler(rotationOffset);
    }
}