using System;

namespace BeatThat
{
	/// <summary>
	/// A presenter that has a model.
	/// </summary>
	public interface HasModel : IController
	{
        /// <summary>
        /// Set the model.
        /// Sends update events according to policy (default is SendOnChange)
        /// </summary>
        /// <param name="model">Model.</param>
        /// <param name="opts">Opts.</param>
        /// <param name="disposePreviousModel">If TRUE and the Model type implements IDisposable, 
        /// then calls Dispose on the previous model after set and all events.
        /// </param>
        void SetModel(object model,
                      PropertyEventOptions opts = PropertyEventOptions.SendOnChange,
                      bool disposePreviousModel = true);

		object GetModel();

		/// <summary>
		/// Sets the model then calls Reset,Bind,Go sequence. Will throw InvalidCastException if arg is wrong type for presenter
		/// </summary>
		void GoWithModel(object model);

		Type GetModelType();
	}
}
