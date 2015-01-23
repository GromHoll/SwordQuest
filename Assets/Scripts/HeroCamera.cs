using UnityEngine;

public class HeroCamera : MonoBehaviour {

    public float rotateSpeed = 4.0f;
    public float moveSpeed = 4.0f;

    private bool firstMovementPartFinished  = true;
    private bool rotateMovementPartFinished = true;
    private bool secondMovementPartFinished = true;

    private Vector3 moveTarget;
    private float rotationTarget;
    
    void Update() {
        if (!firstMovementPartFinished) {
            firstMovementPartFinished = !Move();
            if (firstMovementPartFinished) {
                rotationTarget = 90;
            }
        } else if (!rotateMovementPartFinished) {
            rotateMovementPartFinished = !Rotate();
            if (rotateMovementPartFinished) {
                moveTarget = new Vector3(0, 0, 4);
            }
        } else if (!secondMovementPartFinished) {
            secondMovementPartFinished = !Move();
        }
    }

    private bool Move() {
        if (moveTarget == Vector3.zero) { return false; }

        var norm = Vector3.Normalize(moveTarget);
        var movement = norm * moveSpeed * Time.deltaTime;

        transform.Translate(movement);
        moveTarget -= movement;

        if (moveTarget.sqrMagnitude < 0.01) {
            transform.Translate(moveTarget);
            moveTarget = Vector3.zero;
        }

        return true; 
    }

    private bool Rotate() {
        if (rotationTarget == 0) { return false; }

        var rotation = rotationTarget * rotateSpeed * Time.deltaTime;
        transform.RotateAround(transform.position, Vector3.up, -rotation);
        rotationTarget -= rotation;

        if (rotationTarget < 0.1) {
            transform.RotateAround(transform.position, Vector3.up, rotationTarget);
            rotationTarget = 0;
        }

        return true;
    }
    
    public void MoveToNextPoint() {
        firstMovementPartFinished  = false;
        rotateMovementPartFinished = false;
        secondMovementPartFinished = false;
        moveTarget = new Vector3(0, 0, 4);
    }

    public bool IsStop() {
        return firstMovementPartFinished && rotateMovementPartFinished && secondMovementPartFinished;
    }

}






/* 
var target : Transform;
var distance = 3.0;
var height = 3.0;
var damping = 5.0;
var smoothRotation = true;
var rotationDamping = 10.0;
 
function Update ()  {    
    var wantedPosition = target.TransformPoint(0, height, -distance);
    transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);
 
    if (smoothRotation) {
        var wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
        transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
    }
 
    else transform.LookAt (target, target.up);
} 
*/