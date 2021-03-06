namespace org.nxbre.ri.drivers {
	using System;
	using System.Xml;

	using net.ideaity.util.events;
	
	using org.nxbre.rule;
	using org.nxbre.util;
	
	/// <summary>
	/// Driver for loading rules files valid against businessRules.xsd (native NxBRE grammar)
	/// </summary>
	/// <author>David Dossot</author>
	/// <remarks>
	///  businessRules.xsd must be included in the assembly.
	/// </remarks>
	public sealed class BusinessRulesFileDriver:AbstractRulesDriver {
		public BusinessRulesFileDriver(string xmlFileURI):base(xmlFileURI) {}
		
		protected override XmlValidatingReader GetReader() {
			if (LogDispatcher != null)
				LogDispatcher.DispatchLog("BusinessRulesFileDriver loading "+xmlSource, LogEventImpl.INFO);
			
			return (XmlValidatingReader) GetXmlInputReader(xmlSource,
			                                               Parameter.GetString("businessrules.xsd", "businessRules.xsd"));
		}
	}
}
