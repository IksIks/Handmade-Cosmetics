namespace HandmadeСosmetics.Command
{
    internal class LambdaCommand : CommandBase
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public LambdaCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return canExecute?.Invoke(parameter) ?? true;
        }

        public override void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}