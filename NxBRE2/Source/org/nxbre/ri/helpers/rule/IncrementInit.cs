namespace org.nxbre.ri.helpers.rule
{
	using System;
	using System.Collections;
	
	using net.ideaity.util;
	using org.nxbre.rule;

	/// <summary> This class is designed to reset increments or decrements
	/// <P>
	/// This class takes the following parameters:</P>
	/// <P>
	/// Examples:</P>
	/// <PRE>
	/// <Rule id="VALUE1" factory="org.nxbre.ri.rule.helpers.IncrementInit">
	/// <Parameter name="Id" value="INC_X"/>
	/// <Parameter name="Init" value="25"/>
	/// </Rule>
	///
	/// <Rule id="VALUE1" factory="org.nxbre.ri.rule.helpers.IncrementInit">
	/// <Parameter name="Id" value="INC_X"/>
	/// <Parameter name="Init" ruleValue="abc"/>
	/// </Rule>
	/// </PRE>
	/// *
	/// </summary>
	/// <author>  David Dossot
	/// </author>
	/// <version>  1.8.2
	/// </version>
	public sealed class IncrementInit : IBRERuleFactory
	{
		public const string INIT = "Init";

		public const string ID = "Id";
		
		/// <summary> If passed the parameter Id and Init it call the Init method of
		/// the Increment
		/// </summary>
		/// <param name="aBrc">- The BRERuleContext object
		/// </param>
		/// <param name="aMap">- The Map of parameters from the XML
		/// </param>
		/// <param name="aStep">- The step that it is on
		/// </param>
		/// <returns> The current value of the index
		/// 
		/// </returns>
		public object ExecuteRule(IBRERuleContext aBrc, Hashtable aMap, object aStep)
		{
			if (!aMap.ContainsKey(ID))
			{
				throw new BRERuleException("Parameter 'Id' not found");
			}
			else if (!aMap.ContainsKey(INIT))
			{
				throw new BRERuleException("Parameter 'Init' not found");
			}
			else
			{
				if (aBrc.FactoryMap.ContainsKey(aMap[ID]))
				{
					((IInitializable)aBrc.GetFactory(aMap[ID])).Init(aMap[INIT]);
				}
				else
				{
					throw new BRERuleException("Increment '"+aMap[ID]+"' not found");				
				}
			}
			return null;
		}
	}
}
