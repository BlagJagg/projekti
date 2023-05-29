using UnityEngine;

public class RemoveObjectsOutsideCameraView : MonoBehaviour
{
    public string excludedTag = "Player"; // Tag to exclude from removal

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Get the screen bounds in world space
        Vector3 cameraBoundsMin = mainCamera.ScreenToWorldPoint(Vector3.zero);
        Vector3 cameraBoundsMax = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

        // Find all objects in the scene
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (var obj in allObjects)
        {
            // Check if the object has the excluded tag
            if (obj.CompareTag(excludedTag))
                continue; // Skip to the next object if it has the excluded tag

            // Check if the object is outside the camera's view
            Collider2D collider = obj.GetComponent<Collider2D>();

            if (collider != null)
            {
                Vector3 objectBoundsMin = collider.bounds.min;
                Vector3 objectBoundsMax = collider.bounds.max;

                if (objectBoundsMax.x < cameraBoundsMin.x || objectBoundsMin.x > cameraBoundsMax.x ||
                    objectBoundsMax.y < cameraBoundsMin.y || objectBoundsMin.y > cameraBoundsMax.y)
                {
                    // If the object is outside the camera's view, remove it from the scene
                    Destroy(obj);
                }
            }
        }
    }
}
