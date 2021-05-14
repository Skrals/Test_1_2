using UnityEngine;

public class CameraTransform : MonoBehaviour
{
    public void Transform(Transform t, Vector3 offset)
    {
        transform.position = transform.localRotation * offset + t.position;
    }
    public void MouseZoom(Vector3 vector, float zoomMax, float zoomMin)
    {
        vector.z = Mathf.Clamp(vector.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));// значение между мин и макс
    }
}