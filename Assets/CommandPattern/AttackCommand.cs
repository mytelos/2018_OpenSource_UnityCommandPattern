using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;

namespace BasicCommandPattern
{
    public class AttackCommand : Command
    {        
        private int _targetHP;
        private int _previousHP;
        private int _damage;
        public Animator _animator;
        public int _controllerLayer;
        public int _stateHash;

        public AttackCommand(ref int TargetHP, int Damage, int StateHash, int ControllerLayer, GameObject Unit, UnityAction ExecFinishedCallback) : base(Unit, ExecFinishedCallback)
        {
            _targetHP = TargetHP;
            _previousHP = _targetHP;
            _damage = Damage;
            _animator = Unit.GetComponent<Animator>();
            this._controllerLayer = ControllerLayer;
            this._stateHash = StateHash;
        }

        protected override void ExecutionWork()
        {
            _previousHP = _targetHP;
            _targetHP -= _damage;
            _animator.Play(_stateHash, _controllerLayer);
        }

        protected override void UndoExecution()
        {
            _targetHP = _previousHP;
        }
    }
}
