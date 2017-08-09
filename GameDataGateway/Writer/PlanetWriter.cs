using System.Collections.Generic;
using System.IO;
using GameDataGateway.Model;

namespace GameDataGateway.Writer {
    public class PlanetWriter {

        protected readonly string fileName;

        public PlanetWriter(string fileName) {
            this.fileName = fileName;
        }

        public virtual void WriteGameObjectsToFile(IEnumerable<Planet> planets) {
            using (StreamWriter writer = new StreamWriter(fileName)) {
                string planetXml = 
                    "<?xml version=\"1.0\"?>\n" +
                    "<Planets>";
                
                foreach (var planet in planets)
                    planetXml += CreatePlanetXmlString(planet);
                
                planetXml += "</Planets>";

                writer.Write(planetXml);
                writer.Close();
            }
        }

        protected string CreatePlanetXmlString(Planet planet) {
            return BeginStartTag("Planet")
            + AddAttribute("Name", planet.Name)
            + CloseTag() + "\n"
            + WritePosition(planet)
            + WriteIncompleteXmlContent(planet)
            + CreateEndTag("Planet");
        }

        private static string WriteIncompleteXmlContent(Planet planet) {
            var planetXml = string.Empty;
            if (planet is IncompleteGameObject) {
                var incompletePlanet = planet as IncompleteGameObject;
                planetXml += incompletePlanet.GetString() + "\n";
            }
            return planetXml;
        }

        private static string WritePosition(Planet planet) {
            var planetXml = "\t" + BeginStartTag("Galactic_Position") + CloseTag();
            planetXml += planet.X + ", " + planet.Y + ", " + planet.Z;
            planetXml += CreateEndTag("Galactic_Position");
            return planetXml;
        }

        private static string BeginStartTag(string name) {
            return "<" + name;
        }

        private static string AddAttribute(string attribute, string value) {
            return " " + attribute + " =\"" + value + "\"";
        }

        private static string CloseTag() {
            return ">";
        }

        private static string CreateEndTag(string name) {
            return "</" + name + ">\n";
        }

    }
}
