using NUnit.Framework;
using yahoofinance;

namespace usingfromcsharp
{
    [TestFixture]
    public class YahooFinanceTests
    {
        [Test]
        public void Load_symbol() {
            var sut = new YahooFinance();
        } 
    }
}