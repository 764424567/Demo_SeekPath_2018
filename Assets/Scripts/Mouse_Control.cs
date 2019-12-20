using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Control : MonoBehaviour
{
    public float xRoatationSpeed = 250.0f;
    public float yRoatationSpeed = 120.0f;

    public float moveSpeed = 800f;

    public float yRoatationMinLimit = -90f;
    public float yRoatationMaxLimit = 90f;

    public float ScaleSpeed = 300;

    public float KeyboardMoveSpeed = 10;
    public float DefaultKeyboardMoveSpeed = 10;
    public float KeyboardMoveAcceleratedSpeed = 3;

    public float MaxMoveDistance = 5000f;

    private KeyCode _forwardKey = KeyCode.W;

    public KeyCode ForwardKey
    {
        get { return _forwardKey; }
        set { _forwardKey = value; }
    }

    private KeyCode _backKey = KeyCode.S;

    public KeyCode BackKey
    {
        get { return _backKey; }
        set { _backKey = value; }
    }

    private KeyCode _leftKey = KeyCode.A;

    public KeyCode LeftKey
    {
        get { return _leftKey; }
        set { _leftKey = value; }
    }

    private KeyCode _rightKey = KeyCode.D;

    public KeyCode RightKey
    {
        get { return _rightKey; }
        set { _rightKey = value; }
    }
    private void Update()
    {
        //Vector3 intos = gameObject.transform.position;
        //if (intos.y < -5600)
        //{
        //    moveSpeed = 80f;
        //    ScaleSpeed = 30f;
        //}
        //else if (intos.y > -5600)
        //{
        //    moveSpeed = 800f;
        //    ScaleSpeed = 3000f;
        //}
    }

    void Awake()
    {

    }

    void Start()
    {
    }

    void LateUpdate()
    {
        Vector3 oldPos = this.transform.position;

        //鼠标左键
        if (Input.GetMouseButton(0))
        {
            var position = transform.position;
            position += transform.TransformDirection(Vector3.left).normalized * (Input.GetAxis("Mouse X") * moveSpeed * 0.02f);
            position += transform.TransformDirection(Vector3.down).normalized * (Input.GetAxis("Mouse Y") * moveSpeed * 0.02f);

            movePosition(position);
        }

        //鼠标右键
        if (Input.GetMouseButton(1))
        {
            float x = 0;
            float y = 0;

            x += Input.GetAxis("Mouse X") * xRoatationSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * yRoatationSpeed * 0.02f;

            y = ClampAngle(y, yRoatationMinLimit, yRoatationMaxLimit);

            transform.Rotate(y, x, 0);

            var angles = transform.eulerAngles;
            angles.z = 0;

            transform.eulerAngles = angles;
        }

        //鼠标滑轮
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            var moveDistance = Input.GetAxis("Mouse ScrollWheel") * ScaleSpeed;

            var position = transform.position;
            position += transform.TransformDirection(Vector3.forward).normalized * moveDistance;

            movePosition(position);
        }

        if (Input.GetKey(ForwardKey))
        {
            var position = transform.position;
            position += transform.TransformDirection(Vector3.forward).normalized * KeyboardMoveSpeed * 0.02f;

            movePosition(position);
        }

        if (Input.GetKey(BackKey))
        {
            var position = transform.position;
            position += transform.TransformDirection(Vector3.back).normalized * KeyboardMoveSpeed * 0.02f;

            movePosition(position);
        }

        if (Input.GetKey(LeftKey))
        {
            var position = transform.position;
            position += transform.TransformDirection(Vector3.left).normalized * KeyboardMoveSpeed * 0.02f;

            movePosition(position);
        }

        if (Input.GetKey(RightKey))
        {
            var position = transform.position;
            position += transform.TransformDirection(Vector3.right).normalized * KeyboardMoveSpeed * 0.02f;

            movePosition(position);
        }

        if (Input.GetKey(ForwardKey) || Input.GetKey(BackKey) || Input.GetKey(LeftKey) || Input.GetKey(RightKey))
        {
            KeyboardMoveSpeed += KeyboardMoveAcceleratedSpeed * 0.02f;
        }
        else
        {
            KeyboardMoveSpeed = DefaultKeyboardMoveSpeed;
        }

        if (Vector3.Distance(transform.position, Vector3.zero) > MaxMoveDistance)
        {
            movePosition(oldPos + oldPos.normalized * -100);
        }
    }

    void movePosition(Vector3 moveToPosition)
    {
        if (transform.GetComponent<Rigidbody>())
        {
            if (!Physics.Raycast(transform.position, moveToPosition - transform.position, (moveToPosition - transform.position).magnitude))
            {
                transform.GetComponent<Rigidbody>().MovePosition(moveToPosition);
            }
        }
    }

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
