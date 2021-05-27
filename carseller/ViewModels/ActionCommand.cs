﻿using System;
using System.Windows.Input;

namespace carseller.ViewModels
{
    public class ActionCommand<T> : ICommand
    {
        Action<T> action;
        public ActionCommand(Action<T> action)
        {
            this.action = action;
        }
        public bool CanExecute(object parameter) => true;

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter) => action((T)parameter);
    }

    public class ActionCommand : ICommand
    {
        Action action;
        public ActionCommand(Action action)
        {
            this.action = action;
        }
        public bool CanExecute(object parameter) => true;

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter) => action();
    }
}
