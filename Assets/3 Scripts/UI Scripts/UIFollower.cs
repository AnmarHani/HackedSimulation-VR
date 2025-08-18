using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class UIFollower : MonoBehaviour
{
    [Tooltip("Head or camera transform to follow. If empty will try Camera.main.")]
    public Transform headTransform;

    [Tooltip("Distance in meters in front of the head.")]
    public float distance = 2f;

    [Tooltip("Local offset relative to the head-forward position (x = right, y = up).")]
    public Vector3 offset = Vector3.zero;

    [Tooltip("Smoothing time for movement.")]
    public float smoothTime = 0.08f;

    [Tooltip("If true, UI will rotate to face the player.")]
    public bool facePlayer = true;

    [Tooltip("If true, only rotate around Y so UI stays upright.")]
    public bool onlyYRotation = true;

    [Tooltip("Yaw offset in degrees. Negative = left, positive = right.")]
    public float yawOffset = 0f;

    [Tooltip("Pitch offset in degrees. Negative = down, positive = up.")]
    public float pitchOffset = 0f;

    Vector3 velocity;

    void Start()
    {
        if (headTransform == null && Camera.main != null)
            headTransform = Camera.main.transform;

        // Ensure canvas is in World Space for correct positioning
        var canvas = GetComponent<Canvas>();
        if (canvas != null)
            canvas.renderMode = RenderMode.WorldSpace;
    }

    void LateUpdate()
    {
        if (headTransform == null) return;

        // Compute desired position in front of the head
        Vector3 desired = headTransform.position + headTransform.forward * distance
                          + headTransform.right * offset.x
                          + headTransform.up * offset.y
                          + headTransform.forward * offset.z;

        // Smoothly move to desired position
        transform.position = Vector3.SmoothDamp(transform.position, desired, ref velocity, smoothTime);

        if (facePlayer)
        {
            if (onlyYRotation)
            {
                // Look at player but keep UI upright (only rotate Y)
                Vector3 direction = transform.position - headTransform.position;
                direction.y = 0f;
                if (direction.sqrMagnitude > 0.000001f)
                {
                    Quaternion targetRot = Quaternion.LookRotation(direction.normalized, Vector3.up);

                    // apply yaw offset (rotate around world up)
                    if (Mathf.Abs(yawOffset) > 0.0001f)
                        targetRot = Quaternion.Euler(0f, yawOffset, 0f) * targetRot;

                    // remove any roll/pitch to keep upright
                    Vector3 e = targetRot.eulerAngles;
                    e.x = 0f;
                    e.z = 0f;
                    targetRot = Quaternion.Euler(e);

                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 1f - Mathf.Exp(-12f * Time.deltaTime));
                }
            }
            else
            {
                // Fully face the player's head, but allow small pitch/yaw adjustments and prevent roll
                Vector3 dir = transform.position - headTransform.position;
                if (dir.sqrMagnitude > 0.000001f)
                {
                    Quaternion look = Quaternion.LookRotation(dir.normalized, Vector3.up);
                    Vector3 e = look.eulerAngles;

                    // apply offsets
                    e.x += pitchOffset;
                    e.y += yawOffset;
                    e.z = 0f; // prevent roll

                    Quaternion targetRot = Quaternion.Euler(e);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 1f - Mathf.Exp(-12f * Time.deltaTime));
                }
            }
        }
    }
}