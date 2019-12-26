using Bizland.Domain.Core;
using Bizland.Domain.Entities.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Domain.Entities.Commands
{
    public class AddNewRoomCommand : RoomCommand
    {
        public AddNewRoomCommand(string roomName, string alias, int roomCategoryID, int? wardID, int? districtID, int provinceID, int? vipID, int? moreInfomationID, int? paymentID, string thumbnailImage, string moreImages, double? acreage, decimal price, string phone, string address, Guid userID, string description, string content, double? lat, double? lng, int? viewCount, int roomStar, string createdBy, string updatedBy, bool isDeleted, Status status, DateTime dateCreated, DateTime dateModified, string seoPageTitle, string seoAlias, string seoKeywords, string seoDescription, int sortOrder, string tags)
        {
            RoomName = roomName;
            Alias = alias;
            RoomCategoryID = roomCategoryID;
            WardID = wardID;
            DistrictID = districtID;
            ProvinceID = provinceID;
            VipID = vipID;
            MoreInfomationID = moreInfomationID;
            PaymentID = paymentID;
            ThumbnailImage = thumbnailImage;
            MoreImages = moreImages;
            Acreage = acreage;
            Price = price;
            Phone = phone;
            Address = address;
            UserID = userID;
            Description = description;
            Content = content;
            Lat = lat;
            Lng = lng;
            ViewCount = viewCount;
            RoomStar = roomStar;
            CreatedBy = createdBy;
            UpdatedBy = updatedBy;
            IsDeleted = isDeleted;
            Status = status;
            DateCreated = dateCreated;
            DateModified = dateModified;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoKeywords;
            SeoDescription = seoDescription;
            SortOrder = sortOrder;
            Tags = tags;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddNewRoomCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
