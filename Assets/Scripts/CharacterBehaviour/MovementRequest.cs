using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public readonly struct MovementRequest
    {
        public readonly Vector3 Direction;

        public readonly float Acceleration;

        public readonly float GoalSpeed;

        public static MovementRequest InvalidRequest => new(Vector3.zero, 0, 0);

        public MovementRequest(Vector3 direction, float goalSpeed, float acceleration)
        {
            Direction = direction;
            GoalSpeed = goalSpeed;
            Acceleration = acceleration;
        }

        public Vector3 GetGoalVelocity() => Direction * GoalSpeed;
        public Vector3 GetAccelerationVector() => Direction * Acceleration;

        public bool IsValid() => Direction != Vector3.zero && Acceleration != 0f && GoalSpeed != 0f;
    }
}
