﻿using OpenMB.Game;
using OpenMB.Mods;
using OpenMB.Script.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMB.Script
{
	public class ScriptTrigger
	{
		public static float TRIGGER_ONCE = -1;

		public string TriggerCondition { get; set; }
		public float CurrentDelay { get; set; }
		public float CurrentFrozen { get; set; }
		public object[] Parameters { get; set; }

		public string Name { get; set; }

		public float delayTime { get; set; }

		public float frozenTime { get; set; }

		public event Action<ScriptTrigger> ExecuteCompleted;

		public List<IScriptCommand> Content { get; set; }

		public ScriptTrigger()
		{
			CurrentDelay = -1;
		}

		public void Execute(params object[] executeArgs)
		{
			if (TriggerCondition != "0" && !string.IsNullOrEmpty(TriggerCondition))
			{
				GameWorld world = executeArgs[0] as GameWorld;
				var triggerConditions = world.ModData.ModTriggerConditions.Where(o => o.Name == TriggerCondition);
				if (triggerConditions.Count() > 0)
				{
					var triggerCondition = triggerConditions.ElementAt(0);
					triggerCondition.CheckCondition(world.ModData, executeArgs);
				}
			}

			for (int i = 0; i < Content.Count; i++)
			{
				Content[i].Execute(executeArgs);
			}
			if (ExecuteCompleted != null)
			{
				ExecuteCompleted(this);
			}
		}
	}
}
