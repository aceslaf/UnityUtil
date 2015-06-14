using System;

public class CovariantTypeDictionary<BaseType> : TypeDictionary<BaseType>
{
	protected override bool ChekKeyValueTypeConstrains(Type key, BaseType value)
	{
		//TODO deside if nulls are asignable
		if (value != null && !key.IsAssignableFrom(value.GetType()))
		{
			return false;
		}

		return true;
	}

	protected override void DefaultAdd(Type key, BaseType value)
	{

		if (key == null)
		{
			throw new ArgumentNullException("key must not be null");
		}

		if (!ChekKeyValueTypeConstrains(key, value))
		{
			throw new ArgumentException(string.Format("value of type {0} can not be assigned to key of type{1}", typeof(BaseType), key));
		}

		if (this.ContainsKey(key))
		{
			this.Remove(key);
		}

		this.dictionary.Add(key, value);
	}
}