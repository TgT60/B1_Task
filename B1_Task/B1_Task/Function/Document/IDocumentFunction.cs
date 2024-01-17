namespace B1_Task.Function.Document
{
	public interface IDocumentFunction
	{
		int CreateCommonDoc(string path, string stringToRemove);
        void StoredDocument(string filePath);

    }
}
