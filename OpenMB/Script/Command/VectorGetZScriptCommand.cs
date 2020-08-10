﻿using OpenMB.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenMB.Script.Command
{
	public class VectorGetZScriptCommand : ScriptCommand
	{
		public VectorGetZScriptCommand()
		{
			commandArgs = new string[] {
				"value",
				"Vector"
			};
		}
		private string[] commandArgs;
		public override string[] CommandArgs
		{
			get
			{
				return commandArgs;
			}
		}

		public override string CommandName
		{
			get
			{
				return "vector_get_z";
			}
		}

		public override ScriptCommandType CommandType
		{
			get
			{
				return ScriptCommandType.Line;
			}
		}

		public override void Execute(params object[] executeArgs)
		{
			GameWorld world = executeArgs[0] as GameWorld;
			string vectorVariable = CommandArgs[0].ToString();
			string value = CommandArgs[1].ToString();

			ScriptLinkTableNode vector = world.GlobalValueTable.GetRecord(vectorVariable);
			if (vector != null)
			{
				Context.ChangeLocalValue(value.Substring(1), vector.NextNodes[2].Value);
			}
		}
	}
}
