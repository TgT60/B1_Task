namespace B1_Task.Function.Document
{
	public interface IDocumentFunction
	{
		int CreateCommonDoc(string path, string stringToRemove);
        Task StoreDocument(string filePath);

    }
}
