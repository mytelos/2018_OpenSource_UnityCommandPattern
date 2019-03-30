using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//Created by Mesutcan Goksoy
//contact: mgksoy@gmail.com
namespace BasicCommandPattern
{
    public class MoveCommand : Command
    {
        Vector3 _target;
        Vector3 _currentPos;
        Vector3 _previousPos;
        Rigidbody _rigid;
        Transform _transform;
        public MoveCommand(Vector3 Target, Vector3 CurrentPos, GameObject Unit, UnityAction ExecFinishedCallback = null) : base(Unit, ExecFinishedCallback)
        {
            this._target = Target;
            this._currentPos = CurrentPos;
            _previousPos = CurrentPos;
            _previousPos = Vector3.zero;
            _rigid = Unit.GetComponent<Rigidbody>();
            _transform = Unit.transform;
        }

        protected override void ExecutionWork()
        {
            GoToPos(_target);
            _previousPos = _currentPos;
            _currentPos = _target;
            _target = Vector3.zero;
        }

        private void GoToPos(Vector3 target)
        {
            _rigid.MovePosition(target);
        }

        protected override void UndoExecution()
        {
            _transform.position = _previousPos;
            _currentPos = _previousPos;
        }
    }
}
