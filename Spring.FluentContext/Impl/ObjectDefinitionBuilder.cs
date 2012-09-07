using System;
using System.Linq.Expressions;
using Spring.FluentContext.Builders;
using Spring.FluentContext.BuildingStages;
using Spring.FluentContext.Utils;
using Spring.Objects.Factory.Support;
using Spring.Objects.Factory.Config;

namespace Spring.FluentContext.Impl
{
	internal class ObjectDefinitionBuilder<TObject> : IScopeBuildStage<TObject>
	{
		private readonly GenericObjectDefinition _definition = new GenericObjectDefinition();
		private readonly ObjectRef<TObject> _ref;

		public ObjectDefinitionBuilder(string objectId)
		{
			_ref = new ObjectRef<TObject>(objectId);
			SetObjectType();
		}

		public GenericObjectDefinition Definition
		{
			get { return _definition; }
		}

		public IInstantiationBuildStage<TObject> AsPrototype()
		{
			_definition.IsSingleton = false;
			return this;
		}

		public IInstantiationBuildStage<TObject> AsSingleton()
		{
			_definition.IsSingleton = true;
			return this;
		}

		public IConfigurationBuildStage<TObject> Autowire()
		{
			return Autowire(AutoWiringMode.AutoDetect);
		}

		public IConfigurationBuildStage<TObject> Autowire(AutoWiringMode mode)
		{
			_definition.AutowireMode = mode;
			return this;
		}

		public IReferencingStage<TObject> CheckDependencies()
		{
			return CheckDependencies(DependencyCheckingMode.All);
		}

		public IReferencingStage<TObject> CheckDependencies(DependencyCheckingMode mode)
		{
			_definition.DependencyCheck = mode;
			return this;
		}

		public IPropertyDefinitionBuilder<TObject, TProperty> BindProperty<TProperty>(Expression<Func<TObject, TProperty>> propertySelector)
		{
			return new PropertyDefinitionBuilder<TObject, TProperty>(this, ReflectionUtils.GetPropertyName(propertySelector));
		}

		public IPropertyDefinitionBuilder<TObject, TProperty> BindPropertyNamed<TProperty>(string propertyName)
		{
			return new PropertyDefinitionBuilder<TObject, TProperty>(this, propertyName);
		}

		public ICtorDefinitionBuilder<TObject, TProperty> BindConstructorArg<TProperty>(int argIndex)
		{
			return new CtorDefinitionBuilder<TObject, TProperty>(this, argIndex);
		}

		public ICtorDefinitionBuilder<TObject, TProperty> BindConstructorArg<TProperty>()
		{
			return new CtorDefinitionBuilder<TObject, TProperty>(this);
		}

		public ILookupMethodDefinitionBuilder<TObject, TResult> BindLookupMethod<TResult>(Expression<Func<TObject, TResult>> methodSelector)
		{
			return new LookupMethodDefinitionBuilder<TObject, TResult>(this, ReflectionUtils.GetMethodName(methodSelector));
		}

		public ILookupMethodDefinitionBuilder<TObject, TResult> BindLookupMethodNamed<TResult>(string methodName)
		{
			return new LookupMethodDefinitionBuilder<TObject, TResult>(this, methodName);
		}

		public ObjectRef<TObject> GetReference()
		{
			return _ref;
		}

		private void SetObjectType()
		{
			_definition.ObjectType = typeof(TObject);
		}
	}
}