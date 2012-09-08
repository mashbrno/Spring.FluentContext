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
using Spring.FluentContext.Builders;
using Spring.FluentContext.BuildingStages;
using Spring.FluentContext.Utils;

namespace Spring.FluentContext.Impl
{
	internal class FactoryMethodDefinitionBuilder<TFactory,TObject> : IFactoryMethodDefinitionBuilder<TFactory,TObject>
	{
		private ObjectDefinitionBuilder<TObject> _builder;

		public FactoryMethodDefinitionBuilder(ObjectDefinitionBuilder<TObject> builder)
		{
			_builder = builder;
		}

		public IAutoConfigurationBuildStage<TObject> OfRegisteredDefault()
		{
			return OfRegistered(IdGenerator<TFactory>.GetDefaultId());
		}

		public IAutoConfigurationBuildStage<TObject> OfRegistered(string objectId)
		{
			_builder.Definition.FactoryObjectName = objectId;
			return _builder;
		}

		public IAutoConfigurationBuildStage<TObject> OfRegistered(ObjectRef<TFactory> reference)
		{
			return OfRegistered(reference.Id);
		}
	}
}