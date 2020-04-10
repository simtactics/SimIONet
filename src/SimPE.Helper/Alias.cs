/***************************************************************************
 *   Copyright (C) 2005 by Ambertation                                     *
 *   quaxi@ambertation.de                                                  *
 *                                                                         *
 *   This program is free software; you can redistribute it and/or modify  *
 *   it under the terms of the GNU General Public License as published by  *
 *   the Free Software Foundation; either version 2 of the License, or     *
 *   (at your option) any later version.                                   *
 *                                                                         *
 *   This program is distributed in the hope that it will be useful,       *
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of        *
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the         *
 *   GNU General Public License for more details.                          *
 *                                                                         *
 *   You should have received a copy of the GNU General Public License     *
 *   along with this program; if not, write to the                         *
 *   Free Software Foundation, Inc.,                                       *
 *   59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.             *
 ***************************************************************************/

using System;
using System.Collections;
using System.IO;
using System.Xml;
using SimPe.Interfaces;

namespace SimPe.Data
{
	/// <summary>
	/// Conects an value with a name
	/// </summary>
	public class StaticAlias : IAlias, IDisposable
	{
		/// <summary>
		/// Cosntructor of the class
		/// </summary>
		/// <param name="val">The id</param>
		/// <param name="name">The name</param>
		public StaticAlias(uint val, string name) : this(val, name, new object[0])
		{			
		}	
		
		~StaticAlias()
		{
			try 
			{
				Dispose();
			} 
			catch {}
		}

		/// <summary>
		/// Cosntructor of the class
		/// </summary>
		/// <param name="val">The id</param>
		/// <param name="name">The name</param>
		/// <param name="tag"></param>
		public StaticAlias(uint val, string name, object[] tag)
		{
			Id = val;
			Name = name;
			Tag = tag;
		}

		/// <summary>
		/// Craetes a String from the Object
		/// </summary>
		/// <returns>Simply Returns the Name Attribute</returns>
		public override string ToString()
		{
			return Name;
		}

		#region IAlias Member

		/// <summary>
		/// The id Value
		/// </summary>
		public uint Id { get; }

		/// <summary>
		/// The long Name
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Stores arbitary Data
		/// </summary>
		public object[] Tag { get; set; }

		#endregion		

		#region IDisposable Member

		public virtual void Dispose()
		{
			Tag = null;
			Name = null;
		}

		#endregion
	}
	/// <summary>
	/// Conects an value with a name
	/// </summary>
	public class Alias : StaticAlias
	{		
		/// <summary>
		/// This is used to format the ToString() Output
		/// </summary>
		private readonly string _template;

		static string DefaultTemplate 
		{
			get 
			{
#if DEBUG
			return "{name} (0x{id})";
#else
			return "{name} (0x{id})";
#endif
			}
		}
		/// <summary>
		/// Cosntructor of the class
		/// </summary>
		/// <param name="val">The id</param>
		/// <param name="name">The name</param>
		public Alias(uint val, string name) : this(val, name, DefaultTemplate)
		{			
		}

		/// <summary>
		/// Cosntructor of the class
		/// </summary>
		/// <param name="val">The id</param>
		/// <param name="name">The name</param>
		/// <param name="tag"></param>
		public Alias(uint val, string name, object[] tag) : this(val, name, tag, DefaultTemplate)
		{
		}

		/// <summary>
		/// Cosntructor of the class
		/// </summary>
		/// <param name="val">The id</param>
		/// <param name="name">The name</param>
		/// <param name="template">The ToString Template</param>
		public Alias(uint val, string name, string template) : this(val, name, null, template)
		{
		}

		/// <summary>
		/// Cosntructor of the class
		/// </summary>
		/// <param name="val">The id</param>
		/// <param name="name">The name</param>
		/// <param name="tag"></param>
		/// <param name="template">The ToString Template</param>
		public Alias(uint val, string name, object[] tag, string template) : base(val, name, tag)
		{
			_template = template;			
		}

		/// <summary>
		/// Craetes a String from the Object
		/// </summary>
		/// <returns>Simply Returns the Name Attribute</returns>
		public override string ToString()
		{
			var ret = _template;

			ret = ret.Replace("{name}", Name);
			ret = ret.Replace("{id}", Id.ToString("X"));

			if (Tag!=null) 
			{
				for (var i=0; i<Tag.Length; i++) 
				{
					var o = Tag[i];
					if (o!=null) ret = ret.Replace($"{{{i}}}", o.ToString());
					else ret = ret.Replace($"{{{i}}}", "");
				}
			}

			return ret;
		}


		#region static Loader
		/// <summary>
		/// Load a List of Aliases form an XML File
		/// </summary>
		/// <param name="flname">Name of the File</param>
		/// <returns>The IAlias List</returns>
		public static IAlias[] LoadFromXml(string flname)
		{
			if (!File.Exists(flname)) return new IAlias[0];

			try 
			{
				//read XML File
				var xmlfile = new XmlDocument();
				xmlfile.Load(flname);

				
				//seek Root Node
				var xmlData = xmlfile.GetElementsByTagName("alias");					

				var list = new ArrayList();
				//Process all Root Node Entries
				for (var i=0; i<xmlData.Count; i++)
				{
					var node = xmlData.Item(i);	
					foreach (XmlNode subnode in node) 
					{
						if (subnode.LocalName.Trim().ToLower()=="item") 
						{
							var sval = subnode.Attributes["value"].Value.Trim();
							uint val = 0;

							if (sval.StartsWith("0x")) val = Convert.ToUInt32(sval, 16);
							else val = Convert.ToUInt32(sval);

							var a = new Alias(val, subnode.InnerText.Trim());
							list.Add(a);
						}
					}
				} // for i			

				var ret = new IAlias[list.Count];
				list.CopyTo(ret);
				return ret;
			}
			catch (Exception ex) 
			{
				Helper.ExceptionMessage("", ex);
			}

			return new IAlias[0];
		}
		#endregion
	}
}
