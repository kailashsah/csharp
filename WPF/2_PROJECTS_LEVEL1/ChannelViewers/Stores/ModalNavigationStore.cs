using ChannelViewers.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelViewers.Stores
{
    public class ModalNavigationStore
    {
        private ViewModelBase _currentVM;
        public bool IsOpen => _currentVM != null;
        public event Action SelectionChanged;        
        
        public ViewModelBase CurrentVM
        {
            get { return _currentVM; }
            set { _currentVM = value;

                SelectionChanged?.Invoke();
            }
        }
        public void Close()
        {
            CurrentVM = null;
        }
    }
}
