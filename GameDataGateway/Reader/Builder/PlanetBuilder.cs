using System.Collections.Generic;
using System.Globalization;
using GameDataGateway.Model;
using GameDataGateway.Model.Implementation;

namespace GameDataGateway.Reader.Builder {
    public class PlanetBuilder : GameObjectBuilder {
        protected Planet planet;

        public void AddAttribute(string attribute, string value) {
            if (planet == null) planet = CreatePlanet();

            if (attribute == "Name")
                planet.Name = value;
            else if (attribute == "Galactic_Position") {
                var positionArray = value.Split(',');
                planet.X = double.Parse(positionArray[0], CultureInfo.InvariantCulture);
                planet.Y = double.Parse(positionArray[1], CultureInfo.InvariantCulture);
                planet.Z = double.Parse(positionArray[2], CultureInfo.InvariantCulture);
            }
        }

        protected virtual Planet CreatePlanet() {
            return new PlanetImp();
        }

        public GameObject GetGameObject() {
            return planet;
        }
    }
}