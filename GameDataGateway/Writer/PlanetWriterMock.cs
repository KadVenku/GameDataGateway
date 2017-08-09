using System.Collections.Generic;
using System.IO;
using GameDataGateway.Model;
using NUnit.Framework;

namespace GameDataGateway.Writer {
    public class PlanetWriterMock : PlanetWriter {
        public PlanetWriterMock(string fileName) : base(fileName) {
        }

        public string XmlString { get; set; }

        public override void WriteGameObjectsToFile(IEnumerable<Planet> planets) {
            base.WriteGameObjectsToFile(planets);

            string expected =
                "<?xml version=\"1.0\"?>" +
                "\n<Planets>" +
                "<Planet Name =\"Test\">" +
                "\n\t<Galactic_Position>1, 5, 10</Galactic_Position>" +
                "\n" + XmlString +
                "\n</Planet>" +
                "\n</Planets>";

            string planetXml = File.ReadAllText(fileName);
            Assert.That(planetXml.Trim(), Is.EqualTo(expected));
            File.Delete(fileName);
        }
    }
}
