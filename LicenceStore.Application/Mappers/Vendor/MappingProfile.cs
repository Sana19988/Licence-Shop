using AutoMapper;
using LicenceStore.Application.Common.Dto.Vendor;

namespace LicenceStore.Application.Mappers.Vendor;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<CreateVendorDto, Domain.Entities.Vendor>().ReverseMap();
        CreateMap<UpdateVendorDto, Domain.Entities.Vendor>().ReverseMap();
        CreateMap<Domain.Entities.Vendor, VendorDetailsDto>().ConstructUsing(x => GetVendorDetails(x));
        CreateMap<IEnumerable<Domain.Entities.Vendor>, VendorListDto>().ConstructUsing(x => GetVendorList(x));

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
    
    // TODO Paginacija 
}