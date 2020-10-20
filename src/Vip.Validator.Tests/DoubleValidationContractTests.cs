using Vip.Validator.Validations;
using Xunit;

namespace Vip.Validator.Tests
{
    public class DoubleContractTests
    {
        [Fact]
        public void IsBetweenDouble()
        {
            var value = 49.999;
            var from = 50.000;
            var to = 59.999;

            var wrong = new Contract()
                .Requires()
                .IsBetween(value, from, to, "double", "The value 49.999 must be between 50.000 and 59.999");

            Assert.False(wrong.Valid);
            Assert.Equal(1, wrong.Notifications.Count);

            value = 1250.01;
            from = 1250.00;
            to = 1299.99;

            var right = new Contract()
                .Requires()
                .IsBetween(value, from, to, "double", "The value 1250.01 is between 1000.01 and 1299.99");

            Assert.True(right.Valid);
        }
    }
}