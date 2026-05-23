using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;        // Player
    public Vector3 offset = new Vector3(0, 3, -6); // Kamera di belakang dan atas Player
    public float followSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        // Posisi target + offset yang selalu relatif terhadap arah player
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(target); // Kamera selalu melihat ke Player
    }
}