using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BasicCommandPattern
{
    public class MoveCommand : Command
    {
        Vector3 Target;
        Vector3 CurrentPos;
        Vector3 PreviousPos;
        Rigidbody Rigid;
        public MoveCommand(Vector3 Target, Vector3 CurrentPos, GameObject Unit, UnityAction ExecFinishedCallback = null) : base(Unit, ExecFinishedCallback)
        {
            this.Target = Target;
            this.CurrentPos = CurrentPos;
            PreviousPos = Vector3.zero;
            Rigid = Unit.GetComponent<Rigidbody>();
        }

        public override void ExecutionWork()
        {
            GoToPos(Target);
            PreviousPos = CurrentPos;
            CurrentPos = Target;
            Target = Vector3.zero;
        }

        private void GoToPos(Vector3 target)
        {
            Rigid.MovePosition(target);
        }
    }
}
