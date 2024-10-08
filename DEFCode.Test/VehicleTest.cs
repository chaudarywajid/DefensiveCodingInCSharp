using DEFCode.DL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DEFCode.Test
{
    [TestClass]
    public class VehicleTest
    {
      
        [TestMethod] 
        public void CalculateWeight_Test()
        {
            // Arrange
            string tareweight = "120";
            string grossweight = "320";
            double expected = 200;
            var vehicle = new Vehicle();
            // Act
            double actual = vehicle.CalculateWeight(tareweight, grossweight);

            // Assert
            Assert.AreEqual(expected, actual);
        }

    }
}
