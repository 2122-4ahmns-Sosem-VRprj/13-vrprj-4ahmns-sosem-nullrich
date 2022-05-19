using UnityEngine;

public class ClawController : MonoBehaviour
{
    public enum Axis {x,y,z}

    public Transform target;
    [Range(0.1f, 2f)]
    public float speed = 0.5f;
    [Range(0.1f, 2f)]
    public float deadZone = 0.2f;
    public Vector2 movementRange;
    public float height;
    public Axis rotationAxis;


    private Vector3 startPos;

    private void Start()
    {
        startPos = target.position;
    }

    private void Update()
    {
        switch (rotationAxis)
        {
            case Axis.x:
                Move(transform.localRotation.x);
                break;
            case Axis.z:
            case Axis.y:
                Move(transform.localRotation.z);
                break;
        }
    }

    private void Move(float rotation)
    { 
        if (rotation > -(deadZone / 2) && rotation < deadZone / 2) return;

        var fac = speed;
        if (rotation < 0f) fac = -fac;

        switch (rotationAxis)
        {
            case Axis.x:
                if(IsNotAtHome()) return;
                target.position = new Vector3(target.position.x, target.position.y, Mathf.Clamp(target.position.z + (fac * Time.deltaTime), startPos.z -movementRange.x, startPos.z + movementRange.y));
                break;
            case Axis.z:
                if (IsNotAtHome()) return;
                target.position = new Vector3(Mathf.Clamp(target.position.x - (fac * Time.deltaTime), startPos.x - movementRange.x, startPos.x + movementRange.y), target.position.y, target.position.z);
                break;
            case Axis.y:
                target.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y + (fac * Time.deltaTime), startPos.y - height, startPos.y), target.position.z);
                break;
        }
    }
    private bool IsNotAtHome()
    {
        return startPos.y != target.position.y;
    }
}
