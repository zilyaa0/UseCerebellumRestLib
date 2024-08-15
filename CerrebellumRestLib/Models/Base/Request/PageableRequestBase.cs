using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Linq;

namespace CerebellumRestLib.Models.Base.Request
{
    public class PageableRequestBase: UrlRequestBase
    {
        /// <summary>
        /// Номер страницы
        /// </summary>
        [Description("page")]
        public int? Page { get; set; }

        /// <summary>
        /// Количество записей
        /// </summary>
        [Description("limit")]
        public int? Limit { get; set; }
    }
}
