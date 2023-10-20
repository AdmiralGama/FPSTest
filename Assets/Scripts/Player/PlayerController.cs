using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    float speed = 5.0f;

    GameObject camera;
    Vector2 rotation = Vector2.zero;
    float sensitivity = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();

        PlayerMove();

        if (Input.GetButton("Fire"))
        {
            Shoot();
        }
    }

    void CameraMove()
    {
        rotation.x += Input.GetAxis("Mouse X") * sensitivity;
        rotation.y += Input.GetAxis("Mouse Y") * sensitivity;
        rotation.y = Mathf.Clamp(rotation.y, -90.0f, 90.0f);
        var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

        camera.transform.localRotation = yQuat;
        this.transform.localRotation = xQuat;
    }

    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.A))
            rb.AddRelativeForce(Vector3.left * speed);

        if (Input.GetKey(KeyCode.D))
            rb.AddRelativeForce(Vector3.right * speed);

        if (Input.GetKey(KeyCode.W))
            rb.AddRelativeForce(Vector3.forward * speed);

        if (Input.GetKey(KeyCode.S))
            rb.AddRelativeForce(Vector3.back * speed);
    }

    void Shoot()
    {
        
    }
}
