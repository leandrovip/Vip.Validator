using Vip.Validator.Validations;
using Xunit;

namespace Vip.Validator.Tests
{
    public class FloatContractTests
    {
        [Fact]
        public void IsBetweenFloat()
        {
            float value = -15;
            var from = -1.000F;
            var to = 1.999F;

            var wrong = new Contract()
                .Requires()
                .IsBetween(value, from, to, "float", "The value -15 must be between -1.000 and 1.999");

            Assert.False(wrong.Valid);
            Assert.Equal(1, wrong.Notifications.Count);

            value = 0;
            from = float.MinValue;
            to = float.MaxValue;

            var right = new Contract()
                .Requires()
                .IsBetween(value, from, to, "float", $"The value 0 is between {from} and {to}");

            Assert.True(right.Valid);
        }
    }
}