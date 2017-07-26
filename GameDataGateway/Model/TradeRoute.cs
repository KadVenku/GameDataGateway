using System;
namespace GameDataGateway.Model {
    public interface TradeRoute : GameObject {
        Planet PointA { get; set; }
        Planet PointB { get; set; }
    }
}
