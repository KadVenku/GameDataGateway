using System;
namespace GameDataGateway.Model {
    public interface Planet : GameObject {
        double X { get; set; }
        double Y { get; set; }
        double Z { get; set; }
    }
}
