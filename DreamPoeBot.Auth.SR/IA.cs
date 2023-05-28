using System.CodeDom.Compiler;
using System.ServiceModel;
using DreamPoeBot.Auth.Objects;

namespace DreamPoeBot.Auth.SR;

[ServiceContract(ConfigurationName = "SR.IA")]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
internal interface IA
{
	[ServiceKnownType(typeof(r0))]
	[ServiceKnownType(typeof(WoWNpc[]))]
	[ServiceKnownType(typeof(string[]))]
	[ServiceKnownType(typeof(WoWMailboxEx[]))]
	[ServiceKnownType(typeof(WoWMailbox[]))]
	[ServiceKnownType(typeof(UsageInfo))]
	[ServiceKnownType(typeof(object[]))]
	[OperationContract(Action = "http://tempuri.org/IA/Do", ReplyAction = "http://tempuri.org/IA/DoResponse")]
	[ServiceKnownType(typeof(d0))]
	[ServiceKnownType(typeof(WoWFragment))]
	d0 Do(byte b, object[] args);
}
