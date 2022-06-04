using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class MoveNode : Unit
{
    [DoNotSerialize]
    private ControlInput _controlInput;
    [DoNotSerialize]
    private ControlOutput _controlOutput;

    [DoNotSerialize]
    private ValueInput _moveSpeedInput;
    [DoNotSerialize]
    private ValueInput _rigidbody2DInput;
    [DoNotSerialize]
    private ValueInput _directionInput;

    private float _moveSpeed;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;

    protected override void Definition()
    {
        _controlInput = ControlInput("", flow =>
        {
            ExecuteDefinition(flow);
            return _controlOutput;
        });

        _moveSpeedInput = ValueInput<float>("Move Speed", 0f);
        _rigidbody2DInput = ValueInput<Rigidbody2D>("Rigidbody2D");
        _directionInput = ValueInput<Vector2>("Direction", Vector2.right);

        _controlOutput = ControlOutput("");
    }

    private void ExecuteDefinition(Flow flow)
    {
        _moveSpeed = flow.GetValue<float>(_moveSpeedInput);
        _rigidbody2D = flow.GetValue<Rigidbody2D>(_rigidbody2DInput);
        _direction = flow.GetValue<Vector2>(_directionInput);

        ApplyMovement();
    }

    private void ApplyMovement() => _rigidbody2D.position += _direction * _moveSpeed;
}
