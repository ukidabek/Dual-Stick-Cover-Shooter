using BaseGameLogic.Singleton;
using UnityEngine;
using System;

namespace CustomType
{
	[CreateAssetMenu(fileName = "SuperKlasaTypeManager.asset", menuName = "Custom Type/SuperKlasa")]
	public  class SuperKlasaTypeManager : SingletonTypeManager<SuperKlasaTypeManager>
	{
	}
	[SerializableAttribute]
	public  class SuperKlasa : BaseGameLogic.Singleton.Type
	{
	}
}
