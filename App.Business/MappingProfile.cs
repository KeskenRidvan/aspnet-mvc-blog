using App.Business.Dtos.Post;
using App.Business.Dtos.PostComment;
using App.Business.Dtos.Setting;
using App.Business.Dtos.User;
using App.Business.DTOs.Category;
using App.Business.DTOs.Page;
using App.Persistence.Data.Entity;
using AutoMapper;

namespace App.Business
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{

			#region Category
			CreateMap<CategoryDto, Category>().ReverseMap();
			CreateMap<ViewCategoryDto, Category>().ReverseMap();
			CreateMap<CreateOrEditCategoryDto, Category>().ReverseMap();
			#endregion

			#region Post
			CreateMap<PostDto, Post>().ReverseMap();
			CreateMap<ViewPostDto, Post>().ReverseMap();
			CreateMap<CreateOrEditCategoryDto, Post>().ReverseMap();
			#endregion

			#region Page
			CreateMap<PageDto, Page>().ReverseMap();
			CreateMap<ViewPageDto, Page>().ReverseMap();
			CreateMap<CreateOrEditPageDto, Page>().ReverseMap();
			#endregion

			#region User
			CreateMap<UserDto, User>().ReverseMap();
			CreateMap<ViewUserDto, User>().ReverseMap();
			CreateMap<CreateOrEditUserDto, User>().ReverseMap();
			#endregion

			#region Setting
			CreateMap<SettingDto, Setting>().ReverseMap();
			CreateMap<ViewSettingDto, Setting>().ReverseMap();
			CreateMap<CreateOrEditSettingDto, Setting>().ReverseMap();
			#endregion

			#region PostComment
			CreateMap<PostCommentCreateOrEditDto, PostComment>().ReverseMap();
			#endregion
		}
	}
}
