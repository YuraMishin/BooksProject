using AutoMapper;
using Domain;

namespace Application.Activities
{
  /// <summary>
  /// Class MappingProfile.
  /// Implements scheme for mapping
  /// </summary>
  public class MappingProfile : Profile
  {
    /// <summary>
    /// Method maps entities
    /// </summary>
    public MappingProfile()
    {
      CreateMap<Book, Book>();
    }
  }
}
