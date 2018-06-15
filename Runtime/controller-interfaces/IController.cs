using BeatThat.Bindings;
/// <summary>
/// Core interface common to all presenters.
/// </summary>
using UnityEngine;
using UnityEngine.Events;

namespace BeatThat.Controllers
{
    public interface IController : HasBinding
    {
		GameObject gameObject { get; }

		Transform transform { get; }

		/// <summary>
		/// Set up the presenter.
		/// </summary>
		void Reset();

		/// <summary>
		/// Binds the presenter to its Model and View,
		/// e.g. binds Clicked events from any view buttons as well as events defined by the Model.
		/// View and Model (if any) must both be assigned/available before calling Bind
		/// </summary>
		void Bind();

		/// <summary>
		/// Default call to activate a presenter,
		/// e.g. in Go text available from the Model might be rendered in labels from the View
		/// </summary>
		void Go();

		/// <summary>
		/// Convenience function to activate a presenter, calls Reset(), Bind(), and Go() in sequence
		/// For IPresenters (that have a parameterized model type), generally use GoWith(ModelType) instead.
		/// </summary>
		void ResetBindGo();

		/// <summary>
		/// Unbind presenters View and Model and does any cleanup.
		/// </summary>
		void Unbind();

		bool isBound { get; }

		/// <summary>
		/// Is hidden (by a call to Hide)?
		/// </summary>
		bool isHidden { get; }

		/// <summary>
		/// Hide (or show) the presenter, typically by gameObject.SetActive(true|false), but not always.
		/// </summary>
		void Hide(bool hide);
	}

  public struct ControllerModelUpdate<ModelType> where ModelType : class
    {
        public IController<ModelType> controller;
        public ModelType modelFrom;
        public ModelType modelTo;
    }

	public interface IController<ModelType> : IController, HasModel
		where ModelType : class
	{
        /// <summary>
        /// Invoked immediately before the model is replaced
        /// </summary>
        UnityEvent<ControllerModelUpdate<ModelType>> onModelWillUpdate { get; }

        /// <summary>
        /// Invoked immediately after the model is replaced. The old/prev model is passed as param
        /// </summary>
        UnityEvent<ControllerModelUpdate<ModelType>> onModelDidUpdate { get; }

		ModelType model { get; }

		void GoWith(ModelType model);

	}

	public interface IController<ModelType, ViewType> : IController<ModelType>, HasView
		where ModelType : class
		where ViewType : class, IView
	{
		ViewType view { get; set; }
	}
}
