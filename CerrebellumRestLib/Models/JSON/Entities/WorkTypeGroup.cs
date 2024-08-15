using CerebellumRestLib.Models.Base;
using Newtonsoft.Json;

namespace CerebellumRestLib.Models.JSON.Entities
{
    /// <summary>
    /// Sample:
    ///         /*{"groups":[
    ///          * {"id":1,"name":"Регламент"},
    ///          * {"id":2,"name":"Пожарная сигнализация"},
    ///          * {"id":3,"name":"Кнопка Тревожной Сигнализации"},
    ///          * {"id":4,"name":"Видеонаблюдение"},
    ///          * {"id":5,"name":"Система контроля доступа"},
    ///          * {"id":6,"name":"Стрелец-мониторинг"}
    ///          * ]}
    ///          */
    /// 
    /// </summary>
    public class WorkTypeGroup : JsonBase
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
