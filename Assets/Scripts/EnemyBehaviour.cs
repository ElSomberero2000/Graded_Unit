using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{

    public float moveSpeed = 6;

    Rigidbody rigidbody;
    Camera viewCamera;
    Vector3 velocity;

    // FOR FIELD OF VIEW!!! //
    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
    //......................//

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        transform.LookAt(mousePos + Vector3.up * transform.position.y);
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized * moveSpeed;
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
    }
}

