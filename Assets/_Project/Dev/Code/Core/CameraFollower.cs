using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothFactor = 0.1f;
    
    private Vector3 _velocity = Vector3.zero;

    private void Update()
    {
        Vector3 target = _target.position;
        float time = _smoothFactor * Time.deltaTime;
        Vector3 smoothed = Vector3.SmoothDamp(transform.position, target, ref _velocity, time);
        
        transform.position = smoothed;
    }
}