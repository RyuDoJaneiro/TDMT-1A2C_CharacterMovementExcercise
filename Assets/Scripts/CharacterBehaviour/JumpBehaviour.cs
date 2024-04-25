using System;
using UnityEngine;

namespace Movement.Jump
{
    public class JumpBehaviour : MonoBehaviour
    {
        [SerializeField] private CharacterBody body;
        [SerializeField] private bool enableLog = true;

        [Header("Jump Settings")]
        [SerializeField] private float force = 10; 
        [SerializeField] private int maxQty = 2; 
        [SerializeField] private float floorAngle = 30; 

        public int CurrentJumpQty { get; private set; } = 0;

        public event Action OnJump = delegate { };
        public event Action OnLand = delegate { };

        private void Reset()
        {
            body = GetComponent<CharacterBody>();
        }

        public bool TryJump()
        {
            if (CurrentJumpQty >= maxQty)
            {
                return false;
            }

            if (enableLog)
                Debug.Log($"{name}: jumped!");
            CurrentJumpQty++;
            body.RequestImpulse(new ImpulseRequest(Vector3.up, force));
            OnJump.Invoke();
            return true;
        }

        private void OnCollisionEnter(Collision collision)
        {
            var contact = collision.contacts[0];
            var contactAngle = Vector3.Angle(contact.normal, Vector3.up);
            if (contactAngle <= floorAngle)
            {
                CurrentJumpQty = 0;
                if (enableLog)
                    Debug.Log($"{name}: jump count reset!");
                OnLand.Invoke();
            }

            if (enableLog)
                Debug.Log($"{name}: Collided with normal angle: {contactAngle}");
        }
    }
}