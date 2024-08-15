using System;
using System.Collections.Generic;
using System.Linq;
using CerebellumRestLib.Helpers;

namespace CerebellumRestLib.Models.JSON.Requests
{
    /// <summary>
    /// Класс для формирования фильтра на получение списка и статистики задач
    /// </summary>
    public class RequestState
    {
        public List<RequestParameter> RequestParameters { get; } = new List<RequestParameter>();

        public RequestParameter this[string index]
        {
            get
            {
                lock (RequestParameters)
                {
                    return RequestParameters.FirstOrDefault(x => x.RequestString == index);
                }
            }
            set
            {
                AddParameter(value);
            }
        }

        public void AddParameter(RequestParameter parameter)
        {
            lock (RequestParameters)
            {
                var existedElement = RequestParameters.FirstOrDefault(x => x.RequestString == parameter.RequestString);
                if (existedElement != null)
                {
                    RequestParameters.Remove(existedElement);
                }

                RequestParameters.Add(parameter);
            }
        }

        public void AddRange(IEnumerable<RequestParameter> parameters)
        {
            foreach (var requestParameter in parameters)
            {
                AddParameter(requestParameter);
            }
        }

        public string GetUrl()
        {
            lock (RequestParameters)
            {
                return String.Join("&", RequestParameters.Select(x => x.GetUrlEntry()).Where(x => !String.IsNullOrWhiteSpace(x)));
            }
        }

        public Dictionary<string, string> GetParams()
        {
            lock (RequestParameters)
            {
                return RequestParameters
                    .Select(x => x.GetParameters())
                    .Where(x => x.HasValue)
                    .Select(x => x.Value)
                    .ToDictionary(x => x.Key, x => x.Value);
            }
        }
    }

    public abstract class RequestParameter
    {
        protected RequestParameter(string requestString)
        {
            if (String.IsNullOrWhiteSpace(requestString))
            {
                throw new ArgumentException($"Incorrect parameter {nameof(requestString)}.");
            }
            
            RequestString = requestString.Trim();
        }

        public string RequestString { get; }

        public abstract string GetValue();

        public string GetUrlEntry()
        {
            var valueString = GetValue();
            return valueString != null ? $"{RequestString}={valueString}" : String.Empty;
        }

        public KeyValuePair<string, string>? GetParameters()
        {
            var valueString = GetValue();
            return valueString != null 
                ? new KeyValuePair<string, string>(RequestString, valueString) 
                : (KeyValuePair<string, string>?)null;
        }
    }

    public class ValueRequestParameter<T> : RequestParameter
    {
        public ValueRequestParameter(string requestString, T value) : base(requestString)
        {
            Value = value;
        }

        public T Value { get; set; }

        public override string GetValue()
        {
            if (typeof(T) == typeof(DateTime))
            {
                return ((DateTime)(object)Value).GetUnixTime().ToString();
            }
            if (Value is bool)
            {
                return ((bool)(object)Value).ToString().ToLower();
            }

            return Value?.ToString();
        }
    }

    public class ListRequestParameter<T> : RequestParameter
    {
        public ListRequestParameter(string requestString, List<T> list) : base(requestString)
        {
            ValuesList = list;
        }

        public List<T> ValuesList { get; set; }

        public override string GetValue()
        {
            var result = String.Join(",", ValuesList.Select(x => x.ToString()));
            return String.IsNullOrWhiteSpace(result) ? null : result;
        }
    }
}
