using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithViewModelLocator
{
    public class NotificationModel
    {
        public ActionType ActionType { get; set; }
        public string Message { get; set; }
    }

    public enum ActionType
    {
        Created,
        Deleted,
        Updated
    }
}
