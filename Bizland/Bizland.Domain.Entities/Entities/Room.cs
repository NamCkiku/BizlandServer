using Bizland.Domain.Core;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bizland.Domain.Entities
{
    [Table("Rooms")]
    public class Room : AggregateRootBase, ISwitchable, IDateTracking,
        IHasSeoMetaData, IHasSoftDelete, ISortable, IUserTracking
    {
        //public Room(string roomName, string alias, int roomCategoryID, int? wardID, int? districtID, int provinceID, int? vipID, int? moreInfomationID, int? paymentID, string thumbnailImage, string moreImages, double? acreage, decimal price, string phone, string address, Guid userID, string description, string content, double? lat, double? lng, int? viewCount, int roomStar, string createdBy, string updatedBy, bool isDeleted, Status status, DateTime dateCreated, DateTime dateModified, string seoPageTitle, string seoAlias, string seoKeywords, string seoDescription, int sortOrder, string tags)
        //{
        //    RoomName = roomName;
        //    Alias = alias;
        //    RoomCategoryID = roomCategoryID;
        //    WardID = wardID;
        //    DistrictID = districtID;
        //    ProvinceID = provinceID;
        //    VipID = vipID;
        //    MoreInfomationID = moreInfomationID;
        //    PaymentID = paymentID;
        //    ThumbnailImage = thumbnailImage;
        //    MoreImages = moreImages;
        //    Acreage = acreage;
        //    Price = price;
        //    Phone = phone;
        //    Address = address;
        //    UserID = userID;
        //    Description = description;
        //    Content = content;
        //    Lat = lat;
        //    Lng = lng;
        //    ViewCount = viewCount;
        //    RoomStar = roomStar;
        //    CreatedBy = createdBy;
        //    UpdatedBy = updatedBy;
        //    IsDeleted = isDeleted;
        //    Status = status;
        //    DateCreated = dateCreated;
        //    DateModified = dateModified;
        //    SeoPageTitle = seoPageTitle;
        //    SeoAlias = seoAlias;
        //    SeoKeywords = seoKeywords;
        //    SeoDescription = seoDescription;
        //    SortOrder = sortOrder;
        //    Tags = tags;
        //}

        /// <summary>
        /// Tên phòng
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string RoomName { set; get; }

        /// <summary>
        /// đường dẫn url của phòng
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Alias { set; get; }

        /// <summary>
        /// Loại phòng
        /// </summary>
        [Required]
        public int RoomCategoryID { set; get; }

        /// <summary>
        /// địa chỉ xã phường
        /// </summary>
        public int? WardID { get; set; }

        /// <summary>
        /// địa chỉ quận huyện
        /// </summary>
        public int? DistrictID { get; set; }

        /// <summary>
        /// địa chỉ tỉnh thành phố
        /// </summary>
        [Required]
        public int ProvinceID { get; set; }

        /// <summary>
        /// Phòng này thuộc vip nào
        /// </summary>
        public int? VipID { get; set; }

        /// <summary>
        /// các thông tin thêm
        /// </summary>
        public int? MoreInfomationID { get; set; }

        /// <summary>
        /// ID thanh toán
        /// </summary>
        public int? PaymentID { get; set; }

        /// <summary>
        /// Anh phong
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string ThumbnailImage { set; get; }

        /// <summary>
        /// Nhiều ảnh
        /// </summary>
        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        /// <summary>
        /// diện tích
        /// </summary>
        [Required]
        public double? Acreage { get; set; }

        /// <summary>
        /// giá phòng
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// số điện thoại chủ phòng
        /// </summary>
        [Required]
        [StringLength(20)]
        public string Phone { get; set; }

        /// <summary>
        /// địa chỉ của phòng
        /// </summary>
        [Required]
        [StringLength(256)]
        public string Address { get; set; }

        /// <summary>
        /// chủ phòng là gì
        /// </summary>
        [Required]
        public Guid UserID { get; set; }

        /// <summary>
        /// mô tả ngắn của phòng
        /// </summary>
        [StringLength(500)]
        public string Description { get; set; }

        /// <summary>
        /// nội dung mô tả của phòng
        /// </summary>
        [Required]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        /// <summary>
        ///vị trí Lat
        /// </summary>
        public double? Lat { get; set; }

        /// <summary>
        /// vị trí lng
        /// </summary>
        public double? Lng { get; set; }

        /// <summary>
        /// số lượt xem
        /// </summary>
        public int? ViewCount { set; get; }

        /// <summary>
        /// số sao của phòng
        /// </summary>
        public int RoomStar { set; get; }

        /// <summary>
        /// người tạo
        /// </summary>
        [StringLength(256)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// người update
        /// </summary>
        [StringLength(256)]
        public string UpdatedBy { get; set; }

        /// <summary>
        /// đã xóa ?
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// trạng thái kích hoạt/không kích hoạt
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// ngày tạo
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// ngày sửa
        /// </summary>
        public DateTime DateModified { get; set; }

        public string SeoPageTitle { get; set; }

        public string SeoAlias { get; set; }

        public string SeoKeywords { get; set; }

        public string SeoDescription { get; set; }

        /// <summary>
        /// sắp xếp
        /// </summary>
        public int SortOrder { get; set; }

        [StringLength(255)]
        public string Tags { get; set; }
    }
}