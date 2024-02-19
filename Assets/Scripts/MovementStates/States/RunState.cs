using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MovementBaseState
{
    // Start is called before the first frame update
    public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("Running", true);
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift)) ExitState(movement, movement.walk);
        else if(movement.dir.magnitude <0.1f) ExitState(movement, movement.idle);

        if (movement.vInput < 0) movement.currentMovementSpeed = movement.runBackSpeed;
        else movement.currentMovementSpeed = movement.runSpeed;
    }

    public void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Running", false);
        movement.SwitchState(state);
    }
}
