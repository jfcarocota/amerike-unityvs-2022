using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMovementInputController : MonoBehaviour
{
    public Vector2 Direction => GameManager.Instance.GameMode.InputsManager.GameInputs.Gameplay.Direction.ReadValue<Vector2>();
    public Vector2 DirectionNormalized => Direction.normalized;
    public Vector3 Direction3D => new Vector3(Direction.x, 0f, Direction.y);
}
