using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Controller settings
    public float rotationSpeed;
    public float minRotationY;
    public float maxRotationY;

    public float movementSpeed;
    public float movementLerpTime;

    /* TODO: Add support for these fellows:
    public Vector3 MinBounds;
    public Vector3 MaxBounds;
    */

    public float zoomSpeed;
    public float minZoom;
    public float maxZoom;

    private float scroll;
    private float hAxis = 0;
    private float vAxis;
    private float rotY;
    private float rotX;
    private bool scrollButton;
    private Vector3 movement;
    RaycastHit hit;


    private void Move()
    {
        if (scrollButton) return; // Don't move when rotating

        Vector3 deltaZoom = transform.forward * zoomSpeed * scroll;

        float rotY = transform.rotation.eulerAngles.y;

        // Set the zoom amount to the distance between the camera position and the pivot point.
        float zoomAmount = Vector3.Distance(hit.point, transform.position + deltaZoom);
        if ((zoomAmount > maxZoom && scroll < 0) || (zoomAmount < minZoom && scroll > 0))
        {
            zoomAmount = Vector3.Distance(hit.point, transform.position);
            if (zoomAmount > maxZoom)
            {
                deltaZoom = transform.position - (hit.point + transform.forward * maxZoom);
            }
            if (zoomAmount < maxZoom)
            {
                deltaZoom = transform.position - (hit.point + transform.forward * minZoom);
            }
            deltaZoom = Vector3.zero;
        }


        // Get WASD movement, apply rotation matrix and combine with deltaZoom
        float moveX = Time.deltaTime * (movementSpeed * (hAxis * Mathf.Cos((Mathf.PI / 180) * rotY) + vAxis * Mathf.Sin((Mathf.PI / 180) * rotY))) * (zoomAmount / maxZoom) + deltaZoom.x;
        float moveZ = Time.deltaTime * (movementSpeed * (vAxis * Mathf.Cos((Mathf.PI / 180) * rotY) - hAxis * Mathf.Sin((Mathf.PI / 180) * rotY))) * (zoomAmount / maxZoom) + deltaZoom.z;
        float moveY = deltaZoom.y;

        // Feed movement values into a vector and lerp velocity.
        movement = Vector3.Lerp(movement, new Vector3(moveX, moveY, moveZ), movementLerpTime);

        // Apply movement. 
        Vector3 newPos = transform.position + movement;
        transform.position = newPos;
    }
    private void Rotate()
    {

        // Apply rotation.
        float newYrotation = -rotY * rotationSpeed + transform.localRotation.eulerAngles.x;

        if (newYrotation < maxRotationY && newYrotation > minRotationY)
            transform.RotateAround(hit.point, transform.right, -rotY * rotationSpeed);

        transform.RotateAround(hit.point, Vector3.up, rotX * rotationSpeed);


    }
    private void Start()
    {
        Physics.Raycast(transform.position, transform.forward, out hit);
    }
    private void Update()
    {
        Physics.Raycast(transform.position, transform.forward, out hit);
        rotX = Input.GetAxis("Mouse X");
        rotY = Input.GetAxis("Mouse Y");

        scrollButton = Input.GetMouseButton(2);

        scroll = Input.GetAxis("Mouse ScrollWheel");
        vAxis = 0;
        hAxis = 0;

        if (Input.GetKey("w")) vAxis = 1;
        else if (Input.GetKey("s")) vAxis = -1;
        else if (Input.GetKey("a")) hAxis = -1;
        else if (Input.GetKey("d")) hAxis = 1;

        Move();

        if (scrollButton) Rotate();
    }
