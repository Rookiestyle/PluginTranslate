using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

using KeePass.Plugins;
using KeePass.Util;
using KeePassLib.Utility;

namespace PluginTranslationOwn
{
	public static class PluginTranslate
	{
		public static long TranslationVersion = 0;
		#region Definitions of translated texts go here
		public const string PluginName = "PluginName";
		public static string Field
		{
			get
			{
				return TryGet("Field", "Field text");
			}
		}
		#endregion

		#region NO changes in this area
		private static StringDictionary m_translation = new StringDictionary();

		public static void Init(Plugin plugin, string LanguageCodeIso6391)
		{
			try
			{
				if (string.IsNullOrEmpty(LanguageCodeIso6391))
					LanguageCodeIso6391 = "en";
				string filename = GetFilename(plugin.GetType().Namespace, LanguageCodeIso6391);

				if (!File.Exists(filename)) //If e. g. 'plugin.zh-tw.language.xml' does not exist, try 'plugin.zh.language.xml'
				{
					if (LanguageCodeIso6391.Length > 2)
						Init(plugin, LanguageCodeIso6391.Substring(0, 2));
					return;
				}
				else
				{
					string translation = File.ReadAllText(filename);
					XmlSerializer xs = new XmlSerializer(m_translation.GetType());
					m_translation = (StringDictionary)xs.Deserialize(new StringReader(translation));
				}
			}
			catch (Exception) { }
		}

		public static string TryGet(string key, string def)
		{
			string result = string.Empty;
			if (m_translation.TryGetValue(key, out result))
				return result;
			else
				return def;
		}

		private static string GetFilename(string plugin, string lang)
		{
			string filename = UrlUtil.GetFileDirectory(WinUtil.GetExecutable(), true, true);
			filename += KeePass.App.AppDefs.PluginsDir + UrlUtil.LocalDirSepChar + "Translations" + UrlUtil.LocalDirSepChar;
			filename += plugin + "." + lang + ".language.xml";
			return filename;
		}
		#endregion
	}

	#region NO changes in this area
	[XmlRoot("Translation")]
	public class StringDictionary : Dictionary<string, string>, IXmlSerializable
	{
		public System.Xml.Schema.XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
			bool wasEmpty = reader.IsEmptyElement;
			reader.Read();
			if (wasEmpty)
				return;
			bool bFirst = true;
			while (reader.NodeType != XmlNodeType.EndElement)
			{
				if (bFirst)
				{
					bFirst = false;
					try
					{
						reader.ReadStartElement("TranslationVersion");
						PluginTranslate.TranslationVersion = reader.ReadContentAsLong();
						reader.ReadEndElement();
					}
					catch { }
				}

				reader.ReadStartElement("item");
				reader.ReadStartElement("key");
				string key = reader.ReadContentAsString();
				reader.ReadEndElement();
				reader.ReadStartElement("value");
				string value = reader.ReadContentAsString();
				reader.ReadEndElement();
				this.Add(key, value);
				reader.ReadEndElement();
				reader.MoveToContent();
			}
			reader.ReadEndElement();
		}

		public void WriteXml(XmlWriter writer)
		{
			writer.WriteStartElement("TranslationVersion");
			writer.WriteString(PluginTranslate.TranslationVersion.ToString());
			writer.WriteEndElement();
			foreach (string key in this.Keys)
			{
				writer.WriteStartElement("item");
				writer.WriteStartElement("key");
				writer.WriteString(key);
				writer.WriteEndElement();
				writer.WriteStartElement("value");
				writer.WriteString(this[key]);
				writer.WriteEndElement();
				writer.WriteEndElement();
			}
		}
	}
	#endregion
}