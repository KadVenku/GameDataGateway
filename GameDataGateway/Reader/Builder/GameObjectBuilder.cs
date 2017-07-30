using GameDataGateway.Model;

namespace GameDataGateway.Reader.Builder {
    public interface GameObjectBuilder {
        void AddAttribute(string attributeName, string content);
        bool usesElement(string element);
        GameObject GetGameObject();
    }
}
