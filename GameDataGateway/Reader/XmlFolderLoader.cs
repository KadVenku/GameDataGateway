namespace GameDataGateway.Reader {
    public interface XmlFolderLoader {
        string FolderPath { get; set; }
        void LoadFolder();
    }
}
