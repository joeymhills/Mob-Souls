using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 2.0f; // Mouse sensitivity
    public float smoothing = 2.0f;   // Mouse smoothing

    private Vector2 smoothMouse;
    private Vector2 currentMouse;
    private Vector2 deltaMouse;

    private GameObject player;

    private void Start()
    {
        player = this.transform.parent.gameObject; // Assuming the player is the parent of the camera
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
    }

    private void Update()
    {
        // Get the mouse input
        currentMouse = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        // Smooth the mouse input
        deltaMouse = Vector2.Scale(currentMouse, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothMouse.x = Mathf.Lerp(smoothMouse.x, deltaMouse.x, 1f / smoothing);
        smoothMouse.y = Mathf.Lerp(smoothMouse.y, deltaMouse.y, 1f / smoothing);

        // Apply the mouse rotation to the player
        player.transform.localRotation *= Quaternion.AngleAxis(smoothMouse.x, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(-smoothMouse.y, Vector3.right);
    }
}