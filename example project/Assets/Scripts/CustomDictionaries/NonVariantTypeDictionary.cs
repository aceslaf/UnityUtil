using System;
using UnityEngine;
using System.Collections;

	public class NonVariantTypeDictionary<BaseType> : TypeDictionary<BaseType>
	{
		protected override bool ChekKeyValueTypeConstrains(Type key, BaseType value)
		{
			if (value == null)
			{
				//TODO Decide if nulls are allowed
				return true;
			}



			if (key.Equals(value.GetType()))
			{
				return true;
			}
			return false;
		}

	}

