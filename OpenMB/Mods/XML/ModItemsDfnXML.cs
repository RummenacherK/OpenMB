﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using OpenMB.Game;

namespace OpenMB.Mods.XML
{
	[XmlRoot("Items")]
	public class ModItemsDfnXML
	{
		[XmlElement("Item")]
		public List<ModItemDfnXML> Items { get; set; }
	}

	public class ModItemDfnXML
	{
		[XmlAttribute("damage")]
		public string Damage { get; set; }
		[XmlAttribute("range")]
		public string Range { get; set; }
		[XmlElement("ID")]
		public string ID { get; set; }
		[XmlElement("Desc")]
		public string Desc { get; set; }
		[XmlElement("Model")]
		public string MeshName { get; set; }
		[XmlElement("Type")]
		public string Type { get; set; }
		[XmlArray("Animations")]
		public string[] Animation { get; set; }
		[XmlElement("AttachOptionWhenHave")]
		public ItemHaveAttachOption AttachOptionWhenHave { get; set; }
		[XmlElement("AttachOptionWhenUse")]
		public ItemUseAttachOption AttachOptionWhenUse { get; set; }
		[XmlElement("AmmoCapcity")]
		public int AmmoCapcity { get; set; }
		[XmlElement("AmourNum")]
		public double AmourNum { get; set; }
		[XmlIgnore]
		public string MaterialName { get; set; }
		public string Name { get; set; }

		public ModItemDfnXML()
		{
			AttachOptionWhenHave = ItemHaveAttachOption.IHAO_NO_VALUE;
			AttachOptionWhenUse = ItemUseAttachOption.IAO_NO_VALUE;
		}
	}
}
