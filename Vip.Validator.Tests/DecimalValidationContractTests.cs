using Vip.Validator.Validations;
using Xunit;

namespace Vip.Validator.Tests
{
    public class DecimalContractTests
    {
        [Fact]
        public void IsGreaterThanDecimal()
        {
            const decimal v1 = 5;
            const decimal v2 = 10;
            var wrong = new Contract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2")
                .IsGreaterThan(1, 1M, "decimal", "V1 is not greater than v2");

            Assert.False(wrong.Valid);
            Assert.Equal(2, wrong.Notifications.Count);

            var right = new Contract()
                .Requires()
                .IsGreaterThan(v2, v1, "decimal", "V1 is not greater than v2");

            Assert.True(right.Valid);
        }

        [Fact]
        public void IsGreaterThanDouble()
        {
            double v1 = 5;
            decimal v2 = 10;
            var wrong = new Contract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2");

            Assert.False(wrong.Valid);
            Assert.Equal(1, wrong.Notifications.Count);

            v1 = 10;
            v2 = 5;
            var right = new Contract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2");

            Assert.True(right.Valid);
        }

        [Fact]
        public void IsGreaterThanFloat()
        {
            float v1 = 5;
            decimal v2 = 10;
            var wrong = new Contract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2");

            Assert.False(wrong.Valid);
            Assert.Equal(1, wrong.Notifications.Count);

            v1 = 10;
            v2 = 5;
            var right = new Contract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2");

            Assert.True(right.Valid);
        }

        [Fact]
        public void IsGreaterThanInt()
        {
            const int v1 = 5;
            const decimal v2 = 10;
            var wrong = new Contract()
                .Requires()
                .IsGreaterThan(v1, v2, "decimal", "V1 is not greater than v2");

            Assert.False(wrong.Valid);
            Assert.Equal(1, wrong.Notifications.Count);

            var right = new Contract()
                .Requires()
                .IsGreaterThan(v2, v1, "decimal", "V1 is not greater than v2");

            Assert.True(right.Valid);
        }

        [Fact]
        public void IsBetweenDecimal()
        {
            var value = -1.01M;
            var from = 1.01M;
            decimal to = 10;

            var wrong = new Contract()
                .Requires()
                .IsBetween(value, from, to, "decimal", "The value -1.01 must be between 1.01 and 10");

            Assert.False(wrong.Valid);
            Assert.Equal(1, wrong.Notifications.Count);

            value = 1.015M;
            from = 1.01M;
            to = 1.02M;

            var right = new Contract()
                .Requires()
                .IsBetween(value, from, to, "decimal", "The value 1.015 is between 1.01 and 1.02");

            Assert.True(right.Valid);
        }
    }
}