using UnityEngine;

namespace PizzaMaker.Code.Core
{
    public class CharacterMovement : MonoBehaviour, ICharacterMovement
    {
        [SerializeField] private SideMovement _sideMovement;
        [SerializeField] private PathFollower _pathFollower;

        public float PathProgress => _pathFollower?.PathProgress ?? 0;
        
        private void Start()
        {
            Disable();
        }

        public void Enable()
        {
            _sideMovement.enabled = true;
            _pathFollower.enabled = true;
        }
        
        public void Disable()
        {
            _sideMovement.enabled = false;
            _pathFollower.enabled = false;
        }
    }

    public interface ICharacterMovement
    {
        float PathProgress { get; }
        void Enable();
        void Disable();
    }
}