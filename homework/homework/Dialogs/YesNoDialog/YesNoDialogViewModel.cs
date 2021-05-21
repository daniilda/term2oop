namespace _2Term_OOP_Lab5
{
    public class YesNoDialogViewModel : DialogViewModelBase<DialogResult>
    {
        private static IDialogWindow wnd;
        
        private Controller _yesCommand;
        public Controller YesCommand
        {
            get
            {
                return _yesCommand ??
                       (_yesCommand = new Controller(obj =>
                       {
                           IDialogWindow wnd = obj as IDialogWindow;
                           Yes(wnd);
                       }));
            }
        }
        
        private Controller _noCommand;
        public Controller NoCommand
        {
            get
            {
                return _noCommand ??
                       (_noCommand = new Controller(obj =>
                       {
                           IDialogWindow wnd = obj as IDialogWindow;
                           No(wnd);
                       }));
            }
        }

        private void Yes(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResult.Yes);
        }

        private void No(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResult.No);
        }

        public YesNoDialogViewModel(string title, string message) : base(title, message)
        {
            
        }
    }
}