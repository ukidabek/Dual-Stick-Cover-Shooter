using UnityEditor;
using BaseGameLogic.Singleton;
using UnityEngine;
using UnityEditor;
namespace CustomType
{
	[CustomPropertyDrawer(typeof(SuperKlasa), true)]
	public  class SuperKlasaPropertyDrower : TypePropertyDrower<SuperKlasaTypeManager>
	{
	}
}
