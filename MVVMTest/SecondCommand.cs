using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMTest
{
    class SecondCommand : ICommand
    {
        public TestViewModel ViewModel { get; set; }

        public SecondCommand(TestViewModel model)
        {
            this.ViewModel = model;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                string s = parameter as string;
                if (!String.IsNullOrEmpty(s)) ViewModel.SetText(s);
            }
        }
    }
}
