using System.Collections.Generic;
using System.Linq;

namespace Vip.Validator.Notifications
{
    public abstract class Notifiable
    {
        #region Fields

        private readonly List<Notification> _notifications;

        #endregion

        #region Properties

        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public bool Invalid => _notifications.Any();
        public bool Valid => !Invalid;

        #endregion

        #region Constructors

        protected Notifiable()
        {
            _notifications = new List<Notification>();
        }

        #endregion

        #region Methods

        public void AddNotification(string property, string message)
        {
            _notifications.Add(new Notification(property, message));
        }

        public void AddNotification(Notification notification)
        {
            if (notification == null) return;
            _notifications.Add(notification);
        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            if (notifications == null) return;
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<Notification> notifications)
        {
            if (notifications == null) return;
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<Notification> notifications)
        {
            if (notifications == null) return;
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(Notifiable item)
        {
            AddNotifications(item.Notifications);
        }

        public void AddNotifications(params Notifiable[] items)
        {
            foreach (var item in items) AddNotifications(item);
        }

        public void Clear()
        {
            _notifications.Clear();
        }

        #endregion
    }
}