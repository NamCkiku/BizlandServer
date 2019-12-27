using Bizland.Domain.Core;
using Bizland.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Application.Service.Room.Commands
{
    public abstract class RoomCommand : Command
    {
        public Guid Id { get; protected set; }

        /// <summary>
        /// Tên phòng
        /// </summary>
        public string RoomName { set; get; }

        /// <summary>
        /// đường dẫn url của phòng
        /// </summary>
        public string Alias { set; get; }

        /// <summary>
        /// Loại phòng
        /// </summary>
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
        public string ThumbnailImage { set; get; }

        /// <summary>
        /// Nhiều ảnh
        /// </summary>
        public string MoreImages { get; set; }

        /// <summary>
        /// diện tích
        /// </summary>
        public double? Acreage { get; set; }

        /// <summary>
        /// giá phòng
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// số điện thoại chủ phòng
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// địa chỉ của phòng
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// chủ phòng là gì
        /// </summary>
        public Guid UserID { get; set; }

        /// <summary>
        /// mô tả ngắn của phòng
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// nội dung mô tả của phòng
        /// </summary>
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
        public string CreatedBy { get; set; }

        /// <summary>
        /// người update
        /// </summary>
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

        public string Tags { get; set; }
    }
}
