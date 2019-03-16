using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;

namespace BasicCommandPattern
{
    public class AttackCommand : Command
    {
        private int _TargetHP;
        private int _Damage;
        public Animator Animator;
        public int ControllerLayer;
        public int StateHash;

        public AttackCommand(ref int TargetHP, int Damage, int StateHash, int ControllerLayer, GameObject Unit, UnityAction ExecFinishedCallback) : base(Unit, ExecFinishedCallback)
        {
            Debug.Log("TargetHP HashCode as ref Constructor Param: " + TargetHP.GetHashCode());
            _TargetHP = TargetHP;
            Debug.Log("_TargetHP HashCode as a global Param: " + TargetHP.GetHashCode());
            _Damage = Damage;
            Animator = Unit.GetComponent<Animator>();
            this.ControllerLayer = ControllerLayer;
            this.StateHash = StateHash;
        }

        public override void ExecutionWork()
        {
            _TargetHP -= _Damage;
            Animator.Play(StateHash, ControllerLayer);
        }
    }
}
