using System;
using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class TypeaheadApiView : BaseApiView
    {
        public IEnumerable<TypeaheadOptionalApiView> options { get; set; }

        public TypeaheadApiView(int page, int pageSize, int totalCount, IEnumerable<TypeaheadOptionalApiView> options, string order)
        {
            this.Offset = page;
            this.TotalCount = totalCount;
            this.Limit = pageSize;
            this.options = options;
            this.Order = order;
        }

    }

    public class TypeaheadOptionalApiView
    {
        public Guid key { get; set; }
        public string value { get; set; }
    }
}
