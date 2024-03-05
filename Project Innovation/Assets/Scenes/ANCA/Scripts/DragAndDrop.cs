using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 offset;
    Vector3 startingPos;

    public Camera myCamera;

    private void Start()
    {
        startingPos = this.transform.position;
    }

    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = myCamera.WorldToScreenPoint(transform.position).z;
        return myCamera.ScreenToWorldPoint(mouseScreenPos);
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
        //transform.GetComponent<Collider>().enabled = false;
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    void OnMouseUp()
    {
        //transform.position = startingPos;
        //transform.GetComponent<Collider>().enabled = true;
    }
}
