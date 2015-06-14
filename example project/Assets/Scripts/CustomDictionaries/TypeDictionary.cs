using System;
using System.Collections.Generic;

public abstract class TypeDictionary<BaseType> : IDictionary<Type, BaseType>
{
	protected readonly Dictionary<Type, BaseType> dictionary = new Dictionary<Type, BaseType>();

	public void Add<T>(T value) where T : BaseType
	{
		dictionary.Add(typeof(T), value);
	}

	public bool TryGet<T>(out BaseType value)
	{
		BaseType enumerable;
		if (dictionary.TryGetValue(typeof(T), out enumerable))
		{
			value = (BaseType)enumerable;
			return true;
		}

		value = default(BaseType);
		return false;
	}

	protected virtual void DefaultAdd(Type key, BaseType value)
	{
		if (key == null)
		{
			throw new ArgumentNullException("key must not be null");
		}

		if (!ChekKeyValueTypeConstrains(key, value))
		{
			throw new ArgumentException(string.Format("value of type {0} can not be assigned to key of type{1}", typeof(BaseType), key));
		}

		dictionary.Add(key, value);
	}

	// use explicit implementation to discourage use of this method since
	// the manual type checking is much slower that the generic version above
	void IDictionary<Type, BaseType>.Add(Type key, BaseType value)
	{
		this.DefaultAdd(key, value);
	}

	protected abstract bool ChekKeyValueTypeConstrains(Type key, BaseType value);


	public int Count
	{
		get { return this.dictionary.Count; }
	}


	public bool ContainsKey(Type key)
	{
		return this.dictionary.ContainsKey(key);
	}

	public ICollection<Type> Keys
	{
		get
		{
			return this.dictionary.Keys;

		}
	}

	public bool Remove(Type key)
	{
		return this.dictionary.Remove(key);
	}

	public bool TryGetValue(Type key, out BaseType value)
	{
		return this.dictionary.TryGetValue(key, out value);
	}

	public ICollection<BaseType> Values
	{
		get { return this.dictionary.Values; }
	}

	public BaseType this[Type key]
	{
		get
		{
			throw new NotImplementedException();
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public System.Collections.IEnumerator GetEnumerator()
	{
		return this.dictionary.GetEnumerator();
	}

	public void Add(KeyValuePair<Type, BaseType> item)
	{
		this.DefaultAdd(item.Key, item.Value);
	}

	public void Clear()
	{
		this.dictionary.Clear();
	}

	public bool Contains(KeyValuePair<Type, BaseType> item)
	{
		bool containsKey = this.dictionary.ContainsKey(item.Key);
		if (!containsKey)
		{
			return false;
		}
		BaseType value = this.dictionary[item.Key];
		if (value != null)
		{
			return value.Equals(item.Value);
		}

		return item.Value == null;
	}

	public void CopyTo(KeyValuePair<Type, BaseType>[] array, int arrayIndex)
	{
		foreach (KeyValuePair<Type, BaseType> keyValuePair in dictionary)
		{
			if (arrayIndex >= array.Length)
			{
				break;
			}
			array[arrayIndex] = new KeyValuePair<Type, BaseType>(keyValuePair.Key, keyValuePair.Value);
			arrayIndex++;
		}
	}

	public bool IsReadOnly
	{
		get { return false; }
	}

	public bool Remove(KeyValuePair<Type, BaseType> item)
	{
		return this.dictionary.Remove(item.Key);
	}

	IEnumerator<KeyValuePair<Type, BaseType>> IEnumerable<KeyValuePair<Type, BaseType>>.GetEnumerator()
	{
		return this.dictionary.GetEnumerator();
	}
}