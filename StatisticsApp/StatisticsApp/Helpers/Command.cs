using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StatisticsApp.Helpers
{
    public class Command : ICommand
    {
        private Action execute;
        private Func<bool> canExecute;
        public Command(Action exec, Func<bool> canExec)
        {
            this.execute = exec;
            this.canExecute = canExec;
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null) return true;
            return canExecute();
        }
        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (execute != null) execute();
        }
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(null, new EventArgs());
        }
    }

    public class Command<T> : ICommand
    {
        private Action<T> execute;
        private Func<T,bool> canExecute;
        public Command(Action<T> exec, Func<T,bool> canExec)
        {
            this.execute = exec; this.canExecute = canExec;
        }
        public bool CanExecute(object parameter)
        {
            if (canExecute == null) return true;
            return canExecute((T)parameter);
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            if (execute != null) execute((T)parameter);
        }
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(null, new EventArgs());
        }
    }
}
