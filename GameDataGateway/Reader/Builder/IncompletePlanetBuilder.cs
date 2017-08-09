using System.Collections.Generic;
using GameDataGateway.Model;

namespace GameDataGateway.Reader.Builder {
    public class IncompletePlanetBuilder : PlanetBuilder, IncompleteGameObjectBuilder {

        private readonly List<string> usedElements = new List<string> { "Name", "Galactic_Position" };

        public void AddXmlString(string xmlString) {
            var incompletePlanet = planet as IncompleteGameObject;
            incompletePlanet.SaveString(xmlString);
        }

        public bool UsesElement(string element) {
            return usedElements.Contains(element);
        }
    }
}
