using UnityEngine;
using UnityEngine.Events;
//Created by Mesutcan Goksoy
//contact: mgksoy@gmail.com
namespace BasicCommandPattern
{
    public abstract class Command
    {
        public GameObject _unit;
        public Command(GameObject Unit, UnityAction ExecFinishedCallback = null)
        {
            this._unit = Unit;
            if (ExecFinishedCallback != null)
            {
                if (MyExecutionFinished == null)
                    MyExecutionFinished = new CommandEvent();
                MyExecutionFinished.AddListener(ExecFinishedCallback);
            }
        }

        public CommandEvent MyExecutionFinished;
        private void OnExecutionFinished()
        {
            if (MyExecutionFinished != null)
            {
                MyExecutionFinished.Invoke();
            }
        }

        protected abstract void ExecutionWork();

        public void Execute()
        {
            ExecutionWork();
            OnExecutionFinished();
        }

        protected abstract void UndoExecution();
    }

    public class CommandEvent : UnityEvent
    {

    }
}
