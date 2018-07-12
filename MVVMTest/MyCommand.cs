using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MVVMTest
{
    public class MyCommand : ICommand

    {
        public TestViewModel TestViewModel { get; set; }

        public MyCommand(TestViewModel testViewModel)
        {
            this.TestViewModel = testViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBoxResult messageBox = MessageBox.Show(parameter.ToString(), "TEST", MessageBoxButton.OK);
            TestViewModel.Increment();
        }
    }
}
