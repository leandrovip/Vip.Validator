using Vip.Validator.Validations;
using Xunit;

namespace Vip.Validator.Tests
{
    public class StringContractTests
    {
        [Fact]
        public void IsNotNullOrEmpty()
        {
            var wrong = new Contract()
                .Requires()
                .IsNotNullOrEmpty(null, "string", "String is Null")
                .IsNotNullOrEmpty("", "string", "String is Empty");

            Assert.False(wrong.Valid);
            Assert.Equal(2, wrong.Notifications.Count);

            var right = new Contract()
                .Requires()
                .IsNotNullOrEmpty("Some valid string", "string", "String is Null");

            Assert.True(right.Valid);
        }

        [Fact]
        public void IsNullOrEmpty()
        {
            var right = new Contract()
                .Requires()
                .IsNullOrEmpty(null, "string", "String is Null")
                .IsNullOrEmpty("", "string", "String is Empty");

            Assert.True(right.Valid);
            Assert.Equal(0, right.Notifications.Count);

            var wrong = new Contract()
                .Requires()
                .IsNullOrEmpty("Some valid string", "string", "String is Null");

            Assert.False(wrong.Valid);
        }

        [Fact]
        public void MinLen()
        {
            var wrong = new Contract()
                .Requires()
                .HasMinLen(true, "null", 5, "string", "String len is less than permited");

            Assert.False(wrong.Valid);
            Assert.Equal(1, wrong.Notifications.Count);

            var rightPredicate = new Contract()
                .Requires()
                .HasMinLen(false, "null", 5, "string", "String len is less than permited");

            Assert.True(rightPredicate.Valid);

            var right = new Contract()
                .Requires()
                .HasMinLen("Some Valid String", 5, "string", "String len is less than permited");

            Assert.True(right.Valid);
        }

        [Fact]
        public void MaxLen()
        {
            var wrong = new Contract()
                .Requires()
                .HasMaxLen(true, "null", 3, "string", "String len is more than permited");

            Assert.False(wrong.Valid);
            Assert.Equal(1, wrong.Notifications.Count);

            var rightPredicate = new Contract()
                .Requires()
                .HasMaxLen(false, "null", 3, "string", "String len is more than permited");

            Assert.True(rightPredicate.Valid);
            Assert.Equal(1, wrong.Notifications.Count);

            var right = new Contract()
                .Requires()
                .HasMaxLen("Some", 5, "string", "String len is less than permited");

            Assert.True(right.Valid);
        }

        [Fact]
        public void Len()
        {
            var x = new Contract()
                .Requires()
                .HasLen("null", 3, "string", "String len is more than permited");

            Assert.False(x.Valid);
            Assert.Equal(1, x.Notifications.Count);

            var right = new Contract()
                .Requires()
                .HasLen("Some1", 5, "string", "String len is less than permited");

            Assert.True(right.Valid);
        }

        [Fact]
        public void Contains()
        {
            var x = new Contract()
                .Requires()
                .Contains("some text here", "banana", "string", "String does not contains banana");

            Assert.False(x.Valid);
            Assert.Equal(1, x.Notifications.Count);

            var right = new Contract()
                .Requires()
                .Contains("some banana here", "banana", "string", "String does not contains banana");

            Assert.True(right.Valid);
        }

        [Fact]
        public void Email()
        {
            var wrong = new Contract()
                .Requires()
                .IsEmail("wrongemail", "string", "Invalid E-mail");

            Assert.False(wrong.Valid);
            Assert.Equal(1, wrong.Notifications.Count);

            var right = new Contract()
                .Requires()
                .IsEmail("email@gmail.com", "string", "Invalid E-mail");

            Assert.True(right.Valid);
        }

        [Fact]
        public void EmailOrEmpty()
        {
            var right = new Contract()
                .Requires()
                .IsEmailOrEmpty("", "string", "Invalid E-mail");

            Assert.True(right.Valid);
        }

        [Fact]
        public void Url()
        {
            var wrong = new Contract()
                .Requires()
                .IsUrl("wrongurl", "string", "Invalid URL");

            Assert.False(wrong.Valid);
            Assert.Equal(1, wrong.Notifications.Count);

            var right = new Contract()
                .Requires()
                .IsUrl("https://gmail.com", "string", "Valid URL")
                .IsUrl("http://gmail.com", "string", "Valid URL");

            Assert.True(right.Valid);
        }

        [Fact]
        public void UrlOrEmpty()
        {
            var right = new Contract()
                .Requires()
                .IsUrlOrEmpty("", "string", "Invalid URL");

            Assert.True(right.Valid);
        }

        [Fact]
        public void Match()
        {
            var wrong = new Contract()
                .Requires()
                .Matchs("wrongurl", @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$", "string", "Invalid URL");

            Assert.False(wrong.Valid);
            Assert.Equal(1, wrong.Notifications.Count);

            var right = new Contract()
                .Requires()
                .Matchs("http://gmail.com", @"^(http:\/\/www\.|https:\/\/www\.|http:\/\/|https:\/\/)[a-z0-9]+([\-\.]{1}[a-z0-9]+)*\.[a-z]{2,5}(:[0-9]{1,5})?(\/.*)?$", "string", "Invalid URL");

            Assert.True(right.Valid);
        }
    }
}