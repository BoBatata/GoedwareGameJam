using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;

    [Header("Movement Variables")]
    [SerializeField] private int speed;
    public Vector2 _moveDir;
    private Vector3 _currentMoveDir;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // private void RotateHanlder()
    // {
    //     Vector3 positionToLookAt = Camera.main.transform.rotation * Vector3.forward;
    //
    //     // positionToLookAt.x = currentMovement.x;
    //     // positionToLookAt.y = 0.0f;
    //     // positionToLookAt.z = currentMovement.z;
    //
    //     Quaternion currentRotation = transform.rotation;
    //     Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
    //     transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, 10 * Time.deltaTime);
    // }


    public void WalkHandler(Vector3 direction)
    {
        _moveDir = direction;

        _currentMoveDir.x = _moveDir.x;
        _currentMoveDir.y = _rb.linearVelocity.y;
        _currentMoveDir.z = _moveDir.y;
        
        Vector3 cameraRelativeDir = ConvertMoveDirectionToCameraSpace(_moveDir);

        _rb.linearVelocity = new Vector3(cameraRelativeDir.x * speed, _currentMoveDir.y, cameraRelativeDir.z * speed);
    }
    
    private Vector3 ConvertMoveDirectionToCameraSpace(Vector3 directionMove)
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;
        
        Vector3 cameraMove = (cameraForward * directionMove.y + cameraRight * directionMove.x).normalized;

        return cameraMove;
    }
}
