//******************************************************************************************************
//  ElementExtensions.cs - Gbtc
//
//  Copyright © 2016, Grid Protection Alliance.  All Rights Reserved.
//
//  Licensed to the Grid Protection Alliance (GPA) under one or more contributor license agreements. See
//  the NOTICE file distributed with this work for additional information regarding copyright ownership.
//  The GPA licenses this file to you under the MIT License (MIT), the "License"; you may
//  not use this file except in compliance with the License. You may obtain a copy of the License at:
//
//      http://opensource.org/licenses/MIT
//
//  Unless agreed to in writing, the subject software distributed under the License is distributed on an
//  "AS-IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. Refer to the
//  License for the specific language governing permissions and limitations.
//
//  Code Modification History:
//  ----------------------------------------------------------------------------------------------------
//  04/19/2016 - Stephen C. Wills
//       Generated original version of source code.
//
//******************************************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GSF;
using GSF.PQDIF;
using GSF.PQDIF.Physical;

namespace PQDIFExplorer
{
    public static class ElementExtensions
    {
        // Sets the value of the element to the given value.
        public static void SetValue(this Element element, string value)
        {
            if (element.TypeOfElement == ElementType.Scalar)
                SetValue((ScalarElement)element, value);
            else if (element.TypeOfElement == ElementType.Vector)
                SetValue((VectorElement)element, value);
        }

        // Sets the value of the scalar element to the given value.
        public static void SetValue(this ScalarElement element, string value)
        {
            string trim = value.Trim();

            Tag tag = Tag.GetTag(element.TagOfElement);

            // Determine whether the tag definition contains
            // a list of identifiers which can be used to
            // display the value in a more readable format
            IReadOnlyCollection<Identifier> identifiers = tag?.ValidIdentifiers ?? new List<Identifier>();

            // Some identifier collections define a set of bitfields which can be
            // combined to represent a collection of states rather than a single value
            // and these are identified by the values being represented in hexadecimal
            List<Identifier> bitFields = identifiers.Where(id => id.Value.StartsWith("0x")).ToList();

            if (bitFields.Count > 0)
            {
                HashSet<string> activeBitFields;
                uint bitSet = 0u;

                trim = value.Trim('{', '}');
                activeBitFields = new HashSet<string>(trim.Split(',').Select(bitField => bitField.Trim()), StringComparer.OrdinalIgnoreCase);

                foreach (Identifier bitField in bitFields)
                {
                    if (activeBitFields.Contains(bitField.Name))
                        bitSet |= Convert.ToUInt32(bitField.Value, 16);
                }

                trim = bitSet.ToString();
            }
            else if (identifiers.Count > 0)
            {
                foreach (Identifier identifier in identifiers)
                {
                    if (identifier.Name == value)
                        trim = identifier.Value;
                }
            }

            if (element.TypeOfValue == PhysicalType.Guid)
                element.SetGuid(Guid.Parse(trim));
            else if (element.TypeOfValue == PhysicalType.Complex8)
                element.SetComplex8(ComplexNumber.Parse(trim));
            else if (element.TypeOfValue == PhysicalType.Complex16)
                element.SetComplex16(ComplexNumber.Parse(trim));
            else
                element.Set(trim);
        }

        // Sets the value of the vector element to the given value.
        public static void SetValue(this VectorElement element, string value)
        {
            string[] values = value.Trim('{', '}').Split(',');

            if (element.TypeOfValue == PhysicalType.Char1)
            {
                byte[] bytes = Encoding.ASCII.GetBytes(value + (char)0);
                element.Size = bytes.Length;
                element.SetValues(bytes, 0);
            }
            else if (element.TypeOfValue == PhysicalType.Char2)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(value + (char)0);
                element.Size = bytes.Length;
                element.SetValues(bytes, 0);
            }
            else
            {
                element.Size = values.Length;

                for (int i = 0; i < values.Length; i++)
                {
                    string trim = values[i].Trim();

                    if (element.TypeOfValue == PhysicalType.Guid)
                        element.SetGuid(i, Guid.Parse(trim));
                    else if (element.TypeOfValue == PhysicalType.Complex8)
                        element.Set(i, ComplexNumber.Parse(trim));
                    else if (element.TypeOfValue == PhysicalType.Complex16)
                        element.Set(i, ComplexNumber.Parse(trim));
                    else
                        element.Set(i, trim);
                }
            }
        }

