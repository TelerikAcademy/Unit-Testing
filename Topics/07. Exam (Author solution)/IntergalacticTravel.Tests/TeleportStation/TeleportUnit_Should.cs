using System;
using System.Collections.Generic;
using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using Moq;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.TeleportStation
{
    [TestFixture]
    public class TeleportUnit_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenTheParameterUnitToTeleportIsNull()
        {
            // Arrange
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var teleportStationMapMock = new Mock<IEnumerable<IPath>>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleport = (IUnit)null;
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock.Object, teleportStationLocationMock.Object);
            var expectedExceptionMessage = "unitToTeleport";

            // Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(
                () => teleportStation.TeleportUnit(unitToTeleport, targetLocationMock.Object));
            var actualExceptionMessage = exc.Message;

            // Assert
            StringAssert.Contains(expectedExceptionMessage, actualExceptionMessage);
        }

        [Test]
        public void ThrowArgumentNullException_WhenTheParameterTargetLocationIsNull()
        {
            // Arrange
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var teleportStationMapMock = new Mock<IEnumerable<IPath>>();
            var unitToTeleportMock = new Mock<IUnit>();
            var targetLocation = (ILocation)null;
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock.Object, teleportStationLocationMock.Object);
            var expectedExceptionMessage = "destination";

            // Act & Assert
            var exc = Assert.Throws<ArgumentNullException>(
                () => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocation));
            var actualExceptionMessage = exc.Message;

            // Assert
            StringAssert.Contains(expectedExceptionMessage, actualExceptionMessage);
        }

        [Test]
        public void ThrowTeleportOutOfRangeException_WhenUnitIsTryingToUseTheTeleportStationFromPlanetOrGalaxyDifferentThanThatOfTheStationItself()
        {
            // Arrange
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var teleportStationMapMock = new Mock<IEnumerable<IPath>>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns("PLANET-1");
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns("GALAXY-1");
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns("PLANET-2");
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("GALAXY-2");

            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock.Object, teleportStationLocationMock.Object);
            var expectedExceptionMessage = "unitToTeleport.CurrentLocation";

            // Act & Assert
            var exc = Assert.Throws<TeleportOutOfRangeException>(
                () => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));
            var actualExceptionMessage = exc.Message;

            // Assert
            StringAssert.Contains(expectedExceptionMessage, actualExceptionMessage);
        }

        [Test]
        public void ThrowInvalidTeleportationLocationException_WhenTryingToTeleportUnitToLocationWhichIsAlreadyTakenByAnotherUnit()
        {
            // Arrange
            var expectedExceptionMessage = "units will overlap";
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            var planetaryUnitsList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act & Assert
            var exc = Assert.Throws<InvalidTeleportationLocationException>(
                () => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));
            var actualExceptionMessage = exc.Message;

            // Assert
            StringAssert.Contains(expectedExceptionMessage, actualExceptionMessage);
        }

        [Test]
        public void ThrowLocationNotFoundException_WhenTryingToTeleportUnitToGalaxyWhichDoesntExistInTheGalacticMapOfTheTeleportStation()
        {
            // Arrange
            var expectedExceptionMessage = "Galaxy";
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns("DifferentGalaxyName");

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            var planetaryUnitsList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act & Assert
            var exc = Assert.Throws<LocationNotFoundException>(
                () => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));
            var actualExceptionMessage = exc.Message;

            // Assert
            StringAssert.Contains(expectedExceptionMessage, actualExceptionMessage);
        }

        [Test]
        public void ThrowLocationNotFoundException_WhenTryingToTeleportUnitToPlanetWhichDoesntExistInTheGalacticMapOfTheTeleportStation()
        {
            // Arrange
            var expectedExceptionMessage = "Planet";
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns("DifferentPlanetName");
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            var planetaryUnitsList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act & Assert
            var exc = Assert.Throws<LocationNotFoundException>(
                () => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));
            var actualExceptionMessage = exc.Message;

            // Assert
            StringAssert.Contains(expectedExceptionMessage, actualExceptionMessage);
        }

        [Test]
        public void ThrowInsufficientResourcesException_WhenTryingToTeleportUnitButTheServiceCostsMoreThanTheUnitCurrentAvailableResources()
        {
            // Arrange
            var expectedExceptionMessage = "FREE LUNCH";
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude + 15d);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude + 15d);

            var planetaryUnitsList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(false);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act & Assert
            var exc = Assert.Throws<InsufficientResourcesException>(
                () => teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object));
            var actualExceptionMessage = exc.Message;

            // Assert
            StringAssert.Contains(expectedExceptionMessage, actualExceptionMessage);
        }

        [Test]
        public void RequestPaymentFromTheUnitThatIsBeingTeleportedWithTheAmountOfPathCost_WhenTheValidationsPassSuccessfullyAndTheUnitsIsReadyForTeleportation()
        {
            // Arrange
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude + 15d);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude + 15d);

            var planetaryUnitsList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);

            var currentUnitLocationPlanetaryUnitsList = new List<IUnit> { unitToTeleportMock.Object };
            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(x => x.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentUnitLocationPlanetaryUnitsList);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act
            teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object);

            // Assert
            unitToTeleportMock.Verify(x => x.Pay(pathMock.Object.Cost), Times.Once());
        }

        [Test]
        public void ObtainPaymentFromTheUnitThatIsBeingTeleportedWithTheAmountOfPathCost_WhenTheValidationsPassSuccessfullyAndTheUnitsIsReadyForTeleportation()
        {
            // Arrange
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude + 15d);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude + 15d);

            var planetaryUnitsList = new List<IUnit> { planetaryUnitMock.Object };
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);
            var currentUnitLocationPlanetaryUnitsList = new List<IUnit> { unitToTeleportMock.Object };
            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);
            var initialTeleportStationResources = teleportStation.Resources.Clone();

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(x => x.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentUnitLocationPlanetaryUnitsList);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            var expectedBronzeCoins = initialTeleportStationResources.BronzeCoins + pathMock.Object.Cost.BronzeCoins;
            var expectedSilverCoins = initialTeleportStationResources.SilverCoins + pathMock.Object.Cost.SilverCoins;
            var expectedGoldCoins = initialTeleportStationResources.GoldCoins + pathMock.Object.Cost.GoldCoins;

            // Act
            teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object);
            var actualBronzeCoins = teleportStation.Resources.BronzeCoins;
            var actualSilverCoins = teleportStation.Resources.SilverCoins;
            var actualGoldcoins = teleportStation.Resources.GoldCoins;

            // Assert
            Assert.AreEqual(expectedBronzeCoins, actualBronzeCoins);
            Assert.AreEqual(expectedSilverCoins, actualSilverCoins);
            Assert.AreEqual(expectedGoldCoins, actualGoldcoins);
        }

        [Test]
        public void SetTheUnitToTeleportPreviousLocationToHisCurrentLocation_WhenTheValidationsPassAndTheUnitIsBeingTeleported()
        {
            // Arrange
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude + 15d);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude + 15d);

            var planetaryUnitsList = new List<IUnit> { planetaryUnitMock.Object };

            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);

            var currentUnitLocationPlanetaryUnitsList = new List<IUnit> { unitToTeleportMock.Object };
            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);
            var initialTeleportStationResources = teleportStation.Resources.Clone();

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(x => x.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentUnitLocationPlanetaryUnitsList);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act
            teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object);

            // Assert
            unitToTeleportMock.VerifySet(x => x.PreviousLocation = x.CurrentLocation, Times.Once());
        }

        [Test]
        public void SetTheUnitToTeleportCurrentLocationToTargetLocation_WhenTheValidationsPassAndTheUnitIsBeingTeleported()
        {
            // Arrange
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
            var targetLocationMock = new Mock<ILocation>();
            var unitToTeleportMock = new Mock<IUnit>();

            var planetaryUnitMock = new Mock<IUnit>();
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude + 15d);
            planetaryUnitMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude + 15d);

            var planetaryUnitsList = new List<IUnit> { planetaryUnitMock.Object };
            var currentUnitLocationPlanetaryUnitsList = new List<IUnit> { unitToTeleportMock.Object };
           
            var pathMock = new Mock<IPath>();
            pathMock.Setup(x => x.Cost.BronzeCoins).Returns(10);
            pathMock.Setup(x => x.Cost.SilverCoins).Returns(10);
            pathMock.Setup(x => x.Cost.GoldCoins).Returns(10);
            pathMock.Setup(x => x.TargetLocation.Planet.Name).Returns(planetName);
            pathMock.Setup(x => x.TargetLocation.Planet.Galaxy.Name).Returns(galaxyName);
            pathMock.Setup(x => x.TargetLocation.Planet.Units).Returns(planetaryUnitsList);

            var teleportStationMapMock = new List<IPath> { pathMock.Object };
            var teleportStation = new ExtendedTeleportStation(teleportStationOwnerMock.Object, teleportStationMapMock, teleportStationLocationMock.Object);
            var initialTeleportStationResources = teleportStation.Resources.Clone();

            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Name).Returns(planetName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Galaxy.Name).Returns(galaxyName);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Latitude).Returns(latitude);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Coordinates.Longtitude).Returns(longtitude);
            unitToTeleportMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitToTeleportMock.Setup(x => x.Pay(pathMock.Object.Cost)).Returns(pathMock.Object.Cost);
            unitToTeleportMock.Setup(x => x.CurrentLocation.Planet.Units).Returns(currentUnitLocationPlanetaryUnitsList);

            targetLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            targetLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);
            targetLocationMock.Setup(x => x.Coordinates.Latitude).Returns(latitude);
            targetLocationMock.Setup(x => x.Coordinates.Longtitude).Returns(longtitude);

            teleportStationLocationMock.Setup(x => x.Planet.Name).Returns(planetName);
            teleportStationLocationMock.Setup(x => x.Planet.Galaxy.Name).Returns(galaxyName);

            // Act
            teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object);

            // Assert
            unitToTeleportMock.VerifySet(x => x.CurrentLocation = targetLocationMock.Object, Times.Once());
        }

        [Test]
        public void AddTheUnitToTeleportToTheListOfUnitsOfTheTargetPlanet_WhenTheValidationsPassAndTheUnitIsBeingTeleported()
        {
            // Arrange
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
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

            // Act
            teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object);

            // Assert
            targetLocationPlanetaryUnitsCollectionMock.Verify(x => x.Add(unitToTeleportMock.Object), Times.Once());
        }

        [Test]
        public void RemoveTheUnitToTeleportFromTheListOfUnitsOfItsCurrentPlanet_WhenTheValidationsPassAndTheUnitIsBeingTeleported()
        {
            // Arrange
            var planetName = "P1";
            var galaxyName = "G1";
            var longtitude = 45d;
            var latitude = 45d;
            var teleportStationLocationMock = new Mock<ILocation>();
            var teleportStationOwnerMock = new Mock<IBusinessOwner>();
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

            // Act
            teleportStation.TeleportUnit(unitToTeleportMock.Object, targetLocationMock.Object);

            // Assert
            currentUnitLocationPlanetaryUnitsCollectionMock.Verify(x => x.Remove(unitToTeleportMock.Object), Times.Once());
        }
    }
}
