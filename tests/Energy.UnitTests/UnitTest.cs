using System.Text.Json;
using Xunit.Abstractions;

namespace Energy.UnitTests
{
    /// <summary>
    /// A base class for unit tests.
    /// Any unit test should be able to derive from this class, so it's functionality broad.
    /// </summary>
    public abstract class UnitTest
    {
        private readonly ITestOutputHelper _output;
        protected string TestUsername;

        /// <summary>
        /// Creates a new instance of a UnitTest.
        /// </summary>
        /// <param name="output"></param>
        protected UnitTest(ITestOutputHelper output)
        {
            _output = output;
            TestUsername = GetType().Name;
        }

        /// <summary>
        /// Writes a string to the configured output.
        /// </summary>
        /// <param name="s">The string to write.</param>
        protected virtual void WriteLine(string s)
        {
            _output.WriteLine(s);
        }

        /// <summary>
        /// Writes a string to the configured output with arguments for a string.Format.
        /// </summary>
        /// <param name="s">The string to write.</param>
        /// <param name="args">The arguments to populate placeholders with.</param>
        protected virtual void WriteLine(string s, params object[] args)
        {
            _output.WriteLine(s, args);
        }

        /// <summary>
        /// Writes an object as a json formatted string to the configured output.
        /// </summary>
        /// <param name="o"></param>
        protected virtual void WriteLine(object o)
        {
            _output.WriteLine(JsonSerializer.Serialize(o));
        }
    }
}
