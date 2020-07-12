using Moq.AutoMock;
using Xunit.Abstractions;

namespace Energy.UnitTests
{
    /// <summary>
    /// Sets up a test class with an AutoMocker readily available.
    /// </summary>
    public abstract class AutoMockTest : UnitTest
    {
        protected readonly AutoMocker AutoMocker;

        /// <summary>
        /// Creates a new instance of an AutoMockTest.
        /// </summary>
        /// <param name="output">The helper utility for handling test outputs.</param>
        protected AutoMockTest(ITestOutputHelper output)
            : base(output)
        {
            AutoMocker = new AutoMocker();
        }
    }

    /// <summary>
    /// Sets up a test class where the generic type argument is used to generate a mock of that type and make it available to each test by way of the CUT (Class Under Test) object.
    /// </summary>
    /// <typeparam name="TCUT"></typeparam>
    public abstract class AutoMockTest<TCUT> : AutoMockTest where TCUT : class
    {
        // Give each test their own instance.
        protected TCUT CUT => AutoMocker.CreateInstance<TCUT>();

        /// <summary>
        /// Creates a new instance of an AutoMockTest.
        /// </summary>
        /// <param name="output">The helper utility for handling test outputs.</param>
        protected AutoMockTest(ITestOutputHelper output)
            : base(output) { }
    }
}
