using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregatorSample
{
    #region Created
    public delegate void UserCreatedEvent(UserCreatedEventArgs args);

    public class UserCreatedEventArgs : PubSubEventArgs<UserModel> { }
    #endregion

    #region Removed

    public delegate void UserRemovedEvent(UserRemovedEventArgs args);

    public class UserRemovedEventArgs : PubSubEventArgs<UserModel> { }
    #endregion

    #region Updated

    public delegate void UserUpdatedEvent(UserUpdatedEventArgs args);

    public class UserUpdatedEventArgs : PubSubEventArgs<UserModel> { }
    #endregion

}
