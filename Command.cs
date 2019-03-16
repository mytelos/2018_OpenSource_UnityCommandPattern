using UnityEngine;
using UnityEngine.Events;

namespace BasicCommandPattern
{
    public abstract class Command
    {
        public GameObject Unit;
        public Command(GameObject Unit, UnityAction ExecFinishedCallback = null)
        {
            this.Unit = Unit;
            if (ExecFinishedCallback != null)
            {
                MyExecutionFinished.AddListener(ExecFinishedCallback);
            }
        }
        //public delegate void ExecutionFinished();
        public UnityEvent MyExecutionFinished;
        private void OnExecutionFinished()
        {
            if (MyExecutionFinished != null)
            {
                MyExecutionFinished.Invoke();
            }
        }

        public abstract void ExecutionWork();

        public void Execute()
        {
            ExecutionWork();
            OnExecutionFinished();
        }
    }
}
