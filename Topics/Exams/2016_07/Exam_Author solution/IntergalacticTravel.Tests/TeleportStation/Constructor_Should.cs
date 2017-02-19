using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntergalacticTravel.Contracts;
using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.TeleportStation
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetupAllOfTheProvidedFields_WhenValidParametersArePased()
        {
            // Arrange
            var locationMock = new Mock<ILocation>();
            var ownerMock = new Mock<IBusinessOwner>();
            var mapMock = new Mock<IEnumerable<IPath>>();
            var expectedMap = mapMock.Object;
            var expectedOwner = ownerMock.Object;
            var expectedLocation = locationMock.Object;

            // Act
            var teleportStation = new ExtendedTeleportStation(expectedOwner, expectedMap, expectedLocation);
            var actualOwner = teleportStation.Owner;
            var actualMap = teleportStation.GalacticMap;
            var actualLocation = teleportStation.Location;

            // Assert
            Assert.AreSame(expectedOwner, actualOwner);
            Assert.AreSame(expectedLocation, actualLocation);
            Assert.AreSame(expectedMap, actualMap);
        }
    }
}
