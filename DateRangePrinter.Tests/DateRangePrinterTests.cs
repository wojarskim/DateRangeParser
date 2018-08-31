using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace DateRangePrinter.Tests
{
    [TestClass]
    public class DateRangePrinterTests
    {
        [TestMethod]
        public void RunValidInputDataTest()
        {
            DateTime fromDateTime = new DateTime(2017, 1, 1);
            DateTime toDateTime = new DateTime(2017, 1, 5);
            string errorMessage;

            var inputArgumentServiceMock = new Mock<IInputArgumentsService>();
            inputArgumentServiceMock.Setup(i => i.TryParseInputArguments(It.IsAny<string[]>(), out fromDateTime, out toDateTime, out errorMessage))
                .Returns(true);

            var dateRangeServiceMock = new Mock<IDateRangeService>();
            dateRangeServiceMock.Setup(i => i.PrintDateRange(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns("01 - 05.01.2017");

            var dateRangePrinter = new DateRangeConsolePrinter(inputArgumentServiceMock.Object, dateRangeServiceMock.Object);
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                dateRangePrinter.Run(new[] { "01.01.2017", "05.01.2017" });

                Assert.AreEqual("01 - 05.01.2017\r\n", stringWriter.ToString());
            }           
        }

        [TestMethod]
        public void RunInvalidInputDataTest()
        {
            DateTime fromDateTime;
            DateTime toDateTime;
            string errorMessage = "Error message";

            var inputArgumentServiceMock = new Mock<IInputArgumentsService>();
            inputArgumentServiceMock.Setup(i => i.TryParseInputArguments(It.IsAny<string[]>(), out fromDateTime, out toDateTime, out errorMessage))
                .Returns(false);

            var dateRangeServiceMock = new Mock<IDateRangeService>();

            var dateRangePrinter = new DateRangeConsolePrinter(inputArgumentServiceMock.Object, dateRangeServiceMock.Object);
            using (StringWriter stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                dateRangePrinter.Run(new[] { "01.01.2017", "05.01.2016" });

                Assert.AreEqual("Error message\r\n", stringWriter.ToString());
            }
        }
    }
}