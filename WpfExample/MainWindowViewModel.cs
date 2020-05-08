using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace WpfExample
{
    class MainWindowViewModel
    {
     

        private ICommand hiButtonCommand;
        private ICommand hiTextCommand;
        private ICommand toggleExecuteCommand
        { get; set; }
        private bool canExecute = true;
        public string HiButtonContent
        {
            get { return "click to hi"; }
        }
        public string HiTextContent
        {
            get { return "text"; }
        }
        public bool CanExecute
        {
            get { return this.canExecute; }
            set
            {
                if (this.canExecute == value)
                { return; }
                this.canExecute = value;
            }
        }
        public ICommand ToggleExecuteCommand
        {
            get
            { return toggleExecuteCommand; }
            set
            { toggleExecuteCommand = value; }
        }
        public ICommand HiButtonCommand
        {
            get
            { return hiButtonCommand; }
            set
            { hiButtonCommand = value; }
        }
        public MainWindowViewModel()
        {
            HiButtonCommand = new RelayCommand(ShowMessage, param => this.canExecute);
            toggleExecuteCommand = new RelayCommand(ChangeCanExecute);
        }
        public void ShowMessage(object obj)
        {
            //it is good we do this with binding to some control

            System.Windows.MessageBox.Show(obj.ToString());
        }
        public void ChangeCanExecute(object obj)
        {
            canExecute = !canExecute;
        }
        /* public string ButtonContent
      {
          get
          {
              return "Click Me";
          }
      }*/
    }
}
