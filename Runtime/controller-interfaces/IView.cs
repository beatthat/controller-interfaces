using UnityEngine;

namespace BeatThat.Controllers
{
    public interface IView
	{
		IController controller { get; }

		Transform transform { get; }
		
		void Reset();
		void Release();
	}
}

