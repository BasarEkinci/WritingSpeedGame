using UnityEngine;

namespace Movement
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float offset;
        [SerializeField] private float smoothSpeed;
        
        private Vector3 _desiredPosition;
        private void LateUpdate()
        {
            _desiredPosition = new Vector3(transform.position.x,transform.position.y,target.position.z + offset);
            transform.position = Vector3.Lerp(transform.position, _desiredPosition, smoothSpeed);
        }
    }
}
