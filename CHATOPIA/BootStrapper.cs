using Autofac;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CHATOPIA {
	class Bootstrapper : BootstrapperBase {
		// Constructor
		//		Start Application

		IContainer _Container;
		public Bootstrapper() {
			this.StartRuntime();
		}

		// Override the OnStartup() Method
		//		call the base class.
		//		Call for displaying the root shell (the ShellViewModel.cs)

		protected override void OnStartup(object sender, System.Windows.StartupEventArgs e) {

			base.OnStartup(sender, e);
			DisplayRootViewFor<ViewModels.ShellViewModel>();

		}

		// Override Configure()
		//		Configure Autofac
		//			Register IEventAggregator, IWindowManager as Singletons
		//			Register Conventions based stuff
		//			Register modules.

		protected override void Configure() {

			var builder = new ContainerBuilder();
			var asm = Assembly.GetExecutingAssembly();

			builder.RegisterAssemblyTypes(asm)
				.Where(t => t.Name.EndsWith("ViewModel"))
				.AsSelf();

			builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();
			builder.RegisterType<WindowManager>().As<IWindowManager>().SingleInstance();

			_Container = builder.Build();
		}

		// Override GetInstance()
		//		use IoC container to get instances
		protected override object GetInstance(System.Type service, string key) {
			object instance;
			if (string.IsNullOrEmpty(key)) {
				if (_Container.TryResolve(service, out instance)) {
					return instance;
				}
			} else {
				if (_Container.TryResolveNamed(key, service, out instance)) {
					return instance;
				}
			}
			throw new Exception(string.Format("Could not locate any instances of service {0} with key \"{1}\".", service.Name, key));
		}

		// Override GetAllInstances()
		//		Use IoC container to get "all" instances
		protected override IEnumerable<object> GetAllInstances(Type service) {
			IEnumerable<object> result = _Container.Resolve(typeof(IEnumerable<>).MakeGenericType(service)) as IEnumerable<object>;
			return result;
		}

		// Override BuildUp()
		//		Use IoC container to buildup instance passed into routine.

		protected override void BuildUp(object instance) {

			_Container.InjectProperties(instance);

		}
	}
}
