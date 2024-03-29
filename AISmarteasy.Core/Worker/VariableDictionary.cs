﻿using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace AISmarteasy.Core;

public sealed class VariableDictionary : IDictionary<string, string>
{
    public string Input => _variables[INPUT];
    public string Context => _variables[CONTEXT];

    public VariableDictionary(string? value = null)
    {
        _variables[INPUT] = string.Empty;
        _variables[CONTEXT] = string.Empty;
    }

    public VariableDictionary Clone()
    {
        var clone = new VariableDictionary();
        foreach (KeyValuePair<string, string> x in _variables)
        {
            clone.Set(x.Key, x.Value);
        }

        return clone;
    }

    public VariableDictionary UpdateInput(string value)
    {
        _variables[INPUT] = value;
        return this;
    }

    public VariableDictionary UpdateContext(string value)
    {
        if(_variables[CONTEXT] !=string.Empty)
            value = " " + value;

        _variables[CONTEXT] += value;
        return this;
    }

    public VariableDictionary Update(VariableDictionary newData, bool merge = true)
    {
        if (ReferenceEquals(this, newData)) return this;

        if (!merge) { _variables.Clear(); }

        foreach (KeyValuePair<string, string> varData in newData._variables)
        {
            _variables[varData.Key] = varData.Value;
        }

        return this;
    }

    public void Set(string name, string? value)
    {
        Verifier.NotNullOrWhitespace(name);
        if (value != null)
        {
            _variables[name] = value;
        }
        else
        {
            _variables.TryRemove(name, out _);
        }
    }

    public bool TryGetValue(string name, [NotNullWhen(true)] out string? value)
    {
        if (_variables.TryGetValue(name, out value))
        {
            return true;
        }

        value = null;
        return false;
    }

    public string this[string name]
    {
        get => _variables[name];
        set => _variables[name] = value;
    }

    public bool ContainsKey(string name)
    {
        return _variables.ContainsKey(name);
    }

    public override string ToString() => Input;

    public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => _variables.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => _variables.GetEnumerator();
    void IDictionary<string, string>.Add(string key, string value) => ((IDictionary<string, string>)_variables).Add(key, value);
    bool IDictionary<string, string>.Remove(string key) => ((IDictionary<string, string>)_variables).Remove(key);
    void ICollection<KeyValuePair<string, string>>.Add(KeyValuePair<string, string> item) => ((ICollection<KeyValuePair<string, string>>)_variables).Add(item);
    void ICollection<KeyValuePair<string, string>>.Clear() => ((ICollection<KeyValuePair<string, string>>)_variables).Clear();
    bool ICollection<KeyValuePair<string, string>>.Contains(KeyValuePair<string, string> item) => ((ICollection<KeyValuePair<string, string>>)_variables).Contains(item);
    void ICollection<KeyValuePair<string, string>>.CopyTo(KeyValuePair<string, string>[] array, int arrayIndex) => ((ICollection<KeyValuePair<string, string>>)_variables).CopyTo(array, arrayIndex);
    bool ICollection<KeyValuePair<string, string>>.Remove(KeyValuePair<string, string> item) => ((ICollection<KeyValuePair<string, string>>)_variables).Remove(item);
    ICollection<string> IDictionary<string, string>.Keys => ((IDictionary<string, string>)_variables).Keys;
    ICollection<string> IDictionary<string, string>.Values => ((IDictionary<string, string>)_variables).Values;
    int ICollection<KeyValuePair<string, string>>.Count => ((ICollection<KeyValuePair<string, string>>)_variables).Count;
    bool ICollection<KeyValuePair<string, string>>.IsReadOnly => ((ICollection<KeyValuePair<string, string>>)_variables).IsReadOnly;

    string IDictionary<string, string>.this[string key]
    {
        get => ((IDictionary<string, string>)_variables)[key];
        set => ((IDictionary<string, string>)_variables)[key] = value;
    }

    internal const string INPUT = "input";
    internal const string CONTEXT = "context";

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    internal string DebuggerDisplay =>
        TryGetValue(INPUT, out string? input) && !string.IsNullOrEmpty(input)
            ? $"Variables = {_variables.Count}, Input = {input}"
            : $"Variables = {_variables.Count}";

    private readonly ConcurrentDictionary<string, string> _variables = new(StringComparer.OrdinalIgnoreCase);

    private sealed class TypeProxy
    {
        private readonly VariableDictionary _variables;

        public TypeProxy(VariableDictionary variables) => _variables = variables;

        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public KeyValuePair<string, string>[] Items => _variables._variables.ToArray();
    }
}
