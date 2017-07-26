using System.Collections.Generic;
using System.Xml;
using GameDataGateway.Model;
using GameDataGateway.Reader.Builder;

namespace GameDataGateway.Reader {
    public class PlanetFileReader : GameFileReader<Planet> {

        private readonly List<Planet> planets = new List<Planet>();

        private PlanetBuilder planetBuilder;
        private string currentNode;

        public IEnumerable<Planet> ReadGameFile(string filePath) {
            XmlReader reader;
            using (reader = XmlReader.Create(filePath)) {
                while (reader.Read())
                    ReadNode(reader);
                reader.Close();
            }
            return planets;
        }

        private void ReadNode(XmlReader reader) {
            switch (reader.NodeType) {
                case XmlNodeType.Element:
                    HandleElement(reader);
                    currentNode = reader.Name;
                    break;
                case XmlNodeType.EndElement:
                    HandleEndElement(reader);
                    break;
                case XmlNodeType.Text:
                    HandleText(currentNode, reader.Value);
                    break;
            }
        }

        private void HandleElement(XmlReader reader) {
            if (reader.Name == "Planet") {
                planetBuilder = new PlanetBuilder();
                if (reader.HasAttributes)
                    planetBuilder.AddAttribute("Name", reader.GetAttribute("Name"));
            }
        }

        private void HandleText(string nodeName, string content) {
            planetBuilder.AddAttribute(nodeName, content);
        }

        private void HandleEndElement(XmlReader reader) {
            if (reader.Name == "Planet") {
                planets.Add(planetBuilder.GetPlanet());
                currentNode = string.Empty;
            }
        }
    }
}
