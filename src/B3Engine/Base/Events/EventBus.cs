
using System.Collections.Generic;
using System.Reflection;

namespace B3.Events {
	/// <summary>A bus that holds decoupled events, registers objects to listen to events, and emits events to all listeners</summary>
	public sealed class EventBus {
		#region Field Variables
		// Variables
		private Dictionary<System.Type, List<(int, object, MethodInfo)>> events;
		private IGame game;
		private static EventBus instance;
		
		#endregion // Field Variables
		
		#region Public Static Properties
		
		/// <summary>Gets the singleton instance of the event bus</summary>
		public static EventBus Instance { get { return instance; } }
		
		#endregion // Public Static Properties
		
		#region Public Properties
		
		/// <summary>Gets the centralized game class that uses the event bus for decoupled events</summary>
		public IGame Game { get { return this.game; } }
		
		#endregion // Public Properties
		
		#region Public Constructors
		
		/// <summary>A base constructor for setting up the event bus for local use</summary>
		public EventBus() {
			this.events = new Dictionary<System.Type, List<(int, object, MethodInfo)>>();
		}
		
		/// <summary>A base constructor for setting up the event bus</summary>
		/// <param name="game">The game associated with the event bus</param>
		internal EventBus(IGame game) {
			EventBus.instance = this;
			this.game = game;
			this.events = new Dictionary<System.Type, List<(int, object, MethodInfo)>>();
		}
		
		#endregion // Public Constructors
		
		#region Public Methods
		
		/// <summary>Registers the given object to listen to events, if subscribed</summary>
		/// <param name="obj">The object to register event listeners with</param>
		/// <remarks>To register methods, the methods must have the <see cref="B3.Events.SubscribeAttribute"/></remarks>
		public void Register(object obj) {
			if(obj == null) { return; }
			
			// Variables
			System.Type type = obj.GetType();
			MethodInfo[] methods = type.GetMethods();
			ParameterInfo[] parameters;
			System.Type paramType;
			SubscribeAttribute sub;
			
			foreach(MethodInfo info in methods) {
				sub = info.GetCustomAttribute(typeof(SubscribeAttribute)) as SubscribeAttribute;
				parameters = info.GetParameters();
				
				if(sub != null && parameters.Length == 1) {
					paramType = parameters[0].ParameterType;
					
					if(paramType == typeof(EventArgs) || paramType.IsSubclassOf(typeof(EventArgs))) {
						if(!this.events.ContainsKey(paramType)) {
							this.events.Add(paramType, new List<(int, object, MethodInfo)>());
						}
						
						this.events[paramType].Add((sub.Priority, obj, info));
						this.events[paramType].Sort((System.ValueTuple<int, object, MethodInfo> left, System.ValueTuple<int, object, MethodInfo> right) => right.Item1 - left.Item1);
					} 
				}
			}
		}
		
		/// <summary>Registers a delegate method</summary>
		/// <param name="handler">The delegate used to listen to events</param>
		/// <typeparam name="TArgs">The type of event to listen to</typeparam>
		/// <returns>Returns a unique string used to <see cref="B3.Events.EventBus.Unregister{TArgs}(string)"/> the delegate method</returns>
		public string Register<TArgs>(EventHandler<TArgs> handler) where TArgs : EventArgs {
			if(!this.events.ContainsKey(typeof(TArgs))) {
				this.events.Add(typeof(TArgs), new List<(int, object, MethodInfo)>());
			}
			this.events[typeof(TArgs)].Add((0, handler.Target, handler.Method));
			
			return $"0-{handler.Target}-{handler.Method}";
		}
		
		/// <summary>Removes all registered event listeners</summary>
		/// <param name="obj">The object used to register event listeners</param>
		public void Unregister(object obj) {
			if(obj == null) { return; }
			
			// Variables
			System.Type type = obj.GetType();
			MethodInfo[] methods = type.GetMethods();
			ParameterInfo[] parameters;
			System.Type paramType;
			SubscribeAttribute sub;
			
			foreach(MethodInfo info in methods) {
				sub = info.GetCustomAttribute(typeof(SubscribeAttribute)) as SubscribeAttribute;
				parameters = info.GetParameters();
				
				if(sub != null && parameters.Length == 1) {
					paramType = parameters[0].ParameterType;
					if(paramType == typeof(EventArgs) || paramType.IsSubclassOf(typeof(EventArgs))) {
						if(this.events.ContainsKey(paramType)) {
							// Variables
							int index = this.events[paramType].FindIndex(0, this.events[paramType].Count, ((int, object, MethodInfo) item) => (item.Item1 == sub.Priority && item.Item3 == info));
							
							if(index != -1) {
								this.events[paramType].RemoveAt(index);
							}
						}
					}
				}
			}
		}
		
		/// <summary>Unregisters the delegate method given it's unique id retrieved from <see cref="B3.Events.EventBus.Register{TArgs}(EventHandler{TArgs})"/></summary>
		/// <param name="id">The unique id used to identify the delegate method</param>
		/// <typeparam name="TArgs">The type of event to unregister from</typeparam>
		/// <returns>Returns true if the listener was unregistered</returns>
		public bool Unregister<TArgs>(string id) where TArgs : EventArgs {
			// Variables
			System.Type type = typeof(TArgs);
			
			if(this.events.ContainsKey(type)) {
				// Variables
				int index = this.events[type].FindIndex(0, this.events[type].Count, ((int, object, MethodInfo) item) => (id == $"{item.Item1}-{item.Item2}-{item.Item3}"));
				
				if(index != -1) {
					this.events[type].RemoveAt(index);
					return true;
				}
			}
			return false;
		}
		
		/// <summary>Emits the event to all that are listening</summary>
		/// <param name="args">The arguments that the listeners will use</param>
		/// <typeparam name="TArgs">The type of event to emit</typeparam>
		public void Emit<TArgs>(TArgs args) where TArgs : EventArgs {
			if(!this.events.ContainsKey(typeof(TArgs))) { return; }
			
			// Variables
			List<(int, object, MethodInfo)> evs = this.events[typeof(TArgs)];
			
			if(evs != null) {
				foreach((int, object, MethodInfo) ev in evs) {
					if(args.shouldStopPropagation) {
						break;
					}
					ev.Item3.Invoke(ev.Item2, new object[] { args });
				}
			}
		}
		
		#endregion // Public Methods
	}
}
