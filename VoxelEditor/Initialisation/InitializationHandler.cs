﻿using VoxelEditor.Common.Enums;
using VoxelEditor.Core.Controller;
using VoxelEditor.Editor.Model;
using VoxelEditor.Editor.View;
using VoxelEditor.Initialisation.Material;
using VoxelEditor.Menu.Model;
using VoxelEditor.Menu.View;
using VoxelEditor.Registry.Model;
using VoxelEditor.Registry.View;

namespace VoxelEditor.Initialisation
{
	internal class InitializationHandler
	{
		private ModelRegistry _modelRegistry;
		private ViewRegistry _viewRegistry;

		public StateHandler InitializeStateHandler()
		{
			StateHandler stateHandler = new StateHandler();
			stateHandler.AddStateInformation(State.Start, typeof(EditorModel), typeof(EditorView));
			stateHandler.AddStateInformation(State.Menu, typeof(MenuModel), typeof(MenuView));
			stateHandler.AddStateInformation(State.Editor, typeof(EditorModel), typeof(EditorView));
			return stateHandler;
		}

		public ModelRegistry InitalizeModelRegistry()
		{
			if (_modelRegistry == null)
			{
				InitializeRegistry();
			}
			return _modelRegistry;
		}

		public ViewRegistry InitializeViewRegistry()
		{
			if (_viewRegistry == null)
			{
				InitializeRegistry();
			}
			return _viewRegistry;
		}

		private void InitializeRegistry()
		{
			_modelRegistry = new ModelRegistry();
			_viewRegistry = new ViewRegistry();

			//TODO regsiter Materials
		}

		public void RegisterMaterial(int id, MaterialInfo materialInfo)
		{
			_modelRegistry.RegisterMaterial(id, materialInfo.MaterialBehavior);
			_viewRegistry.RegisterMaterial(id, materialInfo.Texture, materialInfo.RenderProperties);
		}
	}
}