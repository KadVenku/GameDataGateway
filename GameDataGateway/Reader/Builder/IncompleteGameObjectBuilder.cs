namespace GameDataGateway.Reader.Builder {
    public interface IncompleteGameObjectBuilder {
        bool UsesElement(string element);
        void AddXmlString(string xmlString);
    }
}
