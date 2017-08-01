using GameDataGateway.Model;

namespace GameDataGateway.Reader.Builder {
    public interface GameObjectBuilder {
        void AddAttribute(string attributeName, string content);
        GameObject GetGameObject();
    }
}
