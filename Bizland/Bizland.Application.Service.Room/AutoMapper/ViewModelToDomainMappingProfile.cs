using AutoMapper;
using Bizland.Application.Service.Room.ViewModels;
using Bizland.Domain.Entities.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bizland.Application.Service.Room.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RoomViewModel, AddNewRoomCommand>()
                .ConstructUsing(c => new AddNewRoomCommand(c.RoomName, c.Alias, c.RoomCategoryID, c.WardID, c.DistrictID, c.ProvinceID, c.VipID, c.MoreInfomationID, c.PaymentID,
                c.ThumbnailImage, c.MoreImages, c.Acreage, c.Price, c.Phone, c.Address, c.UserID, c.Description, c.Content, c.Lat, c.Lng, c.ViewCount, c.RoomStar, c.CreatedBy, c.UpdatedBy, c.IsDeleted, c.Status,
                c.DateCreated, c.DateModified, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription, c.SortOrder, c.Tags));

            CreateMap<AddNewRoomCommand, Bizland.Domain.Entities.Room>()
               .ConstructUsing(c => new Bizland.Domain.Entities.Room(c.RoomName, c.Alias, c.RoomCategoryID, c.WardID, c.DistrictID, c.ProvinceID, c.VipID, c.MoreInfomationID, c.PaymentID,
               c.ThumbnailImage, c.MoreImages, c.Acreage, c.Price, c.Phone, c.Address, c.UserID, c.Description, c.Content, c.Lat, c.Lng, c.ViewCount, c.RoomStar, c.CreatedBy, c.UpdatedBy, c.IsDeleted, c.Status,
               c.DateCreated, c.DateModified, c.SeoPageTitle, c.SeoAlias, c.SeoKeywords, c.SeoDescription, c.SortOrder, c.Tags));
            //CreateMap<CustomerViewModel, UpdateCustomerCommand>()
            //    .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));
        }
    }
}
