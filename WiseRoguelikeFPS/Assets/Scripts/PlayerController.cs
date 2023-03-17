using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 12f;
    public float sensitivity = 400f;
    private float cameraVerticalRotation;

    public Transform myCameraHead;
    public CharacterController myCharacterController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;

        cameraVerticalRotation -= mouseY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90, 90);

        transform.Rotate(Vector3.up * mouseX);
        myCameraHead.localRotation = Quaternion.Euler(cameraVerticalRotation, 0f, 0f);
    }

    private void PlayerMove()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = x * transform.right + z *transform.forward;

        movement *= speed * Time.deltaTime;

        myCharacterController.Move(movement);
    }
}
