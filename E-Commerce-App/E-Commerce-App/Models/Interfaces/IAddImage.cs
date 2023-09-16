namespace E_Commerce_App.Models.Interfaces
{
	public interface IAddImage
	{
		Task<T> UploadImage<T>(IFormFile file, T Model) where T : IHasImage;
   }
}
