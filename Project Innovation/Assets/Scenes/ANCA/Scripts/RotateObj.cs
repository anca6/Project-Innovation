using UnityEngine;

public class RotateObj : MonoBehaviour
{
    //rotates the object on touch
    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch screenTouch = Input.GetTouch(0);

            if (screenTouch.phase == TouchPhase.Moved)
            {
                transform.Rotate(0f, -screenTouch.deltaPosition.x, 0f);
            }
        }
    }
}
