﻿using System;
using System.Collections.Generic;
using System.IO;
using GameDataGateway.Model;
using GameDataGateway.Reader.Builder;
using GameDataGateway.Repository;
using NUnit.Framework;
namespace GameDataGateway.Reader {
    [TestFixture]
    internal class GenericGameObjectFileReaderTest {
        private string filePath;


        private void PrepareData(string type) {
            string data = XmlStringFactory.CreateXmlString(type);
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            filePath = Path.Combine(documents, "GameData.xml");
            File.WriteAllText(filePath, data);
        }

        [Test]
        public void whenReadingXmlWithValidPlanet_shouldReturnListWithPlanet() {
            PrepareData("Planet");

            var repo = new GameObjectRepositoryStub();
            var builderFactory = new GameObjectBuilderFactory(repo);
            var sut = new GenericGameObjectFileReader<Planet>("Planet", builderFactory);

            var result = sut.ReadGameFile(filePath) as List<Planet>;

            Assert.That(result.Count, Is.EqualTo(1));

            var planet = result[0];
            Assert.That(planet, Is.InstanceOf(typeof(Planet)));
            Assert.That(planet.Name, Is.EqualTo("Galaxy_Core_Art_Model"));
            Assert.That(planet.X, Is.EqualTo(12.0));
            Assert.That(planet.Y, Is.EqualTo(34.0));
            Assert.That(planet.Z, Is.EqualTo(-10.0));
        }

        [Test]
        public void whenReadingXmlWithValidTradeRoute_shouldReturnListWithTradeRoute() {
            PrepareData("TradeRoute");

            var repo = new GameObjectRepositoryStub();

            var pointA = new Model.Implementation.PlanetImp { Name = "Abregado_Rae" };
            var pointB = new Model.Implementation.PlanetImp { Name = "Bothawui" };

            repo.AddPlanet(pointB);
            repo.AddPlanet(pointA);

            var builderFactory = new GameObjectBuilderFactory(repo);
            var sut = new GenericGameObjectFileReader<TradeRoute>("TradeRoute", builderFactory);

            var result = sut.ReadGameFile(filePath) as List<TradeRoute>;
            Assert.That(result.Count, Is.EqualTo(1));

            var tradeRoute = result[0];

            Assert.That(tradeRoute.Name, Is.EqualTo("Abregado_Bothawui"));
            Assert.That(tradeRoute.PointA, Is.SameAs(pointA));
            Assert.That(tradeRoute.PointB, Is.SameAs(pointB));
        }

        [TearDown]
        public void TearDown() {
            File.Delete(filePath);
        }
    }

    internal class GameObjectRepositoryStub : GameObjectRepository {
        private List<Planet> planets = new List<Planet>();

        public IEnumerable<Planet> Planets => planets;

        public IEnumerable<TradeRoute> TradeRoutes => throw new NotImplementedException();

        public event EventHandler<RepositoryChangedArgs> RepositoryChanged;

        protected virtual void OnRepositoryChanged(RepositoryChangedArgs e) {
            RepositoryChanged?.Invoke(this, e);
        }

        public void AddPlanet(Planet planet) {
            planets.Add(planet);
        }

        public void AddTradeRoute(TradeRoute tradeRoute) {
            throw new NotImplementedException();
        }

        public void RemovePlanet(Planet planet) {
            throw new NotImplementedException();
        }

        public void RemoveTradeRoute(TradeRoute tradeRoute) {
            throw new NotImplementedException();
        }
    }
}
