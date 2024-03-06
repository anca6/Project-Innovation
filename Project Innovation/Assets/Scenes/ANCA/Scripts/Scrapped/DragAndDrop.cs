using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 offset;
    Vector3 startingPos;

    public Camera myCamera;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        // startingPos = this.transform.position;
        startingPos = rectTransform.anchoredPosition;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        // mouseScreenPos.z = myCamera.WorldToScreenPoint(transform.position).z;
        mouseScreenPos.z = myCamera.WorldToScreenPoint(rectTransform.position).z;
        return myCamera.ScreenToWorldPoint(mouseScreenPos);
    }

    void OnMouseDown()
    {
        //offset = transform.position - MouseWorldPosition();
        offset = rectTransform.position - MouseWorldPosition();
        //transform.GetComponent<Collider>().enabled = false;
    }

    void OnMouseDrag()
    {
        //transform.position = MouseWorldPosition() + offset;
        rectTransform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        var rayOrigin = myCamera.transform.position;
        var rayDirection = MouseWorldPosition() - myCamera.transform.position;

        if (Physics.Raycast(rayOrigin, rayDirection, out RaycastHit hitInfo))
        {
            if (hitInfo.collider != null && hitInfo.collider.CompareTag("DropTarget"))
            {

            Debug.Log("dropped on target");
            }
        }
        else
        {
            rectTransform.position = startingPos + MouseWorldPosition();
        }
    }
}
