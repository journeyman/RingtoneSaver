using System;
using System.Windows.Input;

namespace RingtoneSaver.Commands
{
    public abstract class CommandBase
    {
        private bool isExecuting;
        protected bool IsExecuting
        {
            get { return this.isExecuting; }
            set
            {
                if (value != this.isExecuting)
                {
                    this.isExecuting = value;
                    RaiseCanExecuteChanged();
                }
            }
        }

        protected void RaiseCanExecuteChanged()
        {
            //Dispatch.ToUIIfNeeded(
            //    () =>
            //    {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, null);
            }
            //});
        }

        public event EventHandler CanExecuteChanged;

        public void Cancel()
        {
            this.IsExecuting = false;
        }
    }

    public abstract class CommandWithoutArgsBase : CommandBase, ICommand
    {
        public virtual bool CanExecute()
        {
            return !IsExecuting;
        }

        public abstract void Execute();

        bool ICommand.CanExecute(object parameter)
        {
            return this.CanExecute();
        }

        void ICommand.Execute(object parameter)
        {
            this.Execute();
        }

    }

    public abstract class CommandBase<T> : CommandBase, ICommand
    {
        public abstract void Execute(T arg);

        public virtual bool CanExecute(T arg)
        {
            return !IsExecuting;
        }

        void ICommand.Execute(object param)
        {
            this.Execute((T)param);
        }

        bool ICommand.CanExecute(object param)
        {
            return this.CanExecute((T)param);
        }
    }
}
