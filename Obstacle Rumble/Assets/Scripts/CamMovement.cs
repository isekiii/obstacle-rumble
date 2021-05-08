using UnityEngine;

public class CamMovement : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float mouseSpeed = 10f;
    [SerializeField] private float camSmooth = 0.15f;

    [SerializeField] private float offset;

    private Vector3 smoothingVelocity;
    private Vector3 currentRotation;

    private float mouseX, mouseY;

    private void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * mouseSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * mouseSpeed;
        mouseY = Mathf.Clamp(mouseY, -5, 70);
        
        currentRotation = Vector3.SmoothDamp(currentRotation,
            new Vector3(mouseY,mouseX),ref smoothingVelocity, camSmooth);

        transform.eulerAngles = currentRotation;

        transform.position = target.position - transform.forward * offset;

    }
}
