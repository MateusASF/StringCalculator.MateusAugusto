using FluentAssertions;
using StringCalculator.Domain;

namespace StringCalculator.UnitTests
{
    public class StringCalculatorUnitTests
    {
        [Fact]
        public void StringCalculator_EmptyString_ResultShouldBeZero()
        {
            var sut = new StringCalculators();
            var result = sut.Add("");
            result.Should().Be(0);
        }

        [Fact]
        public void StringCalculator_Null_ResultShouldBeZero()
        {
            var sut = new StringCalculators();

            int result = sut.Add(null);

            Assert.Equal(0, result);
        }


        [Fact]
        public void Add_WhenStringIsNull_ShouldReturnZero()
        {
            var sut = new StringCalculators();

            Action add = () => sut.Add("1,2,3");

            add.Should().Throw<ArgumentException>().WithMessage("*numbers*");
        }

        [Fact]
        public void Add_WhenConsecutiveCommas_ShouldThrowException()
        {
            var sut = new StringCalculators();

            Action add = () => sut.Add("1,,3");

            add.Should().Throw<ArgumentException>().WithMessage("*numbers*");
        }


        [Fact]
        public void Add_WhenContainsNomNumber_ShouldThrowArgumentExecption()
        {
            var sut = new StringCalculators();

            Action add = () => sut.Add("1,a");

            add.Should().Throw<ArgumentException>().WithMessage("*numbers*");
        }

        [Fact]
        public void Add_WhenValidInput_ReturnsSum()
        {
            var sut = new StringCalculators();

            var result = sut.Add("1,3");

            result.Should().Be(4);
        }
    }
}