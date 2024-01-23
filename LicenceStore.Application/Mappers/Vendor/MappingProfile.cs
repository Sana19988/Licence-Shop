using AutoMapper;
using LicenceStore.Application.Common.Dto;
using LicenceStore.Application.Common.Dto.Vendor;

namespace LicenceStore.Application.Mappers.Vendor;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<CreateVendorDto, Domain.Entities.Vendor>().ReverseMap();
        CreateMap<UpdateVendorDto, Domain.Entities.Vendor>().ReverseMap();
        CreateMap<Domain.Entities.Vendor, VendorDetailsDto>().ConstructUsing(x => GetVendorDetails(x));
        CreateMap<IEnumerable<Domain.Entities.Vendor>, VendorListDto>()
            .ConstructUsing(x => GetVendorList(x));
        CreateMap<IEnumerable<Domain.Entities.Vendor>, VendorPagedListDto>()
            .ConstructUsing(v => GetVendorPagedList(v));
    }

    private static VendorDetailsDto GetVendorDetails(Domain.Entities.Vendor vendor)
    {
        return new VendorDetailsDto(vendor.Name, vendor.Active);
    }

    private static VendorListDto GetVendorList(IEnumerable<Domain.Entities.Vendor> vendors)
    {
        var vendorList = vendors.Select(GetVendorDetails).ToList();
        
        return new VendorListDto(vendorList);
    }
    
    private static VendorPagedListDto GetVendorPagedList(IEnumerable<Domain.Entities.Vendor> vendors)
    {
        var vendorList = vendors.Select(GetVendorDetails).ToList();
        
        return new VendorPagedListDto(vendorList, new PaginationDto(0, 0));
    }
}