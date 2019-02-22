using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RepositoryCourse.Models;
using RepositoryCourse.DTO;


namespace RepositoryCourse.MappingProfile
{
    public class MappingProfilecs:Profile
    {
        public MappingProfilecs()
        {
            CreateMap<Autor, AutorDTO>();
            CreateMap<AutorDTO, Autor>();

            CreateMap<Course, CourseDTO>();
            CreateMap<CourseDTO, Course>();

            CreateMap<Tag, TagDTO>();
            CreateMap<TagDTO, Tag>();

        }
    }
}
