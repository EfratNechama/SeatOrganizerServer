using AutoMapper;
using Entities;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ourProject
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Event, EventDTO>().ForMember(dest => dest.userAName, opt => opt.MapFrom(src => src.UserA.UserName)).ReverseMap();
            //.ForMember(dest => dest.userBName, opt => opt.MapFrom(src => src.UserB.UserName)).ReverseMap();



            //CreateMap<EventDTO, Event>().ReverseMap();   ;

        }
        //    public AutoMapping()
        //    {
        //        CreateMap<Order, OrderForCalendar>().ForMember(dest =>dest.CustomerName,opt => opt.MapFrom(src => src.Customer.FirstName + " " + src.Customer.LastName))
        //            .ForMember(dest =>
        //            dest.HotelName,
        //            opt => opt.MapFrom(src => src.Hotel.Name)).ReverseMap();

        //        CreateMap<Customer, customerDTO>().ReverseMap();



        //    }
        //}
    }
}
