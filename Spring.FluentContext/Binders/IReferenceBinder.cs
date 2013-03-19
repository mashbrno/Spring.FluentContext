//
//  Author:
//    Wojciech Kotlarski
//
//  Copyright (c) 2012, Wojciech Kotlarski
//
//  All rights reserved.
//
//  Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:
//
//     * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.	 
//     * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in
//       the documentation and/or other materials provided with the distribution.
//
//  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS 
//  "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT 
//  LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS 
//  FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR 
//  CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, 
//  EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, 
//  PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
//  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF 
//  LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
//  NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS 
//  SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
//

using Spring.FluentContext.Definitions;

namespace Spring.FluentContext.Binders
{
	/// <summary>
	/// Interface for reference binder.
	/// </summary>
	/// <typeparam name="TBuilder">Type of builder returned after binding is done.</typeparam>
	/// <typeparam name="TTargetType">Type of binding.</typeparam>
	public interface IReferenceBinder<out TBuilder, in TTargetType>
	{
		/// <summary>
		/// Specifies object with <c>objectId</c> id as binding target.
		/// </summary>
		/// <param name="objectId">Id of registered object.</param>
		/// <returns>Builder.</returns>
		TBuilder ToRegistered(string objectId);

		/// <summary>
		/// Specifies object referenced with <c>reference</c> as binding target.
		/// </summary>
		/// <param name="reference">Object definition reference.</param>
		/// <returns>Builder.</returns>
		TBuilder ToRegistered(IObjectRef<TTargetType> reference);

		/// <summary>
		/// Specifies object with default id for <c>TReferencedType</c> type as binding target.
		/// </summary>
		/// <typeparam name="TReferencedType">Type of bound object.</typeparam>
		/// <returns>Builder.</returns>
		TBuilder ToRegisteredDefaultOf<TReferencedType>() where TReferencedType : TTargetType;

		/// <summary>
		/// Specifies object with default id for <c>TTargetType</c> type as binding target.
		/// </summary>
		/// <returns>Builder.</returns>
		TBuilder ToRegisteredDefault();
	}
}