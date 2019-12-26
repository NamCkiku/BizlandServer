using Bizland.Domain.Core;

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bizland.Domain.Entities
{
    [Table("RoomCategories")]
    public class RoomCategory : AggregateRootWithIdBase<int>,
       IHasSeoMetaData, ISwitchable, ISortable, IDateTracking
    {
        public RoomCategory(string name, string description, int? parentId, int? homeOrder, string image, bool? homeFlag, DateTime dateCreated, DateTime dateModified, int sortOrder, Status status, string seoPageTitle, string seoAlias, string seoKeywords, string seoDescription)
        {
            Name = name;
            Description = description;
            ParentId = parentId;
            HomeOrder = homeOrder;
            Image = image;
            HomeFlag = homeFlag;
            DateCreated = dateCreated;
            DateModified = dateModified;
            SortOrder = sortOrder;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoKeywords;
            SeoDescription = seoDescription;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int? HomeOrder { get; set; }

        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }
        public int SortOrder { set; get; }
        public Status Status { set; get; }
        public string SeoPageTitle { set; get; }
        public string SeoAlias { set; get; }
        public string SeoKeywords { set; get; }
        public string SeoDescription { set; get; }
    }
}