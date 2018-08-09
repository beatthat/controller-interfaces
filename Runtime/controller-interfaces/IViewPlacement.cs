namespace BeatThat.Controllers
{
    public interface IViewPlacement
	{
		IView view { get; }

		void EnsureCreated();

		void Release();
	}
}


