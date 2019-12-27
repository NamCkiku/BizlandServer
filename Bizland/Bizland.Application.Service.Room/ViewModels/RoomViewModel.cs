using Bizland.Domain.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bizland.Application.Service.Room.ViewModels
{
    public class RoomViewModel
    {
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