        // Converts the value of the element to a string representation.
        public static string ValueAsString(this Element element)
        {
            if (element.TypeOfElement == ElementType.Scalar)
                return ValueAsString((ScalarElement)element);

            if (element.TypeOfElement == ElementType.Vector)
                return ValueAsString((VectorElement)element);

            ErrorElement errorElement = element as ErrorElement;
            if (errorElement != null)
                return ValueAsString(errorElement);

            return null;
        }

        // Converts the value of the element to a string representation.
        public static string ValueAsString(this ScalarElement element)
        {
            string identifierName;
            string valueString;

            object value;

            Tag tag;
            IReadOnlyCollection<Identifier> identifiers;
            List<Identifier> bitFields;

            uint bitSet;
            List<string> setBits;

            // Get the value of the element
            // parsed from the PQDIF file
            value = element.Get();

            // Get the tag definition for the element being displayed
            tag = Tag.GetTag(element.TagOfElement);

            // Use the format string specified by the tag
            // or a default format string if not specified
            if (element.TypeOfValue == PhysicalType.Timestamp)
                valueString = string.Format(tag?.FormatString ?? "{0:yyyy-MM-dd HH:mm:ss.fffffff}", value);
            else
                valueString = string.Format(tag?.FormatString ?? "{0}", value);

            // Determine whether the tag definition contains
            // a list of identifiers which can be used to
            // display the value in a more readable format
            identifiers = tag?.ValidIdentifiers ?? new List<Identifier>();

            // Some identifier collections define a set of bitfields which can be
            // combined to represent a collection of states rather than a single value
            // and these are identified by the values being represented in hexadecimal
            bitFields = identifiers.Where(id => id.Value.StartsWith("0x")).ToList();

            if (bitFields.Count > 0)
            {
                // If the value is not convertible,
                // it cannot be converted to an
                // integer to check for bit states
                if (!(value is IConvertible))
                    return valueString;

                // Convert the value to an integer which can
                // then be checked for the state of its bits
                bitSet = Convert.ToUInt32(value);

                // Get the names of the bitfields in the
                // collection of bitfields that are set
                setBits = bitFields
                    .Select(id => new { Name = id.Name, Value = Convert.ToUInt32(id.Value, 16) })
                    .Where(id => bitSet == id.Value || (bitSet & id.Value) > 0u)
                    .Select(id => id.Name)
                    .ToList();

                // If none of the bitfields are set,
                // show just the value by itself
                if (setBits.Count == 0)
                    return valueString;

                // If any of the bitfields are set,
                // display them as a comma-separated
                // list alongside the value
                identifierName = string.Join(", ", setBits);

                return $"{{ {identifierName} }} ({valueString})";
            }

            // Determine if there are any identifiers whose value exactly
            // matches the string representation of the element's value
            identifierName = identifiers.SingleOrDefault(id => id.Value == valueString)?.Name;

            if ((object)identifierName != null)
                return $"{identifierName} ({element.Get()})";

            // If the tag could not be recognized as
            // one that can be displayed in a more
            // readable form, display the value by itself
            return valueString;
        }

        // Converts the value of the element to a string representation.
        public static string ValueAsString(this VectorElement element)
        {
            Tag tag;
            IEnumerable<string> values;
            string format;
            string join;

            // The physical types Char1 and Char2 indicate the value is a string
            if (element.TypeOfValue == PhysicalType.Char1)
                return Encoding.ASCII.GetString(element.GetValues()).Trim((char)0);

            if (element.TypeOfValue == PhysicalType.Char2)
                return Encoding.Unicode.GetString(element.GetValues()).Trim((char)0);

            // Get the tag definition of the element being displayed
            tag = Tag.GetTag(element.TagOfElement);

            // Determine the format in which to display the values
            // based on the tag definition and the type of the value
            if (element.TypeOfValue == PhysicalType.Timestamp)
                format = tag.FormatString ?? "{0:yyyy-MM-dd HH:mm:ss.fffffff}";
            else
                format = tag.FormatString ?? "{0}";

            // Convert the values to their string representations
            values = Enumerable.Range(0, element.Size)
                .Select(index => string.Format(format, element.Get(index)));

            // Join the values in the collection
            // to a single, comma-separated string
            join = string.Join(", ", values);

            // Wrap the string in curly braces and return
            return $"{{ {join} }}";
        }
        
        public static string ValueAsString(this ErrorElement element)
        {
            return element.Exception.Message;
        }
    }
}
