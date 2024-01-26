namespace B1_Task.Function.Document
{
	public interface IDocumentFunction
	{
		int CreateCommonDoc(string path);
        Task StoreDocument(IFormFile file);

    }
}
