using AutoMapper;
using ExpressDeliveryApp.Domain;
using ExpressDeliveryApp.DTOs;

namespace ExpressDeliveryApp.AutoMapper;

public class DefaultProfile : Profile
{
    public DefaultProfile()
    {
        CreateMap<CancelTicketDto, Ticket>().ReverseMap();
        CreateMap<TicketDto, Ticket>().ReverseMap();
        CreateMap<RegisterTicketDto, Ticket>().ReverseMap();
        CreateMap<UpdateTicketDto, Ticket>().ReverseMap();
        CreateMap<Ticket,TicketDto>().ReverseMap();
    }
}