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
    public class PayProfits_Should
    {
        [Test]
        public void ReturnTheTotalAmountOfProfitsGeneratedUsingTheTeleportUnitService_WhenTheArgumentPassedRepresentsTheActualOwnerOfTheTeleportStation()
        {
            // Arrange
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            teleportStationOwnerMock.Setup(x => x.IdentificationNumber).Returns(12412);
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude + 15d);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude + 15d);

            var targetLocationPlanetaryUnitsCollectionEnumeratorMock = new Mock<IEnumerator<IUnit>>();
            targetLocationPlanetaryUnitsCollectionEnumeratorMock
                .Setup(x => x.Current)
                .Returns(planetaryUnitMock.Object)
                .Callback(
                    () =>
                        targetLocationPlanetaryUnitsCollectionEnumeratorMock
                        .Setup(x => x.Current)
                        .Returns((IUnit)null));

            var targetLocationPlanetaryUnitsCollectionMock = new Mock<IList<IUnit>>();
            targetLocationPlanetaryUnitsCollectionMock.Setup(x => x.GetEnumerator()).Returns(targetLocationPlanetaryUnitsCollectionEnumeratorMock.Object);

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(targetLocationPlanetaryUnitsCollectionMock.Object);

            var currentUnitLocationPlanetaryUnitsCollectionEnumeratorMock = new Mock<IEnumerator<IUnit>>();
            currentUnitLocationPlanetaryUnitsCollectionEnumeratorMock
                .Setup(x => x.Current)
                .Returns(unitToTeleportMock.Object)
                .Callback(
                    () =>
                        currentUnitLocationPlanetaryUnitsCollectionEnumeratorMock
                        .Setup(x => x.Current)
                        .Returns((IUnit)null));

            var currentUnitLocationPlanetaryUnitsCollectionMock = new Mock<IList<IUnit>>();
            currentUnitLocationPlanetaryUnitsCollectionMock.Setup(x => x.GetEnumerator()).Returns(currentUnitLocationPlanetaryUnitsCollectionEnumeratorMock.Object);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);
            var initialTeleportStationResources = teleportStation.Resources.Clone();

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(x => x.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentUnitLocationPlanetaryUnitsCollectionMock.Object);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            var expectedResourcesAmount = new Mock<IResources>();
            expectedResourcesAmount.Setup(x => x.BronzeCoins).Returns(500);
            expectedResourcesAmount.Setup(x => x.SilverCoins).Returns(400);
            expectedResourcesAmount.Setup(x => x.GoldCoins).Returns(300);
            teleportStation.Resources.Add(expectedResourcesAmount.Object);
            
            // Act
            var actualResourcesAmount = teleportStation.PayProfits(teleportStationOwnerMock.Object);

            // Assert
            Assert.AreEqual(expectedResourcesAmount.Object.BronzeCoins, actualResourcesAmount.BronzeCoins);
            Assert.AreEqual(expectedResourcesAmount.Object.SilverCoins, actualResourcesAmount.SilverCoins);
            Assert.AreEqual(expectedResourcesAmount.Object.GoldCoins, actualResourcesAmount.GoldCoins);
        }
    }
}
