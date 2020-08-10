﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Mogre;

namespace OpenMB.Network
{
	public class MpPlayer
	{
		private string playName;
		private TcpClient playerClient;
		private Vector3 playerPos;

		public Vector3 Position
		{
			get { return playerPos; }
			set { playerPos = value; }
		}
		public TcpClient Client
		{
			get { return playerClient; }
			set { playerClient = value; }
		}
		public string Name
		{
			get { return playName; }
			set { playName = value; }
		}
	}
}
