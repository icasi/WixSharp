#region Licence...
/*
The MIT License (MIT)
Copyright (c) 2014 Oleg Shilo
Permission is hereby granted, 
free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
*/
#endregion
using System;
using System.Linq;
using Microsoft.Win32;

namespace WixSharp
{
    public partial class RegFile : WixObject
    {
        public string Path = null;
        public RegFile()
        {
        }

        public RegFile(string path)
        {
            Path = path;
        }
    }

    /// <summary>
    /// Defines registry value to be installed.
    /// </summary>
    ///<example>The following is a complete example of the setup, for installing a file and two 
    ///registry values (string value <c>Message</c> and integer value <c>Count</c> ).
    ///<code>
    ///static public void Main(string[] args)
    ///{
    ///     var project = new Project("MyProduct",
    ///     
    ///             new Dir(@"%ProgramFiles%\My Company\My Product",
    ///                 new File(@"readme.txt")),
    ///         
    ///             new RegValue(RegistryHive.LocalMachine, "Software\\My Company\\My Product", "Message", "Hello"),
    ///             new RegValue(RegistryHive.LocalMachine, "Software\\My Company\\My Product", "Count", 777));
    ///             
    ///     Compiler.BuildMsi(project);
    /// }
    /// </code>
    /// </example>
    public partial class RegValue : WixEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegValue"/> class.
        /// </summary>
        public RegValue() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="RegValue"/> class with properties initialized with specified parameters.
        /// </summary>
        /// <param name="key">The registry key name.</param>
        /// <param name="name">The registry entry name.</param>
        /// <param name="value">The registry entry value.</param>
        public RegValue(string key, string name, object value)
        {
            Name = name;
            Key = key;
            Value = value;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RegValue"/> class with properties initialized with specified parameters.
        /// </summary>
        /// <param name="root">The registry hive name.</param>
        /// <param name="key">The registry key name.</param>
        /// <param name="name">The registry entry name.</param>
        /// <param name="value">The registry entry value.</param>
        public RegValue(RegistryHive root, string key, string name, object value)
        {
            Name = name;
            Root = root;
            Key = key;
            Value = value;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RegValue"/> class with properties initialized with specified parameters.
        /// </summary>
        /// <param name="feature"><see cref="Feature"></see> the file should be included in.</param>
        /// <param name="root">The registry hive name.</param>
        /// <param name="key">The registry key name.</param>
        /// <param name="name">The registry entry name.</param>
        /// <param name="value">The registry entry value.</param>
        public RegValue(Feature feature, RegistryHive root, string key, string name, object value)
        {
            Name = name;
            Root = root;
            Key = key;
            Value = value;
            Feature = feature;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RegValue"/> class with properties initialized with specified parameters.
        /// </summary>
        /// <param name="id">The explicit <see cref="Id"></see> to be associated with <see cref="RegValue"/> instance.</param>
        /// <param name="key">The registry key name.</param>
        /// <param name="name">The registry entry name.</param>
        /// <param name="value">The registry entry value.</param>
        public RegValue(Id id, string key, string name, object value)
        {
            Id = id.Value;
            Name = name;
            Key = key;
            Value = value;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RegValue"/> class with properties initialized with specified parameters.
        /// </summary>
        /// <param name="id">The explicit <see cref="Id"></see> to be associated with <see cref="RegValue"/> instance.</param>
        /// <param name="root">The registry hive name.</param>
        /// <param name="key">The registry key name.</param>
        /// <param name="name">The registry entry name.</param>
        /// <param name="value">The registry entry value.</param>
        public RegValue(Id id, RegistryHive root, string key, string name, object value)
        {
            Id = id.Value;
            Name = name;
            Root = root;
            Key = key;
            Value = value;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="RegValue"/> class with properties initialized with specified parameters.
        /// </summary>
        /// <param name="id">The explicit <see cref="Id"></see> to be associated with <see cref="RegValue"/> instance.</param>
        /// <param name="feature"><see cref="Feature"></see> the file should be included in.</param>
        /// <param name="root">The registry hive name.</param>
        /// <param name="key">The registry key name.</param>
        /// <param name="name">The registry entry name.</param>
        /// <param name="value">The registry entry value.</param>
        public RegValue(Id id, Feature feature, RegistryHive root, string key, string name, object value)
        {
            Id = id.Value;
            Name = name;
            Root = root;
            Key = key;
            Value = value;
            Feature = feature;
        }

        /// <summary>
        /// The registry hive name.
        /// <para>Default value is <c>RegistryHive.CurrentUser</c></para>
        /// </summary>
        public RegistryHive Root = RegistryHive.CurrentUser;
        /// <summary>
        /// The registry key name.
        /// <para>Default value is <c>String.Empty</c></para>
        /// </summary>
        public string Key = "";
        /// <summary>
        /// The registry entry value.
        /// </summary>
        public object Value = null;
        /// <summary>
        /// <see cref="Feature"></see> the registry value is included in.
        /// </summary>
        public Feature Feature;
        /// <summary>
        /// Defines the installation <see cref="Condition"/>, which is to be checked during the installation to 
        /// determine if the registry value should be created on the target system.
        /// </summary>
        public Condition Condition;
        /// <summary>
        /// Facilitates the installation of packages that include both 32-bit and 64-bit components. 
        /// Set this attribute to 'yes' to mark the corresponding RegValue as a 64-bit component. 
        /// </summary>
        public bool Win64 = false;

        internal string RegValueString
        {
            get
            {
                if (Value is byte[])
                {
                    string hex = BitConverter.ToString(Value as byte[]);
                    return hex.Replace("-", "");
                }
                else
                {
                    return Value.ToString();
                }
            }
        }

        internal string RegTypeString
        {
            get
            {
                if (Value is String)
                {
                    var value = Value as string;
                    if (value.Contains("\n"))
                        return "multiString";
                    else if (value.Contains("%"))
                        return "expandable";
                    else
                        return "string";
                }
                else if (Value is byte[])
                {
                    return "binary";
                }
                else if (Value is Int16 || Value is Int32)
                {
                    return "integer";
                }
                else
                {
                    return "unsupported type";
                }
            }
        }
    }
}
