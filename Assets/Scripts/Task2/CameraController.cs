using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public CameraTransform cam = null;
    public Transform target = null;
    public static Vector3 offset;

    Ray ray;
    RaycastHit hit;
    [SerializeField] private float limit = 80;
    [SerializeField] private float zoom = 2f;
    [SerializeField] private float zoomMax = 30;
    [SerializeField] private float zoomMin = 4;
    [SerializeField] private float MouseSense = 5;
    private float X, Y;

    void Start()
    {
        cam = this.gameObject.AddComponent<CameraTransform>();
        limit = Mathf.Abs(limit);
        if (limit > 90) limit = 90;
        offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax) / 2);
        transform.position = target.position + offset;
    }

    void Update()
    {
        SwitchCameraViewTarget();
        MouseInputR();
        MouseScroll();
        if (target == null)
        {
            try { target = GameObject.FindGameObjectWithTag("cube").transform; }
            catch
            {
                target = GameObject.FindGameObjectWithTag("spawn").transform;
            }
        }
    }
    void MouseInputR()
    {
        if (Input.GetKey(KeyCode.Mouse1) && !Input.GetKey(KeyCode.Mouse0))
        {
            X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * MouseSense;
            Y += Input.GetAxis("Mouse Y") * MouseSense;
            Y = Mathf.Clamp(Y, -limit, limit);
            transform.localEulerAngles = new Vector3(-Y, X, 0);
            cam.Transform(target, offset);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    void SwitchCameraViewTarget()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Mouse0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.gameObject.name);
                target = hit.collider.gameObject.GetComponent<Transform>();
            }
            cam.Transform(target, offset);
        }
    }
    void MouseScroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && offset.z < -zoomMin)// приблизить
        {
            offset.z += zoom;
            cam.MouseZoom(offset, zoomMax, zoomMin);
            cam.Transform(target, offset);
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && offset.z > -zoomMax)// отдалить
        {
            offset.z -= zoom;
            cam.MouseZoom(offset, zoomMax, zoomMin);
            cam.Transform(target, offset);
        }
    }

}