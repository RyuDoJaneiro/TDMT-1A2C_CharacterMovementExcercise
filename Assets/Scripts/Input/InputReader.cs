using UnityEngine;
using UnityEngine.InputSystem;
using System;

namespace Inputs
{
    public class InputReader : MonoBehaviour
    {
        public event Action<Vector2> OnMovement = delegate { };
        public event Action OnJump = delegate { };
        public event Action OnRun = delegate { };

        public void OnCharacterMovement(InputAction.CallbackContext context)
        {
            OnMovement?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnCharacterJump(InputAction.CallbackContext context)
        {
            if (context.started)
                OnJump?.Invoke();
        }

        public void OnCharacterRun(InputAction.CallbackContext context)
        {
            if (context.performed)
                OnRun?.Invoke();
        }
    }
}
