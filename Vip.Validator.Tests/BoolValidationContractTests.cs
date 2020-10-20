using Vip.Validator.Validations;
using Xunit;

namespace Vip.Validator.Tests
{
    public class BoolContractTests
    {
        [Fact]
        public void IsTrue()
        {
            var wrong = new Contract()
                .Requires()
                .IsTrue(false, "bool", "Bool is false");

            Assert.False(wrong.Valid);
            Assert.Equal(1, wrong.Notifications.Count);

            var right = new Contract()
                .Requires()
                .IsTrue(true, "bool", "Bool is false");

            Assert.True(right.Valid);
        }

        [Fact]
        public void IsFalse()
        {
            var wrong = new Contract()
                .Requires()
                .IsFalse(true, "bool", "Bool is true");

            Assert.False(wrong.Valid);
            Assert.Equal(1, wrong.Notifications.Count);

            var right = new Contract()
                .Requires()
                .IsFalse(false, "bool", "Bool is true");

            Assert.True(right.Valid);
        }
    }
}