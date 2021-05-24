using System.Windows.Input;

namespace _2Term_OOP_Lab5
{
    public class AlertDialogViewModel : DialogViewModelBase<DialogResult>
    {
        private static IDialogWindow wnd;
        
        private Controller _okCommand;
        public Controller OKCommand
        {
            get
            {
                return _okCommand ??
                       (_okCommand = new Controller(obj =>
                       {
                           IDialogWindow wnd = obj as IDialogWindow;
                           OK(wnd);
                       }));
            }
        }

        private void OK(IDialogWindow window)
        {
            CloseDialogWithResult(window, DialogResult.Undefined);
        }

        public AlertDialogViewModel(string title, string message) : base(title, message)
        {
            
        }
        
    }
}