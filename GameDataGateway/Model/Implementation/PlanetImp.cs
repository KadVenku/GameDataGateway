using System;

namespace GameDataGateway.Model.Implementation {
    public class PlanetImp : IncompleteGameObject, Planet {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public string Name { get; set; }
    }
}