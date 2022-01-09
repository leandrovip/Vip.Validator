using System.Collections.Generic;
using Vip.Validator.Notifications;
using Xunit;

namespace Vip.Validator.Tests
{
    public class NotifiableTests : Notifiable
    {
        [Fact]
        public void AddNotificationForOneNotifiable()
        {
            var name = new Name();
            var cus = new Customer();

            AddNotifications(name);
            AddNotifications(cus);

            Assert.False(Valid);
            Assert.Equal(2, Notifications.Count);
        }

        [Fact]
        public void AddNotificationForMultipleNotifiable()
        {
            var name = new Name();
            var customer = new Customer();

            AddNotifications(name, customer);

            Assert.False(Valid);
            Assert.Equal(2, Notifications.Count);
        }

        [Fact]
        public void AddNotificationsValid()
        {
            // Act
            AddNotifications((IReadOnlyCollection<Notification>) null);

            // Assert
            Assert.Equal(0, Notifications.Count);
        }
    }

    public class Customer : Notifiable
    {
        public Customer()
        {
            AddNotification("Test", "Testing");
        }

        public Name Name { get; set; }
    }

    public class Name : Notifiable
    {
        public Name()
        {
            AddNotification("Test", "Testing");
        }

        public string FirstName { get; set; }
    }
}