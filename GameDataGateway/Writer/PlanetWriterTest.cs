using System;
using System.Collections.Generic;
using System.IO;
using GameDataGateway.Model;
using GameDataGateway.Model.Implementation;
using NUnit.Framework;
namespace GameDataGateway.Writer {
    [TestFixture]
    public class PlanetWriterTest {
        [Test]
        public void testWritePlanetToFile() {
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var filePath = Path.Combine(documents, "GameData.xml");

            var sut = new PlanetWriterMock(filePath);

            var planet = new PlanetImp();
            planet.Name = "Test";
            planet.X = 1.0;
            planet.Y = 5.0;
            planet.Z = 10.0;

            sut.XmlString = "\t<Tag1>Something</Tag1>" +
                "\n\t<Tag2>" +
                "\n\t\t<SubTag>" +
                "\n\t\t\t<SubSubTag>5</SubSubTag>" +
                "\n\t\t<SubTag>" +
                "\n\t</Tag2>";

            var incompletePlanet = planet as IncompleteGameObject;
            incompletePlanet.SaveString(sut.XmlString);
            var planets = new List<Planet> { planet };
            sut.WriteGameObjectsToFile(planets);
        }
    }
}
