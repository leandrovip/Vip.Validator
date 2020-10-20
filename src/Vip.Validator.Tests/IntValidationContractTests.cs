using Vip.Validator.Validations;
using Xunit;

namespace Vip.Validator.Tests
{
    public class IntContractTests
    {
        [Fact]
        public void IsBetweenInt()
        {
            var value = 11;
            var from = 1;
            var to = 10;

            var wrong = new Contract()
                .Requires()
                .IsBetween(value, from, to, "int", "The value 11 must be between 1 and 10");

            Assert.False(wrong.Valid);
            Assert.Equal(1, wrong.Notifications.Count);

            value = 5;
            from = 1;
            to = 10;

            var right = new Contract()
                .Requires()
                .IsBetween(5, 1, 10, "int", "The value 5 is between 1 and 10");

            Assert.True(right.Valid);
        }
    }
}