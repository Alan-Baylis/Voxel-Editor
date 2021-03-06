﻿using System;
using System.Collections.Generic;

namespace MVCCore.Handlers
{
	public class StateHandler
	{
        		private readonly Dictionary<int, (Type ModelType, Type ViewType)> _stateInformation;

		public StateHandler()
		{
			_stateInformation = new Dictionary<int, (Type ModelType, Type ViewType)>();
		}

		public void AddStateInformation(int state, Type modelType, Type viewType)
		{
			_stateInformation.Add(state, (modelType, viewType));
		}

		/// <summary>
		/// Returns the ModelType and ViewType bound to the given State
		/// </summary>
		/// <param name="state"></param>
		/// <returns>A tuple containing ModelType and ViewType</returns>
		public (Type ModelType, Type ViewType) GetStateInformation(int state)
		{
			return _stateInformation[state];
		}
	}
}
