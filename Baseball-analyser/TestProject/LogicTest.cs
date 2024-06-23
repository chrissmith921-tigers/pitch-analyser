using Baseball_analyser.Logic;
using System;
using Xunit;
using FakeItEasy;
using Baseball_analyser.Helper;

namespace TestProject
{
    public class LogicTest
    {
        [Fact]
        public void VerifyStrikeIsCalled()
        {
            var fakeDataLoader = A.Fake<IDataLoader>();
            A.CallTo(() => fakeDataLoader.GetPitchesFromFile(A<string>.Ignored)).Returns(new Baseball_analyser.Datatypes.PitchCollection() { Pitches = new Baseball_analyser.Datatypes.Pitch[1] { new Baseball_analyser.Datatypes.Pitch() { HorizontalPoint = 1.1, PitchType = "FB", VerticalPoint = 3.3 } } });
            PitchAnalyser pa = new PitchAnalyser(fakeDataLoader);
            Assert.Equal(100, pa.GetStrikePercentage("FB"));
        }
        [Fact]
        public void VerifyStrikeIsNotCalledTooFarLeft()
        {
            var fakeDataLoader = A.Fake<IDataLoader>();
            A.CallTo(() => fakeDataLoader.GetPitchesFromFile(A<string>.Ignored)).Returns(new Baseball_analyser.Datatypes.PitchCollection() { Pitches = new Baseball_analyser.Datatypes.Pitch[1] { new Baseball_analyser.Datatypes.Pitch() { HorizontalPoint = -101.1, PitchType = "FB", VerticalPoint = 3.3 } } });
            PitchAnalyser pa = new PitchAnalyser(fakeDataLoader);
            Assert.Equal(0, pa.GetStrikePercentage("FB"));
        }
        [Fact]
        public void VerifyStrikeIsNotCalledTooFarRight()
        {
            var fakeDataLoader = A.Fake<IDataLoader>();
            A.CallTo(() => fakeDataLoader.GetPitchesFromFile(A<string>.Ignored)).Returns(new Baseball_analyser.Datatypes.PitchCollection() { Pitches = new Baseball_analyser.Datatypes.Pitch[1] { new Baseball_analyser.Datatypes.Pitch() { HorizontalPoint = 101.1, PitchType = "FB", VerticalPoint = 3.3 } } });
            PitchAnalyser pa = new PitchAnalyser(fakeDataLoader);
            Assert.Equal(0, pa.GetStrikePercentage("FB"));
        }
        [Fact]
        public void VerifyStrikeIsNotCalledTooLow()
        {
            var fakeDataLoader = A.Fake<IDataLoader>();
            A.CallTo(() => fakeDataLoader.GetPitchesFromFile(A<string>.Ignored)).Returns(new Baseball_analyser.Datatypes.PitchCollection() { Pitches = new Baseball_analyser.Datatypes.Pitch[1] { new Baseball_analyser.Datatypes.Pitch() { HorizontalPoint = 1.1, PitchType = "FB", VerticalPoint = -103.3 } } });
            PitchAnalyser pa = new PitchAnalyser(fakeDataLoader);
            Assert.Equal(0, pa.GetStrikePercentage("FB"));
        }
        [Fact]
        public void VerifyStrikeIsNotCalledTooHigh()
        {
            var fakeDataLoader = A.Fake<IDataLoader>();
            A.CallTo(() => fakeDataLoader.GetPitchesFromFile(A<string>.Ignored)).Returns(new Baseball_analyser.Datatypes.PitchCollection() { Pitches = new Baseball_analyser.Datatypes.Pitch[1] { new Baseball_analyser.Datatypes.Pitch() { HorizontalPoint = 1.1, PitchType = "FB", VerticalPoint = 103.3 } } });
            PitchAnalyser pa = new PitchAnalyser(fakeDataLoader);
            Assert.Equal(0, pa.GetStrikePercentage("FB"));
        }
        [Fact]
        public void Verify50PercentStrikeRateIsCalled()
        {
            var fakeDataLoader = A.Fake<IDataLoader>();
            A.CallTo(() => fakeDataLoader.GetPitchesFromFile(A<string>.Ignored)).Returns(new Baseball_analyser.Datatypes.PitchCollection() { Pitches = new Baseball_analyser.Datatypes.Pitch[2] { new Baseball_analyser.Datatypes.Pitch() { HorizontalPoint = 1.1, PitchType = "FB", VerticalPoint = 3.3 } , new Baseball_analyser.Datatypes.Pitch() { HorizontalPoint = 1.1, PitchType = "FB", VerticalPoint = 300.3 } } });
            PitchAnalyser pa = new PitchAnalyser(fakeDataLoader);
            Assert.Equal(50, pa.GetStrikePercentage("FB"));
        }
    }
}
