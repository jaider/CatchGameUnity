using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatController : MonoBehaviour {

    public Camera cam;
    private float maxWidth;
    private bool canMoveHat;

    // Use this for initialization
    void Start () {
        if (cam == null)
            cam = Camera.main;

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float hatWidth = GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - hatWidth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Update is called once per physics timestep
    void FixedUpdate()
    {
        if (!canMoveHat)
            return;

        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        var targetPosition = new Vector3(rawPosition.x, 0f, 0f);
        var targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        targetPosition = new Vector3(targetWidth, targetPosition.y, targetPosition.z);
        GetComponent<Rigidbody2D>().MovePosition(targetPosition);
    }

    public void ToggleControl(bool toggle)
    {
        canMoveHat = toggle;
    }
}
