using UnityEngine;

public class ObjectManipulator : MonoBehaviour
{
    private float initialDistance;
    private Vector3 initialScale;

    private float initialRotationAngle;
    private Quaternion initialRotation;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // ---- Scale ----
            if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
                initialScale = transform.localScale;

                initialRotationAngle = Mathf.Atan2(touchOne.position.y - touchZero.position.y,
                                                   touchOne.position.x - touchZero.position.x) * Mathf.Rad2Deg;
                initialRotation = transform.rotation;
            }
            else
            {
                float currentDistance = Vector2.Distance(touchZero.position, touchOne.position);
                if (Mathf.Approximately(initialDistance, 0)) return;

                float scaleFactor = currentDistance / initialDistance;
                transform.localScale = initialScale * scaleFactor;

                // ---- Rotate ----
                float currentAngle = Mathf.Atan2(touchOne.position.y - touchZero.position.y,
                                                 touchOne.position.x - touchZero.position.x) * Mathf.Rad2Deg;
                float angleDelta = currentAngle - initialRotationAngle;

                transform.rotation = initialRotation * Quaternion.Euler(0, -angleDelta, 0);
            }
        }
    }
}
