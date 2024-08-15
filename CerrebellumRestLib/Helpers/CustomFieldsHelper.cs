using System;
using System.Collections.Generic;
using System.Linq;
using CerebellumRestLib.Models.JSON.Entities;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models
{
    public class CustomFieldHelper
    {
        private readonly CustomField[] _customFields;

        private readonly Dictionary<CustomField, object> _customFieldValues;

        public CustomFieldHelper(IEnumerable<CustomField> customFields)
        {
            _customFieldValues = new Dictionary<CustomField, object>();
            _customFields = customFields.ToArray();
        }

        public void AddField(int id, object value)
        {
            var customField = _customFields.FirstOrDefault(x => x.Id == id);

            if (customField == null)
            {
                throw new CustomFieldNotFoundException($"Custom field with id {id} was not found.");
            }

            _customFieldValues[customField] = value;
        }

        public void AddField(CustomField customField, object value)
        {
            AddField(customField.Id, value);
        }

        public string GetString(bool autoSetRequired = false)
        {
            var dict = GetDictionary(autoSetRequired);

            return JsonConvert.SerializeObject(dict);
        }

        public Dictionary<string, FieldData> GetDictionary(bool autoSetRequired = false)
        {
            var result = new Dictionary<string, FieldData>();

            if (autoSetRequired)
            {
                foreach (var customField in _customFields.Where(x => x.IsRequired && _customFieldValues.All(y => y.Key.Id != x.Id)))
                {
                    result.Add(customField.Translit, new FieldData { FieldId = customField.Id, Value = customField.DefaultValue });
                }
            }

            foreach (var customFieldValue in _customFieldValues)
            {
                result.Add(customFieldValue.Key.Translit, new FieldData { FieldId = customFieldValue.Key.Id, Value = customFieldValue.Value});
            }
            
            return result;
        }
    }

    public class CustomFieldNotFoundException : Exception
    {
        public CustomFieldNotFoundException(string message) : base(message)
        {
        }
    }
}
