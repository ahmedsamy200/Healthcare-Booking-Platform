using AutoMapper;
using Domain;

namespace Web.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorViewModel>().ForMember(dest =>
           dest.city,
            opt => opt.MapFrom(src => src.City.city))
                .ReverseMap();


            CreateMap<Offer, OfferViewModel>().ForMember(dest =>
            dest.address,
            opt => opt.MapFrom(src => src.Doctor.address))
           .ForMember(dest =>
            dest.doctorName,
            opt => opt.MapFrom(src => src.Doctor.name))
            .ForMember(dest =>
            dest.doctorImage,
            opt => opt.MapFrom(src => src.Doctor.photo))
            .ForMember(dest =>
            dest.city,
            opt => opt.MapFrom(src => src.Doctor.City.city))
            .ReverseMap();
         

            CreateMap<Specialization, SpecializationViewModel>().ReverseMap();
            CreateMap<ContactUs, ContactUsViewModel>().ReverseMap();

            CreateMap<Appointments, AppointmentsViewModel>().ForMember(dest =>
            dest.name,
            opt => opt.MapFrom(src => src.User.name))
            .ForMember(dest =>
            dest.doctorName,
            opt => opt.MapFrom(src => src.Doctor.name))
            .ForMember(dest =>
            dest.userPhone,
            opt => opt.MapFrom(src => src.User.phone))
            .ForMember(dest =>
            dest.address,
            opt => opt.MapFrom(src => src.Doctor.address)).ReverseMap();

            CreateMap<City, CityViewModel>().ReverseMap();

            CreateMap<DoctorAppointments, DoctorAppointmentsViewModel>().ForMember(dest =>
            dest.doctorName,
            opt => opt.MapFrom(src => src.Doctor.name))
            .ForMember(dest =>
            dest.address,
            opt => opt.MapFrom(src => src.Doctor.address)).ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
