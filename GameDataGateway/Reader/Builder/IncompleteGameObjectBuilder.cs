namespace GameDataGateway.Reader.Builder {
    public interface IncompleteGameObjectBuilder {
        bool usesElement(string element);
        void AddXmlString(string xmlString);
    }
}
